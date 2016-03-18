using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Windows
{
    public partial class MainWindow : Form
    {
        protected ResourceHolder CurrentResource;
        public ResourceLoader ResourceLoader { get; }

        private SearchParams _currentSearch;

        public SearchParams CurrentSearch
        {
            get { return _currentSearch; }
            set
            {
                _currentSearch = value;
                ExecuteFind();
            }
        }

        protected int LastClickedLanguageIndex;

        public MainWindow()
        {
            InitializeComponent();

            labelTitle.Visible = false;
            ResourceLoader = new ResourceLoader();
            ResourceLoader.ResourceLoadProgress += (sender, args) => this.InvokeIfRequired(x =>
            {
                toolStripStatusLabelCurrentItem.Text = args.CurrentlyProcessedItem ?? string.Empty;
                toolStripStatusLabel1.Text = args.CurrentProcess ?? string.Empty;
                if (args.Progress < args.ProgressTop)
                {
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Maximum = args.ProgressTop;
                    toolStripProgressBar1.Value = args.Progress;
                }
                else
                {
                    toolStripProgressBar1.Visible = false;
                }
            });
        }

        private void ExecuteFind()
        {
            ExecuteFindInNodes(treeViewResx.Nodes);
        }

        private void ExecuteFindInNodes(TreeNodeCollection searchNodes)
        {
            var matchColor = Color.GreenYellow;
            foreach (TreeNode treeNode in searchNodes)
            {
                treeNode.BackColor = Color.White;
                ExecuteFindInNodes(treeNode.Nodes);
                var resourceHolder = treeNode.Tag as ResourceHolder;
                if (resourceHolder != null)
                {
                    var resource = resourceHolder;
                    if (CurrentSearch.Match(SearchParams.TargetType.Lang, resource.NoLanguageLanguage))
                    {
                        treeNode.BackColor = matchColor;
                    }
                    var file = resource.Filename.Split('\\');

                    if (CurrentSearch.Match(SearchParams.TargetType.File, file[file.Length - 1]))
                    {
                        treeNode.BackColor = matchColor;
                    }
                    foreach (var lng in resource.Languages.Values)
                    {
                        if (CurrentSearch.Match(SearchParams.TargetType.Lang, lng.Id))
                        {
                            treeNode.BackColor = matchColor;
                        }
                    }
                    foreach (DataRow row in resource.StringsTable.Rows)
                    {
                        if (CurrentSearch.Match(SearchParams.TargetType.Key, row["Key"].ToString()))
                        {
                            treeNode.BackColor = matchColor;
                        }
                        if (CurrentSearch.Match(SearchParams.TargetType.Text, row["NoLanguageValue"].ToString()))
                        {
                            treeNode.BackColor = matchColor;
                        }
                        foreach (var lng in resource.Languages.Values)
                        {
                            if (CurrentSearch.Match(SearchParams.TargetType.Text, row[lng.Id].ToString()))
                            {
                                treeNode.BackColor = matchColor;
                            }
                        }
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetTranslationAvailable(!string.IsNullOrEmpty(Settings.Default.BingAppId));

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 2 && args[1].Trim() == "-f" && !string.IsNullOrEmpty(args[2]))
            {
                var path = args[2].Trim();
                if (path.Contains("\""))
                {
                    path = path.Replace("\"", "").Trim();
                }
                try
                {
                    var fldr = new DirectoryInfo(path);
                    if (!fldr.Exists)
                        throw new ArgumentException("Folder '" + path + "' does not exist.");
                    path = (fldr.FullName + "\\").Replace("\\\\", "\\");
                    LoadResourcesFromFolder(path);
                }
                catch (Exception inner)
                {
                    throw new ArgumentException(
                        "Invalid command line \r\n" + Environment.CommandLine + "\r\nPath: " + path, inner);
                }
            }/*
            else
            {
                if (string.IsNullOrEmpty(Settings.Default.BingAppId))
                {
                    MessageBox.Show("Note! to use auto translate you need to get a Bing AppID.", "ResxTranslator");
                }
            }*/
        }

        private void LoadResourcesFromFolder(string path)
        {
            ResourceLoader.OpenProject(path);

            treeViewResx.Nodes.Clear();
            foreach (var resource in ResourceLoader.Resources.Values)
            {
                BuildTreeView(resource);
            }

            treeViewResx.ExpandAll();
            addLanguageToolStripMenuItem.DropDownItems.Clear();
            foreach (var s in ResourceLoader.LanguagesInUse.Keys)
            {
                addLanguageToolStripMenuItem.DropDownItems.Add(s);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ResourceLoader.CanClose())
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ResourceLoader.CanClose())
            {
                return;
            }

            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = Settings.Default.Mrud,
                Description = "Browse to the root of the project, typically where the sln file is"
            };

            if (folderDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadResourcesFromFolder(folderDialog.SelectedPath);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save
            ResourceLoader.SaveAll();
        }

        private void revertCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentResource.Revert();
            resourceGrid1.CurrentResource = CurrentResource;
        }

        private void saveCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResourceLoader.SaveResourceHolder(CurrentResource);
        }

        private void setBingAppIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new BingSettingsWindow();
            frm.ShowDialog(this);
        }

        private void hideNontranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideNontranslatedToolStripMenuItem.Checked = !hideNontranslatedToolStripMenuItem.Checked;

            resourceGrid1.ApplyFilterCondition();
        }

        private void addNewKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource != null)
            {
                AddResourceKeyWindow.ShowDialog(this, CurrentResource);
            }
        }

        private void deleteKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource == null || resourceGrid1.RowCount == 0)
                return;

            if (MessageBox.Show("Are you sure you want to delete the current key?", "Delete",
                MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                resourceGrid1.DeleteSelectedRow();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ResourceLoader.CanClose())
            {
                return;
            }

            treeViewResx.Nodes.Clear();
            checkedListBoxLanguages.Items.Clear();
            labelTitle.Visible = false;

            CurrentResource = null;
            Settings.Default.Save();
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new FindWindow();
            frm.ShowDialog(this);
        }


        //================== General structures ==================================


        public void SetTranslationAvailable(bool isIt)
        {
            translateUsingBingToolStripMenuItem.Enabled = isIt;
            autoTranslateToolStripMenuItem1.Enabled = isIt;
            resourceGrid1.DisplayContextMenu = isIt;
        }

        //================== Tree ==================================

        public void BuildTreeView(ResourceHolder resource)
        {
            TreeNode parentNode = null;
            var topFolders = resource.DisplayFolder.Split('\\');
            foreach (var subFolder in topFolders)
            {
                var searchNodes = parentNode?.Nodes ?? treeViewResx.Nodes;
                var found = false;
                foreach (TreeNode treeNode in searchNodes)
                {
                    var holder = treeNode.Tag as PathHolder;
                    if (holder != null && holder.Id.Equals(subFolder, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        parentNode = treeNode;
                        break;
                    }
                }

                if (found) continue;

                var pathTreeNode = new TreeNode("[" + subFolder + "]");
                var pathHolder = new PathHolder();
                pathHolder.Id = subFolder;
                pathTreeNode.Tag = pathHolder;
                searchNodes.Add(pathTreeNode);

                parentNode = pathTreeNode;
            }

            var leafNode = new TreeNode(resource.Id);
            leafNode.Tag = resource;

            resource.DirtyChanged
                += delegate { SetTreeNodeDirty(leafNode, resource); };

            SetTreeNodeTitle(leafNode, resource);

            resource.LanguageChange
                += delegate { SetTreeNodeTitle(leafNode, resource); };

            parentNode?.Nodes.Add(leafNode);
        }

        public void SetTreeNodeTitle(TreeNode node, ResourceHolder res)
        {
            this.InvokeIfRequired(
                c => { node.Text = res.Caption; });
        }

        public void SetTreeNodeDirty(TreeNode node, ResourceHolder res)
        {
            this.InvokeIfRequired(
                c => { node.ForeColor = res.IsDirty ? Color.Blue : Color.Black; });
        }

        private void treeViewResx_DoubleClick(object sender, EventArgs e)
        {
            SelectResourceFromTree();
        }

        private void treeViewResx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectResourceFromTree();
        }
        
        private void SelectResourceFromTree()
        {
            var selectedTreeNode = treeViewResx.SelectedNode;
            if (selectedTreeNode == null)
            {
                return;
            }

            if (selectedTreeNode.Tag is PathHolder)
            {
                return;
            }

            if (!(selectedTreeNode.Tag is ResourceHolder))
            {
                // Shouldn't happen
                return;
            }
            
            CurrentResource = (ResourceHolder)selectedTreeNode.Tag;

            resourceGrid1.CurrentResource = CurrentResource;
        }
        

        
        //

        #region ================== Top checkboxes ==================================

        private void checkedListBoxLanguages_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var languageHolder = checkedListBoxLanguages.Items[e.Index] as LanguageHolder;
            if (languageHolder == null)
            {
                return;
            }

            if (resourceGrid1.CurrentResource == null)
            {
                // Not populated yet
                return;
            }

            resourceGrid1.SetLanguageColumnVisible(languageHolder.Id, e.NewValue == CheckState.Checked);
        }


        private void addLanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CurrentResource.AddLanguage(e.ClickedItem.Text);
            resourceGrid1.CurrentResource = CurrentResource;
        }

        private void translateUsingBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK ==
                MessageBox.Show(
                    "Do you want to autotranslate all non-translated texts for all languages in this resource?"))
            {
                CurrentResource.AutoTranslate();
            }
        }

        private void deleteLanguageFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myItem = sender as ToolStripMenuItem;
            //Get the ContextMenuString (owner of the ToolsStripMenuItem)
            var theStrip = myItem?.Owner as ContextMenuStrip;
            //The SourceControl is the control that opened the contextmenustrip.
            var box = theStrip?.SourceControl as CheckedListBox;
            if (box != null && MessageBox.Show("Do you really want to delete file for language " +
                                               box.Items[LastClickedLanguageIndex]) == DialogResult.OK)
            {
                CurrentResource.DeleteLanguage(box.Items[LastClickedLanguageIndex].ToString());

                resourceGrid1.CurrentResource = CurrentResource;
            }
        }

        private void autoTranslateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var myItem = sender as ToolStripMenuItem;
            //Get the ContextMenuString (owner of the ToolsStripMenuItem)
            var theStrip = myItem?.Owner as ContextMenuStrip;
            //The SourceControl is the control that opened the contextmenustrip.
            //In my case it could be a linkLabel
            var box = theStrip?.SourceControl as CheckedListBox;
            if (box != null)
            {
                BingTranslator.AutoTranslate(CurrentResource, box.Items[LastClickedLanguageIndex].ToString());
            }
        }

        private void checkedListBoxLanguages_MouseDown(object sender, MouseEventArgs e)
        {
            LastClickedLanguageIndex = checkedListBoxLanguages.IndexFromPoint(e.Location);
        }

        #endregion

        private class PathHolder
        {
            public string Id { get; set; }
        }

    }
}