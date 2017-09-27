using System.Collections.Generic;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public static class ItemGroupXElementHelper
    {
        public static XName ProjectReferenceXName => XName.Get("ProjectReference", CsProjXDocumentHelper.NamespaceName);

        public static XName ReferenceXName => XName.Get("Reference", CsProjXDocumentHelper.NamespaceName);

        internal static IEnumerable<XElement> WhereHasProjectReferenceElements(this IEnumerable<XElement> xElements)
        {
            IEnumerable<XElement> filteredElements = xElements.WhereHasElements(ProjectReferenceXName);
            return filteredElements;
        }

        internal static IEnumerable<XElement> WhereHasReferenceElements(this IEnumerable<XElement> xElements)
        {
            IEnumerable<XElement> filteredElements = xElements.WhereHasElements(ReferenceXName);
            return filteredElements;
        }

        internal static IEnumerable<XElement> GetProjectReferenceXElements(XElement xElement)
        {
            IEnumerable<XElement> projectReferenceXElements = xElement.Elements(ProjectReferenceXName);
            return projectReferenceXElements;
        }

        internal static IEnumerable<XElement> GetReferenceXElements(XElement xElement)
        {
            IEnumerable<XElement> referenceXElements = xElement.Elements(ReferenceXName);
            return referenceXElements;
        }
    }
}
