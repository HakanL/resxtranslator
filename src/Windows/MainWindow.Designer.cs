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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.exportAllResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertCurrentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openResourceLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNontranslatableDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNonTLFromOpenedTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNonTLFromAllTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimWhitespaceFromCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreEmptyResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayNullValuesAsGrayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLastDirectoryOnProgramStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadAssembliesFromResourcePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setReferencePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.licenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabelCurrentItem
            // 
            this.toolStripStatusLabelCurrentItem.Name = "toolStripStatusLabelCurrentItem";
            resources.ApplyResources(this.toolStripStatusLabelCurrentItem, "toolStripStatusLabelCurrentItem");
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainerMain);
            resources.ApplyResources(this.panelMain, "panelMain");
            this.panelMain.Name = "panelMain";
            // 
            // splitContainerMain
            // 
            resources.ApplyResources(this.splitContainerMain, "splitContainerMain");
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControl3);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.resourceTreeView1);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.missingTranslationView1);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.languageSettings1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPageEditedResource);
            resources.ApplyResources(this.tabControl3, "tabControl3");
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            // 
            // tabPageEditedResource
            // 
            this.tabPageEditedResource.Controls.Add(this.resourceGrid1);
            resources.ApplyResources(this.tabPageEditedResource, "tabPageEditedResource");
            this.tabPageEditedResource.Name = "tabPageEditedResource";
            this.tabPageEditedResource.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.findToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Name = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAllModifiedToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.reloadCurrentDirectoryToolStripMenuItem,
            this.exportAllResourcesToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.revertCurrentFileToolStripMenuItem,
            this.openResourceLocationToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.openfolderHS;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAllModifiedToolStripMenuItem
            // 
            this.saveAllModifiedToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.SaveAllHS;
            this.saveAllModifiedToolStripMenuItem.Name = "saveAllModifiedToolStripMenuItem";
            resources.ApplyResources(this.saveAllModifiedToolStripMenuItem, "saveAllModifiedToolStripMenuItem");
            this.saveAllModifiedToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // reloadCurrentDirectoryToolStripMenuItem
            // 
            this.reloadCurrentDirectoryToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.RefreshArrow;
            this.reloadCurrentDirectoryToolStripMenuItem.Name = "reloadCurrentDirectoryToolStripMenuItem";
            resources.ApplyResources(this.reloadCurrentDirectoryToolStripMenuItem, "reloadCurrentDirectoryToolStripMenuItem");
            this.reloadCurrentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.reloadCurrentDirectoryToolStripMenuItem_Click);
            // 
            // exportAllResourcesToolStripMenuItem
            // 
            this.exportAllResourcesToolStripMenuItem.Name = "exportAllResourcesToolStripMenuItem";
            resources.ApplyResources(this.exportAllResourcesToolStripMenuItem, "exportAllResourcesToolStripMenuItem");
            this.exportAllResourcesToolStripMenuItem.Click += new System.EventHandler(this.exportAllResourcesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.saveHS;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentToolStripMenuItem_Click);
            // 
            // revertCurrentFileToolStripMenuItem
            // 
            this.revertCurrentFileToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Edit_UndoHS;
            this.revertCurrentFileToolStripMenuItem.Name = "revertCurrentFileToolStripMenuItem";
            resources.ApplyResources(this.revertCurrentFileToolStripMenuItem, "revertCurrentFileToolStripMenuItem");
            this.revertCurrentFileToolStripMenuItem.Click += new System.EventHandler(this.revertCurrentToolStripMenuItem_Click);
            // 
            // openResourceLocationToolStripMenuItem
            // 
            this.openResourceLocationToolStripMenuItem.Name = "openResourceLocationToolStripMenuItem";
            resources.ApplyResources(this.openResourceLocationToolStripMenuItem, "openResourceLocationToolStripMenuItem");
            this.openResourceLocationToolStripMenuItem.Click += new System.EventHandler(this.openResourceLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem1,
            this.findNextToolStripMenuItem,
            this.clearSearchToolStripMenuItem});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            resources.ApplyResources(this.findToolStripMenuItem, "findToolStripMenuItem");
            this.findToolStripMenuItem.DropDownOpened += new System.EventHandler(this.findToolStripMenuItem_DropDownOpened);
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Image = global::ResxTranslator.Properties.Resources.Find_VS;
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            resources.ApplyResources(this.findToolStripMenuItem1, "findToolStripMenuItem1");
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // clearSearchToolStripMenuItem
            // 
            this.clearSearchToolStripMenuItem.Name = "clearSearchToolStripMenuItem";
            resources.ApplyResources(this.clearSearchToolStripMenuItem, "clearSearchToolStripMenuItem");
            this.clearSearchToolStripMenuItem.Click += new System.EventHandler(this.clearSearchToolStripMenuItem_Click);
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewKeyToolStripMenuItem,
            this.deleteKeyToolStripMenuItem});
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            resources.ApplyResources(this.keysToolStripMenuItem, "keysToolStripMenuItem");
            // 
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Add;
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            resources.ApplyResources(this.addNewKeyToolStripMenuItem, "addNewKeyToolStripMenuItem");
            this.addNewKeyToolStripMenuItem.Click += new System.EventHandler(this.addNewKeyToolStripMenuItem_Click);
            // 
            // deleteKeyToolStripMenuItem
            // 
            this.deleteKeyToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Delete_black_32x32;
            this.deleteKeyToolStripMenuItem.Name = "deleteKeyToolStripMenuItem";
            resources.ApplyResources(this.deleteKeyToolStripMenuItem, "deleteKeyToolStripMenuItem");
            this.deleteKeyToolStripMenuItem.Click += new System.EventHandler(this.deleteKeyToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLanguageToolStripMenuItem,
            this.removeLanguageToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            resources.ApplyResources(this.languagesToolStripMenuItem, "languagesToolStripMenuItem");
            this.languagesToolStripMenuItem.DropDownOpened += new System.EventHandler(this.languagesToolStripMenuItem_DropDownOpened);
            // 
            // addLanguageToolStripMenuItem
            // 
            this.addLanguageToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Add;
            this.addLanguageToolStripMenuItem.Name = "addLanguageToolStripMenuItem";
            resources.ApplyResources(this.addLanguageToolStripMenuItem, "addLanguageToolStripMenuItem");
            this.addLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.addLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // removeLanguageToolStripMenuItem
            // 
            this.removeLanguageToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Delete_black_32x32;
            this.removeLanguageToolStripMenuItem.Name = "removeLanguageToolStripMenuItem";
            resources.ApplyResources(this.removeLanguageToolStripMenuItem, "removeLanguageToolStripMenuItem");
            this.removeLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.removeLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeNontranslatableDataToolStripMenuItem,
            this.trimWhitespaceFromCellsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
            // 
            // removeNontranslatableDataToolStripMenuItem
            // 
            this.removeNontranslatableDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeNonTLFromOpenedTranslationsToolStripMenuItem,
            this.removeNonTLFromAllTranslationsToolStripMenuItem});
            this.removeNontranslatableDataToolStripMenuItem.Name = "removeNontranslatableDataToolStripMenuItem";
            resources.ApplyResources(this.removeNontranslatableDataToolStripMenuItem, "removeNontranslatableDataToolStripMenuItem");
            // 
            // removeNonTLFromOpenedTranslationsToolStripMenuItem
            // 
            this.removeNonTLFromOpenedTranslationsToolStripMenuItem.Name = "removeNonTLFromOpenedTranslationsToolStripMenuItem";
            resources.ApplyResources(this.removeNonTLFromOpenedTranslationsToolStripMenuItem, "removeNonTLFromOpenedTranslationsToolStripMenuItem");
            this.removeNonTLFromOpenedTranslationsToolStripMenuItem.Click += new System.EventHandler(this.fromOpenedTranslationsToolStripMenuItem_Click);
            // 
            // removeNonTLFromAllTranslationsToolStripMenuItem
            // 
            this.removeNonTLFromAllTranslationsToolStripMenuItem.Name = "removeNonTLFromAllTranslationsToolStripMenuItem";
            resources.ApplyResources(this.removeNonTLFromAllTranslationsToolStripMenuItem, "removeNonTLFromAllTranslationsToolStripMenuItem");
            this.removeNonTLFromAllTranslationsToolStripMenuItem.Click += new System.EventHandler(this.fromAllTranslationsToolStripMenuItem_Click);
            // 
            // trimWhitespaceFromCellsToolStripMenuItem
            // 
            this.trimWhitespaceFromCellsToolStripMenuItem.Name = "trimWhitespaceFromCellsToolStripMenuItem";
            resources.ApplyResources(this.trimWhitespaceFromCellsToolStripMenuItem, "trimWhitespaceFromCellsToolStripMenuItem");
            this.trimWhitespaceFromCellsToolStripMenuItem.Click += new System.EventHandler(this.trimWhitespaceFromCellsToolStripMenuItem_Click);
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
            this.storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadAssembliesFromResourcePathToolStripMenuItem,
            this.setReferencePathsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // copyDefaultValuesOnLanguageAddToolStripMenuItem
            // 
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Name = "copyDefaultValuesOnLanguageAddToolStripMenuItem";
            resources.ApplyResources(this.copyDefaultValuesOnLanguageAddToolStripMenuItem, "copyDefaultValuesOnLanguageAddToolStripMenuItem");
            // 
            // ignoreEmptyResourcesToolStripMenuItem
            // 
            this.ignoreEmptyResourcesToolStripMenuItem.Name = "ignoreEmptyResourcesToolStripMenuItem";
            resources.ApplyResources(this.ignoreEmptyResourcesToolStripMenuItem, "ignoreEmptyResourcesToolStripMenuItem");
            // 
            // doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem
            // 
            this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem.Name = "doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem";
            resources.ApplyResources(this.doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem, "doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem");
            // 
            // markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem
            // 
            this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem.Name = "markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem";
            resources.ApplyResources(this.markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem, "markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem");
            // 
            // displayNullValuesAsGrayedToolStripMenuItem
            // 
            this.displayNullValuesAsGrayedToolStripMenuItem.Name = "displayNullValuesAsGrayedToolStripMenuItem";
            resources.ApplyResources(this.displayNullValuesAsGrayedToolStripMenuItem, "displayNullValuesAsGrayedToolStripMenuItem");
            // 
            // openLastDirectoryOnProgramStartToolStripMenuItem
            // 
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Name = "openLastDirectoryOnProgramStartToolStripMenuItem";
            resources.ApplyResources(this.openLastDirectoryOnProgramStartToolStripMenuItem, "openLastDirectoryOnProgramStartToolStripMenuItem");
            // 
            // storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem
            // 
            this.storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem.Name = "storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem";
            resources.ApplyResources(this.storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem, "storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // loadAssembliesFromResourcePathToolStripMenuItem
            // 
            this.loadAssembliesFromResourcePathToolStripMenuItem.Name = "loadAssembliesFromResourcePathToolStripMenuItem";
            resources.ApplyResources(this.loadAssembliesFromResourcePathToolStripMenuItem, "loadAssembliesFromResourcePathToolStripMenuItem");
            // 
            // setReferencePathsToolStripMenuItem
            // 
            this.setReferencePathsToolStripMenuItem.Name = "setReferencePathsToolStripMenuItem";
            resources.ApplyResources(this.setReferencePathsToolStripMenuItem, "setReferencePathsToolStripMenuItem");
            this.setReferencePathsToolStripMenuItem.Click += new System.EventHandler(this.setReferencePathsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.licenceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::ResxTranslator.Properties.Resources.Help;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // licenceToolStripMenuItem
            // 
            this.licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            resources.ApplyResources(this.licenceToolStripMenuItem, "licenceToolStripMenuItem");
            this.licenceToolStripMenuItem.Click += new System.EventHandler(this.licenceToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            resources.ApplyResources(this.findNextToolStripMenuItem, "findNextToolStripMenuItem");
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            // 
            // resourceTreeView1
            // 
            resources.ApplyResources(this.resourceTreeView1, "resourceTreeView1");
            this.resourceTreeView1.Name = "resourceTreeView1";
            // 
            // missingTranslationView1
            // 
            resources.ApplyResources(this.missingTranslationView1, "missingTranslationView1");
            this.missingTranslationView1.Name = "missingTranslationView1";
            this.missingTranslationView1.ResourceLoader = null;
            // 
            // languageSettings1
            // 
            resources.ApplyResources(this.languageSettings1, "languageSettings1");
            this.languageSettings1.Name = "languageSettings1";
            // 
            // resourceGrid1
            // 
            this.resourceGrid1.CurrentResource = null;
            this.resourceGrid1.CurrentSearch = null;
            resources.ApplyResources(this.resourceGrid1, "resourceGrid1");
            this.resourceGrid1.Name = "resourceGrid1";
            this.resourceGrid1.ShowNullValuesAsGrayed = false;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainWindow";
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
        private ToolStripMenuItem languagesToolStripMenuItem;
        private ToolStripMenuItem removeLanguageToolStripMenuItem;
        private ToolStripMenuItem clearSearchToolStripMenuItem;
        private ToolStripMenuItem openResourceLocationToolStripMenuItem;
        private ToolStripMenuItem reloadCurrentDirectoryToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem licenceToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem removeNontranslatableDataToolStripMenuItem;
        private ToolStripMenuItem removeNonTLFromOpenedTranslationsToolStripMenuItem;
        private ToolStripMenuItem removeNonTLFromAllTranslationsToolStripMenuItem;
        private ToolStripMenuItem trimWhitespaceFromCellsToolStripMenuItem;
        private ToolStripMenuItem exportAllResourcesToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem copyDefaultValuesOnLanguageAddToolStripMenuItem;
        private ToolStripMenuItem ignoreEmptyResourcesToolStripMenuItem;
        private ToolStripMenuItem doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem;
        private ToolStripMenuItem markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem;
        private ToolStripMenuItem displayNullValuesAsGrayedToolStripMenuItem;
        private ToolStripMenuItem openLastDirectoryOnProgramStartToolStripMenuItem;
        private ToolStripMenuItem storeAndLoadCommentsFromAllLanguageFilesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem loadAssembliesFromResourcePathToolStripMenuItem;
        private ToolStripMenuItem setReferencePathsToolStripMenuItem;
        private ToolStripMenuItem findNextToolStripMenuItem;
    }
}

