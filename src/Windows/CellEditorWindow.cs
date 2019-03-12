using System.Drawing;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ScintillaNET;

namespace ResxTranslator.Windows
{
    public sealed partial class CellEditorWindow : Form
    {
        public CellEditorWindow()
        {
            InitializeComponent();
            
            textBoxString.Styles[Style.Default].Font = "Microsoft Sans Serif";
            textBoxString.Styles[Style.Default].Size = 11;
            textBoxString.StyleClearAll();

            textBoxString.Styles[Style.LineNumber].BackColor = Color.DarkGray;
            textBoxString.Styles[Style.LineNumber].ForeColor = Color.LightGray;
            var nums = textBoxString.Margins[1];
            nums.Type = MarginType.Number;
            nums.Mask = 0;

            textBoxString.SetWhitespaceForeColor(true, Color.Brown);

            Settings.Binder.BindControl(checkBox1, settings => settings.CellEditorWrapContents, this);
            Settings.Binder.Subscribe((sender, args) => textBoxString.WrapMode = args.NewValue ? WrapMode.Word : WrapMode.None,
                settings => settings.CellEditorWrapContents, this);

            Settings.Binder.BindControl(chbShowWhitespace, settings => settings.CellEditorShowWhitespace, this);
            Settings.Binder.Subscribe((sender, args) => textBoxString.ViewWhitespace = args.NewValue ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible,
                settings => settings.CellEditorShowWhitespace, this);

            Settings.Binder.SendUpdates(this);
        }

        private void ZoomWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Binder.RemoveHandlers(this);
        }

        private void CellEditorWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
            {
                e.Handled = true;
                buttonOK.PerformClick();
            }

            if (e.KeyChar == 27)
            {
                e.Handled = true;
                buttonCancel.PerformClick();
            }
        }

        
        private void textBoxString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.F2)
            {
                if (string.IsNullOrEmpty(textBoxString.Text))
                    return;

                string lastChar = textBoxString.Text.Substring(textBoxString.Text.Length - 1, 1);
                if (lastChar.ToUpper().Equals(lastChar))
                {
                    char[] chars = textBoxString.Text.ToLower().ToCharArray();
                    chars[0] = System.Convert.ToChar(chars[0].ToString().ToUpper());
                    textBoxString.Text = new string(chars);
                }

                else
                    textBoxString.Text = textBoxString.Text.ToUpper();
            }
        }
    }
}