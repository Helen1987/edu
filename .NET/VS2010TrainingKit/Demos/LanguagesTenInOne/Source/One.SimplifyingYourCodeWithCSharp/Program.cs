// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace One.SimplifyingYourCodeWithCSharp
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Excel = Microsoft.Office.Interop.Excel;
    using Word = Microsoft.Office.Interop.Word;

    class Program
    {
        static object _missingValue = Missing.Value;

        static void Main(string[] args)
        {
            GenerateChart(copyToWord: true);
        }

        static void GenerateChart(bool copyToWord = false)
        {
            var excel = new Excel.Application();
            excel.Visible = true;
            excel.Workbooks.Add();

            excel.Range["A1"].Value2 = "Process Name";
            excel.Range["B1"].Value2 = "Memory Usage";

            var processes = Process.GetProcesses()
                                        .OrderByDescending(p => p.WorkingSet64)
                                        .Take(10);
            int i = 2;
            foreach (var p in processes)
            {
                excel.Range["A" + i].Value2 = p.ProcessName;
                excel.Range["B" + i].Value2 = p.WorkingSet64;
                i++;
            }

            Excel.Range range = excel.get_Range("A1");
            Excel.Chart chart = (Excel.Chart)excel.ActiveWorkbook.Charts.Add(
                After: excel.ActiveSheet);

            chart.ChartWizard(Source: range.CurrentRegion,
                Title: "Memory Usage in " + Environment.MachineName);

            chart.ChartStyle = 45;
            chart.CopyPicture(Excel.XlPictureAppearance.xlScreen,
                Excel.XlCopyPictureFormat.xlBitmap,
                Excel.XlPictureAppearance.xlScreen);

            if (copyToWord)
            {
                var word = new Word.Application();
                word.Visible = true;
                word.Documents.Add();

                word.Selection.Paste();
            }
        }
    }
}
