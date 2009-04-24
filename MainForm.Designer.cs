namespace ResxTranslator
{
	partial class MainForm
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
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hideNontranslatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridEXStrings = new Janus.Windows.GridEX.GridEX();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.treeViewResx = new System.Windows.Forms.TreeView();
			this.splitContainerResource = new System.Windows.Forms.SplitContainer();
			this.checkedListBoxLanguages = new System.Windows.Forms.CheckedListBox();
			this.panelTitle = new System.Windows.Forms.Panel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.menuStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEXStrings)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.splitContainerResource.Panel1.SuspendLayout();
			this.splitContainerResource.Panel2.SuspendLayout();
			this.splitContainerResource.SuspendLayout();
			this.panelTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(728, 24);
			this.menuStripMain.TabIndex = 0;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
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
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideNontranslatedToolStripMenuItem});
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
			// gridEXStrings
			// 
			this.gridEXStrings.ColumnAutoResize = true;
			this.gridEXStrings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridEXStrings.GroupByBoxVisible = false;
			this.gridEXStrings.Location = new System.Drawing.Point(0, 35);
			this.gridEXStrings.Name = "gridEXStrings";
			this.gridEXStrings.Size = new System.Drawing.Size(483, 254);
			this.gridEXStrings.TabIndex = 1;
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.treeViewResx);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.splitContainerResource);
			this.splitContainerMain.Size = new System.Drawing.Size(728, 354);
			this.splitContainerMain.SplitterDistance = 241;
			this.splitContainerMain.TabIndex = 2;
			// 
			// treeViewResx
			// 
			this.treeViewResx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewResx.HideSelection = false;
			this.treeViewResx.Location = new System.Drawing.Point(0, 0);
			this.treeViewResx.Name = "treeViewResx";
			this.treeViewResx.Size = new System.Drawing.Size(241, 354);
			this.treeViewResx.TabIndex = 0;
			this.treeViewResx.DoubleClick += new System.EventHandler(this.treeViewResx_DoubleClick);
			// 
			// splitContainerResource
			// 
			this.splitContainerResource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerResource.Location = new System.Drawing.Point(0, 0);
			this.splitContainerResource.Name = "splitContainerResource";
			this.splitContainerResource.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerResource.Panel1
			// 
			this.splitContainerResource.Panel1.Controls.Add(this.checkedListBoxLanguages);
			// 
			// splitContainerResource.Panel2
			// 
			this.splitContainerResource.Panel2.Controls.Add(this.gridEXStrings);
			this.splitContainerResource.Panel2.Controls.Add(this.panelTitle);
			this.splitContainerResource.Size = new System.Drawing.Size(483, 354);
			this.splitContainerResource.SplitterDistance = 61;
			this.splitContainerResource.TabIndex = 2;
			// 
			// checkedListBoxLanguages
			// 
			this.checkedListBoxLanguages.CheckOnClick = true;
			this.checkedListBoxLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkedListBoxLanguages.FormattingEnabled = true;
			this.checkedListBoxLanguages.Location = new System.Drawing.Point(0, 0);
			this.checkedListBoxLanguages.MultiColumn = true;
			this.checkedListBoxLanguages.Name = "checkedListBoxLanguages";
			this.checkedListBoxLanguages.Size = new System.Drawing.Size(483, 55);
			this.checkedListBoxLanguages.TabIndex = 0;
			this.checkedListBoxLanguages.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxLanguages_ItemCheck);
			// 
			// panelTitle
			// 
			this.panelTitle.Controls.Add(this.labelTitle);
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Location = new System.Drawing.Point(0, 0);
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Size = new System.Drawing.Size(483, 35);
			this.panelTitle.TabIndex = 2;
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(4, 4);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(476, 28);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "{Title}";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 378);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.menuStripMain);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "MainForm";
			this.Text = "ResxTranslator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEXStrings)).EndInit();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			this.splitContainerMain.ResumeLayout(false);
			this.splitContainerResource.Panel1.ResumeLayout(false);
			this.splitContainerResource.Panel2.ResumeLayout(false);
			this.splitContainerResource.ResumeLayout(false);
			this.panelTitle.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private Janus.Windows.GridEX.GridEX gridEXStrings;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.TreeView treeViewResx;
		private System.Windows.Forms.SplitContainer splitContainerResource;
		private System.Windows.Forms.CheckedListBox checkedListBoxLanguages;
		private System.Windows.Forms.Panel panelTitle;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideNontranslatedToolStripMenuItem;
	}
}

