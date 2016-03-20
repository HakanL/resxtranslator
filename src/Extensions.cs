using System;
using System.Windows.Forms;

namespace ResxTranslator
{
    public static class Extensions
    {
        public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
                c.BeginInvoke(new Action(() => action(c)));
            else
                action(c);
        }
    }
}