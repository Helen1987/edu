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


Public Class SimpleStack
    Private _items As ArrayList

    Public Sub New()
        Me._items = New ArrayList
    End Sub

    Public ReadOnly Property IsEmpty() As Boolean
        Get
            Return (Me._items.Count = 0)
        End Get
    End Property

    Public Sub Push(ByVal p As Integer)
        Me._items.Add(p)
    End Sub

    Public Function Pop() As Integer
        Dim value As Integer = CInt(Me._items.Item(0))
        Me._items.RemoveAt(0)
        Return value
    End Function
End Class
