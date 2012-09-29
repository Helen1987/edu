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

Imports System.Net
Imports System.Runtime.InteropServices.Automation
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports SilverlightWebBrowser.Data

Namespace SilverlightWebBrowser
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			' Register Click events for the buttons in the WindowControlsPanel
			AddHandler OnTopButton.Click, AddressOf OnTopButton_Click
			AddHandler MinimizeButton.Click, AddressOf MinimizeButton_Click
			AddHandler MaximizeButton.Click, AddressOf MaximizeButton_Click
			AddHandler CloseButton.Click, AddressOf CloseButton_Click

			' Register Click events for the Export buttons
			AddHandler ExcelButton.Click, AddressOf ExcelButton_Click
			AddHandler WordButton.Click, AddressOf WordButton_Click
			AddHandler OutlookButton.Click, AddressOf OutlookButton_Click
			AddHandler PowerPointButton.Click, AddressOf PowerPointButton_Click
		End Sub

		Private Sub ExcelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim excel As Object = AutomationFactory.CreateObject("Excel.Application")
			excel.Visible = True

			Dim workbook As Object = excel.workbooks
			workbook.Add()

			Dim sheet As Object = excel.ActiveSheet
			Dim cell As Object = Nothing
			Dim i As Integer = 1

			' Populate the excel sheet
			For Each item In (TryCast(LayoutRoot.DataContext, Bookmarks)).Sites
				cell = sheet.Cells(i, 1)
				cell.Value = item.Title

				cell = sheet.Cells(i, 2)
				cell.Value = item.Uri
				cell.ColumnWidth = 100

				i += 1
			Next item
		End Sub

		Private Sub WordButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If AutomationFactory.IsAvailable Then
				Dim word As Object = AutomationFactory.CreateObject("Word.Application")
				word.Visible = True

				word.Documents.Add()
				word.Selection.TypeText("Bookmarks")
				word.Selection.TypeText(String.Format("Exported at: {0}", Date.Today.ToShortDateString()))
				word.Selection.TypeParagraph()
				For Each item In (TryCast(LayoutRoot.DataContext, Bookmarks)).Sites
					word.Selection.TypeText(String.Format("{0} " & vbVerticalTab & "URL: {1}" & vbVerticalTab, item.Title, item.Uri))
				Next item
				word.ActiveDocument.SaveAs("BookmarksFromSL")
			End If
		End Sub

		Private Sub OutlookButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If AutomationFactory.IsAvailable Then
				Dim outlook As Object = AutomationFactory.CreateObject("Outlook.Application")
				Dim mail As Object = outlook.CreateItem(0)
				mail.To = "me@myname.com"
				mail.Subject = "My Bookmarks"
				Dim sb As New StringBuilder()
				For Each item In (TryCast(LayoutRoot.DataContext, Bookmarks)).Sites
					sb.Append(String.Format("{0} " & vbVerticalTab & "URL: {1}" & vbVerticalTab & vbVerticalTab, item.Title, item.Uri))
				Next item
				mail.Body = sb.ToString()
				mail.Display()
			End If
		End Sub

		Private Sub PowerPointButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If AutomationFactory.IsAvailable Then
				Dim cmd As Object = AutomationFactory.CreateObject("WScript.Shell")
				cmd.Run("c:\windows\notepad.exe", 1, True)
			End If
		End Sub


		Private Sub OnTopButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Toggle between being on top and not
			Application.Current.MainWindow.TopMost = Not Application.Current.MainWindow.TopMost
		End Sub

		Private Sub MinimizeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Minimize the application
			Application.Current.MainWindow.WindowState = WindowState.Minimized
		End Sub

		Private Sub MaximizeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Toggle between the Normal and Maximized state
			If Application.Current.MainWindow.WindowState <> WindowState.Maximized Then
				Application.Current.MainWindow.WindowState = WindowState.Maximized
			Else
				Application.Current.MainWindow.WindowState = WindowState.Normal
			End If
		End Sub

		Private Sub CloseButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Close the application
			Application.Current.MainWindow.Close()
		End Sub

	End Class
End Namespace
