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

Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Data.Services.Providers
Imports System.IO

Namespace BLOBStreams
    Public Class BLOBStreamService
        Inherits DataService(Of BLOBStreamContext)
        Implements IServiceProvider
        
        Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2
            config.SetEntitySetAccessRule("Products", EntitySetRights.All)
            config.SetEntitySetPageSize("Products", 10)
        End Sub

        Public Function GetService(ByVal serviceType As Type) As Object Implements System.IServiceProvider.GetService
            If (serviceType IsNot GetType(IDataServiceStreamProvider)) Then
                Return Nothing
            End If
            Return New ProductStreamProvider
        End Function
    End Class

    Public Class ProductStreamProvider
        Implements IDataServiceStreamProvider

        Public Function GetReadStream(ByVal entity As Object, ByVal etag As String, ByVal checkETagForEquality As Nullable(Of Boolean), ByVal operationContext As DataServiceOperationContext) As System.IO.Stream Implements IDataServiceStreamProvider.GetReadStream
            Dim product = TryCast(entity, Product)

            If (product Is Nothing) Then
                Return Nothing
            End If
            Using context = New BLOBStreamContext
                Dim photo = context.ProductPhotos.First(Function(p) p.Id = product.Id)
                Dim stream As New MemoryStream(photo.Photo)
                Return stream
            End Using
        End Function

        Public Function GetReadStreamUri(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As Uri Implements IDataServiceStreamProvider.GetReadStreamUri
            Return Nothing
        End Function

        Public Function GetStreamContentType(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As String Implements IDataServiceStreamProvider.GetStreamContentType
            Return "image/jpeg"
        End Function

        Public Function GetStreamETag(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As String Implements IDataServiceStreamProvider.GetStreamETag
            Return Nothing
        End Function

        Public ReadOnly Property StreamBufferSize As Integer Implements IDataServiceStreamProvider.StreamBufferSize
            Get
                Return 64
            End Get
        End Property

        Public Sub DeleteStream(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) Implements IDataServiceStreamProvider.DeleteStream
            Throw New NotImplementedException
        End Sub

        Public Function GetWriteStream(ByVal entity As Object, ByVal etag As String, ByVal checkETagForEquality As Nullable(Of Boolean), ByVal operationContext As DataServiceOperationContext) As System.IO.Stream Implements IDataServiceStreamProvider.GetWriteStream
            Throw New NotImplementedException
        End Function

        Public Function ResolveType(ByVal entitySetName As String, ByVal operationContext As DataServiceOperationContext) As String Implements IDataServiceStreamProvider.ResolveType
            Throw New NotImplementedException
        End Function
    End Class
End Namespace