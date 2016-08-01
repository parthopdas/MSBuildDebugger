using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Build.BuildEngine;

namespace MSBuildDebugger.UI
{
    public partial class PropertyViewerUserControl : UserControl
    {
        public PropertyViewerUserControl()
        {
            InitializeComponent();
        }

        public void ClearContents()
        {
            dataGridView.Rows.Clear();
        }

        internal void Update(BuildPropertyGroup propertyGroup)
        {
            dataGridView.Rows.Clear();
            foreach (BuildProperty property in propertyGroup)
            {
                dataGridView.Rows.Add(property.Name, property.Value);
            }
        }

        internal void Update(BuildItemGroup itemGroup)
        {
            dataGridView.Rows.Clear();
            foreach (BuildItem item in itemGroup)
            {
                dataGridView.Rows.Add(item.Name, item.FinalItemSpec);
            }
        }
    }
}
