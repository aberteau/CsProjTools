using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.Xml;

namespace CsProjTools.CsProjInspector.Helpers
{
    public static class CsProjDocHelper
    {
        private static CsProjDoc GetCsProjDoc(string csProjPath)
        {
            string csprojDirPath = Path.GetDirectoryName(csProjPath);

            CsProjDoc csProjDoc = new CsProjDoc();
            csProjDoc.Path = csProjPath;
            csProjDoc.ProjectName = Path.GetFileNameWithoutExtension(csProjPath);

            XDocument xDocument = XDocument.Load(csProjPath);
            XElement projectElement = CsProjXDocumentHelper.GetProjectElement(xDocument);

            IEnumerable<XElement> propertyGroupXElements = ProjectXElementHelper.GetPropertyGroupElementsHavingCondtionAttribute(projectElement);
            csProjDoc.PropertyGroups = propertyGroupXElements.ToPropertyGroups();

            IEnumerable<XElement> projectReferenceXElements = ProjectXElementHelper.GetProjectReferenceXElements(projectElement);
            csProjDoc.ProjectReferences = projectReferenceXElements.ToProjectReferences();

            IEnumerable<XElement> referenceXElements = ProjectXElementHelper.GetReferenceXElements(projectElement);
            csProjDoc.References = referenceXElements.ToReferences(csprojDirPath);

            return csProjDoc;
        }

        public static IEnumerable<CsProjDoc> GetCsProjDocs(IEnumerable<String> filenames)
        {
            IEnumerable<CsProjDoc> csProjDocs = filenames.Select(csprojFile => GetCsProjDoc(csprojFile));
            return csProjDocs;
        }

        public static IEnumerable<String> GetPropertyGroupConditions(IEnumerable<CsProjDoc> csProjDocs)
        {
            IEnumerable<String> conditions = new List<string>();
            foreach (CsProjDoc csProjDoc in csProjDocs)
            {
                IEnumerable<string> csProjConditions = PropertyGroupHelper.GetConditions(csProjDoc.PropertyGroups);
                conditions = conditions.Union(csProjConditions);
            }

            return conditions;
        }
    }
}
