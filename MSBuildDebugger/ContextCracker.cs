using System.Text.RegularExpressions;
using Microsoft.Build.Framework;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace MSBuildDebugger
{
    /// <summary>
    /// This class will take information from the XEventArgs passed to the logger
    /// and give back the PdbEntry corresponding to the current position & context
    /// 
    /// LIMITATIONS:
    /// - If adjascent, 3M M, 2M M, M 3M => M 3M
    /// - If only tasks, M 2M => . 3M
    /// - If only tasks, M 2M M => . M 4M
    /// 
    /// WORKAROUNDS:
    /// - Have a dummy message (active or inactive) before the first task, if they are the only tasks in the target
    /// - Have a dummy message (active or inactive) between batch and dup named tasks
    /// </summary>
    internal class ContextCracker
    {
        private class ProjectStackFrame 
        {
            internal PDB PDB { get; private set; }
            internal Stack<TargetStackFrame> TargetStack { get; private set; }

            internal ProjectStackFrame(PDB pdb)
            {
                PDB = pdb;
                TargetStack = new Stack<TargetStackFrame>();
            }
        }

        private class TargetStackFrame 
        {
            internal PdbEntry TargetSymbol { get; private set; }
            internal int TaskNumber { get; set; }

            internal TargetStackFrame(PdbEntry targetSymbol)
            {
                TargetSymbol = targetSymbol;
                TaskNumber = 0;
            }
        }

        private static readonly Regex SkippedTaskCracker = new Regex(@"^Task ""(?<TaskName>\w*)"" skipped, due to false condition;", RegexOptions.Compiled | RegexOptions.ECMAScript);

        private Stack<ProjectStackFrame> projectStack = new Stack<ProjectStackFrame>();

        internal PdbEntry ProjectStarted(ProjectStartedEventArgs e)
        {
            // Load symbol information for the project
            PDB pdb = SymbolStore.Instance[e.ProjectFile];

            // Create a new stack frame
            projectStack.Push(new ProjectStackFrame(pdb));

            // Return the symbol for the project
            return pdb.ProjectPdbEntry;
        }

        internal void ProjectFinished(ProjectFinishedEventArgs e)
        {
            // Kill the stackframe
            projectStack.Pop();
        }

        internal PdbEntry TargetStarted(TargetStartedEventArgs e)
        {
            // Get the current target symbol
            PdbEntry targetSymbol = SymbolStore.Instance[e.TargetFile].TargetSymbolEntries[e.TargetName];

            // Create a stackframe
            projectStack.Peek().TargetStack.Push(new TargetStackFrame(targetSymbol));

            return targetSymbol;
        }

        internal void TargetFinished(TargetFinishedEventArgs e)
        {
            // Kill the stackframe
            projectStack.Peek().TargetStack.Pop();
        }


        internal PdbEntry TaskStarted(TaskStartedEventArgs e)
        {
            PdbEntry taskSymbol = null;

            // We need to deal with 2 issues (a) batching (b) consecutive targets with same name (c) both
            // We will make a compromise here - in case of (c), we will have one symbol for the 1st task 
            // and rest of symbols for the 2nd - irrespective of kind of combination we have for (c)
            // i.e. 3M M or 2M 2M or M 3M are all treated as M 3M
            string currentTaskName = projectStack.Peek().TargetStack.Peek().TargetSymbol.Children[projectStack.Peek().TargetStack.Peek().TaskNumber].Name;
            if (!string.Equals(e.TaskName, currentTaskName,  StringComparison.OrdinalIgnoreCase))
            {
                taskSymbol = projectStack.Peek().TargetStack.Peek().TargetSymbol.Children[++projectStack.Peek().TargetStack.Peek().TaskNumber];
            }
            else
            {
                string nextTaskName = (projectStack.Peek().TargetStack.Peek().TaskNumber < (projectStack.Peek().TargetStack.Peek().TargetSymbol.Children.Count - 1)) ?
                    projectStack.Peek().TargetStack.Peek().TargetSymbol.Children[projectStack.Peek().TargetStack.Peek().TaskNumber + 1].Name : null;

                if (string.Equals(e.TaskName, nextTaskName, StringComparison.OrdinalIgnoreCase))
                {
                    ++projectStack.Peek().TargetStack.Peek().TaskNumber;
                }

                taskSymbol = projectStack.Peek().TargetStack.Peek().TargetSymbol.Children[projectStack.Peek().TargetStack.Peek().TaskNumber];
            }

            // Return the symbol
            Debug.Assert(null != taskSymbol, "taskSymbol is null - this should never happen, we are going to crash!");
            return taskSymbol;
        }

        internal void TaskFinished(TaskFinishedEventArgs e)
        {
        }

        /// <summary>
        /// This method will parse the message and see if it says some task is being skipped.
        /// 
        /// If so, it will fire a dummy pair of TaskStarted and TaskFinished events
        /// This will ensure that, we get notified of all Tasks - whether they are executed or they are skipped
        /// </summary>
        internal void MessageRaised(BuildMessageEventArgs e)
        {
            // See if the message is of format: Task "XXXXX" skipped, due to false condition; YYYYY.
            Match match = SkippedTaskCracker.Match(e.Message);
            if (!match.Success) return;

            // OK so some task has been skipped - which one is it?
            string taskName = match.Groups["TaskName"].Value;

            // Let us treat this as a dummy pair of task started/finished events
            TaskStarted(new TaskStartedEventArgs(e.Message, string.Empty, projectStack.Peek().PDB.ExecutablePath, projectStack.Peek().TargetStack.Peek().TargetSymbol.ExecutablePath, taskName));
            TaskFinished(new TaskFinishedEventArgs(e.Message, string.Empty, projectStack.Peek().PDB.ExecutablePath, projectStack.Peek().TargetStack.Peek().TargetSymbol.ExecutablePath, taskName, true));
        }
    }
}
