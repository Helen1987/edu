' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Runtime.InteropServices.Automation
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.DataVisualization.Charting
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DesktopDashboard.Model

Namespace DesktopDashboard
	Partial Public Class DataWidget
		Inherits UserControl
        Private Property Data() As ObservableCollection(Of YearValueData)

        Public Sub New()
            ' Required to initialize variables
            InitializeComponent()

            Me.Data = New ObservableCollection(Of YearValueData)()
            AddHandler ImportPanel.Drop, AddressOf ImportPanel_Drop
        End Sub

        Private Sub ImportPanel_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data IsNot Nothing Then
                Dim files() As FileInfo = TryCast(e.Data.GetData(DataFormats.FileDrop), FileInfo())

                If files.Length > 0 Then
                    If AutomationFactory.IsAvailable Then
                        Dim fi = files(0)
                        If fi.Name.ToLower().Contains(".xls") OrElse fi.Name.ToLower().Contains(".xlsx") Then
                            VisualStateManager.GoToState(Me, "Loading", True)

                            Dim myDocuments As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                            Dim tempDirectory As String = String.Format("{0}\temp", myDocuments)
                            Dim tempFullPath As String = String.Format("{0}\{1}", tempDirectory, fi.Name)

                            ' Copy the file to a temp directory in My Documents
                            CopyFileToTempDirectory(fi, tempDirectory, fi.Name)

                            ' Now we know the file is in My Document, we can open and parse in Excel 
                            Me.Data = ParseExcelData(tempFullPath)

                            ' Clean up temp file
                            CleanUpFileSystem(tempDirectory, tempFullPath)

                            ' Populate the DataGrid
                            ExcelDataGrid.ItemsSource = Me.Data

                            ' Create LineSeries
                            Dim lineSeries_Renamed As New LineSeries()
                            lineSeries_Renamed.ItemsSource = Me.Data
                            lineSeries_Renamed.IndependentValueBinding = New Binding("Year")
                            lineSeries_Renamed.DependentValueBinding = New Binding("Value")
                            Me.Chart.Series.Add(lineSeries_Renamed)

                            VisualStateManager.GoToState(Me, "DetailsState", True)
                        Else
                            ' Display  error: "Hey this isn't an Excel file, please select valid excel file"
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub CleanUpFileSystem(ByVal tempDirectory As String, ByVal tempFullPath As String)
            File.Delete(tempFullPath)

            ' Remove temp directory
            Directory.Delete(tempDirectory & "\", True)
        End Sub

        Private Function ParseExcelData(ByVal tempFullPath As String) As ObservableCollection(Of YearValueData)
            Dim result = New ObservableCollection(Of YearValueData)()

            Dim excel As Object

            Try
                ' Check to see if Excel is already running
                excel = AutomationFactory.GetObject("Excel.Application")
            Catch
                excel = AutomationFactory.CreateObject("Excel.Application")
            End Try

            ' Open the excel document
            Dim excelWorkBook As Object = excel.Workbooks.Open(tempFullPath)

            ' Read the Worksheet
            Dim activeWorkSheet As Object = excelWorkBook.ActiveSheet()

            ' Cells to Read
            Dim cell1, cell2 As Object

            Title.Text = activeWorkSheet.Cells(1, 1).Value

            ' Iterate through Cells
            For count As Integer = 3 To 29
                cell1 = activeWorkSheet.Cells(count, 1)
                cell2 = activeWorkSheet.Cells(count, 2)

                result.Add(New YearValueData() With {.Year = cell1.Value, .Value = cell2.Value})
            Next count
            ' Close the workbook
            excelWorkBook.Close()

            ' Close the Excel process
            excel.Quit()

            Return result
        End Function

		Private Function CopyFileToTempDirectory(ByVal fi As FileInfo, ByVal tempDirectory As String, ByVal fileName As String) As Boolean
			Using stream_Renamed As Stream = fi.OpenRead()
				Try
					' Copy file to My Documents. This ensures we can open it up in Excel
					Dim buffer(Convert.ToInt32(stream_Renamed.Length) - 1) As Byte
					stream_Renamed.Read(buffer, 0, Convert.ToInt32(stream_Renamed.Length))
					stream_Renamed.Close()

					' Create a temporary directory in My Documents
					Directory.CreateDirectory(tempDirectory)

					' Write a new file to the temp directory
					File.WriteAllBytes(String.Format("{0}\{1}", tempDirectory, fileName), buffer)

					Return True
				Catch e As Exception
					Return False
				End Try
			End Using
		End Function
	End Class
End Namespace