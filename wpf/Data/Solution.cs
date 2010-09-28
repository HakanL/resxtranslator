using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public class Solution
    {
        private string rootPath;
        private List<Project> projects;
        private Dictionary<string, Language> languages;

        public Solution(string rootPath)
        {
            this.rootPath = rootPath;

            this.projects = new List<Project>();
            this.languages = new Dictionary<string, Language>();
        }


        public string RootPath { get { return rootPath; } }

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
            this.projects.Add(new Project(this, 
                System.IO.Path.Combine(rootPath, relativeFilename), relativeFilename));
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
