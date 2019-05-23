using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ResxTranslator.Resources;

namespace ResxTranslator.ResourceOperations
{
    public class ResourceLoader
    {
        private static readonly IEnumerable<CultureInfo> SupportedCultureCache
            = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(x => x.Name != string.Empty).ToList();

        private readonly Dictionary<string, ResourceHolder> _resourceStore;
        private bool _hideEmptyResources;
        private bool _hideNontranslatedResources;
        private string _openedPath;

        public ResourceLoader()
        {
            _resourceStore = new Dictionary<string, ResourceHolder>();
        }

        public string OpenedPath
        {
            get { return _openedPath; }
            private set
            {
                _openedPath = value;
                OnResourcesChanged();
            }
        }

        public IEnumerable<ResourceHolder> Resources
        {
            get
            {
                var result = _resourceStore.Values.AsEnumerable();
                if (HideEmptyResources)
                    result = result.Where(x => x.StringsTable.Rows.Count > 0);
                if (HideNontranslatedResources)
                    result = result.Where(x => x.Languages.Count > 0);
                return result;
            }
        }

        public bool HideEmptyResources
        {
            get { return _hideEmptyResources; }
            set
            {
                _hideEmptyResources = value;
                OnResourcesChanged();
            }
        }

        public bool HideNontranslatedResources
        {
            get { return _hideNontranslatedResources; }
            set
            {
                _hideNontranslatedResources = value;
                OnResourcesChanged();
            }
        }

        public event EventHandler<ResourceLoadProgressEventArgs> ResourceLoadProgress;

        public event EventHandler ResourcesChanged;

        /// <summary>
        /// Check and prompt for save
        /// </summary>
        /// <returns>True if we can safely close</returns>
        public bool CanClose()
        {
            var isDirty = Resources.Any(resource => resource.IsDirty);

            if (isDirty)
            {
                var dialogResult = MessageBox.Show(Localization.MessageBox_SaveChangesBeforeClose_Message,
                    Localization.MessageBox_SaveChangesBeforeClose_Title,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                // Return false only if user presses cancel
                if (dialogResult != DialogResult.Yes)
                    return dialogResult == DialogResult.No;

                SaveAll();
            }
            return true;
        }

        public void Close()
        {
            if (!CanClose())
                throw new InvalidOperationException(Localization.Error_CantClose);

            _resourceStore.Clear();
            OpenedPath = string.Empty;
        }

        public IEnumerable<CultureInfo> GetUsedLanguages()
        {
            return Resources.Aggregate(Enumerable.Empty<LanguageHolder>(),
                (holder, pair) => holder.Concat(pair.Languages.Values))
                .GroupBy(x => x.LanguageId)
                .Select(holders => holders.First().CultureInfo);
        }

        public void OpenProject(string selectedPath)
        {
            Close();

            OnResourceLoadProgress(new ResourceLoadProgressEventArgs(Localization.LoadProgress_LoadingResources));

            FindResx(selectedPath);
            OpenedPath = selectedPath;

            OnResourceLoadProgress(new ResourceLoadProgressEventArgs(Localization.LoadProgress_Done));
        }

        public void SaveAll()
        {
            foreach (var resource in _resourceStore.Values)
            {
                resource.Save();
            }
        }

        protected virtual void OnResourceLoadProgress(ResourceLoadProgressEventArgs e)
        {
            ResourceLoadProgress?.Invoke(this, e);
        }

        protected virtual void OnResourcesChanged()
        {
            ResourcesChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FindResx(string rootDirectory)
        {
            FindResx(rootDirectory, rootDirectory);
        }

        private void FindResx(string rootDirectory, string currentDirectory)
        {
            var displayFolder = string.Empty;
            if (currentDirectory.StartsWith(rootDirectory, StringComparison.InvariantCultureIgnoreCase))
                displayFolder = currentDirectory.Substring(rootDirectory.Length);

            displayFolder = displayFolder.TrimStart('\\', '/');

            var files = Directory.GetFiles(currentDirectory, "*.resx");

            var failedList = new List<string>();

            foreach (var filename in files)
            {
                var filenameNoExt = Path.GetFileNameWithoutExtension(filename);
                if (string.IsNullOrEmpty(filenameNoExt)) continue;

                // Try to get the language code
                var potentialLanguageCode = Path.GetExtension(filenameNoExt).TrimStart('.');

                var culture = SupportedCultureCache.FirstOrDefault(
                    info => info.Name.Equals(potentialLanguageCode, StringComparison.InvariantCultureIgnoreCase));

                if (culture != null)
                {
                    // Get rid of the language code to get the base filename
                    filenameNoExt = Path.GetFileNameWithoutExtension(filenameNoExt);
                }

                ResourceHolder resourceHolder;
                var key = (displayFolder + "\\" + filenameNoExt).ToLower();
                if (!_resourceStore.TryGetValue(key, out resourceHolder))
                {
                    resourceHolder = new ResourceHolder
                    {
                        Id = filenameNoExt,
                        DisplayFolder = displayFolder
                    };

                    var dir = Path.GetDirectoryName(filename);
                    Debug.Assert(dir != null, "dir != null");
                    resourceHolder.Filename = Path.Combine(dir, filenameNoExt + ".resx");

                    try
                    {
                        resourceHolder.LoadResource();

                        _resourceStore.Add(key, resourceHolder);
                    }
                    catch (SystemException)
                    {
                        failedList.Add(resourceHolder.Filename);
                    }
                }

                if (failedList.Any())
                {
                    MessageBox.Show(string.Format(Localization.MessageBox_ResourcesFailedToLoad_Message, string.Join("\n", failedList)),
                        Localization.MessageBox_ResourcesFailedToLoad_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (culture != null)
                {
                    if (resourceHolder.Languages.ContainsKey(culture.Name.ToLower()))
                        throw new InvalidDataException(string.Format(Localization.Error_DuplicateResx, filename));

                    resourceHolder.Languages.Add(culture.Name.ToLower(), new LanguageHolder(culture.Name, filename));
                }
            }

            var subfolders = Directory.GetDirectories(currentDirectory);
            foreach (var subfolder in subfolders)
            {
                FindResx(rootDirectory, subfolder);
            }
        }
    }
}