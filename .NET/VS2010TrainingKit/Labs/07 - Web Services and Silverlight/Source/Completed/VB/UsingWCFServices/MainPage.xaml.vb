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
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace UsingWCFServices
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		' After the Frame navigates, ensure the HyperlinkButton representing the current page is selected
		Private Sub ContentFrame_Navigated(ByVal sender As Object, ByVal e As NavigationEventArgs)
			For Each child As UIElement In LinksStackPanel.Children
				Dim hb As HyperlinkButton = TryCast(child, HyperlinkButton)
				If hb IsNot Nothing AndAlso hb.NavigateUri IsNot Nothing Then
					If hb.NavigateUri.ToString().Equals(e.Uri.ToString()) Then
						VisualStateManager.GoToState(hb, "ActiveLink", True)
					Else
						VisualStateManager.GoToState(hb, "InactiveLink", True)
					End If
				End If
			Next child
		End Sub

		' If an error occurs during navigation, show an error window
		Private Sub ContentFrame_NavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs)
			e.Handled = True
			Dim errorWin As ChildWindow = New ErrorWindow(e.Uri)
			errorWin.Show()
		End Sub
	End Class
End Namespace