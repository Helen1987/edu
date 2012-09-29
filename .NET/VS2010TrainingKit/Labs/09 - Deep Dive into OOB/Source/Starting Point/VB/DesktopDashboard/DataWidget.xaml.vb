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

		End Sub
	End Class
End Namespace