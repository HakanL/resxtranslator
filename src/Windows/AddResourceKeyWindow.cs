using System;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Windows
{
    public partial class AddResourceKeyWindow : Form
    {
        public string DefaultValue => txtDefaultValue.Text;
        public string Key => txtKey.Text;
        public string NoXlateValue => txtNoXlateValue.Text;

        private readonly ResourceHolder _resourceHolder;

        private AddResourceKeyWindow(ResourceHolder resourceHolder)
        {
            InitializeComponent();

            _resourceHolder = resourceHolder;
        }
        
        public static bool ShowDialog(Form owner, ResourceHolder resource)
        {
            using (var window = new AddResourceKeyWindow(resource))
            {
                window.Icon = owner.Icon;
                window.StartPosition = FormStartPosition.CenterParent;
                var result = window.ShowDialog();

                if (result != DialogResult.OK) return false;

                resource.AddString(window.Key, window.NoXlateValue, window.DefaultValue);
                return true;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            var key = txtKey.Text;
            
            txtDefaultValue.Text = key;
            txtNoXlateValue.Text = key;

            string error = null;
            if (_resourceHolder.FindByKey(txtKey.Text) != null)
                error = "Key already exists";

            errorProvider.SetError(txtKey, error);

            btnAdd.Enabled = string.IsNullOrEmpty(error);
        }
    }
}