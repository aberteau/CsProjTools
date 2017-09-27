using System.Collections.Generic;

namespace CsProjTools.CsProjInspector.Data
{
    public class CsProjDoc
    {
        public string Path { get; set; }

        public string ProjectName { get; set; }

        public IEnumerable<PropertyGroup> PropertyGroups { get; set; }

        public IEnumerable<ProjectReference> ProjectReferences { get; set; }

        public IEnumerable<Reference> References { get; set; }
    }
}
