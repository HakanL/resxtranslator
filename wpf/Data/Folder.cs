using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public class Folder : IFileHolder
    {
        private string name;
        private Dictionary<string, Project> projects;
        private Dictionary<string, Folder> folders;


        public Folder(string name)
        {
            this.name = name;
            this.projects = new Dictionary<string, Project>();
            this.folders = new Dictionary<string, Folder>();
        }


        public string Name
        {
            get { return name; }
        }


        public Dictionary<string, Folder> Folders
        {
            get { return folders; }
        }


        public Dictionary<string, Project> Projects
        {
            get { return projects; }
        }


        public bool HasData
        {
            get
            {
                foreach (var project in projects.Values)
                    if (project.HasData)
                        return true;

                foreach (var folder in folders.Values)
                    if (folder.HasData)
                        return true;

                return false;
            }
        }
    }
}
