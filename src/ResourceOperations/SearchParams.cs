using System.Configuration;
using System.Text.RegularExpressions;

namespace ResxTranslator.ResourceOperations
{
    [SettingsProvider("System.Configuration.LocalFileSettingsProvider")]
    [SettingsGroupName("FindParameters")]
    public class SearchParams : ApplicationSettingsBase
    {
        public enum TargetType
        {
            Lang,
            Key,
            OriginalText,
            TranslatedText,
            File
        }

        private Regex _re;

        public SearchParams()
        {
        }

        public SearchParams(string text, bool searchLanguage, bool searchKeys, bool searchOriginalText, bool searchTranslatedText, bool searchFileName, bool useRegex, bool optCase, bool optWord)
        {
            Text = text;

            SearchLanguage = searchLanguage;
            SearchKeys = searchKeys;
            SearchOriginalText = searchOriginalText;
            SearchTranslatedText = searchTranslatedText;
            SearchFileName = searchFileName;
            UseRegex = useRegex;
            OptCase = optCase;
            OptWord = optWord;
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool OptCase
        {
            get { return (bool)this["optCase"]; }
            set { this["optCase"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool OptWord
        {
            get { return (bool)this["optWord"]; }
            set { this["optWord"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool SearchKeys
        {
            get { return (bool)this["searchKeys"]; }
            set { this["searchKeys"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool SearchLanguage
        {
            get { return (bool)this["searchLanguage"]; }
            set { this["searchLanguage"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool SearchOriginalText
        {
            get { return (bool)this["searchOriginalText"]; }
            set { this["searchOriginalText"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool SearchTranslatedText
        {
            get { return (bool)this["searchTranslatedText"]; }
            set { this["searchTranslatedText"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool SearchFileName
        {
            get { return (bool)this["searchFileName"]; }
            set { this["searchFileName"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string Text
        {
            get { return (string)this["text"]; }
            set { this["text"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool UseRegex
        {
            get { return (bool)this["useRegex"]; }
            set { this["useRegex"] = value; }
        }

        private Regex GetComparator()
        {
            if (UseRegex)
            {
                var pattern = Text;
                if (OptWord)
                {
                    pattern = "\\W" + pattern + "\\W";
                }
                return new Regex(pattern, RegexOptions.Compiled | (OptCase ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
            else
            {
                var pattern = Regex.Escape(Text);
                if (OptWord)
                {
                    pattern = "\\W" + pattern + "\\W";
                }
                return new Regex(pattern, RegexOptions.Compiled | (OptCase ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
        }

        public bool Match(TargetType targType, string matchText)
        {
            if (_re == null)
                _re = GetComparator();

            switch (targType)
            {
                case TargetType.Key: return SearchKeys && _re.IsMatch(matchText);
                case TargetType.Lang: return SearchLanguage && _re.IsMatch(matchText);
                case TargetType.OriginalText: return SearchOriginalText && _re.IsMatch(matchText);
                case TargetType.TranslatedText: return SearchTranslatedText && _re.IsMatch(matchText);
                case TargetType.File: return SearchFileName && _re.IsMatch(matchText);
                default: return false;
            }
        }
    }
}