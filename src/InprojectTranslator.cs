using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ResxTranslator
{
    public class InprojectTranslator
    {
        // implementing the InprojectTranslator as a singleton
        private static InprojectTranslator _instance;

        //loading is done in a separate thread, so we need to lock the static's

        // keep track of in wich languages words are used
        private readonly Dictionary<string, Dictionary<string, int>> _languageChecker
                   = new Dictionary<string, Dictionary<string, int>>();
        private readonly object _lockObject = new object();

        // keep track of all translations
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, bool>>>> _lookuptables
                   = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, bool>>>>();
        // i.e. -> Dictionary<FromLanguage, Dictionary<FromText, Dictionary<ToLanguage, Dictonary<TranslatedText,dummy>>>> 

        // To be able to remove all non-characters
        private readonly Regex _reCleanWord = new Regex(@"\P{L}", RegexOptions.Compiled);

        // Can only be instanced by the Instance prop.
        private InprojectTranslator()
        {
        }

        public static InprojectTranslator Instance
        {
            get { return _instance ?? (_instance = new InprojectTranslator()); }
        }

        // add a translation
        /// <summary>
        /// Add a translation to the dictionary
        /// </summary>
        public void AddTranslation(string from, string fromWord, string to, string toWord)
        {
            if (fromWord == toWord)
            {
                return;
            }
            lock (this._lockObject)
            {
                Dictionary<string, bool> tWord = GetTranslatorItem(fromWord, "", to);

                // add translation if new
                if (!tWord.ContainsKey(toWord))
                {
                    tWord[toWord] = true;
                }
            }
        }

        private Dictionary<string, bool> GetTranslatorItem (string fromWord, string from, string to)
        {
            from = (from.Length > 2 ? from.Substring(0, 2) : from).Trim().ToLower();
            to = (to.Length > 2 ? to.Substring(0, 2) : to).Trim().ToLower();
            from = "";

            var language = this._lookuptables.ContainsKey(from)
                               ? this._lookuptables[from]
                               : this._lookuptables[from] = new Dictionary<string, Dictionary<string, Dictionary<string, bool>>>();
            var fWord = language.ContainsKey(fromWord)
                            ? language[fromWord]
                            : language[fromWord] = new Dictionary<string, Dictionary<string, bool>>();
            return fWord.ContainsKey(to)
                       ? fWord[to]
                       : fWord[to] = new Dictionary<string, bool>();
        }

        /// <summary>
        /// Add a string of words to the language checker
        /// </summary>
        public void AddWordsToLanguageChecker(string from, string fromWord)
        {
            string[] words = this.MakeCleanWordArray(ref fromWord);
            from = (from.Length > 2 ? from.Substring(0, 2) : from).Trim().ToLower();

            foreach (string word in words)
            {
                this.AddToLanguageChecker(from, word);
            }
        }

        /// <summary>
        /// Add a string of words to the language checker
        /// </summary>
        public void AddWordsToLanguageChecker(string from, string[] words)
        {
            from = (from.Length > 2 ? from.Substring(0, 2) : from).Trim().ToLower();

            foreach (string word in words)
            {
                this.AddToLanguageChecker(from, word);
            }
        }

        /// <summary>
        /// Return an array of words with all non-word characters removed
        /// </summary>
        private string[] MakeCleanWordArray(ref string fromWord)
        {
            fromWord = this._reCleanWord.Replace(fromWord, " ").ToLower();
            return fromWord.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Add a single word to the language checker
        /// </summary>
        private void AddToLanguageChecker(string lang, string word)
        {
            lock (this._lockObject)
            {
                // remove all non-characters
                word = this._reCleanWord.Replace(word, "");

                if (word == "")
                {
                    return;
                }

                Dictionary<string, int> wordDict = this._languageChecker.ContainsKey(word)
                                                       ? this._languageChecker[word]
                                                       : this._languageChecker[word] = new Dictionary<string, int>();
                lang = lang.ToLower();
                if (!wordDict.ContainsKey(lang))
                {
                    wordDict[lang] = 0;
                }
                wordDict[lang] += 1;
            }
        }

        /// <summary>
        /// Evaluate a number of words, try to guess what language it is
        /// </summary>
        public string CheckLanguage(string sentence)
        {
            lock (this._lockObject)
            {
                string[] words = this.MakeCleanWordArray(ref sentence);

                // try to check language of each word, count number of words of each language
                // giving a list of languages and counts ordered by most frequent first

                var result = words
                    .Select(w => new { Language = this.CheckLanguageOfWord(w) })
                    .Where(x => x.Language.Key != "")
                    .OrderByDescending(x => x.Language.Value)
                    .GroupBy(y => y.Language.Value)
                    .Select(x =>
                            new
                                {
                                    LangCnt = x.Key
                                    ,
                                    Languages = x.GroupBy(y => new
                                                                   {
                                                                       y.Language.Key,
                                                                       y.Language.Value
                                                                   }).OrderByDescending(z => z.Count()).ToList()
                                })
                    .OrderBy(x => x.LangCnt)
                    .ToList();

                if (result.Count() == 0)
                {
                    return ""; // no, didn't find any
                }

                if (result[0].LangCnt == 1)
                {
                    return result[0].Languages[0].Key.Key.Trim();
                }

                return ""; // no, didn't find a conclusive descision
            }
        }


        /// <summary>
        /// Evaluate language of a single word
        /// </summary>
        private KeyValuePair<string, int> CheckLanguageOfWord(string word)
        {
            lock (this._lockObject)
            {
                // remove all non-characters
                word = this._reCleanWord.Replace(word, " ");
                if (word == "")
                {
                    // nothing left -> no language
                    return new KeyValuePair<string, int>("", 0);
                }

                if (!this._languageChecker.ContainsKey(word))
                {
                    // never seen this word -> no language
                    return new KeyValuePair<string, int>("", 0);
                }

                // assume it is the language where it is most frequently used
                var list = this._languageChecker[word];
                if (list.Count==0)
                {
                    return new KeyValuePair<string, int>("", 0);
                }

                KeyValuePair<string, int> ret=new KeyValuePair<string, int>("", 0);
                foreach(var x in list)
                {
                    if (ret.Value < x.Value )
                        ret = x;
                }

                ret = new KeyValuePair<string, int>(ret.Key, list.Count); //Number of diffent languages where found

                return ret;
            }
        }


        // Get a list of previous translations
        /// <summary>
        /// Get previous translations of a text
        /// </summary>
        public List<string> GetTranslations(string from, string fromSentence, string to)
        {
            lock (this._lockObject)
            {
                from = (from.Length > 2 ? from.Substring(0, 2) : from).Trim().ToLower();
                to = (to.Length > 2 ? to.Substring(0, 2) : to).Trim().ToLower();
                from = "";

                var language = this._lookuptables.ContainsKey(from)
                                ? this._lookuptables[from]
                                : this._lookuptables[from] = new Dictionary<string, Dictionary<string, Dictionary<string, bool>>>();
                
                var fWord = language.ContainsKey(fromSentence)
                                ? language[fromSentence]
                                : language[fromSentence] = new Dictionary<string, Dictionary<string, bool>>();

                List<string> toSentence = (fWord.ContainsKey(to)
                                              ? fWord[to]
                                              : fWord[to] = new Dictionary<string, bool>()).Keys.ToList();

                return toSentence;
            }
        }

        /// <summary>
        /// remove all words found in the second string from the first
        /// </summary>
        public string[] RemoveWords(string nontranslated, string translated)
        {
            var wordsNonTr = this.MakeCleanWordArray(ref nontranslated).ToLookup(k => k, e => true, StringComparer.InvariantCultureIgnoreCase);
            string[] wordsTr = this.MakeCleanWordArray(ref translated);

            string[] rest = (from tr in wordsTr
                             where wordsNonTr.Contains(tr) == false
                             select tr).ToArray();
            if (rest.Length * 20 < wordsTr.Length)
                return wordsTr;
            return rest;
        }
    }
}