using System.Windows.Forms;

namespace ResxTranslator.Windows
{
    sealed partial class MainWindow
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelCurrentItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPageEditedResource = new System.Windows.Forms.TabPage();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadCurrentDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertCurrentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openResourceLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreEmptyResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayNullValuesAsGrayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLastDirectoryOnProgramStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setReferencePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.licenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAssembliesFromResourcePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceTreeView1 = new ResxTranslator.Controls.ResourceTreeView();
            this.missingTranslationView1 = new ResxTranslator.Controls.MissingTranslationView();
            this.languageSettings1 = new ResxTranslator.Controls.LanguageSettings();
            this.resourceGrid1 = new ResxTranslator.Controls.ResourceGrid();
            this.statusStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPageEditedResource.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabelCurrentItem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabelCurrentItem
            // 
            this.toolStripStatusLabelCurrentItem.Name = "toolStripStatusLabelCurrentItem";
            this.toolStripStatusLabelCurrentItem.Size = new System.Drawing.Size(0, 17);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainerMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(884, 465);
            this.panelMain.TabIndex = 4;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainerMain.Panel1MinSize = 125;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControl3);
            this.splitContainerMain.Panel2MinSize = 125;
            this.splitContainerMain.Size = new System.Drawing.Size(884, 465);
            this.splitContainerMain.SplitterDistance = 246;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(246, 465);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(246, 312);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.resourceTreeView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(238, 286);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "All resources";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.missingTranslationView1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(238, 286);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Missing translations";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(246, 149);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.languageSettings1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(238, 123);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Displayed languages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPageEditedResource);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(634, 465);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPageEditedResource
            // 
            this.tabPageEditedResource.Controls.Add(this.resourceGrid1);
            this.tabPageEditedResource.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditedResource.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageEditedResource.Name = "tabPageEditedResource";
            this.tabPageEditedResource.Size = new System.Drawing.Size(626, 439);
            this.tabPageEditedResource.TabIndex = 0;
            this.tabPageEditedResource.Text = "Resource editor";
            this.tabPageEditedResource.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.findToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(884, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAllModifiedToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.reloadCurrentDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.revertCurrentFileToolStripMenuItem,
            this.openResourceLocationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.openfolderHS;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openToolStripMenuItem.Text = "&Open directory...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAllModifiedToolStripMenuItem
            // 
            this.saveAllModifiedToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.SaveAllHS;
            this.saveAllModifiedToolStripMenuItem.Name = "saveAllModifiedToolStripMenuItem";
            this.saveAllModifiedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAllModifiedToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.saveAllModifiedToolStripMenuItem.Text = "&Save all modified";
            this.saveAllModifiedToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.closeToolStripMenuItem.Text = "&Close directory";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // reloadCurrentDirectoryToolStripMenuItem
            // 
            this.reloadCurrentDirectoryToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.RefreshArrow;
            this.reloadCurrentDirectoryToolStripMenuItem.Name = "reloadCurrentDirectoryToolStripMenuItem";
            this.reloadCurrentDirectoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.reloadCurrentDirectoryToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.reloadCurrentDirectoryToolStripMenuItem.Text = "Reload current directory";
            this.reloadCurrentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.reloadCurrentDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.saveHS;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.saveToolStripMenuItem.Text = "Save current resource";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentToolStripMenuItem_Click);
            // 
            // revertCurrentFileToolStripMenuItem
            // 
            this.revertCurrentFileToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Edit_UndoHS;
            this.revertCurrentFileToolStripMenuItem.Name = "revertCurrentFileToolStripMenuItem";
            this.revertCurrentFileToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.revertCurrentFileToolStripMenuItem.Text = "Revert current resource";
            this.revertCurrentFileToolStripMenuItem.Click += new System.EventHandler(this.revertCurrentToolStripMenuItem_Click);
            // 
            // openResourceLocationToolStripMenuItem
            // 
            this.openResourceLocationToolStripMenuItem.Name = "openResourceLocationToolStripMenuItem";
            this.openResourceLocationToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openResourceLocationToolStripMenuItem.Text = "Open resource location";
            this.openResourceLocationToolStripMenuItem.Click += new System.EventHandler(this.openResourceLocationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem1,
            this.clearSearchToolStripMenuItem});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.findToolStripMenuItem.Text = "Fi&nd";
            this.findToolStripMenuItem.DropDownOpened += new System.EventHandler(this.findToolStripMenuItem_DropDownOpened);
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Image = global::ResxTranslator.Properties.Resources.Find_VS;
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+F";
            this.findToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.findToolStripMenuItem1.Text = "&Find...";
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // clearSearchToolStripMenuItem
            // 
            this.clearSearchToolStripMenuItem.Name = "clearSearchToolStripMenuItem";
            this.clearSearchToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.clearSearchToolStripMenuItem.Text = "&Clear search";
            this.clearSearchToolStripMenuItem.Click += new System.EventHandler(this.clearSearchToolStripMenuItem_Click);
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewKeyToolStripMenuItem,
            this.deleteKeyToolStripMenuItem});
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.keysToolStripMenuItem.Text = "&Keys";
            // 
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Add;
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            this.addNewKeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add)));
            this.addNewKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addNewKeyToolStripMenuItem.Text = "&Add new Key...";
            this.addNewKeyToolStripMenuItem.Click += new System.EventHandler(this.addNewKeyToolStripMenuItem_Click);
            // 
            // deleteKeyToolStripMenuItem
            // 
            this.deleteKeyToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Delete_black_32x32;
            this.deleteKeyToolStripMenuItem.Name = "deleteKeyToolStripMenuItem";
            this.deleteKeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract)));
            this.deleteKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteKeyToolStripMenuItem.Text = "&Remove Key";
            this.deleteKeyToolStripMenuItem.Click += new System.EventHandler(this.deleteKeyToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLanguageToolStripMenuItem,
            this.removeLanguageToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "&Languages";
            this.languagesToolStripMenuItem.DropDownOpened += new System.EventHandler(this.languagesToolStripMenuItem_DropDownOpened);
            // 
            // addLanguageToolStripMenuItem
            // 
            this.addLanguageToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Add;
            this.addLanguageToolStripMenuItem.Name = "addLanguageToolStripMenuItem";
            this.addLanguageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addLanguageToolStripMenuItem.Text = "&Add new Language";
            this.addLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.addLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // removeLanguageToolStripMenuItem
            // 
            this.removeLanguageToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Delete_black_32x32;
            this.removeLanguageToolStripMenuItem.Name = "removeLanguageToolStripMenuItem";
            this.removeLanguageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.removeLanguageToolStripMenuItem.Text = "&Remove Language";
            this.removeLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.removeLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem,
            this.ignoreEmptyResourcesToolStripMenuItem,
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem,
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem,
            this.displayNullValuesAsGrayedToolStripMenuItem,
            this.openLastDirectoryOnProgramStartToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadAssembliesFromResourcePathToolStripMenuItem,
            this.setReferencePathsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // copyDefaultValuesOnLanguageAddToolStripMenuItem
            // 
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Name = "copyDefaultValuesOnLanguageAddToolStripMenuItem";
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Text = "Copy default values when adding languages";
            // 
            // ignoreEmptyResourcesToolStripMenuItem
            // 
            this.ignoreEmptyResourcesToolStripMenuItem.Name = "ignoreEmptyResourcesToolStripMenuItem";
            this.ignoreEmptyResourcesToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.ignoreEmptyResourcesToolStripMenuItem.Text = "Do not show resources with no strings";
            // 
            // doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem
            // 
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem.Name = "doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem";
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem.Text = "Do not show resources with no translations";
            // 
            // markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem
            // 
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem.Name = "markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem";
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem.Text = "Mark as translatable only if the default value is in [ ] brackets";
            // 
            // displayNullValuesAsGrayedToolStripMenuItem
            // 
            this.displayNullValuesAsGrayedToolStripMenuItem.Name = "displayNullValuesAsGrayedToolStripMenuItem";
            this.displayNullValuesAsGrayedToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.displayNullValuesAsGrayedToolStripMenuItem.Text = "Mark values that will not be saved (null) with gray background";
            // 
            // openLastDirectoryOnProgramStartToolStripMenuItem
            // 
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Name = "openLastDirectoryOnProgramStartToolStripMenuItem";
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Text = "Open last directory on program start";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(399, 6);
            // 
            // setReferencePathsToolStripMenuItem
            // 
            this.setReferencePathsToolStripMenuItem.Name = "setReferencePathsToolStripMenuItem";
            this.setReferencePathsToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.setReferencePathsToolStripMenuItem.Text = "Set paths to referenced assemblies...";
            this.setReferencePathsToolStripMenuItem.Click += new System.EventHandler(this.setReferencePathsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.licenceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::ResxTranslator.Properties.Resources.Help;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // licenceToolStripMenuItem
            // 
            this.licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            this.licenceToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.licenceToolStripMenuItem.Text = "View licence";
            this.licenceToolStripMenuItem.Click += new System.EventHandler(this.licenceToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // loadAssembliesFromResourcePathToolStripMenuItem
            // 
            this.loadAssembliesFromResourcePathToolStripMenuItem.Name = "loadAssembliesFromResourcePathToolStripMenuItem";
            this.loadAssembliesFromResourcePathToolStripMenuItem.Size = new System.Drawing.Size(402, 22);
            this.loadAssembliesFromResourcePathToolStripMenuItem.Text = "Load assemblies from opened resource directory";
            // 
            // resourceTreeView1
            // 
            this.resourceTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceTreeView1.Location = new System.Drawing.Point(0, 0);
            this.resourceTreeView1.Margin = new System.Windows.Forms.Padding(0);
            this.resourceTreeView1.Name = "resourceTreeView1";
            this.resourceTreeView1.Size = new System.Drawing.Size(238, 286);
            this.resourceTreeView1.TabIndex = 0;
            // 
            // missingTranslationView1
            // 
            this.missingTranslationView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.missingTranslationView1.Location = new System.Drawing.Point(0, 0);
            this.missingTranslationView1.Margin = new System.Windows.Forms.Padding(0);
            this.missingTranslationView1.Name = "missingTranslationView1";
            this.missingTranslationView1.ResourceLoader = null;
            this.missingTranslationView1.Size = new System.Drawing.Size(238, 286);
            this.missingTranslationView1.TabIndex = 0;
            // 
            // languageSettings1
            // 
            this.languageSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.languageSettings1.Location = new System.Drawing.Point(0, 0);
            this.languageSettings1.Margin = new System.Windows.Forms.Padding(0);
            this.languageSettings1.Name = "languageSettings1";
            this.languageSettings1.Size = new System.Drawing.Size(238, 123);
            this.languageSettings1.TabIndex = 0;
            // 
            // resourceGrid1
            // 
            this.resourceGrid1.CurrentResource = null;
            this.resourceGrid1.CurrentSearch = null;
            this.resourceGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceGrid1.Location = new System.Drawing.Point(0, 0);
            this.resourceGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.resourceGrid1.Name = "resourceGrid1";
            this.resourceGrid1.ShowNullValuesAsGrayed = false;
            this.resourceGrid1.Size = new System.Drawing.Size(626, 439);
            this.resourceGrid1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(430, 280);
            this.Name = "MainWindow";
            this.Text = "Resx Resource Translator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPageEditedResource.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            resources.ApplyResources(this.toolStripStatusLabelCurrentItem, "toolStripStatusLabelCurrentItem");
            resources.ApplyResources(this.panelMain, "panelMain");
            resources.ApplyResources(this.splitContainerMain, "splitContainerMain");
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            resources.ApplyResources(this.tabControl2, "tabControl2");
            resources.ApplyResources(this.tabPage3, "tabPage3");
            resources.ApplyResources(this.resourceTreeView1, "resourceTreeView1");
            resources.ApplyResources(this.tabPage5, "tabPage5");
            resources.ApplyResources(this.missingTranslationView1, "missingTranslationView1");
            resources.ApplyResources(this.tabControl1, "tabControl1");
            resources.ApplyResources(this.tabPage1, "tabPage1");
            resources.ApplyResources(this.languageSettings1, "languageSettings1");
            resources.ApplyResources(this.tabControl3, "tabControl3");
            resources.ApplyResources(this.tabPageEditedResource, "tabPageEditedResource");
            resources.ApplyResources(this.resourceGrid1, "resourceGrid1");
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            resources.ApplyResources(this.saveAllModifiedToolStripMenuItem, "saveAllModifiedToolStripMenuItem");
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            resources.ApplyResources(this.reloadCurrentDirectoryToolStripMenuItem, "reloadCurrentDirectoryToolStripMenuItem");
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            resources.ApplyResources(this.revertCurrentFileToolStripMenuItem, "revertCurrentFileToolStripMenuItem");
            resources.ApplyResources(this.openResourceLocationToolStripMenuItem, "openResourceLocationToolStripMenuItem");
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            resources.ApplyResources(this.findToolStripMenuItem, "findToolStripMenuItem");
            resources.ApplyResources(this.findToolStripMenuItem1, "findToolStripMenuItem1");
            resources.ApplyResources(this.clearSearchToolStripMenuItem, "clearSearchToolStripMenuItem");
            resources.ApplyResources(this.keysToolStripMenuItem, "keysToolStripMenuItem");
            resources.ApplyResources(this.addNewKeyToolStripMenuItem, "addNewKeyToolStripMenuItem");
            resources.ApplyResources(this.deleteKeyToolStripMenuItem, "deleteKeyToolStripMenuItem");
            resources.ApplyResources(this.languagesToolStripMenuItem, "languagesToolStripMenuItem");
            resources.ApplyResources(this.addLanguageToolStripMenuItem, "addLanguageToolStripMenuItem");
            resources.ApplyResources(this.removeLanguageToolStripMenuItem, "removeLanguageToolStripMenuItem");
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            resources.ApplyResources(this.copyDefaultValuesOnLanguageAddToolStripMenuItem, "copyDefaultValuesOnLanguageAddToolStripMenuItem");
            resources.ApplyResources(this.ignoreEmptyResourcesToolStripMenuItem, "ignoreEmptyResourcesToolStripMenuItem");
            resources.ApplyResources(this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem, "doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem");
            resources.ApplyResources(this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem, "markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem");
            resources.ApplyResources(this.displayNullValuesAsGrayedToolStripMenuItem, "displayNullValuesAsGrayedToolStripMenuItem");
            resources.ApplyResources(this.openLastDirectoryOnProgramStartToolStripMenuItem, "openLastDirectoryOnProgramStartToolStripMenuItem");
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            resources.ApplyResources(this.loadAssembliesFromResourcePathToolStripMenuItem, "loadAssembliesFromResourcePathToolStripMenuItem");
            resources.ApplyResources(this.setReferencePathsToolStripMenuItem, "setReferencePathsToolStripMenuItem");
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
            resources.ApplyResources(this.licenceToolStripMenuItem, "licenceToolStripMenuItem");
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            resources.ApplyResources(this, "$this");
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private Panel panelMain;
        private SplitContainer splitContainerMain;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveAllModifiedToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem revertCurrentFileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem1;
        private ToolStripMenuItem keysToolStripMenuItem;
        private ToolStripMenuItem addNewKeyToolStripMenuItem;
        private ToolStripMenuItem deleteKeyToolStripMenuItem;
        private ToolStripMenuItem addLanguageToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabelCurrentItem;
        private Controls.ResourceGrid resourceGrid1;
        private Controls.ResourceTreeView resourceTreeView1;
        private Controls.LanguageSettings languageSettings1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabControl tabControl3;
        private TabPage tabPageEditedResource;
        private TabPage tabPage5;
        private Controls.MissingTranslationView missingTranslationView1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem copyDefaultValuesOnLanguageAddToolStripMenuItem;
        private ToolStripMenuItem ignoreEmptyResourcesToolStripMenuItem;
        private ToolStripMenuItem languagesToolStripMenuItem;
        private ToolStripMenuItem removeLanguageToolStripMenuItem;
        private ToolStripMenuItem openLastDirectoryOnProgramStartToolStripMenuItem;
        private ToolStripMenuItem clearSearchToolStripMenuItem;
        private ToolStripMenuItem openResourceLocationToolStripMenuItem;
        private ToolStripMenuItem reloadCurrentDirectoryToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem;
        private ToolStripMenuItem licenceToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem;
        private ToolStripMenuItem displayNullValuesAsGrayedToolStripMenuItem;
        private ToolStripMenuItem setReferencePathsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem loadAssembliesFromResourcePathToolStripMenuItem;
    }
}

