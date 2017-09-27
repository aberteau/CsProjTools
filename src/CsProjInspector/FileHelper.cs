using System;
using System.IO;

namespace CsProjTools.CsProjInspector
{
    public class FileHelper
    {
        private static string EnsureTrailingBackslash(string path)
        {
            string str = path.TrimEnd('\\') + "\\";
            return str;
        }

        private static string ReplacePathSeparator(string path)
        {
            string str = path.Replace('/', Path.DirectorySeparatorChar);
            return str;
        }

        public static string GetAbsolutePath(string basePath, string relativePath)
        {
            if (String.IsNullOrWhiteSpace(relativePath))
                return null;

            string newPath = Path.Combine(basePath, relativePath);
            string absolutePath = Path.GetFullPath(newPath);

            return absolutePath;
        }

        public static string GetRelativePath(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            string correctedReferencePath = EnsureTrailingBackslash(referencePath);
            var referenceUri = new Uri(correctedReferencePath);
            Uri relativeUri = referenceUri.MakeRelativeUri(fileUri);

            string relativePath = ReplacePathSeparator(relativeUri.ToString());
            return relativePath;
        }
    }
}
