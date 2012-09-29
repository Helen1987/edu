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

Imports System.Collections.ObjectModel
Imports System.ServiceModel.Discovery

Public Class FindAsyncResult
    Inherits CompletedAsyncResult
    Private matchingEndpoints As Collection(Of EndpointDiscoveryMetadata)

    Public Sub New(ByVal matchingEndpoints As Collection(Of EndpointDiscoveryMetadata), ByVal callback As AsyncCallback, ByVal state As Object)
        MyBase.New(callback, state)
        Me.matchingEndpoints = matchingEndpoints
    End Sub

    ' Hides the inherited End from CompletedAsyncResult
    ' This method returns a collection of metadata
    Public Shared Shadows Function [End](ByVal result As IAsyncResult) As Collection(Of EndpointDiscoveryMetadata)
        Dim thisPtr = AsyncResult.End(Of FindAsyncResult)(result)
        Return thisPtr.matchingEndpoints
    End Function
End Class