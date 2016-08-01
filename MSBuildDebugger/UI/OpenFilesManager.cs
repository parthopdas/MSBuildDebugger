using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Build.Framework;
using System;
using MSBuildDebugger.UI;

namespace MSBuildDebugger.UI
{
    /// <summary>
    /// This class does *everything* related to opening and managing files
    /// </summary>
    internal class OpenFilesManager
    {
        private Dictionary<string, TabPage> _openedFiles = new Dictionary<string, TabPage>(StringComparer.OrdinalIgnoreCase);

        private MainWindow _mainWindow;

        internal OpenFilesManager(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        internal void OpenSourceFile(string path)
        {
            Debug.Assert(File.Exists(path), "File doesnt exist!");

            // If the file is already open, activate it and return
            if (_openedFiles.ContainsKey(path))
            {
                _mainWindow.OpenFilesControl.SelectTab(_openedFiles[path].Name);
                return;
            }

            // Otherwise instantiate a new control and store it for the future
            OpenFileUserControl fvUC = new OpenFileUserControl(path);
            fvUC.richTextBox.Lines = File.ReadAllLines(path);
            fvUC.Dock = DockStyle.Fill;

            TabPage newOpenedFile = new TabPage();
            newOpenedFile.Name = path;
            newOpenedFile.Text = Path.GetFileName(path);
            newOpenedFile.Controls.Add(fvUC);

            _mainWindow.OpenFilesControl.TabPages.Add(newOpenedFile);
            _mainWindow.OpenFilesControl.SelectTab(newOpenedFile.Name);

            _openedFiles[path] = newOpenedFile;
        }

        internal void OpenSourceFile(string path, Point location)
        {
            OpenSourceFile(path);

            // Now scroll to the location
            TabPage tabPage = _mainWindow.OpenFilesControl.TabPages[path];
            OpenFileUserControl fvUC = tabPage.Controls[0] as OpenFileUserControl;
            RichTextBox rtb = fvUC.richTextBox;

            int caretLocation = rtb.GetFirstCharIndexFromLine(location.Y - 1) + location.X - 1;
            rtb.SelectionStart = caretLocation;
            rtb.SelectionLength = 0;
            rtb.ScrollToCaret();
        }

        private Color highlightedBackColor;
        private int highlightedIndex;
        private RichTextBox highlightedRTB;

        internal void LocateExecutionPoint(StackFrame stackFrame, bool atStart)
        {
            // Open project file
            OpenSourceFile(stackFrame.ExecutablePath);

            // Get the RTB displaying the file
            TabPage tabPage = _mainWindow.OpenFilesControl.TabPages[stackFrame.ExecutablePath];
            OpenFileUserControl fvUC = tabPage.Controls[0] as OpenFileUserControl;
            highlightedRTB = fvUC.richTextBox;

            // Get the symbol information and locate execution point in the source file
            PDB pdb = SymbolStore.Instance[stackFrame.ExecutablePath];
            Point location = atStart ? stackFrame.StartLocation : stackFrame.EndLocation;

            // Now highlight the pos
            highlightedIndex = highlightedRTB.GetFirstCharIndexFromLine(location.Y - 1) + location.X - 2;
            highlightedRTB.SelectionStart = highlightedIndex;
            highlightedRTB.SelectionLength = 1;
            highlightedBackColor = highlightedRTB.SelectionBackColor;
            highlightedRTB.SelectionBackColor = Color.Yellow;
            highlightedRTB.SelectionLength = 0;
        }

        internal void ClearExecutionPointHighlighting()
        {
            if (null == highlightedRTB) return;

            highlightedRTB.SelectionStart = highlightedIndex;
            highlightedRTB.SelectionLength = 1;
            highlightedRTB.SelectionBackColor = highlightedBackColor;
            highlightedRTB.SelectionLength = 0;
        }

        internal bool GetCaretLocation(out BreakPoint unboundBreakPoint)
        {
            unboundBreakPoint = null;

            // Get the currently opened file
            TabPage selectedTab = _mainWindow.OpenFilesControl.SelectedTab;
            if (null != selectedTab)
            {
                OpenFileUserControl fvUC = selectedTab.Controls[0] as OpenFileUserControl;
                Point caretLocation = GetCaretLocationInRichTextBox(fvUC.richTextBox);
                unboundBreakPoint = new BreakPoint
                {
                    ExecutablePath = fvUC.OpenedFilePath,
                    Location = caretLocation
                };

                return true;
            }

            return false;
        }

        private static Point GetCaretLocationInRichTextBox(RichTextBox richTextBox)
        {
            int index = richTextBox.SelectionStart;
            int line = richTextBox.GetLineFromCharIndex(index); // get the caret position in pixel coordinates 

            Point pos;
            pos = richTextBox.GetPositionFromCharIndex(index); // now get the character index at the start of the line, and subtract from the current index to get the column 
            pos.X = 0; 

            int column = index - richTextBox.GetCharIndexFromPosition(pos);

            return new Point(++column, ++line);
        }

        internal void MarkSetBreakPoint(BreakPoint breakPoint, bool clear)
        {
            // We can assume here that the location is already scrolled in view
            TabPage tabPage = _mainWindow.OpenFilesControl.TabPages[breakPoint.ExecutablePath];
            OpenFileUserControl fvUC = tabPage.Controls[0] as OpenFileUserControl;
            RichTextBox rtb = fvUC.richTextBox;

            rtb.SelectionStart = rtb.GetFirstCharIndexFromLine(breakPoint.Location.Y - 1) + breakPoint.Location.X - 2; ;
            rtb.SelectionLength = 1;
            rtb.SelectionBackColor = clear ? rtb.BackColor : Color.Red;
            rtb.SelectionLength = 0;
        }
    }
}
