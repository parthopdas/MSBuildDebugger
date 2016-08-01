namespace MSBuildDebugger.UI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.environmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBPtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBreak = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stepIntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.stopDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpenProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStartDebugging = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBreakAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowNextStatement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStepInto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSetBreakPoint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowBreakPoints = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControlAnalyzer = new System.Windows.Forms.TabControl();
            this.tabPageImports = new System.Windows.Forms.TabPage();
            this.treeViewImports = new System.Windows.Forms.TreeView();
            this.tabPageExecutableNodes = new System.Windows.Forms.TabPage();
            this.treeViewExecutableNodes = new System.Windows.Forms.TreeView();
            this.tabControlOpenFiles = new System.Windows.Forms.TabControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControlToolWindows1 = new System.Windows.Forms.TabControl();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.propertyViewerUserControlProperties = new MSBuildDebugger.UI.PropertyViewerUserControl();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.propertyViewerUserControlItems = new MSBuildDebugger.UI.PropertyViewerUserControl();
            this.tabControlToolWindows2 = new System.Windows.Forms.TabControl();
            this.tabPageOutputWindow = new System.Windows.Forms.TabPage();
            this.textBoxOutputWindow = new System.Windows.Forms.TextBox();
            this.tabPageCallStack = new System.Windows.Forms.TabPage();
            this.listViewCallStack = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.tabPageBreakPoints = new System.Windows.Forms.TabPage();
            this.listViewBreakPoints = new System.Windows.Forms.ListView();
            this.columnHeaderBP = new System.Windows.Forms.ColumnHeader();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControlAnalyzer.SuspendLayout();
            this.tabPageImports.SuspendLayout();
            this.tabPageExecutableNodes.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControlToolWindows1.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            this.tabControlToolWindows2.SuspendLayout();
            this.tabPageOutputWindow.SuspendLayout();
            this.tabPageCallStack.SuspendLayout();
            this.tabPageBreakPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.environmentToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(886, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenProject,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItemOpenProject
            // 
            this.toolStripMenuItemOpenProject.Name = "toolStripMenuItemOpenProject";
            this.toolStripMenuItemOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpenProject.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemOpenProject.Text = "Open Project";
            this.toolStripMenuItemOpenProject.Click += new System.EventHandler(this.toolStripMenuItemOpenProject_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // environmentToolStripMenuItem
            // 
            this.environmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.environmentToolStripMenuItem.Name = "environmentToolStripMenuItem";
            this.environmentToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.environmentToolStripMenuItem.Text = "&Environment";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setBPtoolStripMenuItem,
            this.toolStripSeparator4,
            this.runToolStripMenuItem,
            this.toolStripMenuItemBreak,
            this.toolStripSeparator2,
            this.stepIntoToolStripMenuItem,
            this.stepOverToolStripMenuItem,
            this.toolStripSeparator3,
            this.stopDebuggingToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "&Debug";
            // 
            // setBPtoolStripMenuItem
            // 
            this.setBPtoolStripMenuItem.Name = "setBPtoolStripMenuItem";
            this.setBPtoolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.setBPtoolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.setBPtoolStripMenuItem.Text = "Set Breakpoint";
            this.setBPtoolStripMenuItem.Click += new System.EventHandler(this.setBPtoolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(195, 6);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.runToolStripMenuItem.Text = "&Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolStripMenuItemBreak
            // 
            this.toolStripMenuItemBreak.Name = "toolStripMenuItemBreak";
            this.toolStripMenuItemBreak.ShortcutKeyDisplayString = "Ctrl+Shift+Break";
            this.toolStripMenuItemBreak.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Pause)));
            this.toolStripMenuItemBreak.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItemBreak.Text = "Break";
            this.toolStripMenuItemBreak.Click += new System.EventHandler(this.toolStripMenuItemBreak_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // stepIntoToolStripMenuItem
            // 
            this.stepIntoToolStripMenuItem.Name = "stepIntoToolStripMenuItem";
            this.stepIntoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.stepIntoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.stepIntoToolStripMenuItem.Text = "Step &Into";
            this.stepIntoToolStripMenuItem.Click += new System.EventHandler(this.stepIntoToolStripMenuItem_Click);
            // 
            // stepOverToolStripMenuItem
            // 
            this.stepOverToolStripMenuItem.Enabled = false;
            this.stepOverToolStripMenuItem.Name = "stepOverToolStripMenuItem";
            this.stepOverToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.stepOverToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.stepOverToolStripMenuItem.Text = "Step &Over";
            this.stepOverToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // stopDebuggingToolStripMenuItem
            // 
            this.stopDebuggingToolStripMenuItem.Enabled = false;
            this.stopDebuggingToolStripMenuItem.Name = "stopDebuggingToolStripMenuItem";
            this.stopDebuggingToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.stopDebuggingToolStripMenuItem.Text = "&Stop Debugging";
            this.stopDebuggingToolStripMenuItem.Visible = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 638);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(886, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Open Project or File...";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpenProject,
            this.toolStripButtonOpenFile,
            this.toolStripSeparator5,
            this.toolStripButtonStartDebugging,
            this.toolStripButtonBreakAll,
            this.toolStripButtonShowNextStatement,
            this.toolStripButtonStepInto,
            this.toolStripSeparator6,
            this.toolStripButtonSetBreakPoint,
            this.toolStripButtonShowBreakPoints});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(886, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonOpenProject
            // 
            this.toolStripButtonOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenProject.Image = global::MSBuildDebugger.UI.Resources.OpenProject;
            this.toolStripButtonOpenProject.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonOpenProject.Name = "toolStripButtonOpenProject";
            this.toolStripButtonOpenProject.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenProject.Text = "Open Project... (Ctrl+Shift+O)";
            this.toolStripButtonOpenProject.Click += new System.EventHandler(this.toolStripButtonOpenProject_Click);
            // 
            // toolStripButtonOpenFile
            // 
            this.toolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenFile.Image = global::MSBuildDebugger.UI.Resources.OpenFile;
            this.toolStripButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
            this.toolStripButtonOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenFile.Text = "Open File... (Ctrl+O)";
            this.toolStripButtonOpenFile.Click += new System.EventHandler(this.toolStripButtonOpenFile_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonStartDebugging
            // 
            this.toolStripButtonStartDebugging.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartDebugging.Image = global::MSBuildDebugger.UI.Resources.StartDebugging;
            this.toolStripButtonStartDebugging.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonStartDebugging.Name = "toolStripButtonStartDebugging";
            this.toolStripButtonStartDebugging.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStartDebugging.Text = "Start/Resume Debugging... (F5)";
            this.toolStripButtonStartDebugging.Click += new System.EventHandler(this.toolStripButtonStartDebugging_Click);
            // 
            // toolStripButtonBreakAll
            // 
            this.toolStripButtonBreakAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBreakAll.Image = global::MSBuildDebugger.UI.Resources.BreakAll;
            this.toolStripButtonBreakAll.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonBreakAll.Name = "toolStripButtonBreakAll";
            this.toolStripButtonBreakAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBreakAll.Text = "Break All... (Ctrl+Shift+Break)";
            this.toolStripButtonBreakAll.Click += new System.EventHandler(this.toolStripButtonBreakAll_Click);
            // 
            // toolStripButtonShowNextStatement
            // 
            this.toolStripButtonShowNextStatement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowNextStatement.Image = global::MSBuildDebugger.UI.Resources.ShowNextStatement;
            this.toolStripButtonShowNextStatement.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonShowNextStatement.Name = "toolStripButtonShowNextStatement";
            this.toolStripButtonShowNextStatement.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowNextStatement.Text = "Show Next Statement...";
            this.toolStripButtonShowNextStatement.Click += new System.EventHandler(this.toolStripButtonShowNextStatement_Click);
            // 
            // toolStripButtonStepInto
            // 
            this.toolStripButtonStepInto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStepInto.Image = global::MSBuildDebugger.UI.Resources.StepInto;
            this.toolStripButtonStepInto.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(2)))), ((int)(((byte)(252)))));
            this.toolStripButtonStepInto.Name = "toolStripButtonStepInto";
            this.toolStripButtonStepInto.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStepInto.Text = "Step Into... (F11)";
            this.toolStripButtonStepInto.Click += new System.EventHandler(this.toolStripButtonStepInto_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSetBreakPoint
            // 
            this.toolStripButtonSetBreakPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSetBreakPoint.Image = global::MSBuildDebugger.UI.Resources.SetBreakPoint;
            this.toolStripButtonSetBreakPoint.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonSetBreakPoint.Name = "toolStripButtonSetBreakPoint";
            this.toolStripButtonSetBreakPoint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSetBreakPoint.Text = "Set Breakpoint (F9)";
            this.toolStripButtonSetBreakPoint.Click += new System.EventHandler(this.toolStripButtonSetBreakPoint_Click);
            // 
            // toolStripButtonShowBreakPoints
            // 
            this.toolStripButtonShowBreakPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowBreakPoints.Image = global::MSBuildDebugger.UI.Resources.ShowBreakPoints;
            this.toolStripButtonShowBreakPoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowBreakPoints.Name = "toolStripButtonShowBreakPoints";
            this.toolStripButtonShowBreakPoints.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowBreakPoints.Text = "Show Breakpoints...";
            this.toolStripButtonShowBreakPoints.Click += new System.EventHandler(this.toolStripButtonShowBreakPoints_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 5;
            this.splitContainer1.Size = new System.Drawing.Size(886, 589);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControlAnalyzer);
            this.splitContainer3.Panel1Collapsed = true;
            this.splitContainer3.Panel1MinSize = 5;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControlOpenFiles);
            this.splitContainer3.Size = new System.Drawing.Size(886, 374);
            this.splitContainer3.SplitterDistance = 197;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControlAnalyzer
            // 
            this.tabControlAnalyzer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlAnalyzer.Controls.Add(this.tabPageImports);
            this.tabControlAnalyzer.Controls.Add(this.tabPageExecutableNodes);
            this.tabControlAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAnalyzer.Location = new System.Drawing.Point(0, 0);
            this.tabControlAnalyzer.Name = "tabControlAnalyzer";
            this.tabControlAnalyzer.SelectedIndex = 0;
            this.tabControlAnalyzer.Size = new System.Drawing.Size(195, 98);
            this.tabControlAnalyzer.TabIndex = 0;
            // 
            // tabPageImports
            // 
            this.tabPageImports.Controls.Add(this.treeViewImports);
            this.tabPageImports.Location = new System.Drawing.Point(4, 25);
            this.tabPageImports.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageImports.Name = "tabPageImports";
            this.tabPageImports.Size = new System.Drawing.Size(187, 69);
            this.tabPageImports.TabIndex = 0;
            this.tabPageImports.Text = "Imports";
            this.tabPageImports.UseVisualStyleBackColor = true;
            // 
            // treeViewImports
            // 
            this.treeViewImports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewImports.Location = new System.Drawing.Point(0, 0);
            this.treeViewImports.Name = "treeViewImports";
            this.treeViewImports.Size = new System.Drawing.Size(187, 69);
            this.treeViewImports.TabIndex = 0;
            // 
            // tabPageExecutableNodes
            // 
            this.tabPageExecutableNodes.Controls.Add(this.treeViewExecutableNodes);
            this.tabPageExecutableNodes.Location = new System.Drawing.Point(4, 25);
            this.tabPageExecutableNodes.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageExecutableNodes.Name = "tabPageExecutableNodes";
            this.tabPageExecutableNodes.Size = new System.Drawing.Size(187, 69);
            this.tabPageExecutableNodes.TabIndex = 1;
            this.tabPageExecutableNodes.Text = "Executable Nodes";
            this.tabPageExecutableNodes.UseVisualStyleBackColor = true;
            // 
            // treeViewExecutableNodes
            // 
            this.treeViewExecutableNodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewExecutableNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExecutableNodes.Location = new System.Drawing.Point(0, 0);
            this.treeViewExecutableNodes.Name = "treeViewExecutableNodes";
            this.treeViewExecutableNodes.Size = new System.Drawing.Size(187, 69);
            this.treeViewExecutableNodes.TabIndex = 1;
            // 
            // tabControlOpenFiles
            // 
            this.tabControlOpenFiles.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlOpenFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOpenFiles.Location = new System.Drawing.Point(0, 0);
            this.tabControlOpenFiles.Name = "tabControlOpenFiles";
            this.tabControlOpenFiles.SelectedIndex = 0;
            this.tabControlOpenFiles.Size = new System.Drawing.Size(884, 372);
            this.tabControlOpenFiles.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControlToolWindows1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControlToolWindows2);
            this.splitContainer2.Size = new System.Drawing.Size(886, 211);
            this.splitContainer2.SplitterDistance = 450;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControlToolWindows1
            // 
            this.tabControlToolWindows1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlToolWindows1.Controls.Add(this.tabPageProperties);
            this.tabControlToolWindows1.Controls.Add(this.tabPageItems);
            this.tabControlToolWindows1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlToolWindows1.Location = new System.Drawing.Point(0, 0);
            this.tabControlToolWindows1.Name = "tabControlToolWindows1";
            this.tabControlToolWindows1.SelectedIndex = 0;
            this.tabControlToolWindows1.Size = new System.Drawing.Size(448, 209);
            this.tabControlToolWindows1.TabIndex = 1;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.propertyViewerUserControlProperties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 25);
            this.tabPageProperties.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Size = new System.Drawing.Size(440, 180);
            this.tabPageProperties.TabIndex = 0;
            this.tabPageProperties.Text = "Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // propertyViewerUserControlProperties
            // 
            this.propertyViewerUserControlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyViewerUserControlProperties.Location = new System.Drawing.Point(0, 0);
            this.propertyViewerUserControlProperties.Name = "propertyViewerUserControlProperties";
            this.propertyViewerUserControlProperties.Size = new System.Drawing.Size(440, 180);
            this.propertyViewerUserControlProperties.TabIndex = 0;
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.propertyViewerUserControlItems);
            this.tabPageItems.Location = new System.Drawing.Point(4, 25);
            this.tabPageItems.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Size = new System.Drawing.Size(440, 180);
            this.tabPageItems.TabIndex = 1;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // propertyViewerUserControlItems
            // 
            this.propertyViewerUserControlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyViewerUserControlItems.Location = new System.Drawing.Point(0, 0);
            this.propertyViewerUserControlItems.Name = "propertyViewerUserControlItems";
            this.propertyViewerUserControlItems.Size = new System.Drawing.Size(440, 180);
            this.propertyViewerUserControlItems.TabIndex = 1;
            // 
            // tabControlToolWindows2
            // 
            this.tabControlToolWindows2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlToolWindows2.Controls.Add(this.tabPageOutputWindow);
            this.tabControlToolWindows2.Controls.Add(this.tabPageCallStack);
            this.tabControlToolWindows2.Controls.Add(this.tabPageBreakPoints);
            this.tabControlToolWindows2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlToolWindows2.Location = new System.Drawing.Point(0, 0);
            this.tabControlToolWindows2.Name = "tabControlToolWindows2";
            this.tabControlToolWindows2.SelectedIndex = 0;
            this.tabControlToolWindows2.Size = new System.Drawing.Size(430, 209);
            this.tabControlToolWindows2.TabIndex = 0;
            // 
            // tabPageOutputWindow
            // 
            this.tabPageOutputWindow.Controls.Add(this.textBoxOutputWindow);
            this.tabPageOutputWindow.Location = new System.Drawing.Point(4, 25);
            this.tabPageOutputWindow.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageOutputWindow.Name = "tabPageOutputWindow";
            this.tabPageOutputWindow.Size = new System.Drawing.Size(422, 180);
            this.tabPageOutputWindow.TabIndex = 1;
            this.tabPageOutputWindow.Text = "Output Window";
            this.tabPageOutputWindow.UseVisualStyleBackColor = true;
            // 
            // textBoxOutputWindow
            // 
            this.textBoxOutputWindow.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxOutputWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutputWindow.HideSelection = false;
            this.textBoxOutputWindow.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutputWindow.Multiline = true;
            this.textBoxOutputWindow.Name = "textBoxOutputWindow";
            this.textBoxOutputWindow.ReadOnly = true;
            this.textBoxOutputWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutputWindow.Size = new System.Drawing.Size(422, 180);
            this.textBoxOutputWindow.TabIndex = 2;
            this.textBoxOutputWindow.WordWrap = false;
            // 
            // tabPageCallStack
            // 
            this.tabPageCallStack.Controls.Add(this.listViewCallStack);
            this.tabPageCallStack.Location = new System.Drawing.Point(4, 25);
            this.tabPageCallStack.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageCallStack.Name = "tabPageCallStack";
            this.tabPageCallStack.Size = new System.Drawing.Size(422, 180);
            this.tabPageCallStack.TabIndex = 2;
            this.tabPageCallStack.Text = "Call Stack";
            this.tabPageCallStack.UseVisualStyleBackColor = true;
            // 
            // listViewCallStack
            // 
            this.listViewCallStack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName});
            this.listViewCallStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCallStack.GridLines = true;
            this.listViewCallStack.Location = new System.Drawing.Point(0, 0);
            this.listViewCallStack.MultiSelect = false;
            this.listViewCallStack.Name = "listViewCallStack";
            this.listViewCallStack.Size = new System.Drawing.Size(422, 180);
            this.listViewCallStack.TabIndex = 0;
            this.listViewCallStack.UseCompatibleStateImageBehavior = false;
            this.listViewCallStack.View = System.Windows.Forms.View.Details;
            this.listViewCallStack.DoubleClick += new System.EventHandler(this.listViewCallStack_DoubleClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 500;
            // 
            // tabPageBreakPoints
            // 
            this.tabPageBreakPoints.Controls.Add(this.listViewBreakPoints);
            this.tabPageBreakPoints.Location = new System.Drawing.Point(4, 25);
            this.tabPageBreakPoints.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageBreakPoints.Name = "tabPageBreakPoints";
            this.tabPageBreakPoints.Size = new System.Drawing.Size(422, 180);
            this.tabPageBreakPoints.TabIndex = 3;
            this.tabPageBreakPoints.Text = "Break Points";
            this.tabPageBreakPoints.UseVisualStyleBackColor = true;
            // 
            // listViewBreakPoints
            // 
            this.listViewBreakPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderBP});
            this.listViewBreakPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewBreakPoints.GridLines = true;
            this.listViewBreakPoints.Location = new System.Drawing.Point(0, 0);
            this.listViewBreakPoints.MultiSelect = false;
            this.listViewBreakPoints.Name = "listViewBreakPoints";
            this.listViewBreakPoints.Size = new System.Drawing.Size(422, 180);
            this.listViewBreakPoints.TabIndex = 0;
            this.listViewBreakPoints.UseCompatibleStateImageBehavior = false;
            this.listViewBreakPoints.View = System.Windows.Forms.View.Details;
            this.listViewBreakPoints.DoubleClick += new System.EventHandler(this.listViewBreakPoints_DoubleClick);
            this.listViewBreakPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listViewBreakPoints_KeyPress);
            // 
            // columnHeaderBP
            // 
            this.columnHeaderBP.Text = "Name (Press \'d\' to delete a breakpoint)";
            this.columnHeaderBP.Width = 505;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 660);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainWindow";
            this.Text = "MSBuild Debugger (v1.0 Alpha Release)";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tabControlAnalyzer.ResumeLayout(false);
            this.tabPageImports.ResumeLayout(false);
            this.tabPageExecutableNodes.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControlToolWindows1.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.tabControlToolWindows2.ResumeLayout(false);
            this.tabPageOutputWindow.ResumeLayout(false);
            this.tabPageOutputWindow.PerformLayout();
            this.tabPageCallStack.ResumeLayout(false);
            this.tabPageBreakPoints.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem stepIntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepOverToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem stopDebuggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBPtoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBreak;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenProject;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControlAnalyzer;
        private System.Windows.Forms.TabPage tabPageImports;
        private System.Windows.Forms.TreeView treeViewImports;
        private System.Windows.Forms.TabPage tabPageExecutableNodes;
        private System.Windows.Forms.TreeView treeViewExecutableNodes;
        private System.Windows.Forms.TabControl tabControlOpenFiles;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControlToolWindows1;
        private System.Windows.Forms.TabPage tabPageProperties;
        private PropertyViewerUserControl propertyViewerUserControlProperties;
        private System.Windows.Forms.TabPage tabPageItems;
        private PropertyViewerUserControl propertyViewerUserControlItems;
        private System.Windows.Forms.TabControl tabControlToolWindows2;
        private System.Windows.Forms.TabPage tabPageOutputWindow;
        private System.Windows.Forms.TextBox textBoxOutputWindow;
        private System.Windows.Forms.TabPage tabPageCallStack;
        private System.Windows.Forms.TabPage tabPageBreakPoints;
        private System.Windows.Forms.ListView listViewBreakPoints;
        private System.Windows.Forms.ColumnHeader columnHeaderBP;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenProject;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartDebugging;
        private System.Windows.Forms.ToolStripButton toolStripButtonBreakAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowNextStatement;
        private System.Windows.Forms.ToolStripButton toolStripButtonStepInto;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowBreakPoints;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetBreakPoint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem environmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ListView listViewCallStack;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    }
}

