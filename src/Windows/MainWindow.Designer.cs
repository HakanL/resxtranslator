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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteLanguageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTranslateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelCurrentItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertCurrentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideNontranslatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBingAppIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTranslateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateUsingBingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceTreeView1 = new ResxTranslator.Controls.ResourceTreeView();
            this.languageSettings1 = new ResxTranslator.Controls.LanguageSettings();
            this.resourceGrid1 = new ResxTranslator.Controls.ResourceGrid();
            this.contextMenuStripLanguage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripLanguage
            // 
            this.contextMenuStripLanguage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteLanguageFileToolStripMenuItem,
            this.autoTranslateToolStripMenuItem1});
            this.contextMenuStripLanguage.Name = "contextMenuStripLanguage";
            this.contextMenuStripLanguage.Size = new System.Drawing.Size(182, 48);
            // 
            // deleteLanguageFileToolStripMenuItem
            // 
            this.deleteLanguageFileToolStripMenuItem.Name = "deleteLanguageFileToolStripMenuItem";
            this.deleteLanguageFileToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteLanguageFileToolStripMenuItem.Text = "Delete Language file";
            this.deleteLanguageFileToolStripMenuItem.Click += new System.EventHandler(this.deleteLanguageFileToolStripMenuItem_Click);
            // 
            // autoTranslateToolStripMenuItem1
            // 
            this.autoTranslateToolStripMenuItem1.Name = "autoTranslateToolStripMenuItem1";
            this.autoTranslateToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.autoTranslateToolStripMenuItem1.Text = "Auto translate";
            this.autoTranslateToolStripMenuItem1.Click += new System.EventHandler(this.autoTranslateToolStripMenuItem1_Click);
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
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(0, 24, 0, 3);
            this.panelMain.Size = new System.Drawing.Size(946, 511);
            this.panelMain.TabIndex = 4;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.resourceTreeView1);
            this.splitContainerMain.Panel1.Controls.Add(this.languageSettings1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.resourceGrid1);
            this.splitContainerMain.Size = new System.Drawing.Size(946, 484);
            this.splitContainerMain.SplitterDistance = 246;
            this.splitContainerMain.TabIndex = 3;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.findToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.addLanguageToolStripMenuItem,
            this.autoTranslateToolStripMenuItem});
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
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.revertCurrentFileToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAllModifiedToolStripMenuItem
            // 
            this.saveAllModifiedToolStripMenuItem.Name = "saveAllModifiedToolStripMenuItem";
            this.saveAllModifiedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAllModifiedToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveAllModifiedToolStripMenuItem.Text = "&Save all modified";
            this.saveAllModifiedToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveToolStripMenuItem.Text = "Save current resource";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentToolStripMenuItem_Click);
            // 
            // revertCurrentFileToolStripMenuItem
            // 
            this.revertCurrentFileToolStripMenuItem.Name = "revertCurrentFileToolStripMenuItem";
            this.revertCurrentFileToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.revertCurrentFileToolStripMenuItem.Text = "Revert current resource";
            this.revertCurrentFileToolStripMenuItem.Click += new System.EventHandler(this.revertCurrentToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
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
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+F";
            this.findToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.findToolStripMenuItem1.Text = "&Find";
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideNontranslatedToolStripMenuItem,
            this.setBingAppIdToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // hideNontranslatedToolStripMenuItem
            // 
            this.hideNontranslatedToolStripMenuItem.Name = "hideNontranslatedToolStripMenuItem";
            this.hideNontranslatedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideNontranslatedToolStripMenuItem.Text = "Hide non-translated";
            this.hideNontranslatedToolStripMenuItem.Click += new System.EventHandler(this.hideNontranslatedToolStripMenuItem_Click);
            // 
            // setBingAppIdToolStripMenuItem
            // 
            this.setBingAppIdToolStripMenuItem.Name = "setBingAppIdToolStripMenuItem";
            this.setBingAppIdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setBingAppIdToolStripMenuItem.Text = "Set Bing Parameters";
            this.setBingAppIdToolStripMenuItem.Click += new System.EventHandler(this.setBingAppIdToolStripMenuItem_Click);
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
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            this.addNewKeyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.addNewKeyToolStripMenuItem.Text = "Add New Key";
            this.addNewKeyToolStripMenuItem.Click += new System.EventHandler(this.addNewKeyToolStripMenuItem_Click);
            // 
            // deleteKeyToolStripMenuItem
            // 
            this.deleteKeyToolStripMenuItem.Name = "deleteKeyToolStripMenuItem";
            this.deleteKeyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteKeyToolStripMenuItem.Text = "Delete Key";
            this.deleteKeyToolStripMenuItem.Click += new System.EventHandler(this.deleteKeyToolStripMenuItem_Click);
            // 
            // addLanguageToolStripMenuItem
            // 
            this.addLanguageToolStripMenuItem.Name = "addLanguageToolStripMenuItem";
            this.addLanguageToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.addLanguageToolStripMenuItem.Text = "Add Language";
            this.addLanguageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.addLanguageToolStripMenuItem_DropDownItemClicked);
            // 
            // autoTranslateToolStripMenuItem
            // 
            this.autoTranslateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translateUsingBingToolStripMenuItem});
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
            // resourceTreeView1
            // 
            this.resourceTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceTreeView1.Location = new System.Drawing.Point(0, 0);
            this.resourceTreeView1.Name = "resourceTreeView1";
            this.resourceTreeView1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resourceTreeView1.Size = new System.Drawing.Size(246, 329);
            this.resourceTreeView1.TabIndex = 4;
            // 
            // languageSettings1
            // 
            this.languageSettings1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.languageSettings1.Location = new System.Drawing.Point(0, 329);
            this.languageSettings1.Name = "languageSettings1";
            this.languageSettings1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.languageSettings1.Size = new System.Drawing.Size(246, 155);
            this.languageSettings1.TabIndex = 5;
            // 
            // resourceGrid1
            // 
            this.resourceGrid1.CurrentResource = null;
            this.resourceGrid1.DisplayContextMenu = true;
            this.resourceGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceGrid1.Location = new System.Drawing.Point(0, 0);
            this.resourceGrid1.Name = "resourceGrid1";
            this.resourceGrid1.Size = new System.Drawing.Size(696, 484);
            this.resourceGrid1.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 533);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainWindow";
            this.Text = "ResxTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStripLanguage.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripLanguage;
		private System.Windows.Forms.ToolStripMenuItem deleteLanguageFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoTranslateToolStripMenuItem1;
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
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem hideNontranslatedToolStripMenuItem;
        private ToolStripMenuItem setBingAppIdToolStripMenuItem;
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
    }
}

