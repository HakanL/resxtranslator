using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public class Language
    {
        private string id;


        public Language(string id)
        {
            this.id = id;
        }


        public string Id
        {
            get { return id; }
        }
    }
}
