using System;
using System.Windows.Forms;
using ResxTranslator.Properties;

namespace ResxTranslator
{
    public static class Common
    {
        public static string GetDefaultValue(string key)
        {
            return string.Format(
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