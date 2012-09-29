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
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace SilverlightWebBrowser
	Partial Public Class InstallPrompt
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			AddHandler Loaded, AddressOf InstallPrompt_Loaded
			AddHandler InstallButton.Click, AddressOf InstallButton_Click
		End Sub

		Private Sub InstallPrompt_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If Application.Current.InstallState = InstallState.Installed Then
				InstallPanel.Visibility = Visibility.Collapsed
				AlreadyInstalledPanel.Visibility = Visibility.Visible
			Else
				InstallPanel.Visibility = Visibility.Visible
				AlreadyInstalledPanel.Visibility = Visibility.Collapsed
			End If
		End Sub

		Private Sub InstallButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Application.Current.Install()
		End Sub
	End Class
End Namespace
