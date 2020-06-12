using ResxTranslator.Properties;
using ResxTranslator.Tools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResxTranslator.Windows
{
    public partial class TranslateAPIDialog : Form
    {
        private readonly List<string> _languages;
        private List<string> _languagesFrom;
        private List<string> _languagesTo;
        private bool init;

        public TranslateAPIConfig TranslateAPIConfig { get; } = new TranslateAPIConfig();

        public TranslateAPIDialog()
        {
            InitializeComponent();
        }

        public TranslateAPIDialog(List<string> languages, string[] googleLanguages) : this()
        {
            _languages = languages;

            _languagesFrom = new List<string> { ResxTranslator.Properties.Resources.ColNameNoLang };
            _languagesFrom.AddRange(_languages);

            _languagesTo = new List<string>(_languages);

            cbSourse.DataSource = _languagesFrom;
            cbTarget.DataSource = _languagesTo;
            cbDefaultLanguage.Items.AddRange(googleLanguages);
            cbDefaultLanguage.SelectedItem = Settings.Binder.Settings.DefaultLanguage;

            cbSourse.SelectedIndex = 0;
            cbTarget.SelectedIndex = -1;

            CheckCanContunie();
        }

        private void cbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                return;
            }

            init = false;
            object selectedItem = cbTarget.SelectedItem;
            _languagesTo = new List<string>(_languages);

            if (_languagesTo.Contains((string)cbSourse.SelectedItem))
            {
                _languagesTo.Remove((string)cbSourse.SelectedItem);
            }

            cbTarget.DataSource = _languagesTo;

            if (_languagesTo.Contains((string)selectedItem))
            {
                cbTarget.SelectedItem = selectedItem;
            }
            else
            {
                cbTarget.SelectedIndex = -1;
            }

            CheckCanContunie();
        }

        private void cbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                return;
            }

            init = false;
            object selectedItem = cbSourse.SelectedItem;
            _languagesFrom = new List<string> { ResxTranslator.Properties.Resources.ColNameNoLang };
            _languagesFrom.AddRange(_languages);

            if (_languagesFrom.Contains((string)cbTarget.SelectedItem))
            {
                _languagesFrom.Remove((string)cbTarget.SelectedItem);
            }

            cbSourse.DataSource = _languagesFrom;

            if (_languagesFrom.Contains((string)selectedItem))
            {
                cbSourse.SelectedItem = selectedItem;
            }
            else
            {
                cbSourse.SelectedIndex = -1;
            }

            CheckCanContunie();
        }

        private void CbDefaultLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckCanContunie();
        }

        private void CheckCanContunie()
        {
            lblDefaultLanguage.Enabled = cbDefaultLanguage.Enabled = (string)cbSourse.SelectedItem == ResxTranslator.Properties.Resources.ColNameNoLang;
            btnOk.Enabled = !string.IsNullOrWhiteSpace((string)cbSourse.SelectedItem)
                         && !string.IsNullOrWhiteSpace((string)cbTarget.SelectedItem)
                         && !string.IsNullOrWhiteSpace((string)cbDefaultLanguage.SelectedItem);
            init = true;

            TranslateAPIConfig.SourceLanguage = (string)cbSourse.SelectedItem;
            TranslateAPIConfig.TargetLanguage = (string)cbTarget.SelectedItem;
            TranslateAPIConfig.DefaultLanguage = Settings.Default.DefaultLanguage = (string)cbDefaultLanguage.SelectedItem;
        }

        private void ChbOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            TranslateAPIConfig.Overwrite = chbOverwrite.Checked;
        }
    }
}