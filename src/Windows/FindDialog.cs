using System;
using System.Windows.Forms;

namespace ResxTranslator.Windows
{
    public partial class FindDialog : Form
    {
        public FindDialog()
        {
            InitializeComponent();
        }

        private MainForm MyForm => (MainForm) Owner;
        
        private void buttonFind_Click(object sender, EventArgs e)
        {
            var sp = new SearchParams(
                textBoxSearch.Text
                , checkBoxLang.Checked
                , checkBoxKey.Checked
                , checkBoxText.Checked
                , checkBoxFile.Checked
                , radioButtonRegexp.Checked
                , checkBoxCS.Checked
                , checkBoxWord.Checked);
            sp.Save();
            MyForm.CurrentSearch = sp;
            Close();
        }

        private void FindDialog_Load(object sender, EventArgs e)
        {
            var sp = new SearchParams();
            textBoxSearch.Text = sp.Text;
            checkBoxLang.Checked = sp.SearchLanguage;
            checkBoxKey.Checked = sp.SearchKeys;
            checkBoxText.Checked = sp.SearchText;
            checkBoxFile.Checked = sp.SearchFileName;
            radioButtonRegexp.Checked = sp.UseRegex;
            checkBoxCS.Checked = sp.OptCase;
            checkBoxWord.Checked = sp.OptWord;
        }
    }
}