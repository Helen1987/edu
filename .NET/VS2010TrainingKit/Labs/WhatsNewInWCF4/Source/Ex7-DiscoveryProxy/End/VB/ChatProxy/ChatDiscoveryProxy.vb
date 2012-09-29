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
Imports System.ServiceModel
Imports Microsoft.Samples.Discovery.Contracts

<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single, ConcurrencyMode:=ConcurrencyMode.Multiple)>
Public Class ChatDiscoveryProxy
    Inherits DiscoveryProxy

    Private Shared cache_Renamed As New ChatServiceCollection()

    Friend Shared ReadOnly Property Cache() As ChatServiceCollection
        Get
            Return cache_Renamed
        End Get
    End Property

    Protected Overrides Function OnBeginFind(ByVal findRequestContext As FindRequestContext, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
        If findRequestContext Is Nothing Then
            Throw New ArgumentNullException("findRequestContext")
        End If

        Console.WriteLine("Find request for contract {0}", findRequestContext.Criteria.ContractTypeNames.FirstOrDefault())

        ' Query to find the matching endpoints
        Dim query = From service In Cache
                    Where findRequestContext.Criteria.IsMatch(service)
                    Select service

        ' Collection to contain the results of the query
        Dim matchingEndpoints = New Collection(Of EndpointDiscoveryMetadata)()

        ' Execute the query and add the matching endpoints
        For Each metadata As EndpointDiscoveryMetadata In query
            metadata.WriteLine(Constants.vbTab & "Found")
            matchingEndpoints.Add(metadata)
            findRequestContext.AddMatchingEndpoint(metadata)
        Next metadata

        Return New FindAsyncResult(matchingEndpoints, callback, state)
    End Function

    Protected Overrides Function OnBeginOfflineAnnouncement(ByVal messageSequence As DiscoveryMessageSequence, ByVal endpointDiscoveryMetadata As EndpointDiscoveryMetadata, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
        Try
            If endpointDiscoveryMetadata Is Nothing Then
                Throw New ArgumentNullException("endpointDiscoveryMetadata")
            End If

            ' We care only about ISimpleChatService services
            Dim criteria As New FindCriteria(GetType(ISimpleChatService))

            If criteria.IsMatch(endpointDiscoveryMetadata) Then
                endpointDiscoveryMetadata.WriteLine("Removing")
                Cache.Remove(endpointDiscoveryMetadata.Address.Uri)
            End If
        Catch e1 As KeyNotFoundException
            ' No problem if it does not exist in the cache
        End Try

        Return New CompletedAsyncResult(callback, state)
    End Function

    Protected Overrides Function OnBeginOnlineAnnouncement(ByVal messageSequence As DiscoveryMessageSequence, ByVal endpointDiscoveryMetadata As EndpointDiscoveryMetadata, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
        If endpointDiscoveryMetadata Is Nothing Then
            Throw New ArgumentNullException("endpointDiscoveryMetadata")
        End If

        ' We care only about ISimpleChatService services
        Dim criteria As New FindCriteria(GetType(ISimpleChatService))

        If criteria.IsMatch(endpointDiscoveryMetadata) Then
            endpointDiscoveryMetadata.WriteLine("Adding")
            Cache.Add(endpointDiscoveryMetadata)
        End If

        Return New CompletedAsyncResult(callback, state)
    End Function

    Protected Overrides Sub OnEndFind(ByVal result As System.IAsyncResult)
        FindAsyncResult.End(result)
    End Sub

    Protected Overrides Function OnBeginResolve(ByVal resolveCriteria As ResolveCriteria, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
        Return New CompletedAsyncResult(callback, state)
    End Function

    Protected Overrides Function OnEndResolve(ByVal result As IAsyncResult) As EndpointDiscoveryMetadata
        Return CompletedAsyncResult(Of EndpointDiscoveryMetadata).End(result)
    End Function

    Protected Overrides Sub OnEndOfflineAnnouncement(ByVal result As IAsyncResult)
        CompletedAsyncResult.End(result)
    End Sub

    Protected Overrides Sub OnEndOnlineAnnouncement(ByVal result As IAsyncResult)
        CompletedAsyncResult.End(result)
    End Sub
End Class
