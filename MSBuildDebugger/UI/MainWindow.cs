using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Framework;
using System.IO;

namespace MSBuildDebugger.UI
{
    public partial class MainWindow : Form, IDebuggerHost
    {
        private AutoResetEvent ContineExecutionEvent { get; set; }

        private bool doNotBreak;

        public TabControl OpenFilesControl
        {
            get { return tabControlOpenFiles; }
        }

        private OpenFilesManager _openFilesManager;

        public MainWindow()
        {
            InitializeComponent();

            _openFilesManager = new OpenFilesManager(this);
            ContineExecutionEvent = new AutoResetEvent(false);
            doNotBreak = false;
        }

        string openedProjectPath;

        private bool debugSessionInProgress = false;

        BreakPointManager _breakPointManager = new BreakPointManager();

        private void LaunchDebugger()
        {
            if (!File.Exists(openedProjectPath ?? string.Empty)) return;

            textBoxOutputWindow.Clear();

            string targetToDebug;
            using (ChooseTargetForm ctf = new ChooseTargetForm())
            {
                if (DialogResult.OK != ctf.ShowDialog()) return;
                targetToDebug = ctf.ChosenTarget;
            }

            Thread thread = new Thread(new ParameterizedThreadStart((object param) => { DebugThreadProc(param); }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "MSBuild Debugger Thread";
            thread.Start(targetToDebug);
        }

        private Project _currentProject;

        private void DebugThreadProc(object targetToDebug)
        {
            debugSessionInProgress = true;
            WriteToOutputWindow("=============== Debug Session Started =============== \r\n\r\n");

            // Create a new engine and initialize it
            Engine engine = new Engine();
            engine.RegisterLogger(new DebugEngine(this));

            // Load the project
            _currentProject = new Project(engine);
            _currentProject.Load(openedProjectPath);

            try
            {
                _currentProject.Build(targetToDebug as string);
            }
            catch (Exception e)
            {
                WriteToOutputWindow("\r\n=============== ERROR ===============\r\n");
                WriteToOutputWindow(e.ToString());
                WriteToOutputWindow("\r\n=============== ERROR ===============\r\n");
            }

            // Shut down the engine
            engine.Shutdown();

            WriteToOutputWindow("\r\n=============== Debug Session Ended ===============\r\n\r\n");
            doNotBreak = false;
            debugSessionInProgress = false;
        }

        internal void WriteToOutputWindow(string text)
        {
            if (textBoxOutputWindow.InvokeRequired)
            {
                textBoxOutputWindow.Invoke(new MethodInvoker(() => WriteToOutputWindow(text)));

                return;
            }

            // At this point we are thread safe
            textBoxOutputWindow.AppendText(text);
        }

        private void UpdateCallStackWindow(StackFrame[] callStack, bool atStart)
        {
            listViewCallStack.Items.Clear();
            for (int i = 0; i < callStack.Length; i++)
            {
                listViewCallStack.Items.Add(callStack[i].ToString());
            }

            if (!atStart)
            {
                listViewCallStack.Items.RemoveAt(0);
            }
        }

        private void UpdateBreakPointsWindow()
        {
            listViewBreakPoints.Items.Clear();

            foreach (BreakPoint breakPoint in _breakPointManager.ActiveBreakPoints)
            {
                listViewBreakPoints.Items.Add(breakPoint.ToString());                
            }
        }

        #region IDebuggerHost Members

        public void WriteToOutputWindow(string format, params object[] arg)
        {
            string textToWrite = string.Format(format, arg);
            WriteToOutputWindow(textToWrite);
        }

        public void DoExecutableBlockStarted(StackFrame[] callStack)
        {
            DoExecutableBlockStartedFinshed(callStack, true);
        }

        public void DoExecutableBlockFinished(StackFrame[] callStack)
        {
            DoExecutableBlockStartedFinshed(callStack, false);
        }

        #endregion

        private StackFrame[] _currentCallStack;
        private bool? _currentCallStackAtStart;

        private void DoExecutableBlockStartedFinshed(StackFrame[] callStack, bool atStart)
        {
            // Note down the call stack
            _currentCallStack = callStack;
            _currentCallStackAtStart = new bool?(atStart);

            // Ensure we are not hitting any break points
            BreakPoint hitBP = Array.Find<BreakPoint>(
                _breakPointManager.ActiveBreakPoints,
                bp => (bp.ExecutablePath.Equals(callStack[0].ExecutablePath, StringComparison.OrdinalIgnoreCase) && (bp.Location == callStack[0].StartLocation))
            );
            if (hitBP != null)
            {
                WriteToOutputWindow("DEBUGGER: BreakPoint hit: {0}\r\n", hitBP.ToString());
                doNotBreak = false;
            }

            // If we are not to break, dont react to this event
            if (doNotBreak)
            {
                //UpdateCallStackWindow(new StackFrame[0], true);
                goto CleanupAndExit;
            }

            // Make the UI respond appropriately
            Invoke(
                new MethodInvoker(
                    () =>
                    {
                        _openFilesManager.LocateExecutionPoint(callStack[0], atStart);
                        UpdateCallStackWindow(callStack, atStart);
                        propertyViewerUserControlProperties.Update(_currentProject.EvaluatedProperties);
                        propertyViewerUserControlItems.Update(_currentProject.EvaluatedItems);
                        listViewBreakPoints.Enabled = true;
                        listViewCallStack.Enabled = true;
                        propertyViewerUserControlItems.Enabled = true;
                        propertyViewerUserControlProperties.Enabled = true;
                    }
                )
            );

            // Wait on the main window to tell us to go ahead
            ContineExecutionEvent.WaitOne();

        CleanupAndExit:
            // Finally do any required cleanups
            Invoke(
                new MethodInvoker(
                    () =>
                    {
                        _openFilesManager.ClearExecutionPointHighlighting();
                        listViewBreakPoints.Enabled = false;
                        listViewCallStack.Enabled = false;
                        propertyViewerUserControlItems.Enabled = false;
                        propertyViewerUserControlProperties.Enabled = false;
                    }
                )
            );

            // No call stack when running
            _currentCallStack = null;
            _currentCallStackAtStart = null;
        }

        #region IDebuggerHost Members


        public void DebugSessionStarted()
        {
        }

        public void DebugSessionFinished()
        {
            listViewBreakPoints.Enabled = true;
            listViewCallStack.Items.Clear();
            listViewCallStack.Enabled = true;
            propertyViewerUserControlItems.ClearContents();
            propertyViewerUserControlProperties.ClearContents();
        }

        #endregion
    }
}
