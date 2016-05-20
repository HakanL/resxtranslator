using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ResxTranslator.Data
{
    /// <summary>
    ///     Contains related IResources and allows easy editing of their localizable strings.
    /// </summary>
    internal class TranslatedResourceGroup : IResourceTranslationGroup
    {
        private readonly Dictionary<string, TranslatableText> _localizableStrings;

        public TranslatedResourceGroup(IResource defaultTranslation, IDictionary<CultureInfo, IResource> translations)
        {
            Translations = translations;
            DefaultTranslation = defaultTranslation;

            _localizableStrings = translations.Values.Aggregate(
                defaultTranslation.LocalizableData.Keys.AsEnumerable(),
                (enumerable, resource) => enumerable.Concat(resource.LocalizableData.Keys))
                .Distinct()
                .ToDictionary(keyName => keyName, keyName => new TranslatableText(keyName, this));
        }

        public IDictionary<string, TranslatableText> LocalizableStrings => _localizableStrings;

        public IEnumerable<CultureInfo> GetTranslatedLanguages()
        {
            return Translations.Keys;
        }

        public bool HasDefaultTranslation()
        {
            return DefaultTranslation != null;
        }

        /// <summary>
        ///     Todo Change into a readonly dictionary
        /// </summary>
        public IDictionary<CultureInfo, IResource> Translations { get; }

        public IResource DefaultTranslation { get; }

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

        public bool RemoveLocalizableString(string keyName)
        {
            if (string.IsNullOrWhiteSpace(keyName))
                throw new ArgumentException("Argument is null or whitespace", nameof(keyName));

            if (!_localizableStrings.Remove(keyName)) return false;

            DefaultTranslation?.LocalizableData.Remove(keyName);
            foreach (var resource in Translations.Values)
            {
                resource.LocalizableData.Remove(keyName);
            }
            return true;
        }
    }
}