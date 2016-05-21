namespace ResxTranslator.Data
{
    public class DictionaryItemChangedEventArgs<TKey, TValue> : DictionaryOperationEventArgs<TKey, TValue>
    {
        public DictionaryItemChangedEventArgs(TKey key, TValue newValue, TValue oldValue) : base(key, newValue)
        {
            OldValue = oldValue;
        }

        public TValue OldValue { get; }
    }
}