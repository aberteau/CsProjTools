using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CsProjTools.CsProjInspector.Xml
{
    public static class PropertyGroupXElementHelper
    {
        private const string ConditionAttributeName = "Condition";

        public static XName OutputPathXName => XName.Get("OutputPath", CsProjXDocumentHelper.NamespaceName);

        public static IEnumerable<XElement> WhereHasConditionAttribute(this IEnumerable<XElement> xElements)
        {
            return xElements.WhereHasAttributes(ConditionAttributeName);
        }

        public static XElement GetOutputPathElement(XElement xElement)
        {
            XElement outputPathXElement = xElement.Elements(OutputPathXName).FirstOrDefault();
            return outputPathXElement;
        }

        private static XAttribute GetConditionXAttribute(XElement xElement)
        {
            XAttribute conditionXAttribute = xElement.Attributes(ConditionAttributeName).FirstOrDefault();
            return conditionXAttribute;
        }

        public static string GetOutputPath(XElement xElement)
        {
            XElement outputPathXElement = GetOutputPathElement(xElement);
            string outputPath = outputPathXElement?.Value;
            return outputPath;
        }

        public static string GetCondition(XElement xElement)
        {
            XAttribute conditionXAttribute = GetConditionXAttribute(xElement);
            string condition = conditionXAttribute?.Value.Trim();
            return condition;
        }
    }
}
