using System;

namespace CsProjTools.CsProjInspector.ConsoleApp
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
