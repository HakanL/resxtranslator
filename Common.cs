using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ResxTranslator
{
    public static class Common
    {
        public static string GetDefaultValue(string key)
        {
            return string.Format(
                Properties.Settings.Default.NonTranslatedString,
                key, key.ToUpper(), key.ToLower());
        }

    }
}
