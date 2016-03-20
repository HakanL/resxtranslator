using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.ResourceOperations;

namespace ResxTranslator.Windows
{
    public sealed partial class MainWindow : Form
    {
        private const string MoreLanguagesMenuitemName = "More languages...";
        private readonly string _defaultWindowTitle;
        private readonly SettingBinder<Settings> _settingBinder;

        private ResourceHolder _currentResource;
        private SearchParams _currentSearch;

        public MainWindow()
        {
            InitializeComponent();

            _defaultWindowTitle = Text;

            ResourceLoader = new ResourceLoader();
            ResourceLoader.ResourceLoadProgress += OnResourceLoaderOnResourceLoadProgress;
            ResourceLoader.ResourcesChanged += OnResourceLoaderOnResourcesChanged;

            missingTranslationView1.ResourceLoader = ResourceLoader;

            resourceTreeView1.ResourceOpened += (sender, args) => CurrentResource = args.Resource;

            missingTranslationView1.ItemOpened += (sender, args) =>
            {
                if (!args.Item.Languages.ContainsKey(args.Language.Name))
                {
                    if (MessageBox.Show(this, "Resource file for this language is missing, do you want to create it?",
                        "Missing resource file", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;

                    args.Item.AddLanguage(args.Language.Name, _settingBinder.Settings.AddDefaultValuesOnLanguageAdd);
                    resourceGrid1.RefreshResourceDisplay();
                }
                CurrentResource = args.Item;
            };

            languageSettings1.EnabledLanguagesChanged += (sender, args) =>
            {
                if (resourceGrid1.CurrentResource == null) return;
                resourceGrid1.SetVisibleLanguageColumns(languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray());
            };

            _settingBinder = new SettingBinder<Settings>(Settings.Default);
            _settingBinder.BindControl(ignoreEmptyResourcesToolStripMenuItem, settings => settings.HideEmptyResources, this);
            _settingBinder.BindControl(copyDefaultValuesOnLanguageAddToolStripMenuItem, settings => settings.AddDefaultValuesOnLanguageAdd, this);

            _settingBinder.Subscribe((sender, args) => ResourceLoader.HideEmptyResources = args.NewValue, settings => settings.HideEmptyResources, this);
            _settingBinder.Subscribe((sender, args) => translateUsingBingToolStripMenuItem.Enabled = !string.IsNullOrEmpty(args.NewValue),
                settings => settings.BingAppId, this);

            _settingBinder.SendUpdates(this);
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
                this.InvokeIfRequired(_ =>
                {
                    _currentResource = value;
                    resourceGrid1.CurrentResource = value;
                    resourceGrid1.SetVisibleLanguageColumns(languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray());
                    tabPageEditedResource.Text = value?.Filename ?? "No resource loaded";

                    UpdateMenuStrip();
                });
            }
        }

        private void UpdateMenuStrip()
        {
            var notNull = _currentResource != null;
            keysToolStripMenuItem.Enabled = notNull;
            addNewKeyToolStripMenuItem.Enabled = notNull;
            languagesToolStripMenuItem.Enabled = notNull;
            autoTranslateToolStripMenuItem.Enabled = notNull;

            removeLanguageToolStripMenuItem.DropDownItems.Clear();
            addLanguageToolStripMenuItem.DropDownItems.Clear();

            if (_currentResource == null) return;

            foreach (var info in ResourceLoader.GetUsedLanguages().Where(x => !_currentResource.Languages.Values.Any(y => y.CultureInfo.Equals(x))).OrderBy(x => x.Name))
            {
                addLanguageToolStripMenuItem.DropDownItems.Add($"{info.Name} - {info.DisplayName}").Tag = info;
            }
            if (addLanguageToolStripMenuItem.DropDownItems.Count > 0)
                addLanguageToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            addLanguageToolStripMenuItem.DropDownItems.Add(MoreLanguagesMenuitemName);
            
            foreach (var info in _currentResource.Languages.Values.Select(x => x.CultureInfo).OrderBy(x => x.Name))
            {
                removeLanguageToolStripMenuItem.DropDownItems.Add($"{info.Name} - {info.DisplayName}").Tag = info;
            }
        }

        private void addLanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var tag = e.ClickedItem.Tag as CultureInfo;
            if (tag != null)
            {
                CurrentResource.AddLanguage(tag.Name, _settingBinder.Settings.AddDefaultValuesOnLanguageAdd);

                UpdateMenuStrip();
                resourceGrid1.RefreshResourceDisplay();
            }
            else if (e.ClickedItem.Text.Equals(MoreLanguagesMenuitemName, StringComparison.InvariantCulture))
            {
                var language = LanguageSelectDialog.ShowLanguageSelectDialog(this);
                if(language != null && !CurrentResource.Languages.ContainsKey(language.Name))
                {
                    CurrentResource.AddLanguage(language.Name, _settingBinder.Settings.AddDefaultValuesOnLanguageAdd);

                    UpdateMenuStrip();
                    resourceGrid1.RefreshResourceDisplay();
                }
            }
        }

        private void addNewKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource != null)
            {
                AddResourceKeyWindow.ShowDialog(this, CurrentResource);
                resourceGrid1.RefreshResourceDisplay();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new FindWindow();
            frm.ShowDialog(this);
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
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1].Trim()))
            {
                var path = args[1].Trim();
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
                var nothingLoaded = string.IsNullOrEmpty(ResourceLoader.OpenedPath);
                findToolStripMenuItem.Enabled = !nothingLoaded;

                Text = string.IsNullOrEmpty(ResourceLoader.OpenedPath)
                    ? _defaultWindowTitle
                    : $"{ResourceLoader.OpenedPath} - {_defaultWindowTitle}";

                CurrentResource = null;

                resourceTreeView1.LoadResources(ResourceLoader);

                var usedLanguages = ResourceLoader.GetUsedLanguages().ToList();

                languageSettings1.RefreshLanguages(usedLanguages, false);

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
            if (MessageBox.Show("Do you want to autotranslate all non-translated texts for all languages in this resource?") == DialogResult.OK)
            {
                CurrentResource.AutoTranslate();
            }
        }

        private void removeLanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CurrentResource.DeleteLanguage(((CultureInfo)e.ClickedItem.Tag).Name);

            UpdateMenuStrip();
            resourceGrid1.RefreshResourceDisplay();
        }

        private void languagesToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            removeLanguageToolStripMenuItem.Enabled = removeLanguageToolStripMenuItem.DropDownItems.Count > 0;
        }
    }
}