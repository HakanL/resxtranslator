namespace ResxTranslator
{
    partial class ZoomWindow
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
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(13, 13);
            this.textBoxString.Multiline = true;
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(500, 316);
            this.textBoxString.TabIndex = 0;
            // 
            // ZoomWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 341);
            this.Controls.Add(this.textBoxString);
            this.Name = "ZoomWindow";
            this.Text = "ZoomWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxString;

    }
}