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

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports GuestBook_Data


Public Class WorkerRole
    Inherits RoleEntryPoint

    Private queue As CloudQueue
    Private container As CloudBlobContainer

    Public Overrides Sub Run()
        Trace.TraceInformation("Listening for queue messages...")
        Do
            Try
                ' retrieve a new message from the queue
                Dim msg As CloudQueueMessage = queue.GetMessage()
                If msg IsNot Nothing Then
                    ' parse message retrieved from queue
                    Dim messageParts = msg.AsString.Split(New Char() {","c})
                    Dim imageBlobUri = messageParts(0)
                    Dim partitionKey = messageParts(1)
                    Dim rowKey = messageParts(2)
                    Trace.TraceInformation("Processing image in blob '{0}'.", imageBlobUri)

                    Dim thumbnailBlobUri As String = System.Text.RegularExpressions.Regex.Replace(imageBlobUri, "([^\\.]+)(\\.[^\\.]+)?$", "$1-thumb$2")

                    ' download original image from blob storage
                    Dim inputBlob As CloudBlockBlob = container.GetBlockBlobReference(imageBlobUri)
                    Dim outputBlob As CloudBlockBlob = container.GetBlockBlobReference(thumbnailBlobUri)
                    Using input As BlobStream = inputBlob.OpenRead()
                        Using output As BlobStream = outputBlob.OpenWrite()
                            ProcessImage(input, output)

                            ' commit the blob and set its properties
                            output.Commit()
                            outputBlob.Properties.ContentType = "image/jpeg"
                            outputBlob.SetProperties()

                            ' update the entry in table storage to point to the thumbnail
                            Dim ds = New GuestBookDataSource()
                            ds.UpdateImageThumbnail(partitionKey, rowKey, thumbnailBlobUri)

                            ' remove message from queue
                            queue.DeleteMessage(msg)

                            Trace.TraceInformation("Generated thumbnail in blob '{0}'.", thumbnailBlobUri)
                        End Using
                    End Using
                Else
                    System.Threading.Thread.Sleep(1000)
                End If
            Catch e As StorageClientException
                Trace.TraceError("Exception when processing queue item. Message: '{0}'", e.Message)
                System.Threading.Thread.Sleep(5000)
            End Try
        Loop

    End Sub

    Public Overrides Function OnStart() As Boolean

        ' Set the maximum number of concurrent connections 
        ServicePointManager.DefaultConnectionLimit = 12

        ' read storage account configuration settings
        CloudStorageAccount.SetConfigurationSettingPublisher(Function(configName, configSetter) configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)))
        Dim storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")

        ' initialize blob storage
        Dim blobStorage = storageAccount.CreateCloudBlobClient()
        container = blobStorage.GetContainerReference("guestbookpics")

        ' initialize queue storage 
        Dim queueStorage = storageAccount.CreateCloudQueueClient()
        queue = queueStorage.GetQueueReference("guestthumbs")

        Trace.TraceInformation("Creating container and queue...")

        Dim storageInitialized = False
        Do While (Not storageInitialized)
            Try
                ' create the blob container and allow public access
                container.CreateIfNotExist()
                Dim permissions = container.GetPermissions()
                permissions.PublicAccess = BlobContainerPublicAccessType.Container
                container.SetPermissions(permissions)

                ' create the message queue(s)
                queue.CreateIfNotExist()

                storageInitialized = True
            Catch e As StorageClientException
                If (e.ErrorCode = StorageErrorCode.TransportError) Then
                    Trace.TraceError("Storage services initialization failure. " _
                        & "Check your storage account configuration settings. If running locally, " _
                        & "ensure that the Development Storage service is running. Message: '{0}'", e.Message)
                    System.Threading.Thread.Sleep(5000)
                Else
                    Throw
                End If
            End Try
        Loop

        Return MyBase.OnStart()

    End Function

    Private Sub ProcessImage(ByVal input As Stream, ByVal output As Stream)

        Dim width As Integer
        Dim height As Integer
        Dim originalImage As New Bitmap(input)

        If originalImage.Width > originalImage.Height Then
            width = 128
            height = 128 * originalImage.Height / originalImage.Width
        Else
            height = 128
            width = 128 * originalImage.Width / originalImage.Height
        End If

        Dim thumbnailImage As New Bitmap(width, height)

        Using graphic = Graphics.FromImage(thumbnailImage)
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphic.SmoothingMode = SmoothingMode.AntiAlias
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality
            graphic.DrawImage(originalImage, 0, 0, width, height)
        End Using

        thumbnailImage.Save(output, ImageFormat.Jpeg)

    End Sub

End Class
