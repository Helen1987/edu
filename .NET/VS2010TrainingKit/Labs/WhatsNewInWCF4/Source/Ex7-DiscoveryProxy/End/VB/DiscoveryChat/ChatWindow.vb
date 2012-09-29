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

Imports System.ComponentModel
Imports System.Globalization
Imports System.ServiceModel
Imports Microsoft.Samples.Discovery.Contracts

Partial Public Class ChatWindow
    Inherits Form
    Private chatClient As ISimpleChatService
    Private simpleChatOwner As SimpleChat
    Private peerUser As PeerUser

    Public Sub New(ByVal simpleChat As SimpleChat, ByVal peerUserObject As PeerUser)
        If simpleChat Is Nothing Then Throw New ArgumentNullException("simpleChat")

        If peerUserObject Is Nothing Then Throw New ArgumentNullException("peerUserObject")

        InitializeComponent()

        Me.chatClient = ChannelFactory(Of ISimpleChatService).CreateChannel(New WSHttpBinding(), peerUserObject.Address)

        Me.simpleChatOwner = simpleChat

        Me.peerUser = peerUserObject

        Dim chatWith As String = Nothing

        If (Not String.IsNullOrEmpty(peerUserObject.UserName)) Then
            chatWith = Me.peerUser.UserName
        Else
            chatWith = Me.peerUser.Address.Uri.Host
        End If

        Text = String.Format(CultureInfo.CurrentCulture, My.Resources.ChattingWithMessage, simpleChat.UserName, chatWith)
        Owner = simpleChat

        StartPosition = FormStartPosition.CenterParent
        Show()
        chatText.Focus()
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification:="Demo code")>
    Private Sub SendMessage_Click() Handles sendMessage.Click
        Try
            Dim sentMsg As New ChatMessage(Me.simpleChatOwner.UserName, chatText.Text, Me.simpleChatOwner.LocalAddress)
            Me.chatClient.ProcessSimpleMessage(sentMsg)
            Me.DisplayMessage(sentMsg)
            Me.chatText.Clear()
        Catch cex As CommunicationException
            CType(chatClient, ICommunicationObject).Abort()
            MsgBox(String.Format(CultureInfo.CurrentCulture, My.Resources.UserNotAvailableMessage, Me.peerUser.UserName, cex.Message), MsgBoxStyle.Information, Me.Text)
            Me.simpleChatOwner.RemoveUser(Me.peerUser.Address.Uri)
            Me.Close()
        Catch ex As Exception
            MsgBox(String.Format(CultureInfo.CurrentCulture, My.Resources.UnknownErrorMessage, ex.Message), MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub ChatText_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles chatText.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.SendMessage_Click()
        End If
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        If Me.chatClient IsNot Nothing Then
            Try
                CType(chatClient, ICommunicationObject).Close()
            Catch e1 As CommunicationException
                ' No worries, closing
            End Try
        End If

        MyBase.OnClosing(e)
    End Sub

    Public Sub DisplayMessage(ByVal message As ChatMessage)
        If message Is Nothing Then Throw New ArgumentNullException("message")

        chatBox.Items.Add(message.UserName & " says: " & message.Message)
    End Sub
End Class