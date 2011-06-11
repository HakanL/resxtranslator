using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ResxTranslator.Properties;

namespace ResxTranslator
{
    public partial class BingParams : Form
    {
        public BingParams()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.BingAppId = this.textBoxAppId.Text;
            Settings.Default.NeutralLanguageCode = this.textBoxLanguage.Text;
            Settings.Default.Save();
            if (string.IsNullOrEmpty(Settings.Default.BingAppId))
            {
                ((MainForm)this.Owner).SetTranslationAvailable(false);
            }
            else
            {
                ((MainForm)this.Owner).SetTranslationAvailable(true);
            }
            this.Close();

        }

        private void BingParams_Load(object sender, EventArgs e)
        {
            this.textBoxAppId.Text  = Properties.Settings.Default.BingAppId;
            this.textBoxLanguage.Text = Properties.Settings.Default.NeutralLanguageCode;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(linkLabel1.Text);
            Process.Start(sInfo);
        }
    }
}
