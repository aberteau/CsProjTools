using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public class ProjectXElementHelper
    {
        public static XName PropertyGroupXName => XName.Get("PropertyGroup", CsProjXDocumentHelper.NamespaceName);

        public static XName ItemGroupXName => XName.Get("ItemGroup", CsProjXDocumentHelper.NamespaceName);

        private static IEnumerable<XElement> GetPropertyGroupElements(XElement xElement)
        {
            return xElement.Elements(PropertyGroupXName);
        }

        public static IEnumerable<XElement> GetItemGroupElements(XElement xElement)
        {
            IEnumerable<XElement> itemGroupXElements = xElement.Elements(ItemGroupXName);
            return itemGroupXElements;
        }

        public static IEnumerable<XElement> GetPropertyGroupElementsHavingCondtionAttribute(XElement xElement)
        {
            IEnumerable<XElement> propertyGroupXElements = GetPropertyGroupElements(xElement).WhereHasConditionAttribute();
            return propertyGroupXElements;
        }

        public static IEnumerable<XElement> GetProjectReferenceXElements(XElement xElement)
        {
            XElement itemGroupXElement = GetItemGroupElements(xElement).WhereHasProjectReferenceElements().FirstOrDefault();

            if (itemGroupXElement == null)
                return Enumerable.Empty<XElement>();

            IEnumerable<XElement> projectReferenceXElements = ItemGroupXElementHelper.GetProjectReferenceXElements(itemGroupXElement);
            return projectReferenceXElements;
        }

        public static IEnumerable<XElement> GetReferenceXElements(XElement xElement)
        {
            XElement itemGroupXElement = GetItemGroupElements(xElement).WhereHasReferenceElements().FirstOrDefault();

            if (itemGroupXElement == null)
                return Enumerable.Empty<XElement>();

            IEnumerable<XElement> referenceXElements = ItemGroupXElementHelper.GetReferenceXElements(itemGroupXElement);
            return referenceXElements;
        }
    }
}
