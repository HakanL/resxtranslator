using System;

namespace ResxTranslator.Data
{
    public class DictionaryOperationEventArgs<TKey> : EventArgs
    {
        public DictionaryOperationEventArgs(TKey key)
        {
            Key = key;
        }

        public TKey Key { get; }
    }
}