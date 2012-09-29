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

Public Class SnippetDataSource
    Private m_snippets As ObservableCollection(Of Snippet) = New SafeObservableCollection(Of Snippet)()

    Public Function GetSnippets() As ObservableCollection(Of Snippet)
        Dim loadDelegate = New System.Action(
                           Sub()
                               m_snippets.Add(New Snippet("Header", "Header information", "This is the header"))
                               m_snippets.Add(New Snippet("Footer", "Footer information", "This is the footer"))
                           End Sub)

        loadDelegate.BeginInvoke(Nothing, Nothing)

        Return m_snippets
    End Function
End Class
