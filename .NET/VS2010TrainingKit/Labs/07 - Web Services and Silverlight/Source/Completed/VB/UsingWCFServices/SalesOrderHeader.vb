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

Imports System.ComponentModel
Namespace WebServiceProxies
    Partial Public Class SalesOrderHeader
        Implements IEditableObject

        Private _OriginalObject As SalesOrderHeader
        Private _Editing As Boolean

        Public Sub BeginEdit() Implements IEditableObject.BeginEdit
            If Not _Editing Then
                _Editing = True
                _OriginalObject = TryCast(Me.MemberwiseClone(), SalesOrderHeader)
            End If
        End Sub

        Public Sub CancelEdit() Implements IEditableObject.CancelEdit
            If _Editing Then
                Comment = _OriginalObject.Comment
                ShipDate = _OriginalObject.ShipDate
                _Editing = False
            End If
        End Sub

        Public Sub EndEdit() Implements IEditableObject.EndEdit
            If _Editing Then
                _Editing = False
                _OriginalObject = Nothing
            End If
        End Sub

    End Class
End Namespace
