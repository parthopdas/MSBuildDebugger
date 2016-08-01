using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using MSBuildDebugger;

namespace MSBuildDebugger_Tests
{
    internal class MockDebugEngine : Logger
    {
        private ContextCracker _contextCracker = new ContextCracker();

        internal List<PdbEntry> PdbEntries { get; private set; }

        public override void Initialize(IEventSource eventSource)
        {
            PdbEntries = new List<PdbEntry>();

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
            SymbolStore.Instance.LoadSymbols(e.ProjectFile);

            PdbEntries.Add(_contextCracker.ProjectStarted(e));
        }

        /// <summary>
        /// Project Finished
        /// </summary>
        void eventSource_ProjectFinished(object sender, ProjectFinishedEventArgs e) { }

        /// <summary>
        /// Target Started
        /// </summary>
        void eventSource_TargetStarted(object sender, TargetStartedEventArgs e)
        {
            SymbolStore.Instance.LoadSymbols(e.TargetFile);

            PdbEntries.Add(_contextCracker.TargetStarted(e));
        }

        /// <summary>
        /// Target Finished
        /// </summary>
        void eventSource_TargetFinished(object sender, TargetFinishedEventArgs e)
        {
            _contextCracker.TargetFinished(e);
        }

        /// <summary>
        /// Task Started
        /// </summary>
        void eventSource_TaskStarted(object sender, TaskStartedEventArgs e)
        {
            SymbolStore.Instance.LoadSymbols(e.TaskFile);

            PdbEntries.Add(_contextCracker.TaskStarted(e));
        }

        /// <summary>
        /// Target Finished
        /// </summary>
        void eventSource_TaskFinished(object sender, TaskFinishedEventArgs e)
        {
            _contextCracker.TaskFinished(e);
        }

        /// <summary>
        /// Any arbitrary message is raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void eventSource_MessageRaised(object sender, BuildMessageEventArgs e)
        {
            _contextCracker.MessageRaised(e);
        }

        void eventSource_WarningRaised(object sender, BuildWarningEventArgs e) { }
        void eventSource_StatusEventRaised(object sender, BuildStatusEventArgs e) { }
        void eventSource_ErrorRaised(object sender, BuildErrorEventArgs e) { }
        void eventSource_CustomEventRaised(object sender, CustomBuildEventArgs e) { }
        void eventSource_BuildStarted(object sender, BuildStartedEventArgs e) { }
        void eventSource_BuildFinished(object sender, BuildFinishedEventArgs e) { }
        void eventSource_AnyEventRaised(object sender, BuildEventArgs e) { }
    }
}
