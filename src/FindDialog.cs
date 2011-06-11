using System;
using System.Windows.Forms;

namespace ResxTranslator
{
    public partial class FindDialog : Form
    {
        public FindDialog()
        {
            this.InitializeComponent();
        }

        private MainForm MyForm
        {
            get { return ((MainForm)this.Owner); }
        }


        private void buttonFind_Click(object sender, EventArgs e)
        {
            var sp = new SearchParams(
                this.textBoxSearch.Text
                , this.checkBoxLang.Checked
                , this.checkBoxKey.Checked
                , this.checkBoxText.Checked
                , this.radioButtonRegexp.Checked
                , this.checkBoxCS.Checked
                , this.checkBoxWord.Checked);
            sp.Save();
            this.MyForm.CurrentSearch = sp;
            this.Close();
        }

        private void FindDialog_Load(object sender, EventArgs e)
        {
            SearchParams sp = new SearchParams();
            this.textBoxSearch.Text = sp.Text;
            this.checkBoxLang.Checked = sp.SearchLanguage;
            this.checkBoxKey.Checked = sp.SearchKeys;
            this.checkBoxText.Checked = sp.SearchText;
            this.radioButtonRegexp.Checked = sp.UseRegex;
            this.checkBoxCS.Checked = sp.OptCase;
            this.checkBoxWord.Checked = sp.OptWord;

        }
    }
}