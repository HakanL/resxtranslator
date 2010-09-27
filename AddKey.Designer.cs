namespace ResxTranslator
{
    partial class AddKey
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtNoXlateValue = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelDefaultValue = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.labelKey, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelNoXlateValue, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.txtKey, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.txtNoXlateValue, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnAdd, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelDefaultValue, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtDefaultValue, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(442, 103);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelKey
            // 
            this.labelKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKey.Location = new System.Drawing.Point(3, 0);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(76, 26);
            this.labelKey.TabIndex = 1;
            this.labelKey.Text = "Key";
            this.labelKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNoXlateValue
            // 
            this.labelNoXlateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoXlateValue.Location = new System.Drawing.Point(3, 26);
            this.labelNoXlateValue.Name = "labelNoXlateValue";
            this.labelNoXlateValue.Size = new System.Drawing.Size(76, 26);
            this.labelNoXlateValue.TabIndex = 2;
            this.labelNoXlateValue.Text = "NoXlate Value";
            this.labelNoXlateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(85, 3);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(262, 20);
            this.txtKey.TabIndex = 0;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // txtNoXlateValue
            // 
            this.txtNoXlateValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoXlateValue.Location = new System.Drawing.Point(85, 29);
            this.txtNoXlateValue.Name = "txtNoXlateValue";
            this.txtNoXlateValue.Size = new System.Drawing.Size(262, 20);
            this.txtNoXlateValue.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(364, 3);
            this.btnAdd.Name = "btnAdd";
            this.tableLayoutPanel.SetRowSpan(this.btnAdd, 2);
            this.btnAdd.Size = new System.Drawing.Size(75, 46);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // labelDefaultValue
            // 
            this.labelDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDefaultValue.Location = new System.Drawing.Point(3, 52);
            this.labelDefaultValue.Name = "labelDefaultValue";
            this.labelDefaultValue.Size = new System.Drawing.Size(76, 26);
            this.labelDefaultValue.TabIndex = 2;
            this.labelDefaultValue.Text = "Default Value";
            this.labelDefaultValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultValue.Location = new System.Drawing.Point(85, 55);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(262, 20);
            this.txtDefaultValue.TabIndex = 2;
            // 
            // AddKey
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 103);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "AddKey";
            this.Text = "Add new key";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelNoXlateValue;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtNoXlateValue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelDefaultValue;
        private System.Windows.Forms.TextBox txtDefaultValue;
    }
}