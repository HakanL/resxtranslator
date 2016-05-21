using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ResxTranslator.Data
{
    internal class TranslatableText : ITranslatable, IDisposable
    {
        private TranslatedResourceGroup _resources;

        private ObservableDictionary<CultureInfo, string> _translations;
        private string _defaultTranslation;

        public TranslatableText(string keyName, TranslatedResourceGroup resources)
        {
            if (keyName == null) throw new ArgumentNullException(nameof(keyName));
            if (resources == null) throw new ArgumentNullException(nameof(resources));

            KeyName = keyName;
            _resources = resources;

            _resources.Translations.ItemAdded += TranslationsOnItemAddedChanged;
            _resources.Translations.ItemChanged += TranslationsOnItemAddedChanged;
            _resources.Translations.ItemRemoved += TranslationsOnItemRemoved;

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
            _translations.ItemAdded += (sender, args) => OnTranslationAdded(args.Key, args.Value);
            _translations.ItemRemoved += (sender, args) => OnTranslationRemoved(args.Key, args.Value);
            _translations.ItemChanged += (sender, args) => OnTranslationChanged(args.Key, args.Value, args.OldValue);
        }

        private void TranslationsOnItemRemoved(object sender, DictionaryOperationEventArgs<CultureInfo, IResource> dictionaryOperationEventArgs)
        {
            SetTranslationByCulture(dictionaryOperationEventArgs.Key, null);
        }

        private void TranslationsOnItemAddedChanged(object sender, DictionaryOperationEventArgs<CultureInfo, IResource> dictionaryOperationEventArgs)
        {
            var resource = dictionaryOperationEventArgs.Value;

            resource.LocalizableData.ItemAdded += LocalizableDataOnItemChanged;
            resource.LocalizableData.ItemRemoved += LocalizableDataOnItemRemoved;
            resource.LocalizableData.ItemChanged += LocalizableDataOnItemChanged;

            if (resource.LocalizableData.ContainsKey(KeyName))
                SetTranslationByCulture(dictionaryOperationEventArgs.Key, resource.LocalizableData[KeyName]);
        }

        public IDictionary<CultureInfo, string> Translations => _translations;

        public string KeyName { get; }

        public string DefaultTranslation
        {
            get
            {
                if (Disposed) throw new ObjectDisposedException(nameof(TranslatableText));

                return _defaultTranslation;
            }
            set
            {
                if (Disposed) throw new ObjectDisposedException(nameof(TranslatableText));

                if (!Equals(_defaultTranslation, value))
                {
                    var previous = _defaultTranslation;
                    _defaultTranslation = value;
                    OnTranslationChanged(null, value, previous);
                }
            }
        }

        public IEnumerable<CultureInfo> GetTranslatedLanguages()
        {
            if (Disposed) throw new ObjectDisposedException(nameof(TranslatableText));

            return _translations.Keys;
        }

        public bool HasDefaultTranslation()
        {
            if (Disposed) throw new ObjectDisposedException(nameof(TranslatableText));

            return DefaultTranslation != null;
        }

        private static readonly CultureInfo DefaultTranslationCultureInfo = CultureInfo.InvariantCulture;
        private CultureInfo FindResourceCulture(object sender)
        {
            return sender == _resources.DefaultTranslation ?
                DefaultTranslationCultureInfo :
                _resources.Translations.SingleOrDefault(x => sender.Equals(x.Value)).Key;
        }

        /*private string GetTranslationByCulture(CultureInfo culture)
        {
            if (culture == null)
                return null;
            if (Equals(culture, DefaultTranslationCultureInfo))
                return DefaultTranslation;
            return Translations.ContainsKey(culture) ? Translations[culture] : null;
        }*/

        private void SetTranslationByCulture(CultureInfo culture, string translation)
        {
            if (culture == null)
                return;
            if (Equals(culture, DefaultTranslationCultureInfo))
                DefaultTranslation = translation;

            if (translation == null)
                Translations.Remove(culture);
            else
                Translations[culture] = translation;
        }

        private void LocalizableDataOnItemChanged(object sender,
            DictionaryOperationEventArgs<string, string> dictionaryOperationEventArgs)
        {
            if (dictionaryOperationEventArgs.Key.Equals(KeyName))
            {
                SetTranslationByCulture(FindResourceCulture(sender), dictionaryOperationEventArgs.Value);
            }
        }

        private void LocalizableDataOnItemRemoved(object sender,
            DictionaryOperationEventArgs<string, string> dictionaryOperationEventArgs)
        {
            if (dictionaryOperationEventArgs.Key.Equals(KeyName))
            {
                SetTranslationByCulture(FindResourceCulture(sender), null);
            }
        }

        public string GetTranslation(CultureInfo language)
        {
            if (Disposed) throw new ObjectDisposedException(nameof(TranslatableText));

            if (language == null) return DefaultTranslation;
            string output;
            return _translations.TryGetValue(language, out output) ? output : null;
        }

        /// <summary>
        ///     Fires when a translation is changed. If the default value is changed the Key is null.
        /// </summary>
        public event EventHandler<DictionaryItemChangedEventArgs<CultureInfo, string>> TranslationChanged;

        public event EventHandler<DictionaryOperationEventArgs<CultureInfo, string>> TranslationRemoved;
        public event EventHandler<DictionaryOperationEventArgs<CultureInfo, string>> TranslationAdded;

        protected virtual void OnTranslationChanged(CultureInfo language, string newValue, string oldValue)
        {
            TranslationChanged?.Invoke(this, new DictionaryItemChangedEventArgs<CultureInfo, string>(language, newValue, oldValue));
        }

        protected virtual void OnTranslationRemoved(CultureInfo language, string oldValue)
        {
            TranslationRemoved?.Invoke(this, new DictionaryOperationEventArgs<CultureInfo, string>(language, oldValue));
        }

        protected virtual void OnTranslationAdded(CultureInfo language, string newValue)
        {
            TranslationAdded?.Invoke(this, new DictionaryOperationEventArgs<CultureInfo, string>(language, newValue));
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;

            TranslationAdded = null;
            TranslationChanged = null;
            TranslationRemoved = null;

            _resources.Translations.ItemAdded -= TranslationsOnItemAddedChanged;
            _resources.Translations.ItemChanged -= TranslationsOnItemAddedChanged;
            _resources.Translations.ItemRemoved -= TranslationsOnItemRemoved;
            _resources.DefaultTranslation.LocalizableData.ItemAdded -= LocalizableDataOnItemChanged;
            _resources.DefaultTranslation.LocalizableData.ItemRemoved -= LocalizableDataOnItemRemoved;
            _resources.DefaultTranslation.LocalizableData.ItemChanged -= LocalizableDataOnItemChanged;

            foreach (var translation in _resources.Translations)
            {
                translation.Value.LocalizableData.ItemAdded -= LocalizableDataOnItemChanged;
                translation.Value.LocalizableData.ItemRemoved -= LocalizableDataOnItemRemoved;
                translation.Value.LocalizableData.ItemChanged -= LocalizableDataOnItemChanged;
            }

            _resources = null;
            _translations = null;
        }
    }
}