using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml;
using ResxTranslator.Windows;

namespace ResxTranslator.ResourceOperations
{
    public class ResourceHolder
    {
        private readonly object _lockObject = new object();
        private Dictionary<string, bool> _deletedKeys;
        private bool _dirty;
        private string _noLanguageLanguage = "";
        private DataTable _stringsTable;
        public EventHandler DirtyChanged;
        public EventHandler LanguageChange;

        public ResourceHolder()
        {
            Languages = new SortedDictionary<string, LanguageHolder>();
            _deletedKeys = new Dictionary<string, bool>();
            Dirty = false;
            _deletedKeys = new Dictionary<string, bool>();
        }

        public string Filename { get; set; }
        public string DisplayFolder { get; set; }
        public string Id { get; set; }
        public SortedDictionary<string, LanguageHolder> Languages { get; }

        public DataTable StringsTable
        {
            get
            {
                lock (_lockObject)
                {
                    if (_stringsTable == null)
                    {
                        LoadResource();
                    }
                    return _stringsTable;
                }
            }
            private set
            {
                lock (_lockObject)
                {
                    _stringsTable = value;
                }
            }
        }

        public bool IsDirty
        {
            get
            {
                if (_stringsTable == null)
                {
                    return false;
                }

                return Dirty;
            }
        }

        public bool Dirty
        {
            get { return _dirty; }
            set
            {
                if (value != _dirty)
                {
                    _dirty = value;
                    DirtyChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     The educated guess of the language code for the non translated column
        /// </summary>
        public string NoLanguageLanguage
        {
            get
            {
                if (string.IsNullOrEmpty(_noLanguageLanguage))
                {
                    NoLanguageLanguage = FindDefaultLanguage();
                }
                return _noLanguageLanguage;
            }
            set
            {
                if (value != _noLanguageLanguage)
                {
                    _noLanguageLanguage = value;
                    OnLanguageChange();
                }
            }
        }

        /// <summary>
        ///     Text shown in the tree view for this resourceholder
        /// </summary>
        public string Caption
        {
            get
            {
                var languages = Languages.Keys.Aggregate(
                    ""
                    , (agg, curr) => agg + "," + curr
                    , agg => agg.Length > 2 ? agg.Substring(1) : "");

                return $"{Id} [{_noLanguageLanguage}] ({languages})";
            }
        }

        /// <summary>
        ///     Trigger LanguageChange event when default language is set
        /// </summary>
        private void OnLanguageChange()
        {
            LanguageChange?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Evaluate the non translated langauage using the InprojectTranslator or Bing
        /// </summary>
        private string FindDefaultLanguage()
        {
            if (StringsTable == null)
            {
                return "";
            }
            var sb = new StringBuilder();

            //collect a few entries to decide language of default version
            foreach (DataRow row in StringsTable.Rows)
            {
                //Ignore too short entries
                if (row["NoLanguageValue"].ToString().Trim().Length > 5)
                {
                    sb.Append(". ");
                    sb.Append(row["NoLanguageValue"].ToString().Trim());
                }
            }

            //first try the internal dictionary.
            var lang = InprojectTranslator.Instance.CheckLanguage(sb.ToString());

            // if nothing found, use Bing
            return lang == "" ? BingTranslator.GetDefaultLanguage(this) : lang;
        }


        /// <summary>
        ///     Save one resource file
        /// </summary>
        private void UpdateFile(string filename, string valueColumn)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var rootNode = xmlDoc.SelectSingleNode("/root");

            // first delete all nodes that have been deleted
            // if they since have been added the new ones will be saved later on

            foreach (XmlNode dataNode in xmlDoc.SelectNodes("/root/data"))
            {
                var key = dataNode.Attributes["name"].Value;
                if (_deletedKeys.ContainsKey(key))
                {
                    if (dataNode.Attributes["type"] != null)
                    {
                        // Only support strings don't want to delete random other resource
                        continue;
                    }
                    rootNode.RemoveChild(dataNode);
                }
            }


            var usedKeys = new HashSet<string>();
            var nodesToBeDeleted = new List<XmlNode>();
            foreach (XmlNode dataNode in xmlDoc.SelectNodes("/root/data"))
            {
                if (dataNode.Attributes["type"] != null)
                {
                    // Only support strings
                    continue;
                }

                if (dataNode.Attributes["name"] == null)
                {
                    // Missing name
                    continue;
                }

                var key = dataNode.Attributes["name"].Value;
                var rows = _stringsTable.Select("Key = '" + key + "'");
                if (rows.Length > 0)
                {
                    var anyData = false;
                    if (rows[0][valueColumn] == DBNull.Value || string.IsNullOrEmpty((string) rows[0][valueColumn]))
                    {
                        // Delete value
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                        {
                            if (childNode.Name == "value")
                            {
                                childNode.InnerText = "";
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Add/update
                        anyData = true;
                        var found = false;
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                        {
                            if (childNode.Name == "value")
                            {
                                childNode.InnerText = (string) rows[0][valueColumn];
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            // Add
                            XmlNode newNode = xmlDoc.CreateElement("value");
                            newNode.InnerText = (string) rows[0][valueColumn];
                            dataNode.AppendChild(newNode);
                        }
                    }


                    if (rows[0]["Comment"] == DBNull.Value || string.IsNullOrEmpty((string) rows[0]["Comment"]))
                    {
                        // Delete comment
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                        {
                            if (childNode.Name == "comment")
                            {
                                dataNode.RemoveChild(childNode);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Add/update
                        anyData = true;
                        var found = false;
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                        {
                            if (childNode.Name == "comment")
                            {
                                childNode.InnerText = (string) rows[0]["Comment"];
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            // Add
                            XmlNode newNode = xmlDoc.CreateElement("comment");
                            newNode.InnerText = (string) rows[0]["Comment"];
                            dataNode.AppendChild(newNode);
                        }
                    }

                    if (!anyData)
                    {
                        // Remove
                        nodesToBeDeleted.Add(dataNode);
                    }

                    usedKeys.Add(key);
                }
            }

            foreach (var deleteNode in nodesToBeDeleted)
            {
                rootNode.RemoveChild(deleteNode);
            }

            foreach (DataRow row in _stringsTable.Rows)
            {
                var key = (string) row["Key"];
                if (!usedKeys.Contains(key))
                {
                    // Add
                    XmlNode newNode = xmlDoc.CreateElement("data");
                    var newAttribute = xmlDoc.CreateAttribute("name");
                    newAttribute.Value = key;
                    newNode.Attributes.Append(newAttribute);

                    newAttribute = xmlDoc.CreateAttribute("xml:space");
                    newAttribute.Value = "preserve";
                    newNode.Attributes.Append(newAttribute);

                    var anyData = false;
                    if (row["Comment"] != DBNull.Value && !string.IsNullOrEmpty((string) row["Comment"]))
                    {
                        XmlNode newComment = xmlDoc.CreateElement("comment");
                        newComment.InnerText = (string) row["Comment"];
                        newNode.AppendChild(newComment);
                        anyData = true;
                    }

                    if (row[valueColumn] != DBNull.Value && !string.IsNullOrEmpty((string) row[valueColumn]))
                    {
                        XmlNode newValue = xmlDoc.CreateElement("value");
                        newValue.InnerText = (string) row[valueColumn];
                        newNode.AppendChild(newValue);
                        anyData = true;
                    }
                    else if (anyData)
                    {
                        XmlNode newValue = xmlDoc.CreateElement("value");
                        newValue.InnerText = "";
                        newNode.AppendChild(newValue);
                    }

                    if (anyData)
                    {
                        xmlDoc.SelectSingleNode("/root").AppendChild(newNode);
                    }
                }
            }

            xmlDoc.Save(filename);
        }

        /// <summary>
        ///     Save this resource holders data
        /// </summary>
        public void Save()
        {
            UpdateFile(Filename, "NoLanguageValue");

            foreach (var languageHolder in Languages.Values)
            {
                UpdateFile(languageHolder.Filename, languageHolder.LanguageId);
            }
            Dirty = false;
        }

        /// <summary>
        ///     Read one resource fil
        /// </summary>
        private void ReadResourceFile(string filename, DataTable stringsTable,
            string valueColumn, bool isTranslated)
        {
            // Regex reCleanup = new Regex(@"__designer:mapid="".+?""");
            using (var reader =
                new ResXResourceReader(filename))
            {
                reader.UseResXDataNodes = true;
                foreach (DictionaryEntry de in reader)
                {
                    var key = (string) de.Key;
                    if (key.StartsWith(">>") || key.StartsWith("$"))
                    {
                        if (key != "$this.Text")
                            continue;
                    }

                    var dataNode = de.Value as ResXDataNode;
                    if (dataNode == null)
                    {
                        continue;
                    }
                    if (dataNode.FileRef != null)
                    {
                        continue;
                    }

                    var valueType = dataNode.GetValueTypeName((ITypeResolutionService) null);
                    if (!valueType.StartsWith("System.String, "))
                    {
                        continue;
                    }

                    var valueObject = dataNode.GetValue((ITypeResolutionService) null);
                    var value = valueObject == null ? "" : "" + valueObject;

                    // Was used to cleanup leftovers from old VS designer
                    //if (reCleanup.IsMatch(value))
                    //{
                    //    value = reCleanup.Replace(value, "");
                    //    this.Dirty = true;
                    //}


                    var r = FindByKey(key);
                    if (r == null)
                    {
                        var newRow = stringsTable.NewRow();
                        newRow["Key"] = key;

                        newRow[valueColumn] = value;

                        newRow["Comment"] = dataNode.Comment;
                        newRow["Error"] = false;
                        newRow["Translated"] = isTranslated && !string.IsNullOrEmpty(value);
                        stringsTable.Rows.Add(newRow);
                    }
                    else
                    {
                        r[valueColumn] = value;

                        if (string.IsNullOrEmpty((string) r["Comment"]) &&
                            !string.IsNullOrEmpty(dataNode.Comment))
                        {
                            r["Comment"] = dataNode.Comment;
                        }
                        if (isTranslated && !string.IsNullOrEmpty(value))
                        {
                            r["Translated"] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Sets error field on the row depending on missing translations etc
        /// </summary>
        public void EvaluateRow(DataRow row)
        {
            var foundOne = false;
            var oneMissing = false;
            foreach (var languageHolder in Languages.Values)
            {
                string value = null;
                if (row[languageHolder.LanguageId] != DBNull.Value)
                {
                    value = (string) row[languageHolder.LanguageId];
                    if (!string.IsNullOrEmpty(value))
                    {
                        foundOne = true;
                    }
                }

                if (string.IsNullOrEmpty(value) || value.StartsWith("[") && value.Contains("]"))
                {
                    oneMissing = true;
                }
            }

            if (foundOne && oneMissing)
            {
                row["Error"] = true;
                return;
            }

            if (foundOne && (row["NoLanguageValue"] == DBNull.Value ||
                             string.IsNullOrEmpty((string) row["NoLanguageValue"])))
            {
                row["Error"] = true;
                return;
            }

            row["Error"] = false;
        }

        /// <summary>
        ///     Read the resource files correspondning with this resource holder
        /// </summary>
        public void LoadResource()
        {
            lock (_lockObject)
            {
                _deletedKeys = new Dictionary<string, bool>();

                _stringsTable = new DataTable("Strings");

                _stringsTable.Columns.Add("Key");
                _stringsTable.PrimaryKey = new[] {_stringsTable.Columns["Key"]};
                _stringsTable.Columns.Add("NoLanguageValue");
                foreach (var languageHolder in Languages.Values)
                {
                    _stringsTable.Columns.Add(languageHolder.LanguageId);
                }
                _stringsTable.Columns.Add("Comment");
                _stringsTable.Columns.Add("Translated", typeof (bool));
                _stringsTable.Columns.Add("Error", typeof (bool));

                if (!string.IsNullOrEmpty(Filename))
                {
                    ReadResourceFile(Filename, _stringsTable, "NoLanguageValue", false);
                }
                foreach (var languageHolder in Languages.Values)
                {
                    ReadResourceFile(languageHolder.Filename, _stringsTable, languageHolder.LanguageId, true);
                }

                if (Languages.Count > 0)
                {
                    foreach (DataRow row in _stringsTable.Rows)
                    {
                        EvaluateRow(row);
                    }
                }

                _stringsTable.ColumnChanging += stringsTable_ColumnChanging;
                _stringsTable.ColumnChanged += stringsTable_ColumnChanged;
                _stringsTable.RowDeleting += stringsTable_RowDeleting;
                _stringsTable.TableNewRow += stringsTable_RowInserted;
            }
            OnLanguageChange();
        }

        /// <summary>
        ///     Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            _deletedKeys[e.Row["Key"].ToString()] = true;
            Dirty = true;
        }

        /// <summary>
        ///     Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_RowInserted(object sender, DataTableNewRowEventArgs e)
        {
            Dirty = true;
        }

        /// <summary>
        ///     Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column != e.Column.Table.Columns["Error"])
            {
                Dirty = true;
                EvaluateRow(e.Row);
            }
        }

        /// <summary>
        ///     Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == e.Column.Table.Columns["Key"])
            {
                var foundRows = e.Column.Table.Select("Key='" + e.ProposedValue + "'");
                if (foundRows.Length > 1
                    || (foundRows.Length == 1 && foundRows[0] != e.Row))
                {
                    e.Row["Error"] = true;
                    throw new DuplicateNameException(e.Row["Key"].ToString());
                }
                Dirty = true;
            }
        }

        /// <summary>
        ///     Add one key
        /// </summary>
        public void AddString(string key, string noXlateValue, string defaultValue)
        {
            if (FindByKey(key) != null)
            {
                throw new DuplicateNameException(key);
            }

            var row = _stringsTable.NewRow();
            row["Key"] = key;
            row["NoLanguageValue"] = noXlateValue;
            foreach (var languageHolder in Languages.Values)
            {
                row[languageHolder.LanguageId] = defaultValue;
            }
            row["Comment"] = "";
            _stringsTable.Rows.Add(row);
        }

        /// <summary>
        ///     Check if such a key exists.
        /// </summary>
        public DataRow FindByKey(string key)
        {
            return _stringsTable.Rows.Find(key);
        }

        /// <summary>
        ///     Add the specified language to this object
        /// </summary>
        public void AddLanguage(string languageCode)
        {
            if (!Languages.ContainsKey(languageCode.ToLower()))
            {
                Dirty = true;
                var mainfile = new FileInfo(Filename);
                var newFile = mainfile.Name.Substring(0, mainfile.Name.Length - mainfile.Extension.Length) + "." +
                              languageCode + mainfile.Extension;
                newFile = mainfile.Directory.FullName + "\\" + newFile;
                mainfile.CopyTo(newFile);
                var languageHolder = new LanguageHolder(languageCode, newFile);
                Languages.Add(languageCode.ToLower(), languageHolder);

                _stringsTable.Columns.Add(languageCode.ToLower());

                ReadResourceFile(languageHolder.Filename, _stringsTable, languageHolder.LanguageId, true);

                if (Languages.Count > 0)
                {
                    foreach (DataRow row in _stringsTable.Rows)
                    {
                        EvaluateRow(row);
                    }
                }
                OnLanguageChange();
            }
        }

        /// <summary>
        ///     Auto translate all non-translated text in this object
        /// </summary>
        public void AutoTranslate()
        {
            foreach (var languageHolder in Languages.Values)
            {
                BingTranslator.AutoTranslate(this, languageHolder.LanguageId);
            }
        }

        /// <summary>
        ///     Delete a language from this object (including its file)
        /// </summary>
        public void DeleteLanguage(string languageCode)
        {
            if (Languages.ContainsKey(languageCode.ToLower()))
            {
                var mainfile = new FileInfo(Filename);
                var newFile = mainfile.Name.Substring(0, mainfile.Name.Length - mainfile.Extension.Length) + "." +
                              languageCode + mainfile.Extension;
                newFile = mainfile.Directory.FullName + "\\" + newFile;
                new FileInfo(newFile).Delete();
                Languages.Remove(languageCode.ToLower());
                _stringsTable.Columns.RemoveAt(_stringsTable.Columns[languageCode].Ordinal);

                OnLanguageChange();
            }
        }

        /// <summary>
        ///     Revert all non saved changes and reload
        /// </summary>
        public void Revert()
        {
            StringsTable = null;
            LoadResource();
            Dirty = false;
            _deletedKeys = new Dictionary<string, bool>();

            OnLanguageChange();
        }
    }
}