using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ResxTranslator
{
    [SettingsProvider("System.Configuration.LocalFileSettingsProvider")]
    [SettingsGroupName("FindParameters")]
    public class SearchParams : ApplicationSettingsBase
    {
        #region TargetType enum
        public enum TargetType
        {
            Lang,
            Key,
            Text,
            File
        }
        #endregion

        private Regex _re;

        public SearchParams()
        {
        }

        public SearchParams(string text
            , bool searchLanguage
            , bool searchKeys
            , bool searchText
            , bool searchFileName
            , bool useRegex
            , bool optCase
            , bool optWord)
        {
            this.Text = text;

            this.SearchLanguage = searchLanguage;
            this.SearchKeys = searchKeys;
            this.SearchText = searchText;
            this.SearchFileName = searchFileName;
            this.UseRegex = useRegex;
            this.OptCase = optCase;
            this.OptWord = optWord;
        }

        private void Initialize()
        {
            if (this.UseRegex  )
            {
                string pattern = this.Text;
                if (this.OptWord)
                {
                    pattern = "\\W" + pattern + "\\W";
                }
                this._re = new Regex(pattern, RegexOptions.Compiled | (this.OptCase ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
            else
            {
                string pattern = Regex.Escape(this.Text);
                if (this.OptWord)
                {
                    pattern = "\\W" + pattern + "\\W";
                }
                this._re = new Regex(pattern, RegexOptions.Compiled | (this.OptCase ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
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
            get { return (bool) this["optWord"]; }
            set { this["optWord"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool SearchKeys
        {
            get { return (bool) this["searchKeys"]; }
            set { this["searchKeys"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool SearchLanguage
        {
            get { return (bool) this["searchLanguage"]; }
            set { this["searchLanguage"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool SearchText
        {
            get { return (bool) this["searchText"]; }
            set { this["searchText"] = value; }
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
            get { return (string) this["text"]; }
            set { this["text"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool UseRegex
        {
            get { return (bool) this["useRegex"]; }
            set { this["useRegex"] = value; }
        }

        public bool Match(TargetType targType, string matchText)
        {
            if (_re == null)
                this.Initialize();

            if (targType == TargetType.Key && this.SearchKeys && this._re.IsMatch(matchText))
            {
                return true;
            }
            if (targType == TargetType.Lang && this.SearchLanguage && this._re.IsMatch(matchText))
            {
                return true;
            }
            if (targType == TargetType.Text && this.SearchText && this._re.IsMatch(matchText))
            {
                return true;
            }
            if (targType == TargetType.File && this.SearchFileName && this._re.IsMatch(matchText))
            {
                return true;
            }
            return false;
        }
    }
}