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

Imports System.ServiceModel
Imports Microsoft.Samples.Discovery.Contracts

<ServiceBehavior(InstanceContextMode := InstanceContextMode.Single)>
Friend Class ChatService
    Implements ISimpleChatService
    Private simpleChat As SimpleChat

    Public Sub New(ByVal simpleChat As SimpleChat)
        Me.simpleChat = simpleChat
    End Sub

    Public Sub ProcessSimpleMessage(ByVal chatMessage As ChatMessage) Implements ISimpleChatService.ProcessSimpleMessage
        If chatMessage Is Nothing OrElse String.IsNullOrEmpty(chatMessage.UserName) OrElse chatMessage.UserUri Is Nothing Then Return

        Dim peerUserObject As PeerUser = Me.simpleChat.GetUser(chatMessage.UserUri)
        If peerUserObject Is Nothing Then
            ' User is not in internal store, update container and show message               
            peerUserObject = New PeerUser(chatMessage.UserName, New EndpointAddress(chatMessage.UserUri))
            Me.simpleChat.AddUser(peerUserObject)

            peerUserObject.ChatWindow = New ChatWindow(Me.simpleChat, peerUserObject)
        End If

        If peerUserObject.ChatWindowExists Then
            ' User is in internal store and has an open chat window
            peerUserObject.ChatWindow.DisplayMessage(chatMessage)
            ShowChatWindow(peerUserObject)
        Else
            ' User is in internal store but no chat window is open                
            peerUserObject.ChatWindow = New ChatWindow(Me.simpleChat, peerUserObject)
            peerUserObject.ChatWindow.DisplayMessage(chatMessage)
            ShowChatWindow(peerUserObject)
        End If
    End Sub

    Private Shared Sub ShowChatWindow(ByVal peerUserObject As PeerUser)
        NativeMethods.SetForegroundWindow(peerUserObject.ChatWindow.Handle)
    End Sub
End Class