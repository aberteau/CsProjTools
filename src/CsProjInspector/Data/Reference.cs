using System;

namespace CsProjTools.CsProjInspector.Data
{
    public class Reference
    {
        public string Include { get; set; }

        public string HintPath { get; set; }

        public Nullable<bool> SpecificVersion { get; set; }

        public Nullable<bool> Private { get; set; }

        public string AbsolutePath { get; set; }
    }
}