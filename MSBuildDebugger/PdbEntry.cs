using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace MSBuildDebugger
{
    [DebuggerDisplay("{Name} ({StartLocation} -> {EndLocation}) [{Children.Count} children]")]
    internal class PdbEntry
    {
        internal string ExecutablePath { get; private set; }

        internal string Name { get; private set; }

        internal Point StartLocation { get; set; }

        internal Point EndLocation { get; set; }

        internal List<PdbEntry> Children { get; private set; }

        internal PdbEntry(string name, string executable)
        {
            Name = name;
            ExecutablePath = executable;
            Children = new List<PdbEntry>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} ({1} -> {2})", Name, StartLocation, EndLocation);
            sb.AppendLine();
            sb.AppendLine("Children:");
            foreach (PdbEntry symEntry in Children)
            {
                sb.AppendFormat("- {0} {1} -> {2}", symEntry.Name, symEntry.StartLocation, symEntry.EndLocation);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
