using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ResxTranslator.ResourceOperations
{
    public class ResourceLoader
    {
        private Thread _dictBuilderThread;
        private string _openedPath;
        private volatile bool _requestDictBuilderStop;
        private bool _hideEmptyResources;
        private readonly Dictionary<string, ResourceHolder> _resourceStore;

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

        public IEnumerable<ResourceHolder> Resources => HideEmptyResources ? 
            _resourceStore.Values.Where(x => x.StringsTable.Rows.Count > 0) : _resourceStore.Values;

        public bool HideEmptyResources
        {
            get { return _hideEmptyResources; }
            set
            {
                _hideEmptyResources = value; 
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
                    MessageBox.Show(ex.Message, "Exception while saving: " + resource.Id);
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

                StopDictBuilderThread();
                SaveAll();
            }
            else
            {
                StopDictBuilderThread();
            }
            return true;
        }

        public void Close()
        {
            if (!CanClose())
                throw new InvalidOperationException("Can't close at this time");

            StopDictBuilderThread();
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

            OnResourceLoadProgress(new ResourceLoadProgressEventArgs("Building local dictionary..."));

            StartDictBuilderThread();
        }

        public void SaveAll()
        {
            foreach (var resource in _resourceStore.Values)
            {
                SaveResourceHolder(resource);
            }
        }

        public void StopDictBuilderThread()
        {
            if (_dictBuilderThread != null && _dictBuilderThread.IsAlive)
            {
                _requestDictBuilderStop = true;
                while (false == _dictBuilderThread.Join(50))
                {
                }
            }
            _requestDictBuilderStop = false;
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

        private void StartDictBuilderThread()
        {
            if (_dictBuilderThread != null && _dictBuilderThread.IsAlive)
                throw new InvalidOperationException("Dictionary builder is already running");

            // Make the logic for building the dictionary an anonymous delegate to keep it only callable on the separate thread
            var buildDictionary = (ThreadStart)delegate
           {
               var currentCount = 0;
               var totalCount = _resourceStore.Count;
               var currentTask = "Building language lookup";

               foreach (var res in _resourceStore.Values.TakeWhile(_ => !_requestDictBuilderStop))
               {
                   OnResourceLoadProgress(new ResourceLoadProgressEventArgs(currentTask, res.Filename, currentCount,
                       totalCount));

                   var translator = InprojectTranslator.Instance;

                   foreach (var lang in res.Languages.Keys)
                   {
                       var sbAllNontranslated = new StringBuilder();
                       var sbAllTranslated = new StringBuilder();
                       foreach (DataRow row in res.StringsTable.Rows)
                       {
                           sbAllNontranslated.Append(row["NoLanguageValue"]);
                           sbAllNontranslated.Append(" ");

                           if (row[lang.ToLower()] != DBNull.Value &&
                               row[lang.ToLower()].ToString().Trim() != "")
                           {
                               sbAllTranslated.Append(row[lang.ToLower()].ToString().Trim());
                               sbAllTranslated.Append(" ");
                           }
                       }
                       var diffArray = translator.RemoveWords(sbAllNontranslated.ToString(),
                           sbAllTranslated.ToString());
                       translator.AddWordsToLanguageChecker(lang.ToLower()
                           , diffArray);
                   }

                   ++currentCount;
               }

               currentTask = "Building local translations dictionary";
               currentCount = 0;

               foreach (var res in _resourceStore.Values.TakeWhile(_ => !_requestDictBuilderStop))
               {
                   OnResourceLoadProgress(new ResourceLoadProgressEventArgs(currentTask, res.Filename, currentCount,
                       totalCount));

                   var resDeflang = res.NoLanguageLanguage;
                   var sb = new StringBuilder();
                   foreach (DataRow row in res.StringsTable.Rows)
                   {
                       var nontranslated = row["NoLanguageValue"].ToString();
                       if (!string.IsNullOrEmpty(nontranslated) && nontranslated.Trim() != string.Empty)
                       {
                           foreach (var lang in res.Languages.Keys)
                           {
                               if (row[lang.ToLower()] != DBNull.Value &&
                                   row[lang.ToLower()].ToString().Trim() != string.Empty)
                               {
                                   sb.Append(" ");
                                   sb.Append(row[lang.ToLower()]);

                                   InprojectTranslator.Instance.AddTranslation(resDeflang
                                       , nontranslated
                                       , lang.ToLower()
                                       , row[lang.ToLower()].ToString().Trim());
                                   InprojectTranslator.Instance.AddTranslation(lang.ToLower()
                                       , row[lang.ToLower()].ToString().Trim()
                                       , resDeflang
                                       , nontranslated);
                               }
                           }
                       }
                       if (!string.IsNullOrEmpty(resDeflang))
                           InprojectTranslator.Instance.AddWordsToLanguageChecker(resDeflang,
                               InprojectTranslator.Instance.RemoveWords(sb.ToString(), nontranslated));
                   }

                   ++currentCount;
               }

               OnResourceLoadProgress(new ResourceLoadProgressEventArgs("Done", null, 0, 0));
           };

            _dictBuilderThread = new Thread(buildDictionary)
            {
                Name = "DictBuilder",
                IsBackground = false,
                Priority = ThreadPriority.BelowNormal
            };
            _requestDictBuilderStop = false;

            _dictBuilderThread.Start();
        }
    }
}