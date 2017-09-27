using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsProjTools.CsProjInspector.Data;
using CsProjTools.CsProjInspector.Helpers;
using OfficeOpenXml;

namespace CsProjTools.CsProjInspector.DocGenerator
{
    public class ExcelHelper
    {
        public static void GenerateExcelFile(IEnumerable<CsProjDoc> csProjDocs, string filename)
        {
            ExcelPackage xlPackage = new ExcelPackage();
            WriteCsProjDocs(xlPackage, csProjDocs);
            xlPackage.SaveAs(new FileInfo(filename));
        }

        public static void GenerateExcelFile(string path, String xlsFilename)
        {
            IEnumerable<CsProjDoc> csProjDocs = CsProjFileHelper.GetCsProjDocs(path);
            GenerateExcelFile(csProjDocs, xlsFilename);
        }

        private static void WriteCsProjDocs(ExcelPackage xlPackage, IEnumerable<CsProjDoc> csProjDocs)
        {
            WriteOutputPathsWorksheet(xlPackage, csProjDocs);
            WriteReferencesWorksheet(xlPackage, csProjDocs);
        }

        private static void WriteOutputPathsWorksheet(ExcelPackage xlPackage, IEnumerable<CsProjDoc> csProjDocs)
        {
            IEnumerable<string> propertyGroupConditions = CsProjDocHelper.GetPropertyGroupConditions(csProjDocs);
            WriteOutputPathsWorksheet(xlPackage, csProjDocs, propertyGroupConditions);
        }

        private static void WriteOutputPathsWorksheet(ExcelPackage xlPackage, IEnumerable<CsProjDoc> csProjDocs, IEnumerable<string> conditions)
        {
            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("OutputPaths");

            int headerCellColIndex = 1;

            worksheet.Cells[1, headerCellColIndex++].Value = "ProjectFilePath";
            worksheet.Cells[1, headerCellColIndex++].Value = "ProjectName";

            IDictionary<String, Int32> columnIndexByCondition = new Dictionary<String, int>();

            foreach (String condition in conditions.OrderBy(f => f))
            {
                worksheet.Cells[1, headerCellColIndex].Value = condition;
                columnIndexByCondition.Add(new KeyValuePair<String, int>(condition, headerCellColIndex));
                headerCellColIndex++;
            }

            int rowIndex = 2;

            foreach (CsProjDoc item in csProjDocs)
            {
                worksheet.Cells[rowIndex, 1].Value = item.Path;
                worksheet.Cells[rowIndex, 2].Value = item.ProjectName;

                foreach (PropertyGroup propertyGroup in item.PropertyGroups)
                {
                    int columnIndex = columnIndexByCondition[propertyGroup.Condition];
                    worksheet.Cells[rowIndex, columnIndex].Value = propertyGroup.OutputPath;
                }

                rowIndex++;
            }

            Int32 lastColIndex = columnIndexByCondition.Values.Max();
            ExcelRange excelRange = worksheet.Cells[1, 1, rowIndex - 1, lastColIndex];
            worksheet.Tables.Add(excelRange, "OutputPaths");
        }

        private static void WriteReferencesWorksheet(ExcelPackage xlPackage, IEnumerable<CsProjDoc> csProjDocs)
        {
            IEnumerable<ReferenceRowDto> rowDtos = GetReferenceRowDtos(csProjDocs);
            WriteReferencesWorksheet(xlPackage, rowDtos);
        }

        private static void WriteReferencesWorksheet(ExcelPackage xlPackage, IEnumerable<ReferenceRowDto> rowDtos)
        {
            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("References");

            int headerCellColIndex = 1;

            worksheet.Cells[1, headerCellColIndex++].Value = "ProjectFilePath";
            worksheet.Cells[1, headerCellColIndex++].Value = "ProjectName";
            worksheet.Cells[1, headerCellColIndex++].Value = "Include";
            worksheet.Cells[1, headerCellColIndex++].Value = "SpecificVersion";
            worksheet.Cells[1, headerCellColIndex++].Value = "Private";
            worksheet.Cells[1, headerCellColIndex++].Value = "HintPath";
            worksheet.Cells[1, headerCellColIndex++].Value = "AbsolutePath";

            int lastColIndex = headerCellColIndex - 1;
            int rowIndex = 2;

            foreach (ReferenceRowDto rowDto in rowDtos)
            {
                int cellColIndex = 1;

                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.ProjectFilePath;
                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.ProjectName;
                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.Include;
                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.SpecificVersion;
                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.Private;
                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.HintPath;
                worksheet.Cells[rowIndex, cellColIndex++].Value = rowDto.AbsolutePath;

                rowIndex++;
            }

            ExcelRange excelRange = worksheet.Cells[1, 1, rowIndex - 1, lastColIndex];
            worksheet.Tables.Add(excelRange, "References");
        }

        private static IEnumerable<ReferenceRowDto> GetReferenceRowDtos(IEnumerable<CsProjDoc> csProjDocs)
        {
            List<ReferenceRowDto> rowDtos = new List<ReferenceRowDto>();

            foreach (CsProjDoc csProjDoc in csProjDocs)
            {
                IEnumerable<ReferenceRowDto> csProjRowDtos = GetReferenceRowDtos(csProjDoc);
                rowDtos.AddRange(csProjRowDtos);
            }

            return rowDtos;
        }

        private static IEnumerable<ReferenceRowDto> GetReferenceRowDtos(CsProjDoc csProjDoc)
        {
            IEnumerable<ReferenceRowDto> rowDtos = csProjDoc.References.Select(reference => ToReferenceXlRowDto(csProjDoc, reference));
            return rowDtos;
        }

        private static ReferenceRowDto ToReferenceXlRowDto(CsProjDoc csProjDoc, Reference reference)
        {
            ReferenceRowDto rowDto = new ReferenceRowDto
            {
                ProjectFilePath = csProjDoc.Path,
                ProjectName = csProjDoc.ProjectName,
                Include = reference.Include,
                HintPath = reference.HintPath,
                Private = ToString(reference.Private),
                SpecificVersion = ToString(reference.SpecificVersion),
                AbsolutePath = reference.AbsolutePath
            };
            return rowDto;
        }

        private static string ToString(Nullable<bool> nullableBool)
        {
            return nullableBool?.ToString();
        }
    }
}
