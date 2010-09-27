using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Windows.Forms;


namespace ResxTranslator
{
    public partial class MainForm : Form
    {
        private string rootPath;
        private Dictionary<string, ResourceHolder> resources;
        private ResourceHolder currentResource;

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            rootPath = @"C:\Projects\Kick\KickP4\Client";
#endif

            resources = new Dictionary<string, ResourceHolder>();
            labelTitle.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CanClose())
                return;

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = rootPath;
            folderDialog.Description = "Browse to the root of the project, typically where the sln file is";
            if (folderDialog.ShowDialog(this) != DialogResult.OK)
                return;

            rootPath = folderDialog.SelectedPath;

            FindResx(rootPath);

            treeViewResx.Nodes.Clear();
            foreach (ResourceHolder resource in resources.Values)
            {
                BuildTreeView(resource);
            }

            treeViewResx.ExpandAll();
        }

        private void BuildTreeView(ResourceHolder resource)
        {
            TreeNode parentNode = null;
            string[] topFolders = resource.DisplayFolder.Split('\\');
            foreach (string subFolder in topFolders)
            {
                TreeNodeCollection searchNodes =
                    parentNode == null ? treeViewResx.Nodes : parentNode.Nodes;
                bool found = false;
                foreach (TreeNode treeNode in searchNodes)
                {
                    if (treeNode.Tag is PathHolder &&
                        (treeNode.Tag as PathHolder).Id.Equals(
                        subFolder, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        parentNode = treeNode;
                        break;
                    }
                }
                if (!found)
                {
                    TreeNode pathTreeNode = new TreeNode("[" + subFolder + "]");
                    PathHolder pathHolder = new PathHolder();
                    pathHolder.Id = subFolder;
                    pathTreeNode.Tag = pathHolder;
                    searchNodes.Add(pathTreeNode);

                    parentNode = pathTreeNode;
                }
            }

            TreeNode leafNode = new TreeNode(resource.Id);
            leafNode.Tag = resource;
            parentNode.Nodes.Add(leafNode);
        }

        private void FindResx(string folder)
        {
            string displayFolder = "";
            if (folder.StartsWith(rootPath, StringComparison.InvariantCultureIgnoreCase))
                displayFolder = folder.Substring(rootPath.Length);
            if (displayFolder.StartsWith("\\"))
                displayFolder = displayFolder.Remove(0, 1);

            string[] files = Directory.GetFiles(folder, "*.resx");

            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                string filenameNoExt = Path.GetFileNameWithoutExtension(file);
                string[] fileParts = filenameNoExt.Split('.');
                if (fileParts.Length == 0)
                    continue;

                string language = "";
                if (fileParts[fileParts.Length - 1].Length == 5 && fileParts[fileParts.Length - 1][2] == '-')
                    language = fileParts[fileParts.Length - 1];
                else if (fileParts[fileParts.Length - 1].Length == 2)
                    language = fileParts[fileParts.Length - 1];
                if (!string.IsNullOrEmpty(language))
                    filenameNoExt = Path.GetFileNameWithoutExtension(filenameNoExt);

                ResourceHolder resourceHolder;
                string key = (displayFolder + "\\" + filenameNoExt).ToLower();
                if (!resources.TryGetValue(key, out resourceHolder))
                {
                    resourceHolder = new ResourceHolder();
                    resourceHolder.DisplayFolder = displayFolder;
                    if (string.IsNullOrEmpty(language))
                        resourceHolder.Filename = file;
                    resourceHolder.Id = filenameNoExt;

                    resources.Add(key, resourceHolder);
                }

                if (!string.IsNullOrEmpty(language))
                {
                    if (!resourceHolder.Languages.ContainsKey(language.ToLower()))
                    {
                        LanguageHolder languageHolder = new LanguageHolder();
                        languageHolder.Filename = file;
                        languageHolder.Id = language;
                        resourceHolder.Languages.Add(language.ToLower(), languageHolder);
                    }
                }
                else
                    resourceHolder.Filename = file;

            }

            string[] subfolders = Directory.GetDirectories(folder);
            foreach (string subfolder in subfolders)
            {
                FindResx(subfolder);
            }
        }

        private void treeViewResx_DoubleClick(object sender, EventArgs e)
        {
            SelectResource();
        }

        private void OpenResource(ResourceHolder resource)
        {
            labelTitle.Text = resource.Id;
            checkedListBoxLanguages.Items.Clear();

            foreach (LanguageHolder languageHolder in resource.Languages.Values)
            {
                checkedListBoxLanguages.Items.Add(languageHolder, true);
            }

            gridEXStrings.DataSource = resource.StringsTable;
            gridEXStrings.RetrieveStructure();
            gridEXStrings.RootTable.Columns["Translated"].Visible = false;
            gridEXStrings.RootTable.Columns["Error"].Visible = false;
            Janus.Windows.GridEX.GridEXFormatCondition formatCondition =
                new Janus.Windows.GridEX.GridEXFormatCondition(
                    gridEXStrings.RootTable.Columns["Error"], Janus.Windows.GridEX.ConditionOperator.Equal, true);
            gridEXStrings.RootTable.FormatConditions.Add(formatCondition);
            formatCondition.FormatStyle.ForeColor = Color.Red;

            ApplyFilterCondition();

            gridEXStrings.RootTable.Columns["Key"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
            gridEXStrings.RootTable.SortKeys.Add(gridEXStrings.RootTable.Columns["Key"]);
        }

        private void checkedListBoxLanguages_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            LanguageHolder languageHolder = checkedListBoxLanguages.Items[e.Index] as LanguageHolder;
            if (languageHolder == null)
                return;

            if (gridEXStrings.RootTable == null)
                // Not populated yet
                return;

            if (gridEXStrings.RootTable.Columns.Contains(languageHolder.Id))
                gridEXStrings.RootTable.Columns[languageHolder.Id].Visible = e.NewValue == CheckState.Checked;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save

            foreach (ResourceHolder resource in resources.Values)
            {
                try
                {
                    if (!resource.IsDirty)
                        continue;

                    resource.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception while saving: " + resource.Id);
                }
            }
        }

        private void ApplyFilterCondition()
        {
            if (gridEXStrings.RootTable == null)
                return;

            if (hideNontranslatedToolStripMenuItem.Checked)
            {
                Janus.Windows.GridEX.GridEXFilterCondition filter =
                    new Janus.Windows.GridEX.GridEXFilterCondition(
                        gridEXStrings.RootTable.Columns["Translated"],
                        Janus.Windows.GridEX.ConditionOperator.Equal, true);
                gridEXStrings.RootTable.FilterCondition = filter;
            }
            else
                gridEXStrings.RootTable.RemoveFilter();
        }

        private void hideNontranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideNontranslatedToolStripMenuItem.Checked = !hideNontranslatedToolStripMenuItem.Checked;

            ApplyFilterCondition();
        }


        /// <summary>
        /// Check and prompt for save
        /// </summary>
        /// <returns>True if we can safely close</returns>
        private bool CanClose()
        {
            bool isDirty = false;
            foreach (ResourceHolder resource in resources.Values)
            {
                if (resource.IsDirty)
                {
                    isDirty = true;
                    break;
                }
            }

            if (isDirty)
            {
                if (MessageBox.Show("Are you sure you want to lose all your changes without saving?", "Lose changes?",
                    MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    return true;

                return false;
            }

            return true;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose())
                e.Cancel = true;
        }

        private void gridEXStrings_DoubleClick(object sender, EventArgs e)
        {
            if (gridEXStrings.RowCount == 0)
                return;

            ZoomWindow frm = new ZoomWindow();
            object value = gridEXStrings.GetValue(gridEXStrings.Col);
            frm.textBoxString.Text = (string)value;
            frm.ShowDialog();
            gridEXStrings.SetValue(gridEXStrings.Col, frm.textBoxString.Text);
        }

        private void addNewKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentResource == null)
                return;

            using (AddKey form = new AddKey(currentResource))
            {
                DialogResult result = form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // Add key
                    currentResource.AddString(form.Key, form.NoXlateValue, form.DefaultValue);
                }
            }
        }

        private void deleteKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentResource == null || gridEXStrings.RowCount == 0)
                return;

            if (MessageBox.Show("Are you sure you want to delete the current key?", "Delete", MessageBoxButtons.YesNoCancel) ==
                DialogResult.Yes)
            {
                DataRowView dataRow = gridEXStrings.GetRow().DataRow as DataRowView;

                dataRow.Row.Delete();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CanClose())
                return;

            treeViewResx.Nodes.Clear();
            checkedListBoxLanguages.Items.Clear();
            gridEXStrings.ClearStructure();
            labelTitle.Visible = false;

            currentResource = null;
        }

        private void SelectResource()
        {
            TreeNode selectedTreeNode = treeViewResx.SelectedNode;
            if (selectedTreeNode == null)
                return;

            if (selectedTreeNode.Tag is PathHolder)
                return;

            if (!(selectedTreeNode.Tag is ResourceHolder))
                // Shouldn't happen
                return;

            ResourceHolder resource = selectedTreeNode.Tag as ResourceHolder;

            OpenResource(resource);
            currentResource = resource;
            labelTitle.Visible = true;
        }

        private void treeViewResx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectResource();
        }
    }


    public class LanguageHolder
    {
        public string Id { get; set; }
        public string Filename { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }


    public class PathHolder
    {
        public string Id { get; set; }
    }
}
