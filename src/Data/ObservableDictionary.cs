using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResxTranslator.Data
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _values;

        public ObservableDictionary()
        {
            _values = new Dictionary<TKey, TValue>();
        }

        public ObservableDictionary(IDictionary<TKey, TValue> values)
        {
            _values = new Dictionary<TKey, TValue>(values);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            foreach (var key in _values.Keys)
            {
                Remove(key);
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _values.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _values.AsEnumerable().ToArray().CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public int Count => _values.Count;

        public bool IsReadOnly => false;

        public bool ContainsKey(TKey key)
        {
            return _values.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            _values.Add(key, value);
            OnItemAdded(key, value);
        }

        public bool Remove(TKey key)
        {
            if (!_values.Remove(key)) return false;
            OnItemRemoved(key);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _values.TryGetValue(key, out value);
        }

        public TValue this[TKey key]
        {
            get { return _values[key]; }
            set
            {
                if (Equals(value, _values[key])) return;
                var added = !_values.ContainsKey(key);
                _values[key] = value;
                if(added)
                    OnItemAdded(key, value);
                else
                    OnItemChanged(key, value);
            }
        }

        public ICollection<TKey> Keys => _values.Keys;
        public ICollection<TValue> Values => _values.Values;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _values).GetEnumerator();
        }

        public event EventHandler<DictionaryItemChangedEventArgs<TKey, TValue>> ItemChanged;
        public event EventHandler<DictionaryOperationEventArgs<TKey>> ItemRemoved;
        public event EventHandler<DictionaryItemChangedEventArgs<TKey, TValue>> ItemAdded;

        protected virtual void OnItemChanged(TKey key, TValue newValue)
        {
            ItemChanged?.Invoke(this, new DictionaryItemChangedEventArgs<TKey, TValue>(key, newValue));
        }

        protected virtual void OnItemAdded(TKey key, TValue value)
        {
            ItemAdded?.Invoke(this, new DictionaryItemChangedEventArgs<TKey, TValue>(key, value));
        }

        protected virtual void OnItemRemoved(TKey key)
        {
            ItemRemoved?.Invoke(this, new DictionaryOperationEventArgs<TKey>(key));
        }
    }
}