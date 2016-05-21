using System;
using System.Collections.Generic;
using System.Resources;

namespace ResxTranslator.Data
{
    public interface IResource : IDisposable
    {
        /// <summary>
        ///     Filename of the resource file
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        ///     Metadata present in this resource
        /// </summary>
        IDictionary<string, object> Metadata { get; }

        /// <summary>
        ///     Data that is possible to translate
        /// </summary>
        ObservableDictionary<string, string> LocalizableData { get; }

        /// <summary>
        ///     Data that doesn't fall under any other category, e.g. images, points, sizes
        /// </summary>
        IDictionary<string, ResXDataNode> OtherData { get; }

        /// <summary>
        ///     Fired if the resource has been changed by an external application
        /// </summary>
        event EventHandler ChangedExternally;

        /// <summary>
        ///     Reload the resource
        /// </summary>
        void Reload();

        /// <summary>
        ///     Write the resource to specified Filename
        /// </summary>
        void Write();
    }
}