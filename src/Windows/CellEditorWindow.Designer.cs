namespace ResxTranslator.Windows
{
    sealed partial class CellEditorWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chbShowWhitespace = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxString = new ScintillaNET.Scintilla();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.chbShowWhitespace);
            this.panel1.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chbShowWhitespace
            // 
            resources.ApplyResources(this.chbShowWhitespace, "chbShowWhitespace");
            this.chbShowWhitespace.Name = "chbShowWhitespace";
            this.chbShowWhitespace.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxString
            // 
            this.textBoxString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textBoxString, "textBoxString");
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.ScrollWidth = 200;
            this.textBoxString.WhitespaceSize = 2;
            this.textBoxString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxString_KeyDown);
            // 
            // CellEditorWindow
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "CellEditorWindow";
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZoomWindow_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CellEditorWindow_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox1;
        internal ScintillaNET.Scintilla textBoxString;
        private System.Windows.Forms.CheckBox chbShowWhitespace;
        private System.Windows.Forms.Panel panel2;
    }
}