using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ResxTranslator.Data
{
    /// <summary>
    ///     Todo unsubscribe from events by implementing IDisposable
    /// </summary>
    internal class TranslatableText : ITranslatable
    {
        private readonly IResourceTranslationGroup _resources;

        private readonly ObservableDictionary<CultureInfo, string> _translations;
        private string _defaultTranslation;

        public TranslatableText(string keyName, IResourceTranslationGroup resources)
        {
            if (keyName == null) throw new ArgumentNullException(nameof(keyName));
            if (resources == null) throw new ArgumentNullException(nameof(resources));

            KeyName = keyName;
            _resources = resources;

            string output;
            if (resources.DefaultTranslation.LocalizableData.TryGetValue(keyName, out output))
                DefaultTranslation = output;
            resources.DefaultTranslation.LocalizableData.ItemAdded += LocalizableDataOnItemChanged;
            resources.DefaultTranslation.LocalizableData.ItemRemoved += LocalizableDataOnItemRemoved;
            resources.DefaultTranslation.LocalizableData.ItemChanged += LocalizableDataOnItemChanged;

            var results = new Dictionary<CultureInfo, string>();
            foreach (var translation in resources.Translations)
            {
                if (translation.Value.LocalizableData.TryGetValue(keyName, out output))
                {
                    results.Add(translation.Key, output);
                    translation.Value.LocalizableData.ItemAdded += LocalizableDataOnItemChanged;
                    translation.Value.LocalizableData.ItemRemoved += LocalizableDataOnItemRemoved;
                    translation.Value.LocalizableData.ItemChanged += LocalizableDataOnItemChanged;
                }
            }

            _translations = new ObservableDictionary<CultureInfo, string>(results);
            _translations.ItemAdded += (sender, args) => OnTranslationAdded(args.Key, args.NewValue);
            _translations.ItemRemoved += (sender, args) => OnTranslationRemoved(args.Key);
            _translations.ItemChanged += (sender, args) => OnTranslationChanged(args.Key, args.NewValue);
        }

        public IDictionary<CultureInfo, string> Translations => _translations;

        public string KeyName { get; }

        public string DefaultTranslation
        {
            get { return _defaultTranslation; }
            set
            {
                if (!Equals(_defaultTranslation, value))
                {
                    _defaultTranslation = value;
                    OnTranslationChanged(null, value);
                }
            }
        }

        public IEnumerable<CultureInfo> GetTranslatedLanguages()
        {
            return _translations.Keys;
        }

        public bool HasDefaultTranslation()
        {
            return DefaultTranslation != null;
        }

        private void LocalizableDataOnItemChanged(object sender,
            DictionaryItemChangedEventArgs<string, string> dictionaryItemChangedEventArgs)
        {
            if (dictionaryItemChangedEventArgs.Key.Equals(KeyName))
            {
                if (sender.Equals(_resources.DefaultTranslation))
                {
                    DefaultTranslation = dictionaryItemChangedEventArgs.NewValue;
                }
                else
                {
                    var resource = _resources.Translations.SingleOrDefault(x => sender.Equals(x.Value));
                    if (!Equals(resource, default(KeyValuePair<CultureInfo, IResource>)))
                        Translations[resource.Key] = dictionaryItemChangedEventArgs.NewValue;
                }
            }
        }

        private void LocalizableDataOnItemRemoved(object sender,
            DictionaryOperationEventArgs<string> dictionaryOperationEventArgs)
        {
            if (dictionaryOperationEventArgs.Key.Equals(KeyName))
            {
                if (sender.Equals(_resources.DefaultTranslation))
                {
                    DefaultTranslation = null;
                }
                else
                {
                    var resource = _resources.Translations.SingleOrDefault(x => sender.Equals(x.Value));
                    if (!Equals(resource, default(KeyValuePair<CultureInfo, IResource>)))
                        Translations.Remove(resource.Key);
                }
            }
        }

        public string GetTranslation(CultureInfo language)
        {
            if (language == null) return DefaultTranslation;
            string output;
            return _translations.TryGetValue(language, out output) ? output : null;
        }

        /// <summary>
        ///     Fires when a translation is changed. If the default value is changed the Key is null.
        /// </summary>
        public event EventHandler<DictionaryItemChangedEventArgs<CultureInfo, string>> TranslationChanged;

        public event EventHandler<DictionaryOperationEventArgs<CultureInfo>> TranslationRemoved;
        public event EventHandler<DictionaryItemChangedEventArgs<CultureInfo, string>> TranslationAdded;

        protected virtual void OnTranslationChanged(CultureInfo language, string newValue)
        {
            TranslationChanged?.Invoke(this, new DictionaryItemChangedEventArgs<CultureInfo, string>(language, newValue));
        }

        protected virtual void OnTranslationRemoved(CultureInfo language)
        {
            TranslationRemoved?.Invoke(this, new DictionaryOperationEventArgs<CultureInfo>(language));
        }

        protected virtual void OnTranslationAdded(CultureInfo language, string newValue)
        {
            TranslationAdded?.Invoke(this, new DictionaryItemChangedEventArgs<CultureInfo, string>(language, newValue));
        }
    }
}