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

Imports System.Windows.Input

Public Class TaskPane
    Private m_application As Word.Application

    Public Sub New(ByVal application As Word.Application)
        m_application = application

        InitializeComponent()

        Snippets.Items.Clear()
        Snippets.Items.Add(New Snippet("Header", "Header information", "This is the header"))
        Snippets.Items.Add(New Snippet("Footer", "Footer information", "This is the footer"))
    End Sub

    Private Sub Snippets_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        m_application.Selection.Range.Text = (TryCast(Snippets.SelectedItem, Snippet)).Content
    End Sub
End Class
