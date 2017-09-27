using System.Linq;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public class ProjectReferenceXElementHelper
    {
        public static XName ProjectXName => XName.Get("Project", CsProjXDocumentHelper.NamespaceName);

        public static XName NameXName => XName.Get("Name", CsProjXDocumentHelper.NamespaceName);

        public static string GetInclude(XElement xElement)
        {
            string include = xElement.Attributes("Include").FirstOrDefault()?.Value.Trim();
            return include;
        }

        public static string GetProject(XElement xElement)
        {
            string project = xElement.Elements(ProjectXName).FirstOrDefault()?.Value;
            return project;
        }

        public static string GetName(XElement xElement)
        {
            string project = xElement.Elements(NameXName).FirstOrDefault()?.Value;
            return project;
        }
    }
}
