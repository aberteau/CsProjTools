using System;

namespace CsProjTools.CsProjInspector.Helpers
{
    public class FilenameHelper
    {
        public static string GetChrono()
        {
            string chrono = DateTime.Now.ToString("yyMMddHHmmss");
            return chrono;
        }
    }
}
