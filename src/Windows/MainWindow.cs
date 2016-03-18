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
            ShowResourceInGrid(CurrentResource);
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

            ApplyFilterCondition();
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
            if (CurrentResource == null || dataGridView1.RowCount == 0)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the current key?", "Delete",
                MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                var dataRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

                dataRow?.Row.Delete();
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
            autoTranslateThisCellToolStripMenuItem.Enabled = isIt;
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

        private void ShowResourceInGrid(ResourceHolder resource)
        {
            CurrentResource = resource;

            labelTitle.Text = resource.Id;
            labelTitle.Visible = true;

            dataGridView1.DataSource = resource.StringsTable;

            checkedListBoxLanguages.Items.Clear();

            foreach (var languageHolder in resource.Languages.Values)
            {
                checkedListBoxLanguages.Items.Add(languageHolder, true);
                dataGridView1.Columns[languageHolder.Id].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dataGridView1.Columns["NoLanguageValue"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Comment"].DisplayIndex = dataGridView1.Columns.Count - 1;

            dataGridView1.Columns["Translated"].Visible = false;
            dataGridView1.Columns["Error"].Visible = false;


            ApplyFilterCondition();

            dataGridView1.Columns["Key"].ReadOnly = true;

            ApplyConditionalFormatting();
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
            
            ShowResourceInGrid((ResourceHolder)selectedTreeNode.Tag);
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

            if (dataGridView1.DataSource == null)
            {
                // Not populated yet
                return;
            }

            SetLanguageColumnVisible(languageHolder.Id, e.NewValue == CheckState.Checked);
        }

        private void SetLanguageColumnVisible(string languageId, bool visible)
        {
            if (dataGridView1.Columns.Contains(languageId))
            {
                dataGridView1.Columns[languageId].Visible = visible;
            }
        }

        private void addLanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CurrentResource.AddLanguage(e.ClickedItem.Text);
            ShowResourceInGrid(CurrentResource);
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
                ShowResourceInGrid(CurrentResource);
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

        #region ================== Data Grid  ==================================

        private void ApplyFilterCondition()
        {
            if (dataGridView1.DataSource == null)
            {
                return;
            }

            ((DataTable) dataGridView1.DataSource).DefaultView.RowFilter
                = hideNontranslatedToolStripMenuItem.Checked ? " Translated = 1" : "";
        }

        private void ApplyConditionalFormatting()
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                ApplyConditionalFormatting(r);
            }
        }

        private void ApplyConditionalFormatting(DataGridViewRow r)
        {
            if (r.Cells["Error"].Value != null && (bool) r.Cells["Error"].Value)
            {
                r.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                r.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                return;
            }
            if (dataGridView1.CurrentCell.IsInEditMode)
            {
                return;
            }

            var frm = new ZoomWindow();
            var value = dataGridView1.CurrentCell.Value;
            if (value == DBNull.Value)
            {
                frm.textBoxString.Text = "";
            }
            else
            {
                frm.textBoxString.Text = (string) value;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.CurrentCell.Value = frm.textBoxString.Text;
                dataGridView1.EndEdit();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((DataGridViewTextBoxEditingControl) e.Control).AcceptsReturn = true;
            ((DataGridViewTextBoxEditingControl) e.Control).Multiline = true;
        }

        private void autoTranslateThisCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var column = dataGridView1.Columns[colIndex].Name;
            var source = dataGridView1.CurrentCell.Value.ToString();

            var autoTranslate =
                contextMenuStripCell.Items["autoTranslateThisCellToolStripMenuItem"] as ToolStripMenuItem;

            var preferred = "NoLanguageValue";
            if (!(autoTranslate.DropDownItems[1] as ToolStripMenuItem).Checked)
            {
                var subChk = FindCheckedSubItemIndex(autoTranslate);
                preferred = subChk > -1 ? autoTranslate.DropDownItems[subChk].Text : Settings.Default.PreferredSourceLanguage;
            }

            if (string.IsNullOrEmpty(source.Trim()))
            {
                source = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[preferred].Value.ToString();
            }
            if (column == "NoLanguageValue")
            {
                column = CurrentResource.NoLanguageLanguage;
            }

            var translation = BingTranslator.TranslateString(source, column);
            dataGridView1.CurrentCell.Value = translation;
            dataGridView1.EndEdit();
        }

        private void autoTranslateThisCellToolStripMenuItem_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            var checkedItem = e.ClickedItem as ToolStripMenuItem;
            var autoTranslate =
                contextMenuStripCell.Items["autoTranslateThisCellToolStripMenuItem"] as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in autoTranslate.DropDownItems)
                item.Checked = false;
            checkedItem.Checked = true;
            var preferred = "" + checkedItem.Tag == "NoLanguageValue" ? "NoLanguageValue" : checkedItem.Text;

            Settings.Default.PreferredSourceLanguage = preferred;

            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var column = dataGridView1.Columns[colIndex].Name;
            if (column == "NoLanguageValue")
            {
                column = CurrentResource.NoLanguageLanguage;
            }
            var source = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[preferred].Value.ToString();

            var translation = BingTranslator.TranslateString(source, column);
            dataGridView1.CurrentCell.Value = translation;
            dataGridView1.EndEdit();
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender,
            DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }
            e.ContextMenuStrip = contextMenuStripCell;

            var autoTranslate =
                contextMenuStripCell.Items["autoTranslateThisCellToolStripMenuItem"] as ToolStripMenuItem;

            if (autoTranslate.DropDownItems.Count < 3)
            {
                //rebuild the language select drop down
                var subChk = FindCheckedSubItemIndex(autoTranslate);
                var chkedLang = "";
                if (subChk > -1)
                {
                    chkedLang = autoTranslate.DropDownItems[subChk].Text;
                }
                else
                {
                    (autoTranslate.DropDownItems[0] as ToolStripMenuItem).Checked = true;
                }

                for (var i = autoTranslate.DropDownItems.Count - 1
                    ;
                    i > 1
                    ;
                    --i)
                {
                    autoTranslate.DropDownItems.RemoveAt(i);
                }

                foreach (var lang in CurrentResource.Languages.Keys)
                {
                    autoTranslate.DropDownItems.Add(lang);
                    var newItem =
                        autoTranslate.DropDownItems[autoTranslate.DropDownItems.Count - 1] as ToolStripMenuItem;
                    if (chkedLang == lang)
                    {
                        newItem.Checked = true;
                    }
                }
            }


            var preferred = "NoLanguageValue";
            if (!(autoTranslate.DropDownItems[1] as ToolStripMenuItem).Checked)
            {
                var subChk = FindCheckedSubItemIndex(autoTranslate);
                if (subChk > -1)
                {
                    preferred = autoTranslate.DropDownItems[subChk].Text;
                }
            }

            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var source = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[preferred].Value.ToString();
            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var column = dataGridView1.Columns[colIndex].Name;

            var listofalternatives = InprojectTranslator.Instance.GetTranslations(CurrentResource.NoLanguageLanguage,
                source, column);
            for (var i = e.ContextMenuStrip.Items.Count - 1
                ;
                i > 0
                ;
                --i)
            {
                if (e.ContextMenuStrip.Items[i].Name.StartsWith("Transl"))
                {
                    e.ContextMenuStrip.Items.RemoveAt(i);
                }
            }
            foreach (var alt in listofalternatives)
            {
                e.ContextMenuStrip.Items.Add(alt);
                var newItem = e.ContextMenuStrip.Items[e.ContextMenuStrip.Items.Count - 1];
                var translation = alt;
                var cell = dataGridView1.CurrentCell;
                newItem.Click += (EventHandler) delegate
                {
                    cell.Value = translation;
                    dataGridView1.EndEdit();
                };
                newItem.Name = "Transl_" + alt;
            }
        }

        private static int FindCheckedSubItemIndex(ToolStripMenuItem autoTranslate)
        {
            for (var index = 0; index < autoTranslate.DropDownItems.Count; index++)
            {
                var item = autoTranslate.DropDownItems[index] as ToolStripMenuItem;
                if (item.Checked)
                {
                    return index;
                }
            }
            return -1;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ApplyConditionalFormatting(dataGridView1.Rows[e.RowIndex]);
        }

        #region ============================= Drag and drop cell copying ==============================

        private DateTime _mouseDownStart = DateTime.MaxValue;
        private bool _dndInProgress;

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _mouseDownStart = DateTime.Now;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            _mouseDownStart = DateTime.MaxValue;
            dataGridView1.AllowDrop = false;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DateTime.Now.Subtract(_mouseDownStart).TotalMilliseconds > 50)
            {
                _mouseDownStart = DateTime.MaxValue;
                if (e.RowIndex > -1 && e.ColumnIndex > 0)
                {
                    var text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        dataGridView1.AllowDrop = true;
                        DoDragDrop(text, DragDropEffects.All);
                        _dndInProgress = true;
                    }
                }
            }
        }


        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            var p = dataGridView1.PointToClient(new Point(e.X, e.Y));
            var info = dataGridView1.HitTest(p.X, p.Y);
            var value = e.Data.GetData(typeof (string));
            dataGridView1.AllowDrop = false;
            if (info.RowIndex != -1 && info.ColumnIndex != -1 && (ModifierKeys & Keys.Control) != 0)
            {
                if (value != null)
                {
                    dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Value = value.ToString();
                }
            }
            _dndInProgress = false;
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            if (_dndInProgress)
            {
                e.Effect = (ModifierKeys & Keys.Control) != 0 ? DragDropEffects.Copy : DragDropEffects.None;
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }


        //=========================================================================================

        #endregion

        #endregion
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