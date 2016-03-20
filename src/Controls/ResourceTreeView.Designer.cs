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
            this.SuspendLayout();
            // 
            // treeViewResx
            // 
            this.treeViewResx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewResx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResx.FullRowSelect = true;
            this.treeViewResx.HideSelection = false;
            this.treeViewResx.Location = new System.Drawing.Point(0, 0);
            this.treeViewResx.Name = "treeViewResx";
            this.treeViewResx.ShowNodeToolTips = true;
            this.treeViewResx.Size = new System.Drawing.Size(199, 406);
            this.treeViewResx.TabIndex = 1;
            this.treeViewResx.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewResx_AfterSelect);
            this.treeViewResx.DoubleClick += new System.EventHandler(this.treeViewResx_DoubleClick);
            // 
            // ResourceTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewResx);
            this.Name = "ResourceTreeView";
            this.Size = new System.Drawing.Size(199, 406);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewResx;
    }
}
