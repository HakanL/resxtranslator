namespace ResxTranslator.Controls
{
    partial class LanguageSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageSettings));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectNone = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectInvert = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCode,
            this.columnHeaderName});
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeaderCode
            // 
            resources.ApplyResources(this.columnHeaderCode, "columnHeaderCode");
            // 
            // columnHeaderName
            // 
            resources.ApplyResources(this.columnHeaderName, "columnHeaderName");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSelectAll,
            this.toolStripButtonSelectNone,
            this.toolStripButtonSelectInvert});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonSelectAll
            // 
            resources.ApplyResources(this.toolStripButtonSelectAll, "toolStripButtonSelectAll");
            this.toolStripButtonSelectAll.Name = "toolStripButtonSelectAll";
            this.toolStripButtonSelectAll.Click += new System.EventHandler(this.toolStripButtonSelectAll_Click);
            // 
            // toolStripButtonSelectNone
            // 
            resources.ApplyResources(this.toolStripButtonSelectNone, "toolStripButtonSelectNone");
            this.toolStripButtonSelectNone.Name = "toolStripButtonSelectNone";
            this.toolStripButtonSelectNone.Click += new System.EventHandler(this.toolStripButtonSelectNone_Click);
            // 
            // toolStripButtonSelectInvert
            // 
            this.toolStripButtonSelectInvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelectInvert.Image = global::ResxTranslator.Properties.Resources.clipboard;
            resources.ApplyResources(this.toolStripButtonSelectInvert, "toolStripButtonSelectInvert");
            this.toolStripButtonSelectInvert.Name = "toolStripButtonSelectInvert";
            this.toolStripButtonSelectInvert.Click += new System.EventHandler(this.toolStripButtonSelectInvert_Click);
            // 
            // LanguageSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.Name = "LanguageSettings";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderCode;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectNone;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectInvert;
    }
}
