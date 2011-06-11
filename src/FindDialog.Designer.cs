namespace ResxTranslator
{
    partial class FindDialog
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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonRegexp = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxText = new System.Windows.Forms.CheckBox();
            this.checkBoxKey = new System.Windows.Forms.CheckBox();
            this.checkBoxLang = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxWord = new System.Windows.Forms.CheckBox();
            this.checkBoxCS = new System.Windows.Forms.CheckBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 17);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(384, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "Text";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButtonRegexp
            // 
            this.radioButtonRegexp.AutoSize = true;
            this.radioButtonRegexp.Location = new System.Drawing.Point(79, 19);
            this.radioButtonRegexp.Name = "radioButtonRegexp";
            this.radioButtonRegexp.Size = new System.Drawing.Size(63, 17);
            this.radioButtonRegexp.TabIndex = 2;
            this.radioButtonRegexp.Text = "RegExp";
            this.radioButtonRegexp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonText);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButtonRegexp);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Location = new System.Drawing.Point(16, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Use:";
            // 
            // radioButtonText
            // 
            this.radioButtonText.AutoSize = true;
            this.radioButtonText.Checked = true;
            this.radioButtonText.Location = new System.Drawing.Point(7, 19);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(46, 17);
            this.radioButtonText.TabIndex = 2;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "Text";
            this.radioButtonText.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(79, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(63, 17);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Text = "RegExp";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSearch);
            this.groupBox2.Location = new System.Drawing.Point(16, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 49);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Find:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxText);
            this.groupBox3.Controls.Add(this.checkBoxKey);
            this.groupBox3.Controls.Add(this.checkBoxLang);
            this.groupBox3.Location = new System.Drawing.Point(16, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 43);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "What:";
            // 
            // checkBoxText
            // 
            this.checkBoxText.AutoSize = true;
            this.checkBoxText.Checked = true;
            this.checkBoxText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxText.Location = new System.Drawing.Point(7, 19);
            this.checkBoxText.Name = "checkBoxText";
            this.checkBoxText.Size = new System.Drawing.Size(47, 17);
            this.checkBoxText.TabIndex = 0;
            this.checkBoxText.Text = "Text";
            this.checkBoxText.UseVisualStyleBackColor = true;
            // 
            // checkBoxKey
            // 
            this.checkBoxKey.AutoSize = true;
            this.checkBoxKey.Location = new System.Drawing.Point(87, 19);
            this.checkBoxKey.Name = "checkBoxKey";
            this.checkBoxKey.Size = new System.Drawing.Size(44, 17);
            this.checkBoxKey.TabIndex = 0;
            this.checkBoxKey.Text = "Key";
            this.checkBoxKey.UseVisualStyleBackColor = true;
            // 
            // checkBoxLang
            // 
            this.checkBoxLang.AutoSize = true;
            this.checkBoxLang.Location = new System.Drawing.Point(156, 19);
            this.checkBoxLang.Name = "checkBoxLang";
            this.checkBoxLang.Size = new System.Drawing.Size(74, 17);
            this.checkBoxLang.TabIndex = 0;
            this.checkBoxLang.Text = "Language";
            this.checkBoxLang.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxWord);
            this.groupBox4.Controls.Add(this.checkBoxCS);
            this.groupBox4.Location = new System.Drawing.Point(16, 173);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 50);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options:";
            // 
            // checkBoxWord
            // 
            this.checkBoxWord.AutoSize = true;
            this.checkBoxWord.Location = new System.Drawing.Point(106, 19);
            this.checkBoxWord.Name = "checkBoxWord";
            this.checkBoxWord.Size = new System.Drawing.Size(83, 17);
            this.checkBoxWord.TabIndex = 0;
            this.checkBoxWord.Text = "Whole word";
            this.checkBoxWord.UseVisualStyleBackColor = true;
            // 
            // checkBoxCS
            // 
            this.checkBoxCS.AutoSize = true;
            this.checkBoxCS.Location = new System.Drawing.Point(6, 20);
            this.checkBoxCS.Name = "checkBoxCS";
            this.checkBoxCS.Size = new System.Drawing.Size(94, 17);
            this.checkBoxCS.TabIndex = 0;
            this.checkBoxCS.Text = "Case sensitive";
            this.checkBoxCS.UseVisualStyleBackColor = true;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(331, 229);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 6;
            this.buttonFind.Text = "Find all";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // FindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 263);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FindDialog";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.FindDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonRegexp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxText;
        private System.Windows.Forms.CheckBox checkBoxKey;
        private System.Windows.Forms.CheckBox checkBoxLang;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxWord;
        private System.Windows.Forms.CheckBox checkBoxCS;
        private System.Windows.Forms.Button buttonFind;
    }
}