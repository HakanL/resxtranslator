using System;

namespace ResxTranslator.Tools
{
    public sealed class SettingChangedEventArgs<T> : EventArgs
    {
        internal SettingChangedEventArgs(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NewValue = value;
        }

        public T NewValue { get; }
    }
}