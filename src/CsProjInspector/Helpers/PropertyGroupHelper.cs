using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.Xml;

namespace CsProjTools.CsProjInspector.Helpers
{
    static class PropertyGroupHelper
    {
        public static IEnumerable<PropertyGroup> ToPropertyGroups(this IEnumerable<XElement> xElements)
        {
            IEnumerable<PropertyGroup> propertyGroups = xElements.Select(e => e.ToPropertyGroup());
            return propertyGroups;
        }

        public static PropertyGroup ToPropertyGroup(this XElement xElement)
        {
            PropertyGroup propertyGroup = new PropertyGroup();
            propertyGroup.Condition = PropertyGroupXElementHelper.GetCondition(xElement);
            propertyGroup.OutputPath = PropertyGroupXElementHelper.GetOutputPath(xElement);
            return propertyGroup;
        }

        public static IEnumerable<String> GetConditions(IEnumerable<PropertyGroup> propertyGroups)
        {
            IEnumerable<string> conditions = propertyGroups.Select(pg => pg.Condition).Distinct();
            return conditions;
        }

    }
}
