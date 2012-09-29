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

Imports Microsoft.Office.Core

Public Class ExportProperties
    Public Property XpsEnabled As Boolean
        Get
            Return Me.GetProperty(Of Boolean)("XpsEnabled")
        End Get
        Set(ByVal value As Boolean)
            Me.SetProperty("XpsEnabled", MsoDocProperties.msoPropertyTypeBoolean, value)
        End Set
    End Property

    Public Property XpsExportPath As String
        Get
            Return Me.GetProperty(Of String)("XpsExportPath")
        End Get
        Set(ByVal value As String)
            Me.SetProperty("XpsExportPath", MsoDocProperties.msoPropertyTypeString, value)
        End Set
    End Property

    Public Property PdfEnabled As Boolean
        Get
            Return Me.GetProperty(Of Boolean)("PdfEnabled")
        End Get
        Set(ByVal value As Boolean)
            Me.SetProperty("PdfEnabled", MsoDocProperties.msoPropertyTypeBoolean, value)
        End Set
    End Property

    Public Property PdfExportPath As String
        Get
            Return Me.GetProperty(Of String)("PdfExportPath")
        End Get
        Set(ByVal value As String)
            Me.SetProperty("PdfExportPath", MsoDocProperties.msoPropertyTypeString, value)
        End Set
    End Property

        Private Function GetProperty(Of T)(ByVal propertyName As String) As T
        Dim prop = Me.FindProperty(propertyName)
        If prop Is Nothing Then
            Return Nothing
        Else
            Return CType(prop.Value, T)
        End If
    End Function

    Private Sub SetProperty(ByVal propertyName As String, ByVal propertyType As MsoDocProperties, ByVal value As Object)
        Dim prop = Me.FindProperty(propertyName)
        If prop Is Nothing Then
            Me.AddProperty(propertyName, propertyType, value)
        Else
            prop.Value = value
        End If
    End Sub

    Private Function FindProperty(ByVal propertyName As String) As DocumentProperty
        Dim properties = Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties

        For Each prop As Office.DocumentProperty In properties
            If prop.Name = propertyName Then
                Return prop
            End If
        Next

        Return Nothing
    End Function

    Private Sub AddProperty(ByVal propertyName As String, ByVal propertyType As MsoDocProperties, ByVal value As Object)
        Dim properties = Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties
        properties.Add(propertyName, False, propertyType, value)
    End Sub
End Class
