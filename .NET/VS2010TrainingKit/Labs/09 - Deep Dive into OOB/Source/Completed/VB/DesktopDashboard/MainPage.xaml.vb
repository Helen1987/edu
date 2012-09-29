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
Imports System.Globalization
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Net
Imports System.Runtime.InteropServices.Automation
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.DataVisualization.Charting
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports DesktopDashboard.Model

Namespace DesktopDashboard
	Partial Public Class MainPage
		Inherits UserControl
        Private populationData As ObservableCollection(Of YearValueData)
        Private _files As New Queue(Of FileInfo)()

        Public Sub New()
            InitializeComponent()

            AddHandler CompositionTarget.Rendering, AddressOf CompositionTarget_Rendering

            AddHandler CheckForUpdatesButton.Click, AddressOf CheckForUpdatesButton_Click
        End Sub

        Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            populationData = New ObservableCollection(Of YearValueData)()
        End Sub

        Private Sub ImportPanel_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data IsNot Nothing Then
                Dim files() As FileInfo = TryCast(e.Data.GetData(DataFormats.FileDrop), FileInfo())

                For Each fi As FileInfo In files
                    _files.Enqueue(fi)
                Next fi
            End If
        End Sub

        Private Sub CompositionTarget_Rendering(ByVal sender As Object, ByVal e As EventArgs)
            If _files.Count <> 0 Then
                ' Create a photo
                Dim fi As FileInfo = _files.Dequeue()
                ProcessFile(fi)
            End If
        End Sub

        Private Sub ProcessFile(ByVal fi As FileInfo)
            If AutomationFactory.IsAvailable Then
                If fi.Name.ToLower().Contains(".xls") OrElse fi.Name.ToLower().Contains(".xlsx") Then

                    Dim myDocs As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    Directory.CreateDirectory(myDocs & "\DesktopDashboard_Silverlight")

                    Using stream_Renamed As Stream = fi.OpenRead()
                        Try

                            Try
                                Dim buffer(Convert.ToInt32(stream_Renamed.Length) - 1) As Byte
                                stream_Renamed.Read(buffer, 0, Convert.ToInt32(stream_Renamed.Length))
                                stream_Renamed.Close()
                                File.WriteAllBytes(myDocs & "\DesktopDashboard_Silverlight\" & fi.Name, buffer)
                            Catch e As Exception
                                Return
                            End Try
                        Catch e1 As Exception
                            ' Ignore exceptions resulting from drops of non-image files
                        End Try
                    End Using


                    Dim excel As Object

                    Try
                        'See if Excel is already running
                        excel = AutomationFactory.GetObject("Excel.Application")
                    Catch
                        excel = AutomationFactory.CreateObject("Excel.Application")
                    End Try

                    'dynamic excelWorkBook = excel.Workbooks.Open(fi.FullName);
                    Dim excelWorkBook As Object = excel.Workbooks.Open(myDocs & "\DesktopDashboard_Silverlight\" & fi.Name)

                    'Read the Worksheet
                    Dim activeWorkSheet As Object = excelWorkBook.ActiveSheet()

                    'Cells to Read
                    Dim cell1, cell2 As Object

                    'Iterate through Cells
                    For count As Integer = 2 To 99
                        cell1 = activeWorkSheet.Cells(count, 1)
                        cell2 = activeWorkSheet.Cells(count, 2)

                        populationData.Add(New YearValueData() With {.Year = cell1.Value, .Value = cell2.Value})
                    Next count
                    ' Close the workbook
                    excelWorkBook.Close()

                    ' Close the Excel process
                    excel.Quit()

                    ' Clean up temp file
                    File.Delete(myDocs & "\DesktopDashboard_Silverlight\" & fi.Name)

                    ' Remove temp directory
                    Directory.Delete(myDocs & "\DesktopDashboard_Silverlight\")

                    ' Populate the DataGrid
                    'ExcelDataGrid.ItemsSource = populationData;

                    ' Create LineSeries
                    Dim lineSeries_Renamed As New LineSeries()
                    lineSeries_Renamed.ItemsSource = populationData
                    lineSeries_Renamed.IndependentValueBinding = New Binding("Year")
                    lineSeries_Renamed.DependentValueBinding = New Binding("Value")
                    'this.Chart.Series.Add(lineSeries);

                Else
                    ' Display  error: "Hey this isn't an Excel file, please select valid excel file"
                End If
            End If
        End Sub

		Private Sub CheckForUpdatesButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Application.Current.CheckAndDownloadUpdateAsync()
			AddHandler Application.Current.CheckAndDownloadUpdateCompleted, AddressOf Current_CheckAndDownloadUpdateCompleted
		End Sub

		Private Sub Current_CheckAndDownloadUpdateCompleted(ByVal sender As Object, ByVal e As CheckAndDownloadUpdateCompletedEventArgs)
			If e.UpdateAvailable Then
				MessageBox.Show("An application update has been downloaded. " & "Restart the application to run the new version.")
			ElseIf e.Error IsNot Nothing Then
				MessageBox.Show("An application update is available, but an error has occurred." & vbLf & "This can happen, for example, when the update requires" & vbLf & "a new version of Silverlight or requires elevated trust." & vbLf & "To install the update, visit the application home page.")
				LogErrorToServer(e.Error)
			Else
				MessageBox.Show("There is no update available.")
			End If
		End Sub

		Private Sub LogErrorToServer(ByVal ex As Exception)
			' Not implemented. Logging the exact error to the server can help
			' diagnose any problems that are not resolved by the user reinstalling
			' the application from its home page. 
		End Sub



	End Class


End Namespace
