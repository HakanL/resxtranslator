using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public class Resource
    {
        private string name;
        private string relativeFilename;
        private string dependentUpon;
        private Dictionary<string, ResourceData> resourceData;


        public Resource(string name, string relativeFilename, string dependentUpon)
        {
            this.name = name;
            this.relativeFilename = relativeFilename;
            this.dependentUpon = dependentUpon;

            this.resourceData = new Dictionary<string, ResourceData>();
        }


        public string Name
        {
            get { return name; }
        }


        public Dictionary<string, ResourceData> ResourceData
        {
            get { return resourceData; }
        }


        public bool HasData
        {
            get { return resourceData.Count > 0; }
        }


        public void AddLanguageFile(string languageId, string fullFilename)
        {
            using (System.Resources.ResXResourceReader reader =
                new System.Resources.ResXResourceReader(fullFilename))
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

                    ResourceData data;
                    if (!resourceData.TryGetValue(key, out data))
                    {
                        data = new ResourceData(this, key);
                        resourceData.Add(key, data);
                    }
                    if (string.IsNullOrEmpty(data.Comments) && !string.IsNullOrEmpty(dataNode.Comment))
                        data.Comments = dataNode.Comment;

                    if (string.IsNullOrEmpty(languageId))
                        data.BaseData = value;
                    else
                        data.SetData(languageId, value);
                }
            }

        }
    }
}
