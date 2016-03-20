using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Windows
{
    public sealed partial class MainWindow : Form
    {
        private readonly string _defaultWindowTitle;

        private ResourceHolder _currentResource;
        private SearchParams _currentSearch;

        public MainWindow()
        {
            InitializeComponent();

            _defaultWindowTitle = Text;

            ResourceLoader = new ResourceLoader();
            ResourceLoader.ResourceLoadProgress += OnResourceLoaderOnResourceLoadProgress;
            ResourceLoader.ResourcesChanged += OnResourceLoaderOnResourcesChanged;

            resourceTreeView1.ResourceOpened += (sender, args) => CurrentResource = args.Resource;

            languageSettings1.EnabledLanguagesChanged += (sender, args) =>
            {
                if (resourceGrid1.CurrentResource == null) return;
                resourceGrid1.SetVisibleLanguageColumns(languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray());
            };
        }

        public SearchParams CurrentSearch
        {
            get { return _currentSearch; }
            set
            {
                _currentSearch = value;
                resourceTreeView1.ExecuteFindInNodes(value);
            }
        }

        public ResourceLoader ResourceLoader { get; }

        private ResourceHolder CurrentResource
        {
            get { return _currentResource; }
            set
            {
                _currentResource = value;
                resourceGrid1.CurrentResource = value;
                resourceGrid1.SetVisibleLanguageColumns(languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray());
            }
        }

        public void SetBingTranslationAvailable(bool isIt)
        {
            translateUsingBingToolStripMenuItem.Enabled = isIt;
            autoTranslateToolStripMenuItem1.Enabled = isIt;
            resourceGrid1.DisplayContextMenu = isIt;
        }

        private void addLanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CurrentResource.AddLanguage(e.ClickedItem.Text);
            resourceGrid1.RefreshResourceDisplay();
        }

        private void addNewKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource != null)
            {
                AddResourceKeyWindow.ShowDialog(this, CurrentResource);
                resourceGrid1.RefreshResourceDisplay();
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
                //TODO BingTranslator.AutoTranslate(CurrentResource, box.Items[LastClickedLanguageIndex].ToString());
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ResourceLoader.CanClose())
                return;

            ResourceLoader.Close();
        }

        private void deleteKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource == null || resourceGrid1.RowCount == 0)
                return;

            if (MessageBox.Show("Are you sure you want to delete the currently selected row?", "Delete a key",
                MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                resourceGrid1.DeleteSelectedRow();
            }
        }

        private void deleteLanguageFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myItem = sender as ToolStripMenuItem;
            //Get the ContextMenuString (owner of the ToolsStripMenuItem)
            var theStrip = myItem?.Owner as ContextMenuStrip;
            //The SourceControl is the control that opened the contextmenustrip.
            var box = theStrip?.SourceControl as CheckedListBox;
            if (box != null && MessageBox.Show("Do you really want to delete file for language "
                //TODO + box.Items[LastClickedLanguageIndex]
                ) == DialogResult.OK)
            {
                //CurrentResource.DeleteLanguage(box.Items[LastClickedLanguageIndex].ToString());

                resourceGrid1.RefreshResourceDisplay();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new FindWindow();
            frm.ShowDialog(this);
        }

        private void hideNontranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideNontranslatedToolStripMenuItem.Checked = !hideNontranslatedToolStripMenuItem.Checked;

            resourceGrid1.ApplyFilterCondition();
        }

        private void LoadResourcesFromFolder(string path)
        {
            ResourceLoader.OpenProject(path);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ResourceLoader.CanClose())
            {
                e.Cancel = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetBingTranslationAvailable(!string.IsNullOrEmpty(Settings.Default.BingAppId));

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
            }
        }

        private void OnResourceLoaderOnResourceLoadProgress(object sender, ResourceLoadProgressEventArgs args)
        {
            this.InvokeIfRequired(_ =>
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

        private void OnResourceLoaderOnResourcesChanged(object sender, EventArgs args)
        {
            this.InvokeIfRequired(_ =>
            {
                Text = string.IsNullOrEmpty(ResourceLoader.OpenedPath)
                    ? _defaultWindowTitle
                    : $"{ResourceLoader.OpenedPath} - {_defaultWindowTitle}";

                CurrentResource = null;

                resourceTreeView1.LoadResources(ResourceLoader);

                var usedLanguages = ResourceLoader.GetUsedLanguages().ToList();

                languageSettings1.RefreshLanguages(usedLanguages, false);

                addLanguageToolStripMenuItem.DropDownItems.Clear();
                foreach (var s in usedLanguages.Select(x => x.Name).OrderBy(x => x))
                {
                    addLanguageToolStripMenuItem.DropDownItems.Add(s);
                }

                Settings.Default.LastOpenedDirectory = ResourceLoader.OpenedPath ?? string.Empty;
                Settings.Default.Save();
            });
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ResourceLoader.CanClose())
                return;

            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = Settings.Default.LastOpenedDirectory,
                Description = "Browse to the root of the project, typically where the sln file is."
            };

            if (folderDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadResourcesFromFolder(folderDialog.SelectedPath);
            }
        }

        private void revertCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentResource.Revert();
            resourceGrid1.RefreshResourceDisplay();
        }

        private void saveCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResourceLoader.SaveResourceHolder(CurrentResource);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResourceLoader.SaveAll();
        }

        private void setBingAppIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new BingSettingsWindow();
            frm.ShowDialog(this);
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
    }
}