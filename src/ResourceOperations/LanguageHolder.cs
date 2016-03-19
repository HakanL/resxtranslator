using System.Globalization;

namespace ResxTranslator.ResourceOperations
{
    public class LanguageHolder
    {
        public LanguageHolder(string languageId, string filename)
        {
            LanguageId = languageId;
            Filename = filename;
        }

        private string _languageId;

        public string LanguageId
        {
            get { return _languageId; }
            set
            {
                CultureInfo = CultureInfo.GetCultureInfo(value);
                _languageId = value;
            }
        }

        public string Filename { get; set; }

        public CultureInfo CultureInfo { get; private set; }

        public override string ToString()
        {
            return LanguageId;
        }
    }
}