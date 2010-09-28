using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hauksoft.ResxTranslator.Data
{
    public interface IFileHolder
    {
        Dictionary<string, Folder> Folders { get; }
        Dictionary<string, Project> Projects { get; }
    }
}
