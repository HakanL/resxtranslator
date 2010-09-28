using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
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
