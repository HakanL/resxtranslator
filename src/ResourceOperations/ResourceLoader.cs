using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ResxTranslator.ResourceOperations
{
    public class ResourceLoader
    {
        private string _openedPath;
        private bool _hideEmptyResources;
        private readonly Dictionary<string, ResourceHolder> _resourceStore;
        private bool _hideNontranslatedResources;

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

        public static void SaveResourceHolder(ResourceHolder resource)
        {
            if (resource.IsDirty)
            {
                try
                {
                    resource.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception while saving: " + resource.Id, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Check and prompt for save
        /// </summary>
        /// <returns>True if we can safely close</returns>
        public bool CanClose()
        {
            var isDirty = Resources.Any(resource => resource.IsDirty);

            if (isDirty)
            {
                var dialogResult = MessageBox.Show("Do you want save your changes before closing?", "Save Changes",
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
                throw new InvalidOperationException("Can't close at this time");
            
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

            OnResourceLoadProgress(new ResourceLoadProgressEventArgs("Loading resources..."));

            FindResx(selectedPath);
            OpenedPath = selectedPath;

            OnResourceLoadProgress(new ResourceLoadProgressEventArgs("Done"));
        }

        public void SaveAll()
        {
            foreach (var resource in _resourceStore.Values)
            {
                SaveResourceHolder(resource);
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
            {
                displayFolder = currentDirectory.Substring(rootDirectory.Length);
            }
            if (displayFolder.StartsWith("\\"))
            {
                displayFolder = displayFolder.Remove(0, 1);
            }

            var files = Directory.GetFiles(currentDirectory, "*.resx");

            foreach (var filename in files)
            {
                var filenameNoExt = Path.GetFileNameWithoutExtension(filename);
                if (string.IsNullOrEmpty(filenameNoExt)) continue;

                // Try to get the language code
                var potentialLanguageCode = Path.GetExtension(filenameNoExt).Replace(".", string.Empty);

                string languageCode = null;

                // Full language code: xx-yy Short language code: xx
                if ((potentialLanguageCode.Length == 5 && potentialLanguageCode[2] == '-')
                    || potentialLanguageCode.Length == 2)
                {
                    languageCode = potentialLanguageCode;

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

                    if (string.IsNullOrEmpty(languageCode))
                        resourceHolder.Filename = filename;

                    _resourceStore.Add(key, resourceHolder);
                }

                if (string.IsNullOrEmpty(languageCode))
                {
                    // This is the main file
                    resourceHolder.Filename = filename;
                }
                else
                {
                    if (resourceHolder.Languages.ContainsKey(languageCode.ToLower()))
                        throw new InvalidDataException("Duplicate resource file: " + filename);

                    resourceHolder.Languages.Add(languageCode.ToLower(), new LanguageHolder(languageCode, filename));
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