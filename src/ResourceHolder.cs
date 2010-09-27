using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;


namespace ResxTranslator
{
    public class ResourceHolder
    {
        private DataTable stringsTable;
        private bool dirty;

        public string Filename { get; set; }
        public string DisplayFolder { get; set; }
        public string Id { get; set; }
        public Dictionary<string, LanguageHolder> Languages { get; private set; }

        public DataTable StringsTable
        {
            get
            {
                if (stringsTable == null)
                    LoadResource();
                return stringsTable;
            }
            private set
            {
                stringsTable = value;
            }
        }

        public ResourceHolder()
        {
            Languages = new Dictionary<string, LanguageHolder>();
            dirty = false;
        }

        public bool IsDirty
        {
            get
            {
                if (stringsTable == null)
                    return false;

                return dirty;
            }
        }

        private void UpdateFile(string filename, string valueColumn)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            HashSet<string> usedKeys = new HashSet<string>();
            List<XmlNode> nodesToBeDeleted = new List<XmlNode>();
            foreach (XmlNode dataNode in xmlDoc.SelectNodes("/root/data"))
            {
                if (dataNode.Attributes["type"] != null)
                    // Only support strings
                    continue;

                if (dataNode.Attributes["name"] == null)
                    // Missing name
                    continue;

                string key = dataNode.Attributes["name"].Value;
                DataRow[] rows = stringsTable.Select("Key = '" + key + "'");
                if (rows.Length > 0)
                {
                    bool anyData = false;
                    if (rows[0][valueColumn] == DBNull.Value || string.IsNullOrEmpty((string)rows[0][valueColumn]))
                    {
                        // Delete value
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                            if (childNode.Name == "value")
                            {
                                childNode.InnerText = "";
                                break;
                            }
                    }
                    else
                    {
                        // Add/update
                        anyData = true;
                        bool found = false;
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                            if (childNode.Name == "value")
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
                            if (childNode.Name == "comment")
                            {
                                dataNode.RemoveChild(childNode);
                                break;
                            }
                    }
                    else
                    {
                        // Add/update
                        anyData = true;
                        bool found = false;
                        foreach (XmlNode childNode in dataNode.ChildNodes)
                            if (childNode.Name == "comment")
                            {
                                childNode.InnerText = (string)rows[0]["Comment"];
                                found = true;
                                break;
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

            foreach (DataRow row in stringsTable.Rows)
            {
                string key = (string)row["Key"];
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
                        xmlDoc.SelectSingleNode("/root").AppendChild(newNode);
                }
            }

            xmlDoc.Save(filename);
        }

        public void Save()
        {
            UpdateFile(Filename, "NoLanguageValue");

            foreach (LanguageHolder languageHolder in Languages.Values)
            {
                UpdateFile(languageHolder.Filename, languageHolder.Id);
            }
            dirty = false;
        }

        private void ReadResourceFile(string filename, DataTable stringsTable,
            string valueColumn, bool isTranslated)
        {
            using (System.Resources.ResXResourceReader reader =
                new System.Resources.ResXResourceReader(filename))
            {
                reader.UseResXDataNodes = true;
                foreach (DictionaryEntry de in reader)
                {
                    string key = (string)de.Key;
                    if (key.StartsWith(">>") || key.StartsWith("$"))
                        continue;

                    System.Resources.ResXDataNode dataNode = de.Value as System.Resources.ResXDataNode;
                    if (dataNode == null)
                        continue;
                    if (dataNode.FileRef != null)
                        continue;

                    string valueType = dataNode.GetValueTypeName((System.ComponentModel.Design.ITypeResolutionService)null);
                    if (!valueType.StartsWith("System.String, "))
                        continue;

                    object valueObject = dataNode.GetValue((System.ComponentModel.Design.ITypeResolutionService)null);
                    string value = valueObject == null ? "" : valueObject.ToString();

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
                            existingRows[0]["Comment"] = dataNode.Comment;
                        if (isTranslated && !string.IsNullOrEmpty(value))
                            existingRows[0]["Translated"] = true;
                    }
                }
            }
        }

        public void EvaluateRow(DataRow row)
        {
            bool foundOne = false;
            bool oneMissing = false;
            foreach (LanguageHolder languageHolder in Languages.Values)
            {
                string value = null;
                if (row[languageHolder.Id] != DBNull.Value)
                    value = (string)row[languageHolder.Id];
                if (!string.IsNullOrEmpty(value))
                    foundOne = true;
                if (string.IsNullOrEmpty(value) || value.StartsWith("[") && value.Contains("]"))
                    oneMissing = true;
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

        public void LoadResource()
        {
            stringsTable = new DataTable("Strings");

            stringsTable.Columns.Add("Key");
            stringsTable.Columns.Add("NoLanguageValue");
            foreach (LanguageHolder languageHolder in Languages.Values)
            {
                stringsTable.Columns.Add(languageHolder.Id);
            }
            stringsTable.Columns.Add("Comment");
            stringsTable.Columns.Add("Translated", typeof(bool));
            stringsTable.Columns.Add("Error", typeof(bool));

            if (!string.IsNullOrEmpty(Filename))
                ReadResourceFile(Filename, stringsTable, "NoLanguageValue", false);
            foreach (LanguageHolder languageHolder in Languages.Values)
            {
                ReadResourceFile(languageHolder.Filename, stringsTable, languageHolder.Id, true);
            }

            if (Languages.Count > 0)
            {
                foreach (DataRow row in stringsTable.Rows)
                    EvaluateRow(row);
            }

            stringsTable.ColumnChanged += new DataColumnChangeEventHandler(stringsTable_ColumnChanged);
            stringsTable.RowDeleted += new DataRowChangeEventHandler(stringsTable_RowDeleted);
        }

        private void stringsTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            dirty = true;
        }

        private void stringsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column != e.Column.Table.Columns["Error"])
            {
                dirty = true;
                EvaluateRow(e.Row);
            }
        }

        public void AddString(string key, string noXlateValue, string defaultValue)
        {
            if (KeyExists(key))
                throw new DuplicateNameException(key);

            DataRow row = stringsTable.NewRow();
            row["Key"] = key;
            row["NoLanguageValue"] = noXlateValue;
            foreach (LanguageHolder languageHolder in Languages.Values)
            {
                row[languageHolder.Id] = defaultValue;
            }
            row["Comment"] = "";
            stringsTable.Rows.Add(row);
        }

        public bool KeyExists(string key)
        {
            return stringsTable.Select("Key = '" + key + "'").Length > 0;
        }
    }

}
