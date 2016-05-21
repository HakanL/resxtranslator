using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Resources;
using ResxTranslator.Tools;

namespace ResxTranslator.Data
{
    public class ResxResource : IResource
    {
        public ResxResource()
        {
            Metadata = new Dictionary<string, object>();
            LocalizableData = new ObservableDictionary<string, string>();
            OtherData = new Dictionary<string, ResXDataNode>();
        }

        /// <summary>
        /// Read Resx file from the specified filename
        /// </summary>
        public ResxResource(string filename) : this()
        {
            Filename = filename;
            Read();
        }

        public void Close()
        {
            ((IDisposable)this).Dispose();
        }

        void IDisposable.Dispose()
        {
            _fileSystemWatcher?.Dispose();
            Metadata.Clear();
            OtherData.Clear();
            LocalizableData.Clear();
        }

        public string Filename { get; set; }

        public IDictionary<string, object> Metadata { get; }
        public ObservableDictionary<string, string> LocalizableData { get; }
        public IDictionary<string, ResXDataNode> OtherData { get; }

        private FileSystemWatcher _fileSystemWatcher;

        public event EventHandler ChangedExternally;

        public void Read()
        {
            var filename = Filename;
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename is null or empty");
            
            if (!File.Exists(filename))
                throw new FileNotFoundException("Filename doesn't point to an existing file", filename);

            // Check if we have read permissions
            File.OpenRead(filename).Dispose();

            _fileSystemWatcher?.Dispose();

            Metadata.Clear();
            OtherData.Clear();
            LocalizableData.Clear();

            try
            {
                // Read metadata
                using (var reader = new ResXResourceReader(filename,
                    AppDomain.CurrentDomain.GetAssemblies().Select(x => x.GetName()).ToArray()))
                {
                    // Set base path so that relative paths work
                    reader.BasePath = Path.GetDirectoryName(filename);

                    // If UseResXDataNodes == true before you call GetMetadataEnumerator, no resource nodes are retrieved
                    var metadataEnumerator = reader.GetMetadataEnumerator();
                    while (metadataEnumerator.MoveNext())
                    {
                        Metadata.Add((string)metadataEnumerator.Key, metadataEnumerator.Value);
                    }
                }

                // Read localizable data and other data
                using (var reader = new ResXResourceReader(filename))
                {
                    // If GetMetadataEnumerator was already called setting the UseResXDataNodes to true will have no effect
                    // Because of this creating a new reader is necessary
                    reader.UseResXDataNodes = true;
                    var dataEnumerator = reader.GetEnumerator();
                    while (dataEnumerator.MoveNext())
                    {
                        var key = (string)dataEnumerator.Key;
                        // GetEnumerator will also get metadata items, filter them out
                        if (Metadata.ContainsKey(key)) continue;

                        var value = (ResXDataNode)dataEnumerator.Value;

                        if (IsLocalizableString(key, value))
                            LocalizableData.Add(key, value.GetValueAsString());
                        else
                            OtherData.Add(key, value);
                    }
                }
            }
            catch
            {
                Metadata.Clear();
                OtherData.Clear();
                LocalizableData.Clear();

                throw;
            }

            CreateFileWatcher();
        }

        public void Write()
        {
            var filename = Filename;
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename is null or empty");

            if (!Path.GetExtension(filename).Equals(".resx", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Filename must point to a .resx file. \n" + filename);

            // Check if we have write permissions
            File.OpenWrite(filename).Dispose();

            _fileSystemWatcher?.Dispose();

            // Write cached resources to the drive
            using (var writer = new ResXResourceWriter(filename))
            {
                foreach (var locData in LocalizableData.Where(data => !string.IsNullOrWhiteSpace(data.Value)))
                    writer.AddResource(locData.Key, locData.Value);

                foreach (var otherData in OtherData)
                    writer.AddResource(otherData.Value);

                foreach (var metadata in Metadata)
                    writer.AddMetadata(metadata.Key, metadata.Value);

                writer.Generate();
            }

            CreateFileWatcher();
        }

        private void CreateFileWatcher()
        {
            var fullPath = Path.GetFullPath(Filename);

            _fileSystemWatcher?.Dispose();
            _fileSystemWatcher = new FileSystemWatcher
            {
                Filter = Path.GetFileName(fullPath),
                Path = Path.GetDirectoryName(fullPath),
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
                IncludeSubdirectories = false,
                EnableRaisingEvents = true,
            };
            _fileSystemWatcher.Changed += (sender, args) => ChangedExternally?.Invoke(sender, args);
        }

        /// <summary>
        ///     Check if the entry contains a localizable string
        /// </summary>
        private static bool IsLocalizableString(string key, ResXDataNode dataNode)
        {
            if (key.StartsWith(">>") || (key.StartsWith("$") && key != "$this.Text"))
                return false;

            if (dataNode == null)
                return false;
            if (dataNode.FileRef != null)
                return false;

            var valueType = dataNode.GetValueTypeName((ITypeResolutionService)null);
            return valueType.StartsWith("System.String, ");
        }
    }
}