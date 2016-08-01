using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Build.BuildEngine;
using MSBuildDebugger;

namespace MSBuildDebugger_Tests
{
    internal static class Utilities
    {
        internal static string CreateTemporaryProject(string projectContents)
        {
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, projectContents);
            return tempFilePath;
        }

        internal static string BuildProjectAndDumpPdbEntries(string projectFilePath)
        {
            // Create and initialize the engine with our mock DE
            Engine e = new Engine();
            MockDebugEngine mde = new MockDebugEngine();
            e.RegisterLogger(mde);

            // Create the project and build it
            Project project = e.CreateNewProject();
            project.Load(projectFilePath);
            project.Build();

            // Get the dump of PdbEntries
            StringBuilder sb = new StringBuilder();
            foreach (PdbEntry pdbEntry in mde.PdbEntries)
            {
                sb.AppendLine(string.Format("{0} [{1}, {2}]", pdbEntry.Name, pdbEntry.StartLocation.Y, pdbEntry.StartLocation.X));
            }
            string pdbEntriesDump = sb.ToString();

            // Cleanup
            e.Shutdown();

            return pdbEntriesDump;
        }
    }
}
