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
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.ServiceModel
Imports System.ServiceModel.Discovery
Imports Microsoft.Samples.Discovery.Contracts

Partial Public Class SimpleChat
    Inherits Form

#Region "Methods and Fields modified in lab"

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification:="Demo code")>
    Private Sub AdHocDiscovery()
        Me._discoveryClient = New DiscoveryClient(New UdpDiscoveryEndpoint())

        AddHandler _discoveryClient.FindProgressChanged, AddressOf OnFindProgressChanged
        AddHandler _discoveryClient.FindCompleted, AddressOf OnFindCompleted

        ' Setup the form for discovery
        Me.ShowDiscoveryInProgress(True)

        ' Do async discovery
        Me._discoveryClient.FindAsync(New FindCriteria(GetType(ISimpleChatService)))

    End Sub

    Private Sub OnFindProgressChanged(ByVal sender As Object, ByVal e As FindProgressChangedEventArgs)
        Me.PopulateUserList(e.EndpointDiscoveryMetadata)
    End Sub

    Private Sub OnFindCompleted(ByVal sender As Object, ByVal e As FindCompletedEventArgs)
        If e.Cancelled Then
            Me.ShowStatus("Discovery cancelled")
        ElseIf e.Error IsNot Nothing Then
            Me._discoveryClient.Close()
            MessageBox.Show(e.Error.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, CType(0, MessageBoxOptions))
        Else
            If Me._discoveryClient.InnerChannel.State = CommunicationState.Opened Then
                Me._discoveryClient.Close()
            End If
        End If

        Me._discoveryClient = Nothing
        Me.ShowDiscoveryInProgress(False)
    End Sub

    Private Sub OpenServices()
        ' Create a singleton instance for the host
        Dim chatService As New ChatService(Me)
        Me.chatServiceHost = New ServiceHost(chatService, Me._localAddress)

        Me.ShowStatus("Opening chat service...")
        Me.chatServiceHost.BeginOpen(Sub(result)
                                         chatServiceHost.EndOpen(result)
                                         Me.ShowStatus("Chat service ready")
                                     End Sub, Nothing)
    End Sub

    Private Sub CloseServices()
        If Me.chatServiceHost IsNot Nothing Then Me.chatServiceHost.BeginClose(Sub(result) Me.chatServiceHost.EndClose(result), Nothing)
    End Sub

    Private Sub PopulateUserList(ByVal endpointDiscoveryMetadata As EndpointDiscoveryMetadata)
        If Not (Me.EndpointIsSelf(endpointDiscoveryMetadata.Address.Uri)) Then
            Me.AddUser(New PeerUser(endpointDiscoveryMetadata.Address))
        End If
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification:="Demo code")>
    Private Sub ManagedDiscovery()
        Throw New NotImplementedException()
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification:="Demo code")>
    Private Sub InitializeManagedDiscovery()
        ' TODO
    End Sub

#End Region

#Region "Lab Supplied Code"

#Region "Variables and Imports"
    Private chatServiceHost As ServiceHost
    Private _localAddress As Uri
    Private _userName As String
    Private _discoveryClient As DiscoveryClient
#End Region

    Public Sub New()
        InitializeComponent()
        Me.InitializeManagedDiscovery()
    End Sub

    Public ReadOnly Property UserName As String
        Get
            Return Me._userName
        End Get
    End Property

    Public ReadOnly Property LocalAddress As Uri
        Get
            Return Me._localAddress
        End Get
    End Property

#Region "UI code and logic"

    Private Sub OnSignInOut(ByVal signedIn As Boolean)
        Me.buttonSignOn.Enabled = Not signedIn
        Me.buttonSignOut.Enabled = signedIn
        Me.buttonDiscover.Enabled = signedIn
        Me.discoveryBox.Enabled = signedIn
    End Sub

    Private Sub UserNameText_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles userNameText.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.ButtonSignOn_Click()
        End If
    End Sub

    ' User is setting up the chat client
    Private Sub ButtonSignOn_Click() Handles buttonSignOn.Click
        Me.SignIn()
    End Sub

    Private Sub DiscoverChatUsers()
        Me.userListBox.Items.Clear()

        If managedRadioButton.Checked Then
            Me.ManagedDiscovery()
        Else
            Me.AdHocDiscovery()
        End If
    End Sub

    Private Sub ShowStatus(ByVal status As String)
        If Me.IsHandleCreated Then Invoke(New EventHandler(Sub()
                                                               statusLabel.Text = status
                                                           End Sub))
    End Sub

    Private Sub AdHocRadioB_CheckedChanged() Handles adhocRadioButton.CheckedChanged
        If Me.adhocRadioButton.Checked Then Me.proxyAddressText.Enabled = False
    End Sub

    Private Sub ManagedRadioB_CheckedChanged() Handles managedRadioButton.CheckedChanged
        If Me.managedRadioButton.Checked Then Me.EnableManagedDiscovery()
    End Sub

    Private Sub EnableManagedDiscovery()
        Me.proxyAddressText.Enabled = True
        proxyAddressText.Text = My.Resources.ProxyAddress
    End Sub

    Private Sub DiscoverButton_Click() Handles buttonDiscover.Click
        Me.DiscoverChatUsers()
    End Sub

    Private Sub UserListBox_DoubleClick() Handles userListBox.DoubleClick
        Dim selectedPeerUser = TryCast(Me.userListBox.SelectedItem, PeerUser)
        If selectedPeerUser Is Nothing Then
            MsgBox(My.Resources.SelectUserMessage, MsgBoxStyle.Information, Me.Text)
            Return
        End If

        If selectedPeerUser.ChatWindowExists Then
            ShowChatWindow(selectedPeerUser)
        Else
            Dim newChatWindow As New ChatWindow(Me, selectedPeerUser)
            selectedPeerUser.ChatWindow = newChatWindow
            ShowChatWindow(selectedPeerUser)
        End If
    End Sub

    Private Shared Sub ShowChatWindow(ByVal peerUserObject As PeerUser)
        NativeMethods.SetForegroundWindow(peerUserObject.ChatWindow.Owner.Handle)
        NativeMethods.SetForegroundWindow(peerUserObject.ChatWindow.Handle)
    End Sub

    Private Sub ButtonSignOut_Click() Handles buttonSignOut.Click
        Me.SignOut()
    End Sub

    Private Sub ChatButton_Click() Handles chatButton.Click
        Me.UserListBox_DoubleClick()
    End Sub

    Private Sub UserListBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles userListBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.UserListBox_DoubleClick()
        End If
    End Sub

    Public Function GetUser(ByVal searchUri As Uri) As PeerUser
        For Each user As Object In Me.userListBox.Items
            Dim peerUser = TryCast(user, PeerUser)
            If peerUser.Address.Uri.Equals(searchUri) Then Return peerUser
        Next user

        Return Nothing
    End Function

    Public Sub AddUser(ByVal peerUser As PeerUser)
        Me.userListBox.Items.Add(peerUser)
        Me.EnableUsersBox()
    End Sub

    Public Sub RemoveUser(ByVal searchUri As Uri)
        For Each user As Object In Me.userListBox.Items
            Dim peerUser = TryCast(user, PeerUser)
            If peerUser.Address.Uri.Equals(searchUri) Then
                If peerUser.ChatWindowExists Then peerUser.ChatWindow.Close()

                Me.userListBox.Items.Remove(user)
                Exit For
            End If
        Next user
    End Sub

    Private Sub CloseAllWindows()
        For Each userObject As Object In Me.userListBox.Items
            Dim peerUser = TryCast(userObject, PeerUser)
            If peerUser.ChatWindowExists Then peerUser.ChatWindow.Close()
        Next userObject
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        Me.SignOut()
        MyBase.OnClosing(e)
    End Sub

#End Region

    Private Sub SignIn()
        Me._userName = userNameText.Text.Trim()

        If Me._userName.Length = 0 Then
            MsgBox(My.Resources.EnterValidNameMessage, MsgBoxStyle.Information, Me.Text)
            Return
        End If

        Me.Text = String.Format(CultureInfo.CurrentCulture, My.Resources.DiscoveryChat, Me._userName)

        Me.ShowStatus("Getting host name")

        ' Initialize the setup parameters            
        Me._localAddress = New Uri("http://localhost:8000/" & Guid.NewGuid().ToString())

        Me.ShowStatus("Opening chat service host")
        Me.OpenServices()
        Me.OnSignInOut(True)
        Me.DiscoverChatUsers()
    End Sub

    Private Sub SignOut()
        Me.ShowStatus("Signing out...")
        Me.AbortDiscovery()
        Me.CloseServices()
        Me.CloseAllWindows()
        Me.userListBox.Items.Clear()
        Me.EnableUsersBox()
        Me.OnSignInOut(False)
    End Sub

    Private Sub ShowDiscoveryInProgress(ByVal inProgress As Boolean)
        buttonDiscover.Enabled = Not inProgress

        If inProgress Then
            buttonDiscover.Text = My.Resources.DiscoveryInProgressText
        Else
            buttonDiscover.Text = My.Resources.DiscoverUsersText
        End If
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification:="Demo code")>
    Private Function EndpointIsSelf(ByVal endpointUri As Uri) As Boolean
        Return Me._localAddress.Equals(endpointUri)
    End Function

    Private Sub EnableUsersBox()
        Me.usersBox.Enabled = Me.userListBox.Items.Count > 0
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification:="Demo code")>
    Private Sub AbortDiscovery()
        If (Me._discoveryClient IsNot Nothing) Then
            Me._discoveryClient.CancelAsync(Me._discoveryClient)
            Me._discoveryClient.Close()
        End If
    End Sub

    Private Shared Function GetPeerName(ByVal metadata As EndpointDiscoveryMetadata) As String
        Dim peerNameElement = metadata.Extensions.Elements("Name").FirstOrDefault()

        If (peerNameElement IsNot Nothing) Then
            Return peerNameElement.Value
        End If
        Return Nothing
    End Function
#End Region
End Class