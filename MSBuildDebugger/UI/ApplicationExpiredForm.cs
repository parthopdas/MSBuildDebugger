using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MSBuildDebugger.UI
{
    public partial class ApplicationExpiredForm : Form
    {
        public ApplicationExpiredForm()
        {
            InitializeComponent();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = (sender as LinkLabel).Text;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }
    }
}
