using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;


namespace Hauksoft.ResxTranslator.Data
{
    public class Project
    {
        private Solution parent;
        private string name;
        private string fullFilename;
        private string relativeFilename;
        private List<Resource> resources;


        public Project(Solution parent, string name, string fullFilename, string relativeFilename)
        {
            this.parent = parent;
            this.name = name;
            this.fullFilename = fullFilename;
            this.relativeFilename = relativeFilename;

            XmlDocument projectFile = new XmlDocument();
            projectFile.Load(fullFilename);
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(projectFile.NameTable);
            nsMgr.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003");

            
            XmlNodeList resourceNodes = projectFile.SelectNodes("/x:Project/x:ItemGroup/x:EmbeddedResource", nsMgr);

            Dictionary<string, ResourceHolder> holders = new Dictionary<string, ResourceHolder>();
            foreach (XmlNode xmlNode in resourceNodes)
            {
                string dependentUpon = null;
                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    if (childNode.Name == "DependentUpon")
                        dependentUpon = childNode.InnerText;
                }

                XmlAttribute attribute = xmlNode.Attributes["Include"];
                if (attribute != null)
                {
                    if(!attribute.Value.EndsWith(".resx", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string baseFilename = attribute.Value.Substring(0, attribute.Value.Length - 5);

                    ResourceHolder holder = new ResourceHolder(baseFilename, dependentUpon);
                    holders.Add(baseFilename.ToLower(), holder);
                }
            }


            // Find the bases
            Dictionary<string, Resource> baseResources = new Dictionary<string, Resource>();
            foreach (KeyValuePair<string, ResourceHolder> kvp in holders)
            {
                int dotIndex = kvp.Key.LastIndexOf('.');
                if (dotIndex > -1)
                {
                    string baseName = kvp.Key.Substring(0, dotIndex);
                    ResourceHolder baseHolder;
                    if (holders.TryGetValue(baseName, out baseHolder))
                    {
                        // Found our base
                        Resource baseResource;
                        if (!baseResources.TryGetValue(baseName, out baseResource))
                        {
                            // Create new
                            baseResource = new Resource(Path.GetFileName(baseHolder.Filename),
                                baseHolder.Filename, baseHolder.DependentUpon);
                            baseResources.Add(baseName, baseResource);
                        }

                        string languageId = kvp.Value.Filename.Substring(baseName.Length + 1);
                        parent.AddLanguage(languageId);

                        baseResource.AddLanguageFile(languageId, Path.Combine(
                            Path.Combine(parent.RootPath, Path.GetDirectoryName(relativeFilename)),
                            kvp.Value.Filename + ".resx"));
                    }
                    else
                    {
                        // Specified language without a base resource file, ignore
                    }
                }
                else
                {
                    Resource baseResource;
                    if (!baseResources.TryGetValue(kvp.Key, out baseResource))
                    {
                        // Create new
                        baseResource = new Resource(Path.GetFileName(kvp.Value.Filename), kvp.Value.Filename, kvp.Value.DependentUpon);
                        baseResources.Add(kvp.Key, baseResource);
                    }

                    baseResource.AddLanguageFile(string.Empty, Path.Combine(
                        Path.Combine(parent.RootPath, Path.GetDirectoryName(relativeFilename)),
                        kvp.Value.Filename + ".resx"));
                }
            }

            this.resources = baseResources.Values.ToList();
        }


        public bool HasData
        {
            get
            {
                foreach (var resource in resources)
                    if (resource.HasData)
                        return true;

                return false;
            }
        }


        public string Name
        {
            get { return name; }
        }


        public List<Resource> Resources
        {
            get { return resources; }
        }
        

        private class ResourceHolder
        {
            private string filename;
            private string dependentUpon;


            public ResourceHolder(string filename, string dependentUpon)
            {
                this.filename = filename;
                this.dependentUpon = dependentUpon;
            }


            public string Filename { get { return filename; } }
            public string DependentUpon { get { return dependentUpon; } }
        }
    }
}
