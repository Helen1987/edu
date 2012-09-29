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

Public Class GuestBookDataContext
    Inherits Microsoft.WindowsAzure.StorageClient.TableServiceContext

    Public Sub New(ByVal baseAddress As String, ByVal credentials As Microsoft.WindowsAzure.StorageCredentials)
        MyBase.New(baseAddress, credentials)
    End Sub

    Public ReadOnly Property GuestBookEntry() As IQueryable(Of GuestBookEntry)
        Get
            Return Me.CreateQuery(Of GuestBookEntry)("GuestBookEntry")
        End Get
    End Property
End Class
