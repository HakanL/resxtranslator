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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxString = new ScintillaNET.Scintilla();
            this.chbShowWhitespace = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbShowWhitespace);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 208);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(428, 50);
            this.panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Word wrap";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Location = new System.Drawing.Point(350, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 44);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOK.Location = new System.Drawing.Point(275, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 44);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Accept";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textBoxString
            // 
            this.textBoxString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxString.Location = new System.Drawing.Point(3, 3);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.ScrollWidth = 200;
            this.textBoxString.Size = new System.Drawing.Size(428, 205);
            this.textBoxString.TabIndex = 0;
            this.textBoxString.WhitespaceSize = 2;
            // 
            // chbShowWhitespace
            // 
            this.chbShowWhitespace.AutoSize = true;
            this.chbShowWhitespace.Location = new System.Drawing.Point(6, 29);
            this.chbShowWhitespace.Name = "chbShowWhitespace";
            this.chbShowWhitespace.Size = new System.Drawing.Size(113, 17);
            this.chbShowWhitespace.TabIndex = 3;
            this.chbShowWhitespace.Text = "Show Whitespace";
            this.chbShowWhitespace.UseVisualStyleBackColor = true;
            // 
            // CellEditorWindow
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "CellEditorWindow";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cell editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZoomWindow_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CellEditorWindow_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellEditorWindow));
            resources.ApplyResources(this.textBoxString, "textBoxString");
            resources.ApplyResources(this.panel1, "panel1");
            resources.ApplyResources(this.checkBox1, "checkBox1");
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            resources.ApplyResources(this.buttonOK, "buttonOK");
            resources.ApplyResources(this, "$this");
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox1;
        internal ScintillaNET.Scintilla textBoxString;
        private System.Windows.Forms.CheckBox chbShowWhitespace;
    }
}