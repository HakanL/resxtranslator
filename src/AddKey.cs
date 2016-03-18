using System;
using System.Windows.Forms;

namespace ResxTranslator
{
    public partial class AddKey : Form
    {
        private readonly ResourceHolder _resourceHolder;


        public AddKey(ResourceHolder resourceHolder)
        {
            InitializeComponent();

            _resourceHolder = resourceHolder;
        }
        
        public string Key => txtKey.Text;
        
        public string NoXlateValue => txtNoXlateValue.Text;
        
        public string DefaultValue => txtDefaultValue.Text;

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            txtDefaultValue.Text =
                txtNoXlateValue.Text = Common.GetDefaultValue(txtKey.Text);

            string error = null;
            if (_resourceHolder.FindByKey(txtKey.Text) != null)
                error = "Key exists";

            errorProvider.SetError(txtKey, error);

            btnAdd.Enabled = string.IsNullOrEmpty(error);
        }
    }
}