using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.Windows;

namespace ResxTranslator.ResourceOperations
{
    public class ResourceLoader
    {
        private Thread _dictBuilderThread;
        private volatile bool _requestDictBuilderStop;
        private string _rootPath;

        public ResourceLoader()
        {
            Resources = new Dictionary<string, ResourceHolder>();
            LanguagesInUse = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
        }

        public Dictionary<string, ResourceHolder> Resources { set; get; }
        public Dictionary<string, int> LanguagesInUse { get; }

        public event EventHandler<ResourceLoadProgressEventArgs> ResourceLoadProgress;

        public void SaveAll()
        {
            foreach (var resource in Resources.Values)
            {
                SaveResourceHolder(resource);
            }
        }

        private void StartDictBuilderThread()
        {
            // Make the logic for building the dictionary an anonymous delegate to keep it only callable on the separate thread
            var buildDictionary = (ThreadStart) delegate
            {
                var currentCount = 0;
                var totalCount = Resources.Count;
                var currentTask = "Building language lookup";

                foreach (var res in Resources.Values.TakeWhile(_ => !_requestDictBuilderStop))
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

                foreach (var res in Resources.Values.TakeWhile(_ => !_requestDictBuilderStop))
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

            _dictBuilderThread = new Thread(buildDictionary);
            _dictBuilderThread.Name = "DictBuilder";
            _requestDictBuilderStop = false;

            _dictBuilderThread.Start();
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
            var isDirty = Resources.Values.Any(resource => resource.IsDirty);

            if (isDirty)
            {
                var dialogResult = MessageBox.Show("Do you want save your changes before closing?", "Save Changes",
                    MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    StopDictBuilderThread();
                    SaveAll();
                    return true;
                }
                if (dialogResult == DialogResult.No)
                    return true;
                //Bug? Stops thread even though nothing happened
                StopDictBuilderThread();
                return false;
            }
            StopDictBuilderThread();

            return true;
        }

        protected virtual void OnResourceLoadProgress(ResourceLoadProgressEventArgs e)
        {
            ResourceLoadProgress?.Invoke(this, e);
        }

        public void FindResx(string folder)
        {
            var displayFolder = "";
            if (folder.StartsWith(_rootPath, StringComparison.InvariantCultureIgnoreCase))
            {
                displayFolder = folder.Substring(_rootPath.Length);
            }
            if (displayFolder.StartsWith("\\"))
            {
                displayFolder = displayFolder.Remove(0, 1);
            }

            var files = Directory.GetFiles(folder, "*.resx");

            foreach (var file in files)
            {
                var filenameNoExt = "" + Path.GetFileNameWithoutExtension(file);
                var fileParts = filenameNoExt.Split('.');
                if (fileParts.Length == 0)
                {
                    continue;
                }

                var language = "";
                if (fileParts[fileParts.Length - 1].Length == 5 && fileParts[fileParts.Length - 1][2] == '-')
                {
                    language = fileParts[fileParts.Length - 1];
                }
                else if (fileParts[fileParts.Length - 1].Length == 2)
                {
                    language = fileParts[fileParts.Length - 1];
                }
                if (!string.IsNullOrEmpty(language))
                {
                    filenameNoExt = Path.GetFileNameWithoutExtension(filenameNoExt);
                }

                ResourceHolder resourceHolder;
                var key = (displayFolder + "\\" + filenameNoExt).ToLower();
                if (!Resources.TryGetValue(key, out resourceHolder))
                {
                    resourceHolder = new ResourceHolder();
                    resourceHolder.DisplayFolder = displayFolder;
                    if (string.IsNullOrEmpty(language))
                    {
                        resourceHolder.Filename = file;
                    }
                    resourceHolder.Id = filenameNoExt;

                    Resources.Add(key, resourceHolder);
                }

                if (!string.IsNullOrEmpty(language))
                {
                    if (!LanguagesInUse.ContainsKey(language))
                    {
                        LanguagesInUse[language] = 0;
                    }
                    LanguagesInUse[language] += 1;
                    if (!resourceHolder.Languages.ContainsKey(language.ToLower()))
                    {
                        var languageHolder = new LanguageHolder();
                        languageHolder.Filename = file;
                        languageHolder.Id = language;
                        resourceHolder.Languages.Add(language.ToLower(), languageHolder);
                    }
                }
                else
                {
                    resourceHolder.Filename = file;
                }
            }

            var subfolders = Directory.GetDirectories(folder);
            foreach (var subfolder in subfolders)
            {
                FindResx(subfolder);
            }
        }

        public void OpenProject(string selectedPath)
        {
            StopDictBuilderThread();

            OnResourceLoadProgress(new ResourceLoadProgressEventArgs("Building resource tree"));

            _rootPath = selectedPath;

            Settings.Default.Mrud = _rootPath;
            Settings.Default.Save();


            FindResx(_rootPath);


            OnResourceLoadProgress(new ResourceLoadProgressEventArgs("Building local dictionary"));

            StartDictBuilderThread();
        }
    }
}