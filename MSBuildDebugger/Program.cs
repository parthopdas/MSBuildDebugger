using System;
using System.Windows.Forms;
using MSBuildDebugger.UI;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace MSBuildDebugger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Time bomb!
            if (DateTime.Now > new DateTime(2008, 07, 29))
            {
                new ApplicationExpiredForm().ShowDialog();
                return;
            }

            Application.Run(new MainWindow());
        }
    }
}
