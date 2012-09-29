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

Imports System.Windows.Forms
Imports System.Windows.Forms.Integration

Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        Dim taskPane = New UserControl()

        taskPane.Controls.Add(
            New ElementHost With {
                .Child = New TaskPane(),
                .Dock = DockStyle.Fill
            })

        Dim formulaTaskPane = CustomTaskPanes.Add(taskPane, "Custom Snippets")
        formulaTaskPane.Visible = True
        formulaTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight
        formulaTaskPane.Width = 300
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
        Return New Ribbon()
    End Function
End Class
