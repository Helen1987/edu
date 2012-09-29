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

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices.Automation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DesktopDashboard.Model;

namespace DesktopDashboard
{
    public partial class DataWidget : UserControl
    {
        private ObservableCollection<YearValueData> Data { get; set; }

        public DataWidget()
        {
            // Required to initialize variables
            InitializeComponent();

            this.Data = new ObservableCollection<YearValueData>();
            this.ImportPanel.Drop += new DragEventHandler(ImportPanel_Drop);
        }

        void ImportPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                FileInfo[] files = e.Data.GetData(DataFormats.FileDrop) as FileInfo[];

                if (files.Length > 0)
                {
                    if (AutomationFactory.IsAvailable)
                    {
                        var fi = files[0];
                        if (fi.Name.ToLower().Contains(".xls") || fi.Name.ToLower().Contains(".xlsx"))
                        {
                            VisualStateManager.GoToState(this, "Loading", true);

                            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string tempDirectory = string.Format("{0}\\temp", myDocuments);
                            string tempFullPath = string.Format("{0}\\{1}", tempDirectory, fi.Name);

                            // Copy the file to a temp directory in My Documents
                            CopyFileToTempDirectory(fi, tempDirectory, fi.Name);

                            // Now we know the file is in My Document, we can open and parse in Excel 
                            this.Data = ParseExcelData(tempFullPath);

                            // Clean up temp file
                            CleanUpFileSystem(tempDirectory, tempFullPath);

                            // Populate the DataGrid
                            ExcelDataGrid.ItemsSource = this.Data;

                            // Create LineSeries
                            LineSeries lineSeries = new LineSeries();
                            lineSeries.ItemsSource = this.Data;
                            lineSeries.IndependentValueBinding = new Binding("Year");
                            lineSeries.DependentValueBinding = new Binding("Value");
                            this.Chart.Series.Add(lineSeries);

                            VisualStateManager.GoToState(this, "DetailsState", true);
                        }
                        else
                        {
                            // Display  error: "Hey this isn't an Excel file, please select valid excel file"
                        }
                    }
                }
            }
        }

        private void CleanUpFileSystem(string tempDirectory, string tempFullPath)
        {
            File.Delete(tempFullPath);

            // Remove temp directory
            Directory.Delete(tempDirectory + "\\", true);
        }

        private ObservableCollection<YearValueData> ParseExcelData(string tempFullPath)
        {
            var result = new ObservableCollection<YearValueData>();

            dynamic excel;

            try
            {
                // Check to see if Excel is already running
                excel = AutomationFactory.GetObject("Excel.Application");
            }
            catch
            {
                excel = AutomationFactory.CreateObject("Excel.Application");
            }

            // Open the excel document
            dynamic excelWorkBook = excel.Workbooks.Open(tempFullPath);

            // Read the Worksheet
            dynamic activeWorkSheet = excelWorkBook.ActiveSheet();

            // Cells to Read
            dynamic cell1, cell2;

            Title.Text = activeWorkSheet.Cells[1, 1].Value;

            // Iterate through Cells
            for (int count = 3; count < 30; count++)
            {
                cell1 = activeWorkSheet.Cells[count, 1];
                cell2 = activeWorkSheet.Cells[count, 2];

                result.Add
                    (
                        new YearValueData()
                            {
                                Year = cell1.Value,
                                Value = cell2.Value
                            }
                    );
            }
            // Close the workbook
            excelWorkBook.Close();

            // Close the Excel process
            excel.Quit();

            return result;
        }

        private bool CopyFileToTempDirectory(FileInfo fi, string tempDirectory, string fileName)
        {
            using (Stream stream = fi.OpenRead())
            {
                try
                {
                    // Copy file to My Documents. This ensures we can open it up in Excel
                    byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
                    stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                    stream.Close();

                    // Create a temporary directory in My Documents
                    Directory.CreateDirectory(tempDirectory);

                    // Write a new file to the temp directory
                    File.WriteAllBytes(string.Format("{0}\\{1}", tempDirectory, fileName), buffer);

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}