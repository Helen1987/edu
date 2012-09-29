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

Imports System.Runtime.Serialization
Imports System.ServiceModel

Namespace Contracts

    <ServiceContract(ConfigurationName := "ISimpleChatService", Name := "SimpleChat", Namespace := "http://sample.microsoft.com/wcf4")>
    Public Interface ISimpleChatService
        <OperationContract(IsOneWay := True, Action := "http://sample.microsoft.com/wcf4/SendSimpleMsgAction")>
        Sub ProcessSimpleMessage(ByVal message As ChatMessage)
    End Interface

    ' This datacontract defines the basic message that the SimpleChat Service needs to implement
    <DataContract(Name:="ChatMessage", Namespace:="http://sample.microsoft.com/wcf4/ChatClient")>
    Public Class ChatMessage
        Public Sub New(ByVal userName As String, ByVal message As String, ByVal userUri As Uri)
            Me.UserName = userName
            Me.Message = message
            Me.UserUri = userUri
        End Sub

        <DataMember()>
        Public Property UserName() As String

        <DataMember()>
        Public Property Message() As String

        <DataMember()>
        Public Property UserUri() As Uri

    End Class
End Namespace