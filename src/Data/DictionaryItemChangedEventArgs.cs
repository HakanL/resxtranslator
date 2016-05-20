namespace ResxTranslator.Data
{
    public class DictionaryItemChangedEventArgs<TKey, TValue> : DictionaryOperationEventArgs<TKey>
    {
        public DictionaryItemChangedEventArgs(TKey key, TValue newValue) : base(key)
        {
            NewValue = newValue;
        }

        public TValue NewValue { get; }
    }
}