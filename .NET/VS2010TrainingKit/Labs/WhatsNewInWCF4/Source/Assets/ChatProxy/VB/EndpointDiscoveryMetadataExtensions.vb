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

Imports System.ServiceModel.Discovery

Public Module EndpointDiscoveryMetadataExtensions
    Private Const ConsoleFormat = "{0} service {1} user {2}"

    <System.Runtime.CompilerServices.Extension>
    Public Sub WriteLine(ByVal metadata As EndpointDiscoveryMetadata, ByVal verb As String)
        If metadata Is Nothing Then Throw New ArgumentNullException("metadata")

        Dim peerNameElement = metadata.Extensions.<Name>
        Dim name As String
        If peerNameElement IsNot Nothing Then
            name = peerNameElement.Value
        Else
            name = metadata.Address.ToString()
        End If

        Console.WriteLine(ConsoleFormat, verb, metadata.ContractTypeNames.FirstOrDefault(), name)
    End Sub
End Module