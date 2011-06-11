using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace ResxTranslator
{
    public class ResourceHolder
    {
        private bool dirty;
        private DataTable stringsTable;
        private readonly object lockObject = new object();
        public ResourceHolder()
        {
            this.Languages = new SortedDictionary<string, LanguageHolder>();
            this.Dirty = false;
        }

        public string Filename { get; set; }
        public string DisplayFolder { get; set; }
        public string Id { get; set; }
        public SortedDictionary<string, LanguageHolder> Languages { get; private set; }

        public DataTable StringsTable
        {
            get
            {
                lock (lockObject)
                {
                    if (this.stringsTable == null)
                    {
                        this.LoadResource();
                    }
                    return this.stringsTable;
                }
            }
            private set
            {
                lock (lockObject)
                { this.stringsTable = value; }
            }
        }

        public bool IsDirty
        {
            get
            {
                if (this.stringsTable == null)
                {
                    return false;
                }

                return this.Dirty;
            }
        }

        public EventHandler DirtyChanged = null;
        public bool Dirty
        {
            get { return this.dirty; }
            set
            {
                if (value != dirty)
                {
                    this.dirty = value;
                    if (DirtyChanged != null)
                    {
                        DirtyChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public EventHandler LanguageChange = null;
        private string _noLanguageLanguage = "";
        /// <summary>
        /// The educated guess of the language code for the non translated column
        /// </summary>
        public string NoLanguageLanguage
        {
            get
            {
                string oldLanguage = _noLanguageLanguage;
                if (string.IsNullOrEmpty(_noLanguageLanguage))
                    NoLanguageLanguage = FindDefaultLanguage();
                return this._noLanguageLanguage;
            }
            set
            {
                if (value != _noLanguageLanguage)
                {
                    this._noLanguageLanguage = value;
                    OnLanguageChange();
                }
            }
        }

        /// <summary>
        /// Text shown in the tree view for this resourceholder
        /// </summary>
        public string Caption
        {
            get
            {
                string languages = Languages.Keys.Aggregate(
                    ""
                    , (agg, curr) => agg + "," + curr
                    , agg => (agg.Length > 2 ? agg.Substring(1) : ""));

                return string.Format("{0} [{1}] ({2})", Id, _noLanguageLanguage, languages);
            }
        }

        /// <summary>
        /// Trigger LanguageChange event when default language is set
        /// </summary>
        private void OnLanguageChange()
        {
            if (this.LanguageChange != null)
                this.LanguageChange(this, EventArgs.Empty);
        }

        /// <summary>
        /// Evaluate the non translated langauage using the InprojectTranslator or Bing
        /// </summary>
        private string FindDefaultLanguage()
        {
            if (this.StringsTable == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();

            //collect a few entries to decide language of default version
            foreach (DataRow row in this.StringsTable.Rows)
            {
                //Ignore too short entries
                if (row["NoLanguageValue"].ToString().Trim().Length > 5)
                {
                    sb.Append(". ");
                    sb.Append(row["NoLanguageValue"].ToString().Trim());
                }
            }

            //first try the internal dictionary.
            string lang = InprojectTranslator.Instance.CheckLanguage(sb.ToString());

            // if nothing found, use Bing
            if (lang == "")
            {
                return BingTranslator.GetDefaultLanguage(this);
            }
            else
            {
                return lang;
            }
        }


        /// <summary>
        /// Save one resource file
        /// </summary>
   private void UpdateFile(string filename, string valueColumn)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

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

                string key = dataNode.Attributes["name"].Value;
                DataRow[] rows = this.stringsTable.Select("Key = '" + key + "'");
                if (rows.Length > 0)
                {
                    bool anyData = false;
                    if (rows[0][valueColumn] == DBNull.Value || string.IsNullOrEmpty((string)rows[0][valueColumn]))
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
                        bool found = false;
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                        {
                            if (childNode.Name == "value")
                            {
                                childNode.InnerText = (string)rows[0][valueColumn];
                                found = true;
                                break;
                            }
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
                        bool found = false;
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

            XmlNode rootNode = xmlDoc.SelectSingleNode("/root");
            foreach (XmlNode deleteNode in nodesToBeDeleted)
            {
                rootNode.RemoveChild(deleteNode);
            }

            foreach (DataRow row in this.stringsTable.Rows)
            {
                var key = (string)row["Key"];
                if (!usedKeys.Contains(key))
                {
                    // Add
                    XmlNode newNode = xmlDoc.CreateElement("data");
                    XmlAttribute newAttribute = xmlDoc.CreateAttribute("name");
                    newAttribute.Value = key;
                    newNode.Attributes.Append(newAttribute);

                    newAttribute = xmlDoc.CreateAttribute("xml:space");
                    newAttribute.Value = "preserve";
                    newNode.Attributes.Append(newAttribute);

                    bool anyData = false;
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
        /// Save this resource holders data
        /// </summary>
        public void Save()
        {
            this.UpdateFile(this.Filename, "NoLanguageValue");

            foreach (LanguageHolder languageHolder in this.Languages.Values)
            {
                this.UpdateFile(languageHolder.Filename, languageHolder.Id);
            }
            this.Dirty = false;
        }

        /// <summary>
        /// Read one resource fil
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
                    var key = (string)de.Key;
                    if (key.StartsWith(">>") || key.StartsWith("$"))
                    {
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

                    string valueType = dataNode.GetValueTypeName((ITypeResolutionService)null);
                    if (!valueType.StartsWith("System.String, "))
                    {
                        continue;
                    }

                    object valueObject = dataNode.GetValue((ITypeResolutionService)null);
                    string value = valueObject == null ? "" : "" + valueObject;

                    // Was used to cleanup leftovers from old VS designer
                    //if (reCleanup.IsMatch(value))
                    //{
                    //    value = reCleanup.Replace(value, "");
                    //    this.Dirty = true;
                    //}

                    DataRow[] existingRows = stringsTable.Select("Key = '" + key + "'");
                    if (existingRows.Length == 0)
                    {
                        DataRow newRow = stringsTable.NewRow();
                        newRow["Key"] = key;

                        newRow[valueColumn] = value;

                        newRow["Comment"] = dataNode.Comment;
                        newRow["Error"] = false;
                        newRow["Translated"] = isTranslated && !string.IsNullOrEmpty(value);
                        stringsTable.Rows.Add(newRow);
                    }
                    else
                    {
                        existingRows[0][valueColumn] = value;

                        if (string.IsNullOrEmpty((string)existingRows[0]["Comment"]) &&
                            !string.IsNullOrEmpty(dataNode.Comment))
                        {
                            existingRows[0]["Comment"] = dataNode.Comment;
                        }
                        if (isTranslated && !string.IsNullOrEmpty(value))
                        {
                            existingRows[0]["Translated"] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets error field on the row depending on missing translations etc
        /// </summary>
        public void EvaluateRow(DataRow row)
        {
            string defaultValue = "";
            if (row["NoLanguageValue"] != DBNull.Value
                && !string.IsNullOrEmpty((string)row["NoLanguageValue"]))
            {
                defaultValue = row["NoLanguageValue"].ToString();
            }

            bool foundOne = false;
            bool oneMissing = false;
            foreach (LanguageHolder languageHolder in this.Languages.Values)
            {
                string value = null;
                if (row[languageHolder.Id] != DBNull.Value)
                {
                    value = (string)row[languageHolder.Id];
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
                             string.IsNullOrEmpty((string)row["NoLanguageValue"])))
            {
                row["Error"] = true;
                return;
            }

            row["Error"] = false;
        }

        /// <summary>
        /// Read the resource files correspondning with this resource holder
        /// </summary>
        public void LoadResource()
        {
            lock (lockObject)
            {

                this.stringsTable = new DataTable("Strings");

                this.stringsTable.Columns.Add("Key");
                this.stringsTable.Columns.Add("NoLanguageValue");
                foreach (LanguageHolder languageHolder in this.Languages.Values)
                {
                    this.stringsTable.Columns.Add(languageHolder.Id);
                }
                this.stringsTable.Columns.Add("Comment");
                this.stringsTable.Columns.Add("Translated", typeof(bool));
                this.stringsTable.Columns.Add("Error", typeof(bool));

                if (!string.IsNullOrEmpty(this.Filename))
                {
                    this.ReadResourceFile(this.Filename, this.stringsTable, "NoLanguageValue", false);
                }
                foreach (LanguageHolder languageHolder in this.Languages.Values)
                {
                    this.ReadResourceFile(languageHolder.Filename, this.stringsTable, languageHolder.Id, true);
                }

                if (this.Languages.Count > 0)
                {
                    foreach (DataRow row in this.stringsTable.Rows)
                    {
                        this.EvaluateRow(row);
                    }
                }

                this.stringsTable.ColumnChanging += this.stringsTable_ColumnChanging;
                this.stringsTable.ColumnChanged += this.stringsTable_ColumnChanged;
                this.stringsTable.RowDeleted += this.stringsTable_RowDeleted;
                this.stringsTable.TableNewRow += this.stringsTable_RowInserted;
            }
            OnLanguageChange();

        }

        /// <summary>
        /// Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            this.Dirty = true;
        }

        /// <summary>
        /// Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_RowInserted(object sender, DataTableNewRowEventArgs e)
        {
            this.Dirty = true;
        }

        /// <summary>
        /// Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column != e.Column.Table.Columns["Error"])
            {
                this.Dirty = true;
                this.EvaluateRow(e.Row);
            }
        }

        /// <summary>
        /// Eventhandler for the datatable of strings
        /// </summary>
        private void stringsTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == e.Column.Table.Columns["Key"])
            {
                DataRow[] foundRows = e.Column.Table.Select("Key='" + e.ProposedValue + "'");
                if (foundRows.Count() > 1
                    || (foundRows.Count() == 1 && foundRows[0] != e.Row))
                {
                    e.Row["Error"] = true;
                    throw new DuplicateNameException(e.Row["Key"].ToString());
                }
                this.Dirty = true;
            }
        }

        /// <summary>
        /// Add one key
        /// </summary>
        public void AddString(string key, string noXlateValue, string defaultValue)
        {
            if (this.KeyExists(key))
            {
                throw new DuplicateNameException(key);
            }

            DataRow row = this.stringsTable.NewRow();
            row["Key"] = key;
            row["NoLanguageValue"] = noXlateValue;
            foreach (LanguageHolder languageHolder in this.Languages.Values)
            {
                row[languageHolder.Id] = defaultValue;
            }
            row["Comment"] = "";
            this.stringsTable.Rows.Add(row);
        }

        /// <summary>
        /// Check if such a key exists.
        /// </summary>
        public bool KeyExists(string key)
        {
            return this.stringsTable.Select("Key = '" + key + "'").Length > 0;
        }

        /// <summary>
        /// Add the specified language to this object
        /// </summary>
        public void AddLanguage(string languageCode)
        {
            if (!this.Languages.ContainsKey(languageCode.ToLower()))
            {
                this.Dirty = true;
                var mainfile = new FileInfo(this.Filename);
                string newFile = mainfile.Name.Substring(0, mainfile.Name.Length - mainfile.Extension.Length) + "." + languageCode + mainfile.Extension;
                newFile = mainfile.Directory.FullName + "\\" + newFile;
                mainfile.CopyTo(newFile);
                var languageHolder = new LanguageHolder();
                languageHolder.Filename = newFile;
                languageHolder.Id = languageCode;
                this.Languages.Add(languageCode.ToLower(), languageHolder);

                this.stringsTable.Columns.Add(languageCode.ToLower());

                this.ReadResourceFile(languageHolder.Filename, this.stringsTable, languageHolder.Id, true);

                if (this.Languages.Count > 0)
                {
                    foreach (DataRow row in this.stringsTable.Rows)
                    {
                        this.EvaluateRow(row);
                    }
                }
                OnLanguageChange();

            }
        }

        /// <summary>
        /// Auto translate all non-translated text in this object
        /// </summary>
        public void AutoTranslate()
        {
            foreach (LanguageHolder languageHolder in this.Languages.Values)
            {
                BingTranslator.AutoTranslate(this, languageHolder.Id);
            }
        }

        /// <summary>
        /// Delete a language from this object (including its file)
        /// </summary>
        public void DeleteLanguage(string languageCode)
        {
            if (this.Languages.ContainsKey(languageCode.ToLower()))
            {
                var mainfile = new FileInfo(this.Filename);
                string newFile = mainfile.Name.Substring(0, mainfile.Name.Length - mainfile.Extension.Length) + "." + languageCode + mainfile.Extension;
                newFile = mainfile.Directory.FullName + "\\" + newFile;
                (new FileInfo(newFile)).Delete();
                this.Languages.Remove(languageCode.ToLower());

                OnLanguageChange();
            }
        }

        /// <summary>
        /// Revert all non saved changes and reload
        /// </summary>
        public void Revert()
        {
            this.StringsTable = null;
            this.LoadResource();

            OnLanguageChange();
        }
    }
}