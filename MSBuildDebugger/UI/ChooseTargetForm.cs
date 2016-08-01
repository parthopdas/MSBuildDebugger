using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSBuildDebugger.UI
{
    public partial class ChooseTargetForm : Form
    {
        public string ChosenTarget 
        {
            get { return (string)comboBox1.SelectedItem; } 
        }

        public ChooseTargetForm()
        {
            InitializeComponent();


            comboBox1.SelectedIndex = 0;
            comboBox1.SelectionStart = 0;
            comboBox1.SelectionLength = comboBox1.SelectedText.Length;
        }
    }
}
