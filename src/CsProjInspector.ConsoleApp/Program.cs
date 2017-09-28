using System;
using System.IO;
using System.Reflection;
using CsProjTools.CsProjInspector.DocGenerator;
using NDesk.Options;

namespace CsProjTools.CsProjInspector.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool helpFlag = false;
            String csprojPath = null;
            String outputPath = null;

            OptionSet optionSet = new OptionSet() {
                { "csprojPath=", "the {PATH} of csproj folder. [Mandatory]", v => csprojPath = v },
                { "outputPath=", "the {PATH} of output file.", v => outputPath = v },
                { "h|help",  "show this message and exit", v => helpFlag = v != null },
            };

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string applicationName = Path.GetFileName(codeBase);

            try
            {
                optionSet.Parse(args);

                if (String.IsNullOrWhiteSpace(csprojPath))
                    throw new Exception("csprojPath must be provided");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Use '{applicationName} --help' for more information.");
                return;
            }

            if (helpFlag)
            {
                ShowHelp(optionSet);
                return;
            }

            if (String.IsNullOrWhiteSpace(outputPath))
            {
                string applicationFolder = Path.GetDirectoryName(codeBase);
                string chrono = FilenameHelper.GetChrono();
                string xlsFilename = $"{chrono} - CsProjInspector Output.xlsx";
                outputPath = Path.Combine(applicationFolder, xlsFilename);
            }

            Console.WriteLine($"Searching csproj files in folder '{csprojPath}'");
            ExcelHelper.GenerateExcelFile(csprojPath, outputPath);
            Console.WriteLine("Inspection completed");
            Console.WriteLine($"Output file generated in '{outputPath}'");
            Console.WriteLine("Press Enter key to quit...");
            Console.ReadLine();
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: CsProjInspector.ConsoleApp [OPTIONS]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
