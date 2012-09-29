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

Imports System.ServiceModel

Public Class PeerUser
    Private privateUserName As String

    Public Sub New(ByVal address As EndpointAddress)
        Me.Address = address
    End Sub

    Public Sub New(ByVal userName As String, ByVal address As EndpointAddress)
        Me.privateUserName = userName
        Me.Address = address
    End Sub

    Public Sub New(ByVal userName As String, ByVal address As EndpointAddress, ByVal chatWindow As ChatWindow)
        Me.privateUserName = userName
        Me.Address = address
        Me.ChatWindow = chatWindow
    End Sub

    Public ReadOnly Property UserName() As String
        Get
            Return Me.privateUserName
        End Get
    End Property

    Public Property ChatWindow() As ChatWindow

    Public Property Address() As EndpointAddress

    Public ReadOnly Property ChatWindowExists() As Boolean
        Get
            Return (Me.ChatWindow IsNot Nothing) AndAlso Not Me.ChatWindow.IsDisposed
        End Get
    End Property

    Public Overrides Function ToString() As String
        If Me.privateUserName Is Nothing Then
            Return Me.Address.Uri.ToString()
        Else
            Return Me.privateUserName
        End If
    End Function
End Class