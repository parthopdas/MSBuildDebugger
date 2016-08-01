using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace MSBuildDebugger
{
    [DebuggerDisplay("{System.IO.Path.GetFileName(ExecutablePath)} ({TargetSymbolEntries.Count} Entries)")]
    internal class PDB
    {
        internal string ExecutablePath { get; private set; }

        /// <summary>
        /// PdbEntry for the &lt;Project&gt;
        /// </summary>
        internal PdbEntry ProjectPdbEntry { get; private set; }

        /// <summary>
        /// PdbEntries for the targets in the project
        /// </summary>
        internal Dictionary<string, PdbEntry> TargetSymbolEntries { get; private set; }

        private PDB() { }

        internal static PDB Create(string executablePath)
        {
            Debug.Assert(File.Exists(executablePath));

            PDB sdb = new PDB();
            sdb.ExecutablePath = executablePath;
            sdb.ProjectPdbEntry = new PdbEntry(Path.GetFileName(executablePath), executablePath);
            sdb.TargetSymbolEntries = new Dictionary<string, PdbEntry>(StringComparer.OrdinalIgnoreCase);
            sdb.PopulateSymbolInformation();

            return sdb;
        }

        private void PopulateSymbolInformation()
        {
            using (XmlTextReader reader = new XmlTextReader(ExecutablePath))
            {
                // Read into the Project Element
                do
                {
                    reader.Read();
                }
                while (!reader.Name.Equals("Project", StringComparison.OrdinalIgnoreCase));

                // Set the start location
                ProjectPdbEntry.StartLocation = new Point(reader.LinePosition, reader.LineNumber);
                if (reader.IsEmptyElement) ProjectPdbEntry.EndLocation = ProjectPdbEntry.StartLocation;

                // Start traversing the XML
                int currentTask = -1;
                Stack<PdbEntry> contextStack = new Stack<PdbEntry>();
                while (reader.Read())
                {
                    // Not interested in things other than Elements
                    if ((XmlNodeType.Element != reader.NodeType) && (XmlNodeType.EndElement != reader.NodeType)) continue;

                    // If it is the </Project> tag, set the end location
                    if ((XmlNodeType.EndElement == reader.NodeType) && reader.Name.Equals("Project", StringComparison.OrdinalIgnoreCase))
                    {
                        ProjectPdbEntry.EndLocation = new Point(reader.LinePosition, reader.LineNumber);
                        continue;
                    }

                    // Ignore everything except a Target element or its children
                    if (0 == contextStack.Count)
                    {
                        if (!reader.Name.Equals("Target", StringComparison.OrdinalIgnoreCase)) continue;

                        // We have just entered a Target element
                        PdbEntry symEntry = new PdbEntry(reader["Name"], ExecutablePath);
                        symEntry.StartLocation = new Point(reader.LinePosition, reader.LineNumber);
                        TargetSymbolEntries[reader["Name"]] = symEntry;    // Note that this enables the 'oveerriding' behavior of MSBuild Targets
                        contextStack.Push(symEntry);

                        // Close this context if it is an empty element
                        if (reader.IsEmptyElement)
                        {
                            symEntry.EndLocation = new Point(reader.LinePosition, reader.LineNumber);
                            contextStack.Pop();
                        }

                        // Lets proceed
                        continue;
                    }

                    // We are now in one of the target's children or it closing element.

                    // Lets eat up the PropertyGroup and ItemGroups
                    if (
                        reader.Name.Equals("PropertyGroup", StringComparison.OrdinalIgnoreCase)
                        || reader.Name.Equals("ItemGroup", StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        if (!reader.IsEmptyElement)
                        {
                            // Eat up the non-empty node and all its childres - burrrp!
                            string name = reader.Name;
                            int depth = reader.Depth;
                            do
                            {
                                reader.Read();
                            }
                            while ((XmlNodeType.EndElement != reader.NodeType) || !reader.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || (reader.Depth != depth));
                        }

                        continue;
                    }

                    // We could now be on a Task
                    if (XmlNodeType.Element == reader.NodeType)
                    {
                        PdbEntry taskSymEntry = new PdbEntry(reader.Name, ExecutablePath);
                        taskSymEntry.StartLocation = new Point(reader.LinePosition, reader.LineNumber);
                        if (!reader.IsEmptyElement)
                        {
                            // Not an empty task element - has some child elements like <Output> - so eat up all children
                            string nodeName = reader.Name;
                            int currDepth = reader.Depth;
                            do
                            {
                                reader.Read();
                            }
                            while ((XmlNodeType.EndElement != reader.NodeType) || !reader.Name.Equals(nodeName, StringComparison.OrdinalIgnoreCase) || (reader.Depth != currDepth));
                        }

                        taskSymEntry.EndLocation = new Point(reader.LinePosition, reader.LineNumber);
                        contextStack.Peek().Children.Add(taskSymEntry);
                        currentTask++;

                        continue;
                    }

                    // Consider EndElement 
                    if ((XmlNodeType.EndElement == reader.NodeType))
                    {
                        // Now Name has to be "Target" 
                        Debug.Assert(reader.Name.Equals("Target", StringComparison.OrdinalIgnoreCase));

                        contextStack.Peek().EndLocation = new Point(reader.LinePosition, reader.LineNumber);
                        contextStack.Pop();
                        currentTask = -1;

                        continue;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Executable Name: {0} ({1} -> {2})\r\n\r\n", Path.GetFileName(ExecutablePath), ProjectPdbEntry.StartLocation, ProjectPdbEntry.EndLocation);

            foreach (PdbEntry symEntry in TargetSymbolEntries.Values)
            {
                sb.AppendLine(symEntry.ToString());
            }

            return sb.ToString();
        }
    }
}
