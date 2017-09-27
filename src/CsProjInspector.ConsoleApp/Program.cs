using System;
using System.Collections.Generic;
using System.IO;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.DocGenerator;

namespace CsProjTools.CsProjInspector.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Temp\OutputPaths";

            string chrono = FilenameHelper.GetChrono();
            string xlsFilename = $"{chrono} - CsProjInspector Output.xlsx";
            string xlsFilePath = Path.Combine(@"D:\Temp\", xlsFilename);

            ExcelHelper.GenerateExcelFile(path, xlsFilePath);
        }
    }
}
