namespace ResxTranslator.Windows
{
    partial class EditReferencePaths
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditReferencePaths));
        	this.buttonAdd = new System.Windows.Forms.Button();
        	this.buttonRemove = new System.Windows.Forms.Button();
        	this.listBox1 = new System.Windows.Forms.ListBox();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.buttonAccept = new System.Windows.Forms.Button();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        	this.panel2.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// buttonAdd
        	// 
        	resources.ApplyResources(this.buttonAdd, "buttonAdd");
        	this.buttonAdd.Name = "buttonAdd";
        	this.buttonAdd.UseVisualStyleBackColor = true;
        	this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
        	// 
        	// buttonRemove
        	// 
        	resources.ApplyResources(this.buttonRemove, "buttonRemove");
        	this.buttonRemove.Name = "buttonRemove";
        	this.buttonRemove.UseVisualStyleBackColor = true;
        	this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
        	// 
        	// listBox1
        	// 
        	resources.ApplyResources(this.listBox1, "listBox1");
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.Name = "listBox1";
        	this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
        	// 
        	// panel2
        	// 
        	resources.ApplyResources(this.panel2, "panel2");
        	this.panel2.Controls.Add(this.buttonRemove);
        	this.panel2.Controls.Add(this.buttonAdd);
        	this.panel2.Name = "panel2";
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.listBox1);
        	this.groupBox1.Controls.Add(this.panel2);
        	resources.ApplyResources(this.groupBox1, "groupBox1");
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.TabStop = false;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.buttonAccept);
        	this.panel1.Controls.Add(this.buttonCancel);
        	resources.ApplyResources(this.panel1, "panel1");
        	this.panel1.Name = "panel1";
        	// 
        	// buttonAccept
        	// 
        	resources.ApplyResources(this.buttonAccept, "buttonAccept");
        	this.buttonAccept.Name = "buttonAccept";
        	this.buttonAccept.UseVisualStyleBackColor = true;
        	this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
        	// 
        	// buttonCancel
        	// 
        	resources.ApplyResources(this.buttonCancel, "buttonCancel");
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// folderBrowserDialog1
        	// 
        	resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
        	// 
        	// EditReferencePaths
        	// 
        	this.AcceptButton = this.buttonAccept;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.panel1);
        	this.Name = "EditReferencePaths";
        	this.panel2.ResumeLayout(false);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}