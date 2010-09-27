using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxManager
{
    public class ResourceData
    {
        private string key;
        private string comments;
        private string baseData;
        private Dictionary<string, string> data;


        public ResourceData(string key)
        {
            this.key = key;
            this.data = new Dictionary<string, string>();
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

        public void SetData(string languageId, string data)
        {
            this.data[languageId] = data;
        }
    }
}
