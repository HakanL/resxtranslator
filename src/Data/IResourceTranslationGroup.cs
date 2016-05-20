using System.Collections.Generic;
using System.Globalization;

namespace ResxTranslator.Data
{
    /// <summary>
    ///     Group consisting of a base resource and its translations
    /// </summary>
    internal interface IResourceTranslationGroup : ITranslatable
    {
        /// <summary>
        ///     Translations of the DefaultTranslation resource
        /// </summary>
        IDictionary<CultureInfo, IResource> Translations { get; }

        /// <summary>
        ///     Base resource used as a template for the translations
        /// </summary>
        IResource DefaultTranslation { get; }
    }
}