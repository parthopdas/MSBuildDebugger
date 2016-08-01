using System.Collections.Generic;
using System.Globalization;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MSBuildDebugger
{
    internal class DebugEngine : Logger
    {
        private IDebuggerHost _debuggerHost;

        private Stack<StackFrame> _callStack = new Stack<StackFrame>();

        private ContextCracker _contextCracker = new ContextCracker();

        internal DebugEngine(IDebuggerHost debuggerHost)
        {
            _debuggerHost = debuggerHost;
        }

        public override void Initialize(IEventSource eventSource)
        {
            eventSource.ProjectFinished += new ProjectFinishedEventHandler(eventSource_ProjectFinished);
            eventSource.ProjectStarted += new ProjectStartedEventHandler(eventSource_ProjectStarted);
            eventSource.TargetFinished += new TargetFinishedEventHandler(eventSource_TargetFinished);
            eventSource.TargetStarted += new TargetStartedEventHandler(eventSource_TargetStarted);
            eventSource.TaskFinished += new TaskFinishedEventHandler(eventSource_TaskFinished);
            eventSource.TaskStarted += new TaskStartedEventHandler(eventSource_TaskStarted);

            eventSource.AnyEventRaised += new AnyEventHandler(eventSource_AnyEventRaised);
            eventSource.BuildFinished += new BuildFinishedEventHandler(eventSource_BuildFinished);
            eventSource.BuildStarted += new BuildStartedEventHandler(eventSource_BuildStarted);
            eventSource.CustomEventRaised += new CustomBuildEventHandler(eventSource_CustomEventRaised);
            eventSource.ErrorRaised += new BuildErrorEventHandler(eventSource_ErrorRaised);
            eventSource.MessageRaised += new BuildMessageEventHandler(eventSource_MessageRaised);
            eventSource.StatusEventRaised += new BuildStatusEventHandler(eventSource_StatusEventRaised);
            eventSource.WarningRaised += new BuildWarningEventHandler(eventSource_WarningRaised);
        }

        /// <summary>
        /// Project Started
        /// </summary>
        void eventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
            // Load symbol information
            SymbolStore.Instance.LoadSymbols(e.ProjectFile);

            // Create stack frame
            PdbEntry symbol = _contextCracker.ProjectStarted(e);
            _callStack.Push(new StackFrame
            {
                ExecutablePath = e.ProjectFile,
                TargetName = null,
                TaskName = null,
                StartLocation = symbol.StartLocation,
                EndLocation = symbol.EndLocation
            });

            LogBuildEventArgs(e, "ProjectStarted");

            _debuggerHost.DoExecutableBlockStarted(_callStack.ToArray());
        }

        /// <summary>
        /// Project Finished
        /// </summary>
        void eventSource_ProjectFinished(object sender, ProjectFinishedEventArgs e)
        {
            LogBuildEventArgs(e, "ProjectFinished");

            _contextCracker.ProjectFinished(e);

            _debuggerHost.DoExecutableBlockFinished(_callStack.ToArray());

            // Destroy stack frame
            _callStack.Pop();
        }

        /// <summary>
        /// Target Started
        /// </summary>
        void eventSource_TargetStarted(object sender, TargetStartedEventArgs e)
        {
            // Load symbol information
            SymbolStore.Instance.LoadSymbols(e.TargetFile);

            // Create stack frame
            PdbEntry symbol = _contextCracker.TargetStarted(e);
            _callStack.Push(new StackFrame { 
                ExecutablePath = e.TargetFile, 
                TargetName = e.TargetName,
                TaskName = null,
                StartLocation = symbol.StartLocation, 
                EndLocation = symbol.EndLocation
            });

            LogBuildEventArgs(e, "TargetStarted");

            _debuggerHost.DoExecutableBlockStarted(_callStack.ToArray());
        }

        /// <summary>
        /// Target Finished
        /// </summary>
        void eventSource_TargetFinished(object sender, TargetFinishedEventArgs e)
        {
            LogBuildEventArgs(e, "TargetFinished");

            _contextCracker.TargetFinished(e);

            _debuggerHost.DoExecutableBlockFinished(_callStack.ToArray());

            // Destroy stack frame
            _callStack.Pop();
        }

        /// <summary>
        /// Task Started
        /// </summary>
        void eventSource_TaskStarted(object sender, TaskStartedEventArgs e)
        {
            // Load symbol information
            SymbolStore.Instance.LoadSymbols(e.TaskFile);

            // Create stack frame
            PdbEntry symbol = _contextCracker.TaskStarted(e);
            _callStack.Push(new StackFrame 
            { 
                ExecutablePath = e.TaskFile, 
                TargetName = _callStack.Peek().TargetName, 
                TaskName = e.TaskName,
                StartLocation = symbol.StartLocation,
                EndLocation = symbol.EndLocation
            });

            LogBuildEventArgs(e, "TaskStarted");

            _debuggerHost.DoExecutableBlockStarted(_callStack.ToArray());
        }

        /// <summary>
        /// Target Finished
        /// </summary>
        void eventSource_TaskFinished(object sender, TaskFinishedEventArgs e)
        {
            LogBuildEventArgs(e, "TaskFinished");

            _contextCracker.TaskFinished(e);

            _debuggerHost.DoExecutableBlockFinished(_callStack.ToArray());

            // Destroy stack frame
            _callStack.Pop();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        void eventSource_WarningRaised(object sender, BuildWarningEventArgs e)
        {
            LogBuildEventArgs(e, "WarningRaised");
        }

        void eventSource_StatusEventRaised(object sender, BuildStatusEventArgs e)
        {
            //LogBuildEventArgs(e, "StatusEventRaised");
        }

        void eventSource_MessageRaised(object sender, BuildMessageEventArgs e)
        {
            LogBuildEventArgs(e, "MessageRaised");

            _contextCracker.MessageRaised(e);
        }

        void eventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
        {
            LogBuildEventArgs(e, "ErrorRaised");
        }

        void eventSource_CustomEventRaised(object sender, CustomBuildEventArgs e)
        {
            LogBuildEventArgs(e, "CustomEventRaised");
        }

        void eventSource_BuildStarted(object sender, BuildStartedEventArgs e)
        {
            LogBuildEventArgs(e, "BuildStarted");

            _debuggerHost.DebugSessionStarted();
        }

        void eventSource_BuildFinished(object sender, BuildFinishedEventArgs e)
        {
            LogBuildEventArgs(e, "BuildFinished");

            _debuggerHost.DebugSessionFinished();
        }

        void eventSource_AnyEventRaised(object sender, BuildEventArgs e)
        {
            //LogBuildEventArgs(e, "AnyEventRaised");
        }

        private void LogBuildEventArgs(BuildEventArgs e, string info)
        {
            _debuggerHost.WriteToOutputWindow(
                "[{0}] [{1}.{2:D3}]: {3} ({4})\r\n",
                e.ThreadId.ToString("00", CultureInfo.CurrentCulture),
                e.Timestamp.ToString("HH:mm:ss", CultureInfo.CurrentCulture),
                e.Timestamp.Millisecond,
                e.Message,
                info
            );
        }
    }
}
