namespace ResxTranslator.Windows
{
    partial class CellEditorWindow
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellEditorWindow));
        	this.textBoxString = new System.Windows.Forms.TextBox();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.buttonOK = new System.Windows.Forms.Button();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// textBoxString
        	// 
        	this.textBoxString.AcceptsReturn = true;
        	this.textBoxString.AllowDrop = true;
        	this.textBoxString.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	resources.ApplyResources(this.textBoxString, "textBoxString");
        	this.textBoxString.HideSelection = false;
        	this.textBoxString.Name = "textBoxString";
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.checkBox1);
        	this.panel1.Controls.Add(this.buttonCancel);
        	this.panel1.Controls.Add(this.buttonOK);
        	resources.ApplyResources(this.panel1, "panel1");
        	this.panel1.Name = "panel1";
        	// 
        	// checkBox1
        	// 
        	resources.ApplyResources(this.checkBox1, "checkBox1");
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	// 
        	// buttonCancel
        	// 
        	resources.ApplyResources(this.buttonCancel, "buttonCancel");
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// buttonOK
        	// 
        	resources.ApplyResources(this.buttonOK, "buttonOK");
        	this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOK.Name = "buttonOK";
        	this.buttonOK.UseVisualStyleBackColor = true;
        	// 
        	// CellEditorWindow
        	// 
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.textBoxString);
        	this.Controls.Add(this.panel1);
        	this.Name = "CellEditorWindow";
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZoomWindow_FormClosed);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}