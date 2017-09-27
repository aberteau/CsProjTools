using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public static class XElementExtensions
    {
        internal static bool HasElements(this XElement xElement, XName name)
        {
            bool hasElements = xElement.Elements(name).Any();
            return hasElements;
        }

        internal static bool HasAttributes(this XElement xElement, String name)
        {
            bool hasElements = xElement.Attributes(name).Any();
            return hasElements;
        }

        internal static IEnumerable<XElement> WhereHasElements(this IEnumerable<XElement> xElements, XName name)
        {
            IEnumerable<XElement> filteredElements = xElements.Where(e => e.HasElements(name));
            return filteredElements;
        }

        internal static IEnumerable<XElement> WhereHasAttributes(this IEnumerable<XElement> xElements, String name)
        {
            IEnumerable<XElement> filteredElements = xElements.Where(e => e.HasAttributes(name));
            return filteredElements;
        }

        #region Value

        public static bool? GetNullableBooleanValue(this XElement xElement)
        {
            string elemantValue = xElement?.Value;

            if (String.IsNullOrWhiteSpace(elemantValue))
                return null;

            return Convert.ToBoolean(elemantValue);
        }

        #endregion
    }
}
