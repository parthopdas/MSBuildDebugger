using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MSBuildDebugger.UI
{
    public partial class ViewEnvironment : Form
    {
        public ViewEnvironment()
        {
            InitializeComponent();
        }

        private void ViewEnvironment_Load(object sender, EventArgs e)
        {
            foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables())
            {
                listView1.Items.Add(new ListViewItem(new string[] { entry.Key as string, entry.Value as string }));
            }
        }
    }
}
