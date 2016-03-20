using System;
using System.Windows.Forms;

using ResxTranslator.Properties;
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

        public static bool ShowDialog(IWin32Window owner, ResourceHolder resource)
        {
            using (var form = new AddResourceKeyWindow(resource))
            {
                var result = form.ShowDialog();

                if (result != DialogResult.OK) return false;

                resource.AddString(form.Key, form.NoXlateValue, form.DefaultValue);
                return true;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            var key = txtKey.Text;

            var result = string.Format(Settings.Default.NonTranslatedString,
                key, key.ToUpper(), key.ToLower());

            txtDefaultValue.Text = result;
            txtNoXlateValue.Text = result;

            string error = null;
            if (_resourceHolder.FindByKey(txtKey.Text) != null)
                error = "Key already exists";

            errorProvider.SetError(txtKey, error);

            btnAdd.Enabled = string.IsNullOrEmpty(error);
        }
    }
}