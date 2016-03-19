namespace ResxTranslator.Controls
{
    partial class ResourceTreeView
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
            this.treeViewResx = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewResx
            // 
            this.treeViewResx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResx.HideSelection = false;
            this.treeViewResx.Location = new System.Drawing.Point(6, 18);
            this.treeViewResx.Name = "treeViewResx";
            this.treeViewResx.Size = new System.Drawing.Size(187, 382);
            this.treeViewResx.TabIndex = 1;
            this.treeViewResx.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewResx_AfterSelect);
            this.treeViewResx.DoubleClick += new System.EventHandler(this.treeViewResx_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewResx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(199, 406);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resource files";
            // 
            // ResourceTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ResourceTreeView";
            this.Size = new System.Drawing.Size(199, 406);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewResx;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
