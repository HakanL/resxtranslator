using System;
using System.Windows.Forms;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Windows
{
    public partial class FindWindow : Form
    {
        public static void ShowDialog(Form owner)
        {
            using (var window = new FindWindow())
            {
                window.Icon = owner.Icon;
                window.StartPosition = FormStartPosition.CenterParent;
                window.ShowDialog();
            }
        }

        private FindWindow()
        {
            InitializeComponent();
        }

        private MainWindow MyWindow => (MainWindow) Owner;

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
            MyWindow.CurrentSearch = sp;
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