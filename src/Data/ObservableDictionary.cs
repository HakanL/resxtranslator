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
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            foreach (var key in _values.Keys.ToList())
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
            TValue output;
            if (!_values.TryGetValue(key, out output)) return false;
            if (!_values.Remove(key)) return false;
            OnItemRemoved(key, output);
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
                TValue output;
                if (!_values.TryGetValue(key, out output))
                {
                    _values[key] = value;
                    OnItemAdded(key, value);
                }

                if (Equals(value, output)) return;

                _values[key] = value;
                OnItemChanged(key, value, output);
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
        public event EventHandler<DictionaryOperationEventArgs<TKey, TValue>> ItemRemoved;
        public event EventHandler<DictionaryOperationEventArgs<TKey, TValue>> ItemAdded;

        protected virtual void OnItemChanged(TKey key, TValue newValue, TValue oldValue)
        {
            ItemChanged?.Invoke(this, new DictionaryItemChangedEventArgs<TKey, TValue>(key, newValue, oldValue));
        }

        protected virtual void OnItemAdded(TKey key, TValue value)
        {
            ItemAdded?.Invoke(this, new DictionaryOperationEventArgs<TKey, TValue>(key, value));
        }

        protected virtual void OnItemRemoved(TKey key, TValue value)
        {
            ItemRemoved?.Invoke(this, new DictionaryOperationEventArgs<TKey, TValue>(key, value));
        }
    }
}