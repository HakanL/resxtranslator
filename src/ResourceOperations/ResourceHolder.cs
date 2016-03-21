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
using ResxTranslator.Tools;

namespace ResxTranslator.ResourceOperations
{
    public class ResourceHolder
    {
        private readonly object _lockObject = new object();
        private Dictionary<string, bool> _deletedKeys;
        private bool _dirty;
        private string _noLanguageLanguage = string.Empty;
        private DataTable _stringsTable;
        public event EventHandler DirtyChanged;
        public event EventHandler LanguageChange;

        public ResourceHolder()
        {
            Languages = new SortedDictionary<string, LanguageHolder>();
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

        public bool IsDirty => _stringsTable != null && Dirty;

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
                var languages = string.Join(",", Languages.Keys.OrderBy(x => x));

                return $"{Id} ({languages})"; //[{_noLanguageLanguage}]
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
                return string.Empty;

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
            return string.IsNullOrEmpty(lang) ? BingTranslator.GetDefaultLanguage(this) : lang;
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
                var key = dataNode.Attributes?["name"].Value;
                if (key == null || !_deletedKeys.ContainsKey(key)) continue;

                // Only support strings - don't want to delete other random resources
                if (dataNode.Attributes["type"] == null)
                {
                    rootNode.RemoveChild(dataNode);
                }
            }

            var usedKeys = new HashSet<string>();
            var nodesToBeDeleted = new List<XmlNode>();
            foreach (XmlNode dataNode in xmlDoc.SelectNodes("/root/data"))
            {
                // Only support strings with names
                if (dataNode.Attributes["type"] != null || dataNode.Attributes["name"] == null)
                    continue;

                var key = dataNode.Attributes["name"].Value;
                var rows = _stringsTable.Select("Key = '" + key + "'");
                if (rows.Length > 0)
                {
                    var anyData = false;
                    if (rows[0][valueColumn] == DBNull.Value || string.IsNullOrEmpty((string)rows[0][valueColumn]))
                    {
                        // Delete value
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                        {
                            if (childNode.Name == "value")
                            {
                                childNode.InnerText = string.Empty;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Add/update
                        anyData = true;
                        var found = false;
                        foreach (var childNode in dataNode.ChildNodes.Cast<XmlNode>().Where(childNode => childNode.Name == "value"))
                        {
                            childNode.InnerText = (string)rows[0][valueColumn];
                            found = true;
                            break;
                        }
                        if (!found)
                        {
                            // Add
                            XmlNode newNode = xmlDoc.CreateElement("value");
                            newNode.InnerText = (string)rows[0][valueColumn];
                            dataNode.AppendChild(newNode);
                        }
                    }


                    if (rows[0]["Comment"] == DBNull.Value || string.IsNullOrEmpty((string)rows[0]["Comment"]))
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
                                childNode.InnerText = (string)rows[0]["Comment"];
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            // Add
                            XmlNode newNode = xmlDoc.CreateElement("comment");
                            newNode.InnerText = (string)rows[0]["Comment"];
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
                var key = (string)row["Key"];
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
                    if (row["Comment"] != DBNull.Value && !string.IsNullOrEmpty((string)row["Comment"]))
                    {
                        XmlNode newComment = xmlDoc.CreateElement("comment");
                        newComment.InnerText = (string)row["Comment"];
                        newNode.AppendChild(newComment);
                        anyData = true;
                    }

                    if (row[valueColumn] != DBNull.Value && !string.IsNullOrEmpty((string)row[valueColumn]))
                    {
                        XmlNode newValue = xmlDoc.CreateElement("value");
                        newValue.InnerText = (string)row[valueColumn];
                        newNode.AppendChild(newValue);
                        anyData = true;
                    }
                    else if (anyData)
                    {
                        XmlNode newValue = xmlDoc.CreateElement("value");
                        newValue.InnerText = string.Empty;
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
        ///     Read one resource file
        /// </summary>
        private void ReadResourceFile(string filename, DataTable stringsTable,
            string valueColumn, bool isTranslated)
        {
            using (var reader = new ResXResourceReader(filename))
            {
                reader.UseResXDataNodes = true;
                foreach (DictionaryEntry de in reader)
                {
                    if (!IsLocalizableString(de))
                        continue;

                    var key = (string)de.Key;
                    var dataNode = (ResXDataNode)de.Value;
                    var value = dataNode.GetValueAsString();
                    
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

                        if (string.IsNullOrEmpty((string)r["Comment"]) &&
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
        /// Check if the entry contains a localizable string
        /// </summary>
        /// <param name="data">Data entry to be checked. Requires ResXResourceReader.UseResXDataNodes = true</param>
        private static bool IsLocalizableString(DictionaryEntry data)
        {
            var key = (string)data.Key;

            if ((key.StartsWith(">>") || key.StartsWith("$")) && key != "$this.Text")
                return false;

            var dataNode = data.Value as ResXDataNode;
            if (dataNode == null)
                return false;
            if (dataNode.FileRef != null)
                return false;

            var valueType = dataNode.GetValueTypeName((ITypeResolutionService)null);
            return valueType.StartsWith("System.String, ");
        }

        /// <summary>
        ///     Sets error field on the row depending on missing translations etc
        /// </summary>
        public void EvaluateRow(DataRow row)
        {
            foreach (var languageHolder in Languages.Values)
            {
                if (!RowContainsTranslation(row, languageHolder.LanguageId))
                {
                    // Some translations are missing
                    row["Error"] = true;
                    return;
                }
                if (row["NoLanguageValue"] == DBNull.Value || string.IsNullOrEmpty((string)row["NoLanguageValue"]))
                {
                    // There are translations but the main key is missing
                    row["Error"] = true;
                    return;
                }
            }

            row["Error"] = false;
        }

        private static bool RowContainsTranslation(DataRow row, string languageId)
        {
            if (row[languageId] == DBNull.Value)
                return false;

            var value = (string)row[languageId];
            return !string.IsNullOrWhiteSpace(value) && !(value.StartsWith("[") && value.TrimEnd().EndsWith("]"));
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
                _stringsTable.PrimaryKey = new[] { _stringsTable.Columns["Key"] };
                _stringsTable.Columns.Add("NoLanguageValue");
                foreach (var languageHolder in Languages.Values)
                {
                    _stringsTable.Columns.Add(languageHolder.LanguageId);
                }
                _stringsTable.Columns.Add("Comment");
                _stringsTable.Columns.Add("Translated", typeof(bool));
                _stringsTable.Columns.Add("Error", typeof(bool));

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
            row["Comment"] = string.Empty;
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
        public void AddLanguage(string languageCode, bool copyValues)
        {
            if (Languages.ContainsKey(languageCode.ToLower()))
                return;

            // Create the file
            var cleanFilename = Filename.Substring(0, Filename.LastIndexOf('.'));
            var newFilename = $"{cleanFilename}.{languageCode}.resx";
            File.Delete(newFilename);

            using (var writer = new ResXResourceWriter(newFilename))
            {
                if (copyValues)
                {
                    using (var reader = new ResXResourceReader(Filename))
                    {
                        reader.UseResXDataNodes = true;
                        foreach (DictionaryEntry de in reader)
                        {
                            if(!IsLocalizableString(de))
                                continue;

                            var node = (ResXDataNode) de.Value;
                            var value = node.GetValueAsString();
                            // Skip saving unnecessary items
                            if (!string.IsNullOrWhiteSpace(value))
                                writer.AddResource((string)de.Key, value);
                        }
                    }
                }
                writer.Generate();
            }

            // Add the created file to this ResourceHolder
            var languageHolder = new LanguageHolder(languageCode, newFilename);
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

            Dirty = true;
            OnLanguageChange();
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
                File.Delete(Languages[languageCode.ToLower()].Filename);

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

        public bool HasMissingTranslations(string cultureName)
        {
            return !Languages.ContainsKey(cultureName) ||
                _stringsTable.Rows.Cast<DataRow>().Any(row => !RowContainsTranslation(row, cultureName));
        }
    }
}