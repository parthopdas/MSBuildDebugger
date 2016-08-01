using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace MSBuildDebugger.UI
{
    public partial class MainWindow
    {
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size(workingArea.Width / 4 * 3, workingArea.Height / 4 * 3);
            this.Location = new Point(workingArea.Width / 8, workingArea.Height / 8);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open File...";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                _openFilesManager.OpenSourceFile(openFileDialog.FileName);
            }
        }

        private void toolStripMenuItemOpenProject_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open Project...";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                _openFilesManager.OpenSourceFile(openFileDialog.FileName);
                openedProjectPath = openFileDialog.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doNotBreak = true;
            ContineExecutionEvent.Set();
            this.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// F11 Implementation
        /// </summary>
        private void stepIntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doNotBreak = false;

            if (!debugSessionInProgress)
            {
                LaunchDebugger();
            }
            else
            {
                ContineExecutionEvent.Set();
            }
        }

        /// <summary>
        /// F5 Implementation
        /// </summary>
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doNotBreak = true;

            if (!debugSessionInProgress)
            {
                LaunchDebugger();
            }
            else
            {
                ContineExecutionEvent.Set();
            }
        }

        private void setBPtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BreakPoint breakPoint;
            if (_openFilesManager.GetCaretLocation(out breakPoint))
            {
                // Bind the break point
                breakPoint = _breakPointManager.BindBreakPoint(breakPoint);
                if (null != breakPoint)
                {
                    UpdateBreakPointsWindow();
                    _openFilesManager.MarkSetBreakPoint(breakPoint, false);
                    return;
                }
            }

            string message = "Cannot set break point at current position... Take the caret over a task or target or project and try again!";
            message = (breakPoint == null)
                ? message
                : string.Format("{0}:\r\n\r\nFile: {1}\r\nLocation: {2}", message, breakPoint.ExecutablePath, breakPoint.Location);

            MessageBox.Show(
                this,
                message,
                this.Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void toolStripMenuItemBreak_Click(object sender, EventArgs e)
        {
            if (debugSessionInProgress) doNotBreak = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox ab = new AboutBox())
            {
                ab.ShowDialog();
            }
        }

        private void listViewBreakPoints_DoubleClick(object sender, EventArgs e)
        {
            if (0 == listViewBreakPoints.SelectedIndices.Count) return;

            BreakPoint dclickedBP = _breakPointManager.ActiveBreakPoints[listViewBreakPoints.SelectedIndices[0]];
            _openFilesManager.OpenSourceFile(dclickedBP.ExecutablePath, dclickedBP.Location);
        }

        private void listViewBreakPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (0 == listViewBreakPoints.SelectedIndices.Count) return;
            if (('d' != e.KeyChar) && ('D' != e.KeyChar)) return;

            BreakPoint bp = _breakPointManager.ActiveBreakPoints[listViewBreakPoints.SelectedIndices[0]];
            _openFilesManager.MarkSetBreakPoint(bp, true);
            _breakPointManager.RemoveBreakPoint(bp);
            listViewBreakPoints.Items.Remove(listViewBreakPoints.SelectedItems[0]);

            e.Handled = true;
        }

        private void toolStripButtonOpenProject_Click(object sender, EventArgs e)
        {
            toolStripMenuItemOpenProject_Click(sender, e);
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonStartDebugging_Click(object sender, EventArgs e)
        {
            runToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonBreakAll_Click(object sender, EventArgs e)
        {
            toolStripMenuItemBreak_Click(sender, e);
        }

        private void toolStripButtonShowNextStatement_Click(object sender, EventArgs e)
        {
            if (null == _currentCallStack) return;

            _openFilesManager.OpenSourceFile(
                _currentCallStack[0].ExecutablePath,
                _currentCallStackAtStart.Value ? _currentCallStack[0].StartLocation : _currentCallStack[0].EndLocation
            );
        }

        private void toolStripButtonStepInto_Click(object sender, EventArgs e)
        {
            stepIntoToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSetBreakPoint_Click(object sender, EventArgs e)
        {
            setBPtoolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonShowBreakPoints_Click(object sender, EventArgs e)
        {
            tabControlToolWindows2.SelectTab(tabPageBreakPoints);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ViewEnvironment venv = new ViewEnvironment())
            {
                venv.ShowDialog();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Load the output of 'set' command from your build environment...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            openFileDialog.Title = "Load Environment Variables...";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                // Clear the old environment
                foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables())
                {
                    Environment.SetEnvironmentVariable(entry.Key as string, null);
                }

                // Set the new environment
                foreach (string line in File.ReadAllLines(openFileDialog.FileName))
                {
                    string[] keyVal = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (keyVal.Length == 2)
                    {
                        Environment.SetEnvironmentVariable(keyVal[0], keyVal[1]);
                    }
                }
            }
        }

        private void listViewCallStack_DoubleClick(object sender, EventArgs e)
        {
            if (null == _currentCallStack) return;
            if (0 == listViewCallStack.SelectedIndices.Count) return;

            int index = listViewCallStack.SelectedIndices[0];
            _openFilesManager.OpenSourceFile(
                _currentCallStack[index].ExecutablePath,
                _currentCallStackAtStart.Value ? _currentCallStack[index].StartLocation : _currentCallStack[index].EndLocation
            );
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Create the documentation.html
            string tempFilePath = Path.GetTempFileName();
            string helpHelpFilePath = tempFilePath + "documentation.htm";
            File.Move(tempFilePath, helpHelpFilePath);
            File.WriteAllText(helpHelpFilePath, Resources.Documentation);

            using (Process p = new Process())
            {
                p.StartInfo.FileName = helpHelpFilePath;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }
    }
}
