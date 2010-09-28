using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public class ResourceData
    {
        private Resource parent;
        private string key;
        private string comments;
        private string baseData;
        private Dictionary<string, string> data;


        public ResourceData(Resource parent, string key)
        {
            this.parent = parent;
            this.key = key;
            this.data = new Dictionary<string, string>();
        }


        public string this[string languageId]
        {
            get
            {
                string value;
                if (data.TryGetValue(languageId, out value))
                    return value;

                return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (data.ContainsKey(languageId))
                        data.Remove(languageId);
                }
                else
                    data[languageId] = value;
            }
        }

        public string Key { get { return key; } }
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string BaseData
        {
            get { return baseData; }
            set { baseData = value; }
        }

        public Resource Parent
        {
            get { return parent; }
        }

        public void SetData(string languageId, string data)
        {
            this.data[languageId] = data;
        }
    }
}
