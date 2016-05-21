using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ResxTranslator.Data
{
    /// <summary>
    ///     Contains related IResources and allows easy editing of their localizable strings.
    /// </summary>
    internal class TranslatedResourceGroup : ITranslatable
    {
        private readonly Dictionary<string, TranslatableText> _localizableStrings;

        /// <summary>
        ///     Read-write list of translated resources
        /// </summary>
        public ObservableDictionary<CultureInfo, IResource> Translations { get; }
        
        public TranslatedResourceGroup(IResource defaultTranslation, IDictionary<CultureInfo, IResource> translations)
        {
            Translations = new ObservableDictionary<CultureInfo, IResource>(translations);

            DefaultTranslation = defaultTranslation;

            _localizableStrings = translations.Values.Aggregate(
                defaultTranslation.LocalizableData.Keys.AsEnumerable(),
                (enumerable, resource) => enumerable.Concat(resource.LocalizableData.Keys))
                .Distinct()
                .ToDictionary(keyName => keyName, keyName => new TranslatableText(keyName, this));
            LocalizableStrings = new ReadOnlyDictionaryWrapper<string, TranslatableText>(_localizableStrings);
        }
        
        public IEnumerable<CultureInfo> GetTranslatedLanguages()
        {
            return Translations.Keys;
        }

        public bool HasDefaultTranslation()
        {
            return DefaultTranslation != null;
        }

        public IResource DefaultTranslation { get; }

        public ReadOnlyDictionaryWrapper<string, TranslatableText> LocalizableStrings { get; }

        public void AddLocalizableString(string keyName, string defaultValue,
            IDictionary<CultureInfo, string> translations)
        {
            if (string.IsNullOrWhiteSpace(keyName))
                throw new ArgumentException("Argument is null or whitespace", nameof(keyName));
            if (_localizableStrings.ContainsKey(keyName))
                throw new ArgumentException("Key is already taken");

            var textHolder = new TranslatableText(keyName, this);
            _localizableStrings.Add(keyName, textHolder);

            // Automatically populates values in IResources through added/changed events in TranslatableText
            textHolder.DefaultTranslation = defaultValue;
            foreach (var translation in translations)
            {
                textHolder.Translations.Add(translation.Key, translation.Value);
            }
        }

        /// <summary>
        /// Remove and dispose of the specified localizable string
        /// </summary>
        public bool RemoveLocalizableString(string keyName)
        {
            if (string.IsNullOrWhiteSpace(keyName))
                throw new ArgumentException("Argument is null or whitespace", nameof(keyName));

            TranslatableText output;
            if (!_localizableStrings.TryGetValue(keyName, out output)) return false;

            _localizableStrings.Remove(keyName);
            output.Dispose();

            DefaultTranslation?.LocalizableData.Remove(keyName);
            foreach (var resource in Translations.Values)
            {
                resource.LocalizableData.Remove(keyName);
            }
            return true;
        }
    }
}