using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.Xml;

namespace CsProjTools.CsProjInspector.Helpers
{
    static class ProjectReferenceHelper
    {
        public static IEnumerable<ProjectReference> ToProjectReferences(this IEnumerable<XElement> xElements)
        {
            IEnumerable<ProjectReference> projectReferences = xElements.Select(e => e.ToProjectReference());
            return projectReferences;
        }

        public static ProjectReference ToProjectReference(this XElement xElement)
        {
            ProjectReference projectReference = new ProjectReference();
            projectReference.Include = ProjectReferenceXElementHelper.GetInclude(xElement);
            projectReference.Project = ProjectReferenceXElementHelper.GetProject(xElement);
            projectReference.Name = ProjectReferenceXElementHelper.GetName(xElement);
            return projectReference;
        }
    }
}
