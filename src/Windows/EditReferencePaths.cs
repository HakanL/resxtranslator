using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ResxTranslator.Windows
{
    public partial class EditReferencePaths : Form
    {
        public static string[] ShowDialog(Form owner, string[] referencePaths)
        {
            using (var window = new EditReferencePaths(referencePaths))
            {
                window.Icon = owner.Icon;
                window.StartPosition = FormStartPosition.CenterParent;
                window.ShowDialog();
                return window.ReferencePaths;
            }
        }

        public string[] ReferencePaths
        {
            get { return listBox1.Items.Cast<string>().ToArray(); }
        }

        public EditReferencePaths(string[] paths)
        {
            InitializeComponent();

            if (paths != null)
                listBox1.Items.AddRange(paths);
            
            buttonRemove.Enabled = false;
            buttonAdd.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string dir = textBox1.Text;
            if (Directory.Exists(dir))
            {
                listBox1.Items.Add(dir);
            }
            else
            {
                MessageBox.Show("The specified directory is not valid or does not exist.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Enabled = listBox1.SelectedIndex != -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = !string.IsNullOrEmpty(textBox1.Text);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                listBox1.Items.RemoveAt(index);
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
