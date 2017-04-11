using System;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;
using ResxTranslator.Resources;

namespace ResxTranslator.Windows
{
    public partial class AddResourceKeyWindow : Form
    {
        public string DefaultTranslatedText => textboxTranslated.Text;
        public string KeyName => textboxKeyName.Text;
        public string DefaultText => textboxDefault.Text;

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

                resource.AddString(window.KeyName, window.DefaultText, window.DefaultTranslatedText);
                return true;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            var keyName = textboxKeyName.Text;
            string errorString = null;

            if (_resourceHolder.FindByKey(keyName) != null)
                errorString = Localization.Error_KeyAlreadyExists;
            else if (string.IsNullOrWhiteSpace(keyName))
                errorString = Localization.Error_KeyCantBeEmpty;
            else if (keyName.Any(x => !char.IsLetterOrDigit(x) && x != '_'))
                errorString = Localization.Error_InvalidKeyName;

            errorProvider.SetError(textboxKeyName, errorString);

            btnAdd.Enabled = errorString == null;
        }
    }
}