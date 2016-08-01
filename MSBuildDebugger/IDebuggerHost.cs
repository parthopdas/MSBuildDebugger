using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.BuildEngine;

namespace MSBuildDebugger
{
    interface IDebuggerHost
    {
        void DebugSessionStarted();
        void DoExecutableBlockStarted(StackFrame[] callStack);
        void DoExecutableBlockFinished(StackFrame[] callStack);
        void DebugSessionFinished();
        void WriteToOutputWindow(string format, params object[] arg);
    }
}
