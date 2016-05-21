using System;

namespace ResxTranslator.Data
{
    public class DictionaryOperationEventArgs<TKey, TValue> : EventArgs
    {
        public DictionaryOperationEventArgs(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; }
        public TValue Value { get; }
    }
}