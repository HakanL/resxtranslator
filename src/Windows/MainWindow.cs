using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.ResourceOperations;
using ResxTranslator.Resources;
using ResxTranslator.Tools;

namespace ResxTranslator.Windows
{
    public sealed partial class MainWindow : Form
    {
        private static readonly string MoreLanguagesMenuitemName = Localization.MainWindow_MoreLanguagesMenuItem;
        private readonly string _defaultWindowTitle;

        private ResourceHolder _currentResource;
        private SearchParams _currentSearch;

        public MainWindow()
        {
            Opacity = 0;
            InitializeComponent();

            _defaultWindowTitle = $"{Text} {Assembly.GetAssembly(typeof(MainWindow)).GetName().Version.ToString(2)}";

            ResourceLoader = new ResourceLoader();
            ResourceLoader.ResourceLoadProgress += OnResourceLoadProgress;
            ResourceLoader.ResourcesChanged += OnResourceLoaderOnResourcesChanged;

            missingTranslationView1.ResourceLoader = ResourceLoader;

            resourceTreeView1.ResourceOpened += (sender, args) => CurrentResource = args.Resource;

            missingTranslationView1.ItemOpened += (sender, args) =>
            {
                if (!args.Item.Languages.ContainsKey(args.Language.Name))
                {
                    if (MessageBox.Show(this, Localization.MessageBox_CreateMissingResource_Message,
                        Localization.MessageBox_CreateMissingResource_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    args.Item.AddLanguage(args.Language.Name, Settings.Default.AddDefaultValuesOnLanguageAdd);
                    resourceGrid1.RefreshResourceDisplay();
                }

                languageSettings1.SetLanguageState(args.Language.Name, true);
                CurrentResource = args.Item;
            };

            languageSettings1.EnabledLanguagesChanged += (sender, args) =>
            {
                if (resourceGrid1.CurrentResource == null) return;

                var languageIds = languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray();
                resourceGrid1.CurrentResource.EvaluateAllRows(languageIds);
                resourceGrid1.SetVisibleLanguageColumns(languageIds);
                resourceGrid1.Refresh();
            };

            Settings.Binder.BindControl(ignoreEmptyResourcesToolStripMenuItem,
                settings => settings.HideEmptyResources, this);
            Settings.Binder.BindControl(copyDefaultValuesOnLanguageAddToolStripMenuItem,
                settings => settings.AddDefaultValuesOnLanguageAdd, this);
            Settings.Binder.BindControl(openLastDirectoryOnProgramStartToolStripMenuItem,
                settings => settings.OpenLastDirOnStart, this);
            Settings.Binder.BindControl(doNotShowResourcesWithoutAnyTranslationsToolStripMenuItem,
                settings => settings.HideNontranslatedResources, this);
            Settings.Binder.BindControl(markToTranslateOnlyIfDefaultValueIsInBracketsToolStripMenuItem,
                settings => settings.TranslatableInBrackets, this);
            Settings.Binder.BindControl(displayNullValuesAsGrayedToolStripMenuItem,
                settings => settings.ShowNullValuesAsGrayed, this);
            Settings.Binder.BindControl(loadAssembliesFromResourcePathToolStripMenuItem,
                settings => settings.ReferencePathsFromResourceDir, this);

            Settings.Binder.Subscribe((sender, args) => ResourceLoader.HideEmptyResources = args.NewValue,
                settings => settings.HideEmptyResources, this);
            Settings.Binder.Subscribe((sender, args) => ResourceLoader.HideNontranslatedResources = args.NewValue,
                settings => settings.HideNontranslatedResources, this);
            Settings.Binder.Subscribe((sender, args) => resourceGrid1.ShowNullValuesAsGrayed = args.NewValue,
                settings => settings.ShowNullValuesAsGrayed, this);

            Settings.Binder.SendUpdates(this);

            Icon = Icon.ExtractAssociatedIcon(Assembly.GetAssembly(typeof(MainWindow)).Location);
        }

        public SearchParams CurrentSearch
        {
            get { return _currentSearch; }
            set
            {
                _currentSearch = value;
                resourceTreeView1.ExecuteFindInNodes(value);
                resourceGrid1.CurrentSearch = _currentSearch;
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
                    if (_currentResource != null)
                        _currentResource.LanguageChange -= OnCurrentResourceLanguageChange;

                    _currentResource = value;

                    if (_currentResource != null)
                    {
                        _currentResource.LanguageChange += OnCurrentResourceLanguageChange;
                        _currentResource.EvaluateAllRows(
                            languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray());
                    }

                    resourceGrid1.CurrentResource = value;
                    resourceGrid1.SetVisibleLanguageColumns(
                        languageSettings1.EnabledLanguages.Select(x => x.Name).ToArray());

                    tabPageEditedResource.Text = value?.Filename ?? Localization.MainWindow_CurrentResource_NoResourceLoaded;
                    UpdateMenuStrip();
                });
            }
        }

        private void OnCurrentResourceLanguageChange(object sender, EventArgs eventArgs)
        {
            this.InvokeIfRequired(x =>
            {
                languageSettings1.RefreshLanguages(ResourceLoader.GetUsedLanguages(), true);
                UpdateMenuStrip();
            });
        }

        private void LoadReferenceAssemblies()
        {
            OnResourceLoadProgress(this, new ResourceLoadProgressEventArgs(Localization.LoadProgress_ReferenceAssemblies));

            var assembliesToLoad = new List<string>();

            if (Settings.Default.ReferencePaths != null)
            {
                foreach (var path in Settings.Default.ReferencePaths.Cast<string>().Where(Directory.Exists))
                {
                    assembliesToLoad.AddRange(Directory.EnumerateFiles(path, "*.dll", SearchOption.TopDirectoryOnly));
                }
            }

            if (Settings.Default.ReferencePathsFromResourceDir && Directory.Exists(ResourceLoader.OpenedPath))
            {
                assembliesToLoad.AddRange(Directory.EnumerateFiles(ResourceLoader.OpenedPath, "*.dll", SearchOption.AllDirectories));
            }

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic)
                .Select(x => x.Location).Distinct().ToList();

            assembliesToLoad = assembliesToLoad.Select(x => x.ToLowerInvariant()).Distinct().ToList();

            if (assembliesToLoad.Count > 300 && MessageBox.Show(
                string.Format(
                    Localization.MessageBox_ConfirmLoadAssemblies_Message,
                    assembliesToLoad.Count),
                Localization.MessageBox_ConfirmLoadAssemblies_Title, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                OnResourceLoadProgress(this, new ResourceLoadProgressEventArgs(Localization.LoadProgress_Done, null, 0, 0));
                return;
            }

            var count = 0;
            foreach (var filename in assembliesToLoad)
            {
                count++;
                OnResourceLoadProgress(this, new ResourceLoadProgressEventArgs(Localization.LoadProgress_ReferenceAssemblies,
                    Path.GetFileName(filename), count, assembliesToLoad.Count));

                try
                {
                    if (loadedAssemblies.All(x => !string.Equals(x, filename, StringComparison.OrdinalIgnoreCase)))
                    {
                        Assembly.LoadFile(filename);
                        loadedAssemblies.Add(filename);
                    }
                }
                catch (NotSupportedException) { }
                catch (BadImageFormatException) { }
                catch (FileLoadException) { }
            }

            OnResourceLoadProgress(this, new ResourceLoadProgressEventArgs(Localization.LoadProgress_Done, null, 0, 0));
        }

        private void UpdateMenuStrip()
        {
            var notNull = _currentResource != null;
            keysToolStripMenuItem.Enabled = notNull;
            addNewKeyToolStripMenuItem.Enabled = notNull;
            languagesToolStripMenuItem.Enabled = notNull;

            removeLanguageToolStripMenuItem.DropDownItems.Clear();
            addLanguageToolStripMenuItem.DropDownItems.Clear();

            if (_currentResource == null) return;

            foreach (
                var info in
                    ResourceLoader.GetUsedLanguages()
                        .Where(x => !_currentResource.Languages.Values.Any(y => y.CultureInfo.Equals(x)))
                        .OrderBy(x => x.Name))
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
                CurrentResource.AddLanguage(tag.Name, Settings.Default.AddDefaultValuesOnLanguageAdd);

                UpdateMenuStrip();
                resourceGrid1.RefreshResourceDisplay();
            }
            else if (e.ClickedItem.Text.Equals(MoreLanguagesMenuitemName, StringComparison.InvariantCulture))
            {
                var language = LanguageSelectDialog.ShowLanguageSelectDialog(this);
                if (language != null && !CurrentResource.Languages.ContainsKey(language.Name))
                {
                    CurrentResource.AddLanguage(language.Name, Settings.Default.AddDefaultValuesOnLanguageAdd);

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

            if (MessageBox.Show(Localization.MessageBox_ConfirmDeleteRow_Message, Localization.MessageBox_ConfirmDeleteRow_Title,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            var result = FindWindow.ShowDialog(this);
            if (result != null)
                CurrentSearch = result;
        }

        private void LoadResourcesFromFolder(string path)
        {
            if (!ResourceLoader.CanClose())
                return;

            Enabled = false;
            toolStripStatusLabel1.Text = string.Format(Localization.LoadProgress_OpeningDirectory, path);
            Application.DoEvents();

            ResourceLoader.OpenProject(path);

            Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LastOpenedDirectory = ResourceLoader.OpenedPath ?? string.Empty;

            switch (WindowState)
            {
                case FormWindowState.Normal:
                    Settings.Default.WindowLocation = Location;
                    Settings.Default.WindowSize = Size;
                    Settings.Default.WindowState = WindowState;
                    break;
                case FormWindowState.Maximized:
                    Settings.Default.WindowState = WindowState;
                    break;
            }

            Settings.Default.Save();

            if (!ResourceLoader.CanClose())
                e.Cancel = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!Settings.Default.WindowSize.IsEmpty)
            {
                Location = Settings.Default.WindowLocation;
                Size = Settings.Default.WindowSize;
                WindowState = Settings.Default.WindowState;
            }

            Opacity = 1;

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1].Trim()))
            {
                var path = args[1].Trim();
                try
                {
                    var fldr = new DirectoryInfo(path);
                    if (!fldr.Exists)
                        throw new ArgumentException(string.Format(Localization.Error_DirectoryMissing, path));
                    path = (fldr.FullName + "\\").Replace("\\\\", "\\");
                    LoadResourcesFromFolder(path);
                }
                catch (Exception inner)
                {
                    throw new ArgumentException(
                        string.Format(Localization.Error_InvalidCommandLine, Environment.CommandLine, path), inner);
                }
            }
            else if (Settings.Default.OpenLastDirOnStart &&
                     !string.IsNullOrEmpty(Settings.Default.LastOpenedDirectory) &&
                     Directory.Exists(Settings.Default.LastOpenedDirectory))
            {
                LoadResourcesFromFolder(Settings.Default.LastOpenedDirectory);
            }
        }

        private void OnResourceLoadProgress(object sender, ResourceLoadProgressEventArgs args)
        {
            this.InvokeIfRequired(_ =>
            {
                toolStripStatusLabelCurrentItem.Text = args.CurrentlyProcessedItem ?? string.Empty;
                toolStripStatusLabel1.Text = args.CurrentProcess ?? string.Empty;
                if (args.Progress < args.ProgressTop)
                {
                    toolStripProgressBar1.Visible = true;
                    if (toolStripProgressBar1.Maximum != args.ProgressTop)
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

                LoadReferenceAssemblies();
            });
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ResourceLoader.CanClose())
                return;

            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = Settings.Default.LastOpenedDirectory,
                Description = Localization.MainWindow_OpenDirectory_Description
            };

            if (folderDialog.ShowDialog(this) == DialogResult.OK)
            {
                CurrentResource = null;
                Application.DoEvents();
                LoadResourcesFromFolder(folderDialog.SelectedPath);
            }
        }

        private void revertCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource == null)
                return;

            CurrentResource.Revert();
            resourceGrid1.RefreshResourceDisplay();
        }

        private void saveCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentResource?.Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResourceLoader.SaveAll();
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

        private void clearSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentSearch = null;
        }

        private void findToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            clearSearchToolStripMenuItem.Enabled = CurrentSearch != null;
        }

        private void openResourceLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentResource == null) return;
            Process.Start("explorer.exe", $"\"{Path.GetDirectoryName(CurrentResource.Filename)}\"");
        }

        private void reloadCurrentDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ResourceLoader.OpenedPath))
                LoadResourcesFromFolder(ResourceLoader.OpenedPath);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox.ShowAboutBox(this);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.Homepage);
        }

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(
                Path.GetDirectoryName(Assembly.GetAssembly(typeof(MainWindow)).Location) ?? string.Empty,
                "Licence.txt"));
        }

        private void setReferencePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var referencePaths = EditReferencePaths.ShowDialog(this,
                Settings.Default.ReferencePaths?.Cast<string>().ToArray() ?? new string[] { });

            if (referencePaths != null)
            {
                if (Settings.Default.ReferencePaths == null)
                    Settings.Default.ReferencePaths = new StringCollection();

                Settings.Default.ReferencePaths.Clear();
                Settings.Default.ReferencePaths.AddRange(referencePaths);

                LoadReferenceAssemblies();
            }
        }
    }
}