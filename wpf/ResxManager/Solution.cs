using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxManager
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
    }
}
