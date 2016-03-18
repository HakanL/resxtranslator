using System;
using System.Diagnostics;
using System.Windows.Forms;
using ResxTranslator.Properties;

namespace ResxTranslator.Windows
{
    public partial class BingParams : Form
    {
        public BingParams()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.BingAppId = textBoxAppId.Text;
            Settings.Default.NeutralLanguageCode = textBoxLanguage.Text;
            Settings.Default.Save();
            ((MainForm) Owner).SetTranslationAvailable(!string.IsNullOrEmpty(Settings.Default.BingAppId));
            Close();
        }

        private void BingParams_Load(object sender, EventArgs e)
        {
            textBoxAppId.Text = Settings.Default.BingAppId;
            textBoxLanguage.Text = Settings.Default.NeutralLanguageCode;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo(linkLabel1.Text);
            Process.Start(sInfo);
        }
    }
}