using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace ResxTranslator.Windows
{
    public partial class EditReferencePaths : Form
    {
        private string[] _result;

        private EditReferencePaths(IEnumerable paths)
        {
            InitializeComponent();

            if (paths != null)
                listBox1.Items.AddRange(paths.Cast<object>().ToArray());

            buttonRemove.Enabled = false;
        }

        /// <summary>
        ///     Returns null if user did not accept the changes
        /// </summary>
        public static string[] ShowDialog(Form owner, string[] referencePaths)
        {
            using (var window = new EditReferencePaths(referencePaths))
            {
                window.Icon = owner.Icon;
                window.StartPosition = FormStartPosition.CenterParent;
                window.ShowDialog(owner);
                return window._result;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Enabled = listBox1.SelectedIndex != -1;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            if (index != -1)
            {
                listBox1.Items.RemoveAt(index);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            _result = listBox1.Items.Cast<string>().ToArray();
            DialogResult = DialogResult.OK;
        }
    }
}