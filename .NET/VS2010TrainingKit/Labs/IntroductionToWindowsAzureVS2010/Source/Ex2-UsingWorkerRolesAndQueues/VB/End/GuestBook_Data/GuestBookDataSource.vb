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

Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient

Public Class GuestBookDataSource

    Private Shared storageAccount As CloudStorageAccount
    Private context As GuestBookDataContext

    Shared Sub New()
        storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")

        CloudTableClient.CreateTablesFromModel(GetType(GuestBookDataContext), storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials)
    End Sub

    Public Sub New()
        Me.context = New GuestBookDataContext(storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials)
        Me.context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1))
    End Sub

    Public Function GetGuestBookEntries() As IEnumerable(Of GuestBookEntry)
        Dim results = From g In Me.context.GuestBookEntry _
                      Where g.PartitionKey = DateTime.UtcNow.ToString("MMddyyyy") _
                      Select g
        Return results
    End Function

    Public Sub AddGuestBookEntry(ByVal newItem As GuestBookEntry)
        Me.context.AddObject("GuestBookEntry", newItem)
        Me.context.SaveChanges()
    End Sub

    Public Sub UpdateImageThumbnail(ByVal partitionKey As String, ByVal rowKey As String, ByVal thumbUrl As String)
        Dim results = From g In Me.context.GuestBookEntry _
                      Where g.PartitionKey = partitionKey AndAlso g.RowKey = rowKey _
                      Select g

        Dim entry = results.FirstOrDefault()
        entry.ThumbnailUrl = thumbUrl
        Me.context.UpdateObject(entry)
        Me.context.SaveChanges()
    End Sub
End Class
