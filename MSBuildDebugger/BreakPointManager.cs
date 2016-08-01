using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace MSBuildDebugger
{
    public class BreakPoint
    {
        internal string ExecutablePath { get; set; }
        internal Point Location { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - Line: {1}, Column: {2}", ExecutablePath, Location.Y, Location.X);
        }
    }

    /// <summary>
    /// Crappiest code I have every written. Crappiest logic I ever came up with
    /// Need to redo all this later...
    /// </summary>
    internal class BreakPointManager
    {
        private List<BreakPoint> _breakPoints = new List<BreakPoint>();

        internal BreakPoint[] ActiveBreakPoints
        {
            get 
            {
                return _breakPoints.ToArray();
            }
        }

        internal BreakPoint BindBreakPoint(BreakPoint unboundBreakPoint)
        {
            BreakPoint boundBreakPoint = null;

            // Load the symbols, if not loaded already
            SymbolStore.Instance.LoadSymbols(unboundBreakPoint.ExecutablePath);

            PDB pdb = SymbolStore.Instance[unboundBreakPoint.ExecutablePath];
            PdbEntry bpSymbol = null;

            // First determine the target
            PdbEntry targetSymbol = null;
            PdbEntry[] targetSymbolEntries = pdb.TargetSymbolEntries.Values.ToArray();
            for (int i = 0; i < targetSymbolEntries.Length - 1; i++)
            {
                PdbEntry currEntry = targetSymbolEntries[i];
                PdbEntry nextEntry = targetSymbolEntries[i + 1];

                if (
                    currEntry.StartLocation.Y <= unboundBreakPoint.Location.Y
                    && unboundBreakPoint.Location.Y < nextEntry.StartLocation.Y
                )
                {
                    targetSymbol = currEntry;
                    break;
                }
            }

            // Project with no targets
            if (0 == targetSymbolEntries.Length)
            {
                targetSymbol = pdb.ProjectPdbEntry;
            }

            if ((0 != targetSymbolEntries.Length) && (null == targetSymbol))
            {
                // Ok so the break point is not between targets 1-2, 2-3, 3-4, 4-5
                // So it can be either before 1 or after 5
                // Before 1 => The BP is at project start
                // After 5 => BP at the last target
                if (targetSymbolEntries[0].StartLocation.Y >= unboundBreakPoint.Location.Y)
                {
                    targetSymbol = pdb.ProjectPdbEntry;
                }
                else
                {
                    targetSymbol = targetSymbolEntries[targetSymbolEntries.Length - 1];
                }
            }

            if (null == targetSymbol) goto Done;

            // Second determine the task
            PdbEntry taskSymbol = null;
            for (int i = 0; i < targetSymbol.Children.Count - 1; i++)
            {
                PdbEntry currEntry = targetSymbol.Children[i];
                PdbEntry nextEntry = targetSymbol.Children[i + 1];

                if (
                    currEntry.StartLocation.Y <= unboundBreakPoint.Location.Y
                    && unboundBreakPoint.Location.Y < nextEntry.StartLocation.Y
                )
                {
                    taskSymbol = currEntry;
                    break;
                }
            }

            if ((0 != targetSymbol.Children.Count) && (null == taskSymbol))
            {
                // Ok so the break point is not between tasks 1-2, 2-3, 3-4, 4-5
                // So it can be either before 1 or after 5
                // Before 1 => The BP is at target start
                // After 5 => BP at the last task
                // Take care of only 'after 5' case since not getting the symbol means 'before 1' case
                if (targetSymbol.Children[targetSymbol.Children.Count - 1].StartLocation.Y <= unboundBreakPoint.Location.Y)
                {
                    taskSymbol = targetSymbol.Children[targetSymbol.Children.Count - 1];
                }
            }

            // If we didnt get a task, no issues, set BP on the target
            bpSymbol = taskSymbol ?? targetSymbol;

            // Third create and note down the bound bp
            boundBreakPoint = _breakPoints.Find(bp => (bp.Location == bpSymbol.StartLocation));
            if (null == boundBreakPoint)
            {
                boundBreakPoint = new BreakPoint
                {
                    ExecutablePath = unboundBreakPoint.ExecutablePath,
                    Location = bpSymbol.StartLocation
                };
                _breakPoints.Add(boundBreakPoint);
            }

        Done:
            return boundBreakPoint;
        }

        internal void RemoveBreakPoint(BreakPoint breakPoint)
        {
            _breakPoints.Remove(breakPoint);
        }
    }
}
