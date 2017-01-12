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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddResourceKeyWindow));
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
        	resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
        	this.tableLayoutPanel.Controls.Add(this.labelKey, 0, 0);
        	this.tableLayoutPanel.Controls.Add(this.labelNoXlateValue, 0, 1);
        	this.tableLayoutPanel.Controls.Add(this.textboxKeyName, 1, 0);
        	this.tableLayoutPanel.Controls.Add(this.textboxDefault, 1, 1);
        	this.tableLayoutPanel.Controls.Add(this.labelDefaultValue, 0, 2);
        	this.tableLayoutPanel.Controls.Add(this.textboxTranslated, 1, 2);
        	this.tableLayoutPanel.Name = "tableLayoutPanel";
        	// 
        	// labelKey
        	// 
        	resources.ApplyResources(this.labelKey, "labelKey");
        	this.labelKey.Name = "labelKey";
        	// 
        	// labelNoXlateValue
        	// 
        	resources.ApplyResources(this.labelNoXlateValue, "labelNoXlateValue");
        	this.labelNoXlateValue.Name = "labelNoXlateValue";
        	// 
        	// textboxKeyName
        	// 
        	resources.ApplyResources(this.textboxKeyName, "textboxKeyName");
        	this.textboxKeyName.Name = "textboxKeyName";
        	this.textboxKeyName.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
        	// 
        	// textboxDefault
        	// 
        	resources.ApplyResources(this.textboxDefault, "textboxDefault");
        	this.textboxDefault.Name = "textboxDefault";
        	// 
        	// labelDefaultValue
        	// 
        	resources.ApplyResources(this.labelDefaultValue, "labelDefaultValue");
        	this.labelDefaultValue.Name = "labelDefaultValue";
        	// 
        	// textboxTranslated
        	// 
        	resources.ApplyResources(this.textboxTranslated, "textboxTranslated");
        	this.textboxTranslated.Name = "textboxTranslated";
        	// 
        	// btnAdd
        	// 
        	resources.ApplyResources(this.btnAdd, "btnAdd");
        	this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.btnAdd.Name = "btnAdd";
        	this.btnAdd.UseVisualStyleBackColor = true;
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// button1
        	// 
        	resources.ApplyResources(this.button1, "button1");
        	this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.button1.Name = "button1";
        	this.button1.UseVisualStyleBackColor = true;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.button1);
        	this.panel1.Controls.Add(this.btnAdd);
        	resources.ApplyResources(this.panel1, "panel1");
        	this.panel1.Name = "panel1";
        	// 
        	// AddResourceKeyWindow
        	// 
        	this.AcceptButton = this.btnAdd;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.button1;
        	this.Controls.Add(this.tableLayoutPanel);
        	this.Controls.Add(this.panel1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "AddResourceKeyWindow";
        	this.ShowInTaskbar = false;
        	this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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