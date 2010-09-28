using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public class Solution : IFileHolder
    {
        private string rootPath;
        private Dictionary<string, Project> projects;
        private Dictionary<string, Folder> folders;
        private Dictionary<string, Language> languages;

        public Solution(string rootPath)
        {
            this.rootPath = rootPath;

            this.projects = new Dictionary<string, Project>();
            this.folders = new Dictionary<string, Folder>();
            this.languages = new Dictionary<string, Language>();
        }


        public string RootPath { get { return rootPath; } }

        public Dictionary<string, Folder> Folders
        {
            get { return folders; }
        }


        public Dictionary<string, Project> Projects
        {
            get { return projects; }
        }

        
        public List<Language> Languages
        {
            get
            {
                List<Language> list = new List<Language>(languages.Values);

                list.Sort((a, b) => a.Id.CompareTo(b.Id));

                return list;
            }
        }

        internal void AddProject(string relativeFilename)
        {
            string projectName = Path.GetFileNameWithoutExtension(relativeFilename);
            string[] pathParts = Path.GetDirectoryName(relativeFilename).Split(System.IO.Path.DirectorySeparatorChar);

            Folder currentFolder = null;
            foreach (string pathPart in pathParts)
            {
                if (string.IsNullOrEmpty(pathPart))
                    continue;

                string key = pathPart.ToLower();

                Folder subFolder;
                if(currentFolder == null)
                {
                    if(!this.folders.TryGetValue(key, out subFolder))
                    {
                        subFolder = new Folder(pathPart);
                        this.folders.Add(key, subFolder);
                    }
                } else if (!currentFolder.Folders.TryGetValue(key, out subFolder))
                {
                    subFolder = new Folder(pathPart);
                    currentFolder.Folders.Add(key, subFolder);
                }
                currentFolder = subFolder;
            }

            Project project = new Project(this, projectName, System.IO.Path.Combine(rootPath, relativeFilename), relativeFilename);
            if (currentFolder == null)
                this.projects.Add(projectName, project);
            else
                currentFolder.Projects.Add(projectName, project);
        }


        internal void AddLanguage(string id)
        {
            if (!languages.ContainsKey(id.ToLower()))
            {
                Language language = new Language(id);
                languages.Add(id.ToLower(), language);
            }
        }


        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
