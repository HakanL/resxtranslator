using System.Collections.Generic;
using System.Globalization;

namespace ResxTranslator.Data
{
    internal interface ITranslatable
    {
        /// <summary>
        ///     Get all languages this object has translations for
        /// </summary>
        IEnumerable<CultureInfo> GetTranslatedLanguages();

        /// <summary>
        ///     Check if a default translation is present
        /// </summary>
        bool HasDefaultTranslation();
    }
}