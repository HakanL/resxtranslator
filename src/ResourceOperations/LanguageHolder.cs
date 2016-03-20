using System.Globalization;

namespace ResxTranslator.ResourceOperations
{
    public class LanguageHolder
    {
        private string _languageId;

        public LanguageHolder(string languageId, string filename)
        {
            LanguageId = languageId;
            Filename = filename;
        }

        public CultureInfo CultureInfo { get; private set; }

        public string Filename { get; set; }

        public string LanguageId
        {
            get { return _languageId; }
            set
            {
                CultureInfo = CultureInfo.GetCultureInfo(value);
                _languageId = value;
            }
        }

        public override string ToString()
        {
            return LanguageId;
        }
    }
}