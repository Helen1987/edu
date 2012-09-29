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

Imports System.IO
Imports System.Net
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports GuestBook_Data

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private Shared storageInitialized As Boolean = False
    Private Shared gate As New Object()
    Private Shared blobStorage As CloudBlobClient
    Private Shared queueStorage As CloudQueueClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then
            Timer1.Enabled = True
        End If

    End Sub

    Protected Sub SignButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SignButton.Click

        If FileUpload1.HasFile Then
            InitializeStorage()

            ' upload the image to blob storage
            Dim uniqueBlobName As String = String.Format("guestbookpics/image_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(FileUpload1.FileName))
            Dim blob As CloudBlockBlob = blobStorage.GetBlockBlobReference(uniqueBlobName)
            blob.Properties.ContentType = FileUpload1.PostedFile.ContentType
            blob.UploadFromStream(FileUpload1.FileContent)
            System.Diagnostics.Trace.TraceInformation("Uploaded image '{0}' to blob storage as '{1}'", FileUpload1.FileName, uniqueBlobName)

            ' create a new entry in table storage
            Dim entry As New GuestBookEntry() With {.GuestName = NameTextBox.Text, .Message = MessageTextBox.Text, .PhotoUrl = blob.Uri.ToString(), .ThumbnailUrl = blob.Uri.ToString()}
            Dim ds As New GuestBookDataSource()
            ds.AddGuestBookEntry(entry)
            System.Diagnostics.Trace.TraceInformation("Added entry {0}-{1} in table storage for guest '{2}'", entry.PartitionKey, entry.RowKey, entry.GuestName)

            ' queue a message to process the image
            Dim queue = queueStorage.GetQueueReference("guestthumbs")
            Dim message = New CloudQueueMessage(String.Format("{0},{1},{2}", blob.Uri.ToString(), entry.PartitionKey, entry.RowKey))
            queue.AddMessage(message)
            System.Diagnostics.Trace.TraceInformation("Queued message to process blob '{0}'", uniqueBlobName)
        End If

        NameTextBox.Text = ""
        MessageTextBox.Text = ""

        DataList1.DataBind()

    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick

        DataList1.DataBind()

    End Sub

    Private Sub InitializeStorage()

        If storageInitialized Then
            Return
        End If
        SyncLock gate
            If storageInitialized Then
                Return
            End If

            Try
                ' read account configuration settings
                Dim storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")

                ' create blob container for images
                blobStorage = storageAccount.CreateCloudBlobClient()
                Dim container As CloudBlobContainer = blobStorage.GetContainerReference("guestbookpics")
                container.CreateIfNotExist()

                ' configure container for public access
                Dim permissions = container.GetPermissions()
                permissions.PublicAccess = BlobContainerPublicAccessType.Container
                container.SetPermissions(permissions)

                ' create queue to communicate with worker role
                queueStorage = storageAccount.CreateCloudQueueClient()
                Dim queue As CloudQueue = queueStorage.GetQueueReference("guestthumbs")
                queue.CreateIfNotExist()
            Catch e1 As WebException
                Throw New WebException("Storage services initialization failure. " _
                  & "Check your storage account configuration settings. If running locally, " _
                  & "ensure that the Development Storage service is running.")
            End Try

            storageInitialized = True
        End SyncLock
    End Sub
End Class