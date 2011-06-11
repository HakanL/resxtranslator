using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ResxTranslator
{
    public class SearchParams : ApplicationSettingsBase
    {
        #region TargetType enum
        public enum TargetType
        {
            Lang,
            Key,
            Text
        }
        #endregion

        private bool _optCase;
        private bool _optWord;
        private bool _searchKeys;
        private bool _searchLanguage;
        private bool _searchText;
        private string _text;
        private bool _useRegex;

        private Regex _re=null;

        public SearchParams()
        {
        }

        public SearchParams(
            string text,
            bool searchLanguage,
            bool searchKeys,
            bool searchText,
            bool useRegex,
            bool optCase,
            bool optWord
            )
        {
            this._text = text;

            this._searchLanguage = searchLanguage;
            this._searchKeys = searchKeys;
            this._searchText = searchText;
            this._useRegex = useRegex;
            this._optCase = optCase;
            this._optWord = optWord;
        }

        private void Initialize ()
        {
            if (this._useRegex)
            {
                string pattern = this._text;
                if (this._optWord)
                {
                    pattern = "\\W" + pattern + "\\W";
                }
                this._re = new Regex(pattern, RegexOptions.Compiled | (this._optCase ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
            else
            {
                string pattern = Regex.Escape(this._text);
                if (this._optWord)
                {
                    pattern = "\\W" + pattern + "\\W";
                }
                this._re = new Regex(pattern, RegexOptions.Compiled | (this._optCase ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool OptCase
        {
            get { return this._optCase; }
            set { this._optCase = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool OptWord
        {
            get { return this._optWord; }
            set { this._optWord = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool SearchKeys
        {
            get { return this._searchKeys; }
            set { this._searchKeys = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool SearchLanguage
        {
            get { return this._searchLanguage; }
            set { this._searchLanguage = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool SearchText
        {
            get { return this._searchText; }
            set { this._searchText = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public string Text
        {
            get { return this._text; }
            set { this._text = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool UseRegex
        {
            get { return this._useRegex; }
            set { this._useRegex = value; }
        }

        public bool Match(TargetType targType, string matchText)
        {
            if (_re==null)
                this.Initialize();

            if (targType == TargetType.Key && this._searchKeys && this._re.IsMatch(matchText))
            {
                return true;
            }
            if (targType == TargetType.Lang && this._searchLanguage && this._re.IsMatch(matchText))
            {
                return true;
            }
            if (targType == TargetType.Text && this._searchText && this._re.IsMatch(matchText))
            {
                return true;
            }
            return false;
        }
    }
}