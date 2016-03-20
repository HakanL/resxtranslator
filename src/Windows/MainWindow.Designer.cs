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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.resourceTreeView1 = new ResxTranslator.Controls.ResourceTreeView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.missingTranslationView1 = new ResxTranslator.Controls.MissingTranslationView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.languageSettings1 = new ResxTranslator.Controls.LanguageSettings();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPageEditedResource = new System.Windows.Forms.TabPage();
            this.resourceGrid1 = new ResxTranslator.Controls.ResourceGrid();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTranslateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateUsingBingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBingAppIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreEmptyResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLastDirectoryOnProgramStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertCurrentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(946, 22);
            this.statusStrip1.TabIndex = 3;
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
            this.panelMain.Size = new System.Drawing.Size(946, 487);
            this.panelMain.TabIndex = 4;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControl2);
            this.splitContainerMain.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControl3);
            this.splitContainerMain.Size = new System.Drawing.Size(946, 487);
            this.splitContainerMain.SplitterDistance = 246;
            this.splitContainerMain.TabIndex = 3;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(246, 350);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.resourceTreeView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(238, 324);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "All resources";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // resourceTreeView1
            // 
            this.resourceTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceTreeView1.Location = new System.Drawing.Point(0, 0);
            this.resourceTreeView1.Margin = new System.Windows.Forms.Padding(0);
            this.resourceTreeView1.Name = "resourceTreeView1";
            this.resourceTreeView1.Size = new System.Drawing.Size(238, 324);
            this.resourceTreeView1.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.missingTranslationView1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(238, 324);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Missing translations";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // missingTranslationView1
            // 
            this.missingTranslationView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.missingTranslationView1.Location = new System.Drawing.Point(0, 0);
            this.missingTranslationView1.Margin = new System.Windows.Forms.Padding(0);
            this.missingTranslationView1.Name = "missingTranslationView1";
            this.missingTranslationView1.ResourceLoader = null;
            this.missingTranslationView1.Size = new System.Drawing.Size(238, 324);
            this.missingTranslationView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 350);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(246, 137);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.languageSettings1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(238, 111);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Languages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // languageSettings1
            // 
            this.languageSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.languageSettings1.Location = new System.Drawing.Point(0, 0);
            this.languageSettings1.Margin = new System.Windows.Forms.Padding(0);
            this.languageSettings1.Name = "languageSettings1";
            this.languageSettings1.Size = new System.Drawing.Size(238, 111);
            this.languageSettings1.TabIndex = 5;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPageEditedResource);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(696, 487);
            this.tabControl3.TabIndex = 4;
            // 
            // tabPageEditedResource
            // 
            this.tabPageEditedResource.Controls.Add(this.resourceGrid1);
            this.tabPageEditedResource.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditedResource.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageEditedResource.Name = "tabPageEditedResource";
            this.tabPageEditedResource.Size = new System.Drawing.Size(688, 461);
            this.tabPageEditedResource.TabIndex = 0;
            this.tabPageEditedResource.Text = "Resource editor";
            this.tabPageEditedResource.UseVisualStyleBackColor = true;
            // 
            // resourceGrid1
            // 
            this.resourceGrid1.CurrentResource = null;
            this.resourceGrid1.DisplayContextMenu = true;
            this.resourceGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceGrid1.Location = new System.Drawing.Point(0, 0);
            this.resourceGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.resourceGrid1.Name = "resourceGrid1";
            this.resourceGrid1.Size = new System.Drawing.Size(688, 461);
            this.resourceGrid1.TabIndex = 3;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.findToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.autoTranslateToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(946, 24);
            this.menuStripMain.TabIndex = 5;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAllModifiedToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.revertCurrentFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.closeToolStripMenuItem.Text = "&Close directory";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem1});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewKeyToolStripMenuItem,
            this.deleteKeyToolStripMenuItem});
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.keysToolStripMenuItem.Text = "Keys";
            // 
            // deleteKeyToolStripMenuItem
            // 
            this.deleteKeyToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Delete_black_32x32;
            this.deleteKeyToolStripMenuItem.Name = "deleteKeyToolStripMenuItem";
            this.deleteKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteKeyToolStripMenuItem.Text = "Delete Key";
            this.deleteKeyToolStripMenuItem.Click += new System.EventHandler(this.deleteKeyToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLanguageToolStripMenuItem,
            this.removeLanguageToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            this.languagesToolStripMenuItem.DropDownOpened += new System.EventHandler(this.languagesToolStripMenuItem_DropDownOpened);
            // 
            // removeLanguageToolStripMenuItem
            // 
            this.removeLanguageToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Delete_black_32x32;
            this.removeLanguageToolStripMenuItem.Name = "removeLanguageToolStripMenuItem";
            this.removeLanguageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeLanguageToolStripMenuItem.Text = "Remove Language";
            this.removeLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.removeLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // autoTranslateToolStripMenuItem
            // 
            this.autoTranslateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translateUsingBingToolStripMenuItem,
            this.setBingAppIdToolStripMenuItem});
            this.autoTranslateToolStripMenuItem.Name = "autoTranslateToolStripMenuItem";
            this.autoTranslateToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.autoTranslateToolStripMenuItem.Text = "Auto Translate";
            // 
            // translateUsingBingToolStripMenuItem
            // 
            this.translateUsingBingToolStripMenuItem.Name = "translateUsingBingToolStripMenuItem";
            this.translateUsingBingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.translateUsingBingToolStripMenuItem.Text = "Translate using Bing";
            this.translateUsingBingToolStripMenuItem.Click += new System.EventHandler(this.translateUsingBingToolStripMenuItem_Click);
            // 
            // setBingAppIdToolStripMenuItem
            // 
            this.setBingAppIdToolStripMenuItem.Name = "setBingAppIdToolStripMenuItem";
            this.setBingAppIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setBingAppIdToolStripMenuItem.Text = "Set Bing Parameters";
            this.setBingAppIdToolStripMenuItem.Click += new System.EventHandler(this.setBingAppIdToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem,
            this.ignoreEmptyResourcesToolStripMenuItem,
            this.openLastDirectoryOnProgramStartToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // copyDefaultValuesOnLanguageAddToolStripMenuItem
            // 
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Name = "copyDefaultValuesOnLanguageAddToolStripMenuItem";
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.copyDefaultValuesOnLanguageAddToolStripMenuItem.Text = "Copy default values when adding languages";
            // 
            // ignoreEmptyResourcesToolStripMenuItem
            // 
            this.ignoreEmptyResourcesToolStripMenuItem.Name = "ignoreEmptyResourcesToolStripMenuItem";
            this.ignoreEmptyResourcesToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.ignoreEmptyResourcesToolStripMenuItem.Text = "Do not show empty resources";
            // 
            // openLastDirectoryOnProgramStartToolStripMenuItem
            // 
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Name = "openLastDirectoryOnProgramStartToolStripMenuItem";
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.openLastDirectoryOnProgramStartToolStripMenuItem.Text = "Open last directory on program start";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.openfolderHS;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openToolStripMenuItem.Text = "&Open directory";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAllModifiedToolStripMenuItem
            // 
            this.saveAllModifiedToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.SaveAllHS;
            this.saveAllModifiedToolStripMenuItem.Name = "saveAllModifiedToolStripMenuItem";
            this.saveAllModifiedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAllModifiedToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveAllModifiedToolStripMenuItem.Text = "&Save all modified";
            this.saveAllModifiedToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.saveHS;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveToolStripMenuItem.Text = "Save current resource";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentToolStripMenuItem_Click);
            // 
            // revertCurrentFileToolStripMenuItem
            // 
            this.revertCurrentFileToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Edit_UndoHS;
            this.revertCurrentFileToolStripMenuItem.Name = "revertCurrentFileToolStripMenuItem";
            this.revertCurrentFileToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.revertCurrentFileToolStripMenuItem.Text = "Revert current resource";
            this.revertCurrentFileToolStripMenuItem.Click += new System.EventHandler(this.revertCurrentToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Image = global::ResxTranslator.Properties.Resources.Find_VS;
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+F";
            this.findToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.findToolStripMenuItem1.Text = "&Find";
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Add;
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            this.addNewKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addNewKeyToolStripMenuItem.Text = "Add New Key";
            this.addNewKeyToolStripMenuItem.Click += new System.EventHandler(this.addNewKeyToolStripMenuItem_Click);
            // 
            // addLanguageToolStripMenuItem
            // 
            this.addLanguageToolStripMenuItem.Image = global::ResxTranslator.Properties.Resources.Add;
            this.addLanguageToolStripMenuItem.Name = "addLanguageToolStripMenuItem";
            this.addLanguageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addLanguageToolStripMenuItem.Text = "Add Language";
            this.addLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.addLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 533);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainWindow";
            this.Text = "ResxTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
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
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem1;
        private ToolStripMenuItem keysToolStripMenuItem;
        private ToolStripMenuItem addNewKeyToolStripMenuItem;
        private ToolStripMenuItem deleteKeyToolStripMenuItem;
        private ToolStripMenuItem addLanguageToolStripMenuItem;
        private ToolStripMenuItem autoTranslateToolStripMenuItem;
        private ToolStripMenuItem translateUsingBingToolStripMenuItem;
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
        private ToolStripMenuItem setBingAppIdToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem copyDefaultValuesOnLanguageAddToolStripMenuItem;
        private ToolStripMenuItem ignoreEmptyResourcesToolStripMenuItem;
        private ToolStripMenuItem languagesToolStripMenuItem;
        private ToolStripMenuItem removeLanguageToolStripMenuItem;
        private ToolStripMenuItem openLastDirectoryOnProgramStartToolStripMenuItem;
    }
}

