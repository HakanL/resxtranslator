using System;
using System.Diagnostics;
using System.Windows.Forms;
using ResxTranslator.Properties;

namespace ResxTranslator.Windows
{
    public partial class BingSettingsWindow : Form
    {
        public static void ShowDialog(Form owner)
        {
            using (var window = new BingSettingsWindow())
            {
                window.Icon = owner.Icon;
                window.StartPosition = FormStartPosition.CenterParent;
                window.ShowDialog();
            }
        }

        private BingSettingsWindow()
        {
            InitializeComponent();
        }

        private void BingParams_Load(object sender, EventArgs e)
        {
            textBoxAppId.Text = Settings.Default.BingAppId;
            textBoxLanguage.Text = Settings.Default.NeutralLanguageCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.BingAppId = textBoxAppId.Text;
            Settings.Default.NeutralLanguageCode = textBoxLanguage.Text;
            Settings.Default.Save();
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo(linkLabel1.Text);
            Process.Start(sInfo);
        }
    }
}