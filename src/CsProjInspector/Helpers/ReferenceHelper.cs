using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.Xml;

namespace CsProjTools.CsProjInspector.Helpers
{
    static class ReferenceHelper
    {
        public static IEnumerable<Reference> ToReferences(this IEnumerable<XElement> xElements, String csprojDirPath)
        {
            IEnumerable<Reference> references = xElements.Select(e => e.ToReference(csprojDirPath));
            return references;
        }

        public static Reference ToReference(this XElement xElement, String basePath)
        {
            Reference reference = new Reference();
            reference.Include = ReferenceXElementHelper.GetInclude(xElement);
            reference.HintPath = ReferenceXElementHelper.GetHintPath(xElement);
            reference.SpecificVersion = ReferenceXElementHelper.GetSpecificVersion(xElement);
            reference.Private = ReferenceXElementHelper.GetPrivate(xElement);
            reference.AbsolutePath = FileHelper.GetAbsolutePath(basePath, reference.HintPath);

            return reference;
        }
    }
}
