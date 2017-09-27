using System.Linq;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public static class CsProjXDocumentHelper
    {
        public const string NamespaceName = "http://schemas.microsoft.com/developer/msbuild/2003";

        public static XName ProjectXName => XName.Get("Project", NamespaceName);

        public static XElement GetProjectElement(XDocument xDocument)
        {
            return xDocument.Elements(ProjectXName).FirstOrDefault();
        }
    }
}
