using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ResxTranslator.Properties;
using ResxTranslator.TranslatorSvc;


namespace ResxTranslator
{
    public static class Common
    {
        public static string GetDefaultValue(string key)
        {
            return String.Format(
                Settings.Default.NonTranslatedString,
                key, key.ToUpper(), key.ToLower());
        }

        public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
            {
                c.BeginInvoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }
    }
}
