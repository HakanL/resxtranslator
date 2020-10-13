namespace ResxTranslator.Windows
{
    partial class TranslateAPIDialog
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
            this.chbOverwrite = new System.Windows.Forms.CheckBox();
            this.cbSourse = new System.Windows.Forms.ComboBox();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDefaultLanguage = new System.Windows.Forms.Label();
            this.cbDefaultLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chbOverwrite
            // 
            this.chbOverwrite.AutoSize = true;
            this.chbOverwrite.Location = new System.Drawing.Point(5, 95);
            this.chbOverwrite.Name = "chbOverwrite";
            this.chbOverwrite.Size = new System.Drawing.Size(265, 17);
            this.chbOverwrite.TabIndex = 3;
            this.chbOverwrite.Text = "Overwrite already translated text in target language";
            this.chbOverwrite.UseVisualStyleBackColor = true;
            this.chbOverwrite.CheckedChanged += new System.EventHandler(this.ChbOverwrite_CheckedChanged);
            // 
            // cbSourse
            // 
            this.cbSourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourse.FormattingEnabled = true;
            this.cbSourse.Location = new System.Drawing.Point(174, 6);
            this.cbSourse.Name = "cbSourse";
            this.cbSourse.Size = new System.Drawing.Size(129, 21);
            this.cbSourse.TabIndex = 0;
            this.cbSourse.SelectedIndexChanged += new System.EventHandler(this.cbFrom_SelectedIndexChanged);
            // 
            // cbTarget
            // 
            this.cbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Location = new System.Drawing.Point(174, 64);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(128, 21);
            this.cbTarget.TabIndex = 2;
            this.cbTarget.SelectedIndexChanged += new System.EventHandler(this.cbTo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "Translate source language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Translate target language";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(5, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 40);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(183, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDefaultLanguage
            // 
            this.lblDefaultLanguage.AutoSize = true;
            this.lblDefaultLanguage.Enabled = false;
            this.lblDefaultLanguage.Location = new System.Drawing.Point(5, 39);
            this.lblDefaultLanguage.Name = "lblDefaultLanguage";
            this.lblDefaultLanguage.Size = new System.Drawing.Size(157, 13);
            this.lblDefaultLanguage.TabIndex = 100;
            this.lblDefaultLanguage.Text = "Please specify default language";
            // 
            // cbDefaultLanguage
            // 
            this.cbDefaultLanguage.Enabled = false;
            this.cbDefaultLanguage.FormattingEnabled = true;
            this.cbDefaultLanguage.Location = new System.Drawing.Point(174, 35);
            this.cbDefaultLanguage.Name = "cbDefaultLanguage";
            this.cbDefaultLanguage.Size = new System.Drawing.Size(128, 21);
            this.cbDefaultLanguage.TabIndex = 1;
            this.cbDefaultLanguage.SelectedIndexChanged += new System.EventHandler(this.CbDefaultLanguage_SelectedIndexChanged);
            // 
            // TranslateAPIDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 171);
            this.Controls.Add(this.cbDefaultLanguage);
            this.Controls.Add(this.lblDefaultLanguage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTarget);
            this.Controls.Add(this.cbSourse);
            this.Controls.Add(this.chbOverwrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TranslateAPIDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TranslateAPIDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbOverwrite;
        private System.Windows.Forms.ComboBox cbSourse;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDefaultLanguage;
        private System.Windows.Forms.ComboBox cbDefaultLanguage;
    }
}