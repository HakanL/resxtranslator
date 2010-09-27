using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Hauksoft.ResxManager
{
    public class Scanner
    {
        public Solution ScanRootFolder(string rootFolder)
        {
            Solution solution = new Solution(rootFolder);
            FindResx(solution, rootFolder, string.Empty);

            return solution;
        }


        private void FindResx(Solution solution, string rootPath, string subFolder)
        {
            string findPath = Path.Combine(rootPath, subFolder);

            // Find project files
            string[] files = Directory.GetFiles(findPath, "*.csproj");
            foreach (string file in files)
            {
                solution.AddProject(file.Substring(rootPath.Length + 1));
            }

/*
            files = Directory.GetFiles(findPath, "*.resx");
            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                string filenameNoExt = Path.GetFileNameWithoutExtension(file);
                string[] fileParts = filenameNoExt.Split('.');
                if (fileParts.Length == 0)
                    continue;

                string language = "";
                if (fileParts[fileParts.Length - 1].Length == 5 && fileParts[fileParts.Length - 1][2] == '-')
                    language = fileParts[fileParts.Length - 1];
                else if (fileParts[fileParts.Length - 1].Length == 2)
                    language = fileParts[fileParts.Length - 1];
                if (!string.IsNullOrEmpty(language))
                    filenameNoExt = Path.GetFileNameWithoutExtension(filenameNoExt);

                Resource resourceHolder;
                string key = (displayFolder + "\\" + filenameNoExt).ToLower();
                if (!resources.TryGetValue(key, out resourceHolder))
                {
                    resourceHolder = new ResourceHolder();
                    resourceHolder.DisplayFolder = displayFolder;
                    if (string.IsNullOrEmpty(language))
                        resourceHolder.SetFilename(file, file.Substring(rootPath.Length + 1));
                    resourceHolder.Id = filenameNoExt;

                    resources.Add(key, resourceHolder);
                }

                if (!string.IsNullOrEmpty(language))
                {
                    if (!resourceHolder.Languages.ContainsKey(language.ToLower()))
                    {
                        LanguageHolder languageHolder = new LanguageHolder();
                        languageHolder.Filename = file;
                        languageHolder.Id = language;
                        resourceHolder.Languages.Add(language.ToLower(), languageHolder);
                    }
                }
                else
                    resourceHolder.SetFilename(file, file.Substring(rootPath.Length + 1));
            }
*/
            string[] subfolders = Directory.GetDirectories(findPath);
            foreach (string folder in subfolders)
            {
                if (new DirectoryInfo(folder).Attributes.HasFlag(FileAttributes.Hidden))
                    continue;

                FindResx(solution, rootPath, folder.Substring(rootPath.Length + 1));
            }
        }

    }
}
