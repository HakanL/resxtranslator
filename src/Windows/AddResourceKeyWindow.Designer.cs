namespace ResxTranslator.Windows
{
    partial class AddResourceKeyWindow
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelNoXlateValue = new System.Windows.Forms.Label();
            this.textboxKeyName = new System.Windows.Forms.TextBox();
            this.textboxDefault = new System.Windows.Forms.TextBox();
            this.labelDefaultValue = new System.Windows.Forms.Label();
            this.textboxTranslated = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.labelKey, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelNoXlateValue, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textboxKeyName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.textboxDefault, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelDefaultValue, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textboxTranslated, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.MinimumSize = new System.Drawing.Size(200, 90);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(8, 6, 14, 0);
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(398, 94);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelKey.Location = new System.Drawing.Point(48, 6);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(54, 28);
            this.labelKey.TabIndex = 3;
            this.labelKey.Text = "Key name";
            this.labelKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNoXlateValue
            // 
            this.labelNoXlateValue.AutoSize = true;
            this.labelNoXlateValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelNoXlateValue.Location = new System.Drawing.Point(32, 34);
            this.labelNoXlateValue.Name = "labelNoXlateValue";
            this.labelNoXlateValue.Size = new System.Drawing.Size(70, 28);
            this.labelNoXlateValue.TabIndex = 4;
            this.labelNoXlateValue.Text = "Default value";
            this.labelNoXlateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxKeyName
            // 
            this.textboxKeyName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textboxKeyName.Location = new System.Drawing.Point(108, 11);
            this.textboxKeyName.Name = "textboxKeyName";
            this.textboxKeyName.Size = new System.Drawing.Size(273, 20);
            this.textboxKeyName.TabIndex = 0;
            this.textboxKeyName.Text = "NewKey";
            this.textboxKeyName.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // textboxDefault
            // 
            this.textboxDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textboxDefault.Location = new System.Drawing.Point(108, 39);
            this.textboxDefault.Name = "textboxDefault";
            this.textboxDefault.Size = new System.Drawing.Size(273, 20);
            this.textboxDefault.TabIndex = 1;
            this.textboxDefault.Text = "[PlaceholderText]";
            // 
            // labelDefaultValue
            // 
            this.labelDefaultValue.AutoSize = true;
            this.labelDefaultValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelDefaultValue.Location = new System.Drawing.Point(11, 62);
            this.labelDefaultValue.Name = "labelDefaultValue";
            this.labelDefaultValue.Size = new System.Drawing.Size(91, 28);
            this.labelDefaultValue.TabIndex = 5;
            this.labelDefaultValue.Text = "Translated values";
            this.labelDefaultValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxTranslated
            // 
            this.textboxTranslated.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textboxTranslated.Location = new System.Drawing.Point(108, 67);
            this.textboxTranslated.Name = "textboxTranslated";
            this.textboxTranslated.Size = new System.Drawing.Size(273, 20);
            this.textboxTranslated.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(230, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(311, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 94);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(398, 37);
            this.panel1.TabIndex = 1;
            // 
            // AddResourceKeyWindow
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(398, 131);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 170);
            this.Name = "AddResourceKeyWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add a new key";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelNoXlateValue;
        private System.Windows.Forms.TextBox textboxKeyName;
        private System.Windows.Forms.TextBox textboxDefault;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelDefaultValue;
        private System.Windows.Forms.TextBox textboxTranslated;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}