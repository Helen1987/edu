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

Imports System.Windows
Imports System.Windows.Controls

Namespace UsingWCFServices
	Partial Public Class ErrorWindow
		Inherits ChildWindow
		Public Sub New(ByVal e As Exception)
			InitializeComponent()
			If e IsNot Nothing Then
				ErrorTextBox.Text = e.Message & Environment.NewLine & Environment.NewLine & e.StackTrace
			End If
		End Sub

		Public Sub New(ByVal uri_Renamed As Uri)
			InitializeComponent()
			If uri_Renamed IsNot Nothing Then
				ErrorTextBox.Text = "Page not found: """ & uri_Renamed.ToString() & """"
			End If
		End Sub

		Public Sub New(ByVal message As String, ByVal details As String)
			InitializeComponent()
			ErrorTextBox.Text = message & Environment.NewLine & Environment.NewLine & details
		End Sub

		Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.DialogResult = True
		End Sub
	End Class
End Namespace