using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public static class ReferenceXElementHelper
    {
        private const string IncludeAttributeName = "Include";

        public static XName PrivateXName => XName.Get("Private", CsProjXDocumentHelper.NamespaceName);

        public static XName HintPathXName => XName.Get("HintPath", CsProjXDocumentHelper.NamespaceName);

        public static XName SpecificVersionXName => XName.Get("SpecificVersion", CsProjXDocumentHelper.NamespaceName);

        public static string GetInclude(XElement xElement)
        {
            string include = xElement.Attributes(IncludeAttributeName).FirstOrDefault()?.Value.Trim();
            return include;
        }

        public static IEnumerable<XElement> WhereHasHintPathElement(this IEnumerable<XElement> xElements)
        {
            return xElements.WhereHasElements(HintPathXName);
        }

        public static XElement GetHintPathElement(XElement xElement)
        {
            XElement hintPathXElement = xElement.Elements(HintPathXName).FirstOrDefault();
            return hintPathXElement;
        }

        public static string GetHintPath(XElement xElement)
        {
            XElement hintPathXElement = GetHintPathElement(xElement);
            string hintPath = hintPathXElement?.Value;
            return hintPath;
        }

        public static XElement GetSpecificVersionElement(XElement xElement)
        {
            XElement specificVersionElement = xElement.Elements(SpecificVersionXName).FirstOrDefault();
            return specificVersionElement;
        }

        public static Nullable<bool> GetSpecificVersion(XElement xElement)
        {
            XElement specificVersionElement = GetSpecificVersionElement(xElement);
            bool? specificVersion = specificVersionElement.GetNullableBooleanValue();
            return specificVersion;
        }

        public static XElement GetPrivateElement(XElement xElement)
        {
            XElement privateElement = xElement.Elements(PrivateXName).FirstOrDefault();
            return privateElement;
        }

        public static Nullable<bool> GetPrivate(XElement xElement)
        {
            XElement privateElement = GetPrivateElement(xElement);
            bool? privateValue = privateElement.GetNullableBooleanValue();
            return privateValue;
        }
    }
}
