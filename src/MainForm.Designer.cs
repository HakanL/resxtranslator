using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStripLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteLanguageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTranslateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoTranslateThisCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelCurrentItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeViewResx = new System.Windows.Forms.TreeView();
            this.splitContainerResource = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxLanguages = new System.Windows.Forms.CheckedListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
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
            this.selectSourceColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripLanguage.SuspendLayout();
            this.contextMenuStripCell.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainerResource.Panel1.SuspendLayout();
            this.splitContainerResource.Panel2.SuspendLayout();
            this.splitContainerResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTitle.SuspendLayout();
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
            // contextMenuStripCell
            // 
            this.contextMenuStripCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoTranslateThisCellToolStripMenuItem});
            this.contextMenuStripCell.Name = "contextMenuStripLanguage";
            this.contextMenuStripCell.Size = new System.Drawing.Size(192, 48);
            // 
            // autoTranslateThisCellToolStripMenuItem
            // 
            this.autoTranslateThisCellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSourceColumnToolStripMenuItem,
            this.noLanguageToolStripMenuItem});
            this.autoTranslateThisCellToolStripMenuItem.Name = "autoTranslateThisCellToolStripMenuItem";
            this.autoTranslateThisCellToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.autoTranslateThisCellToolStripMenuItem.Text = "Auto translate this cell";
            this.autoTranslateThisCellToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.autoTranslateThisCellToolStripMenuItem_DropDownItemClicked);
            this.autoTranslateThisCellToolStripMenuItem.Click += new System.EventHandler(this.autoTranslateThisCellToolStripMenuItem_Click);
            // 
            // noLanguageToolStripMenuItem
            // 
            this.noLanguageToolStripMenuItem.Checked = true;
            this.noLanguageToolStripMenuItem.CheckOnClick = true;
            this.noLanguageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noLanguageToolStripMenuItem.Name = "noLanguageToolStripMenuItem";
            this.noLanguageToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.noLanguageToolStripMenuItem.Tag = "NoLanguageValue";
            this.noLanguageToolStripMenuItem.Text = "Non-translated column";
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
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewResx);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerResource);
            this.splitContainerMain.Size = new System.Drawing.Size(946, 484);
            this.splitContainerMain.SplitterDistance = 246;
            this.splitContainerMain.TabIndex = 3;
            // 
            // treeViewResx
            // 
            this.treeViewResx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResx.HideSelection = false;
            this.treeViewResx.Location = new System.Drawing.Point(0, 0);
            this.treeViewResx.Name = "treeViewResx";
            this.treeViewResx.Size = new System.Drawing.Size(246, 484);
            this.treeViewResx.TabIndex = 0;
            this.treeViewResx.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewResx_AfterSelect);
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
            this.splitContainerResource.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainerResource.Panel2.Controls.Add(this.panelTitle);
            this.splitContainerResource.Size = new System.Drawing.Size(696, 484);
            this.splitContainerResource.SplitterDistance = 51;
            this.splitContainerResource.TabIndex = 2;
            // 
            // checkedListBoxLanguages
            // 
            this.checkedListBoxLanguages.CheckOnClick = true;
            this.checkedListBoxLanguages.ContextMenuStrip = this.contextMenuStripLanguage;
            this.checkedListBoxLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxLanguages.FormattingEnabled = true;
            this.checkedListBoxLanguages.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxLanguages.MultiColumn = true;
            this.checkedListBoxLanguages.Name = "checkedListBoxLanguages";
            this.checkedListBoxLanguages.Size = new System.Drawing.Size(696, 51);
            this.checkedListBoxLanguages.TabIndex = 0;
            this.checkedListBoxLanguages.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxLanguages_ItemCheck);
            this.checkedListBoxLanguages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxLanguages_MouseDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(696, 394);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView1_CellContextMenuStripNeeded);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(696, 35);
            this.panelTitle.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(4, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(689, 28);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "{Title}";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.autoTranslateToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.autoTranslateToolStripMenuItem.Text = "Auto Translate";
            // 
            // translateUsingBingToolStripMenuItem
            // 
            this.translateUsingBingToolStripMenuItem.Name = "translateUsingBingToolStripMenuItem";
            this.translateUsingBingToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.translateUsingBingToolStripMenuItem.Text = "Translate using Bing";
            this.translateUsingBingToolStripMenuItem.Click += new System.EventHandler(this.translateUsingBingToolStripMenuItem_Click);
            // 
            // selectSourceColumnToolStripMenuItem
            // 
            this.selectSourceColumnToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.selectSourceColumnToolStripMenuItem.Enabled = false;
            this.selectSourceColumnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSourceColumnToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.selectSourceColumnToolStripMenuItem.Name = "selectSourceColumnToolStripMenuItem";
            this.selectSourceColumnToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.selectSourceColumnToolStripMenuItem.Text = "Select Source Column";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 533);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "ResxTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStripLanguage.ResumeLayout(false);
            this.contextMenuStripCell.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerResource.Panel1.ResumeLayout(false);
            this.splitContainerResource.Panel2.ResumeLayout(false);
            this.splitContainerResource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripLanguage;
		private System.Windows.Forms.ToolStripMenuItem deleteLanguageFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoTranslateToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripCell;
        private System.Windows.Forms.ToolStripMenuItem autoTranslateThisCellToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private Panel panelMain;
        private SplitContainer splitContainerMain;
        private TreeView treeViewResx;
        private SplitContainer splitContainerResource;
        private CheckedListBox checkedListBoxLanguages;
        private DataGridView dataGridView1;
        private Panel panelTitle;
        private Label labelTitle;
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
        private ToolStripMenuItem noLanguageToolStripMenuItem;
        private ToolStripMenuItem selectSourceColumnToolStripMenuItem;
	}
}

