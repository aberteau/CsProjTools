using System.Collections.Generic;
using System.IO;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.Helpers;

namespace CsProjTools.CsProjInspector
{
    public class CsProjFileHelper
    {
        private static IEnumerable<string> GetCsProjFiles(string path)
        {
            IEnumerable<string> csProjFiles = Directory.EnumerateFiles(path, "*.csproj", SearchOption.AllDirectories);
            return csProjFiles;
        }

        public static IEnumerable<CsProjDoc> GetCsProjDocs(string path)
        {
            IEnumerable<string> csProjFiles = GetCsProjFiles(path);
            IEnumerable<CsProjDoc> csProjDocs = CsProjDocHelper.GetCsProjDocs(csProjFiles);
            return csProjDocs;
        }
    }
}
