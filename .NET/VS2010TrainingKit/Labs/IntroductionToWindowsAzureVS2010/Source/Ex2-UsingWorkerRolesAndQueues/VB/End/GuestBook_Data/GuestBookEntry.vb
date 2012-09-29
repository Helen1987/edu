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

Public Class GuestBookEntry
    Inherits Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    Public Sub New()
        PartitionKey = DateTime.UtcNow.ToString("MMddyyyy")

        ' Row key allows sorting, so we make sure the rows come back in time order.
        RowKey = String.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid())
    End Sub

    Public Property Message As String
    Public Property GuestName As String
    Public Property PhotoUrl As String
    Public Property ThumbnailUrl As String
End Class
