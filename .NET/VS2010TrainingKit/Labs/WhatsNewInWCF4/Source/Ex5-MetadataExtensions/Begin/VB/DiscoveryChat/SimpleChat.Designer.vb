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

Partial Public Class SimpleChat
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId:="chatServiceHost", Justification:="Demo code")>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(SimpleChat))
        Me.adhocRadioButton = New System.Windows.Forms.RadioButton()
        Me.managedRadioButton = New System.Windows.Forms.RadioButton()
        Me.proxyAddressText = New System.Windows.Forms.TextBox()
        Me.discoveryBox = New System.Windows.Forms.GroupBox()
        Me.discoverStatus = New System.Windows.Forms.Label()
        Me.buttonDiscover = New System.Windows.Forms.Button()
        Me.usersBox = New System.Windows.Forms.GroupBox()
        Me.chatButton = New System.Windows.Forms.Button()
        Me.userListBox = New System.Windows.Forms.ListBox()
        Me.setupBox = New System.Windows.Forms.GroupBox()
        Me.buttonSignOut = New System.Windows.Forms.Button()
        Me.buttonSignOn = New System.Windows.Forms.Button()
        Me.userNameText = New System.Windows.Forms.TextBox()
        Me.userNameLabel = New System.Windows.Forms.Label()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.discoveryBox.SuspendLayout()
        Me.usersBox.SuspendLayout()
        Me.setupBox.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' adhocRadioButton
        ' 
        resources.ApplyResources(Me.adhocRadioButton, "adhocRadioButton")
        Me.adhocRadioButton.Checked = True
        Me.adhocRadioButton.Name = "adhocRadioButton"
        Me.adhocRadioButton.TabStop = True
        Me.adhocRadioButton.UseVisualStyleBackColor = True
        ' AddHandler Me.adhocRadioButton.CheckedChanged, AddressOf Me.AdHocRadioB_CheckedChanged
        ' 
        ' managedRadioButton
        ' 
        resources.ApplyResources(Me.managedRadioButton, "managedRadioButton")
        Me.managedRadioButton.Name = "managedRadioButton"
        Me.managedRadioButton.UseVisualStyleBackColor = True
        ' AddHandler Me.managedRadioButton.CheckedChanged, AddressOf Me.ManagedRadioB_CheckedChanged
        ' 
        ' proxyAddressText
        ' 
        resources.ApplyResources(Me.proxyAddressText, "proxyAddressText")
        Me.proxyAddressText.Name = "proxyAddressText"
        ' 
        ' discoveryBox
        ' 
        Me.discoveryBox.Controls.Add(Me.discoverStatus)
        Me.discoveryBox.Controls.Add(Me.buttonDiscover)
        Me.discoveryBox.Controls.Add(Me.adhocRadioButton)
        Me.discoveryBox.Controls.Add(Me.proxyAddressText)
        Me.discoveryBox.Controls.Add(Me.managedRadioButton)
        resources.ApplyResources(Me.discoveryBox, "discoveryBox")
        Me.discoveryBox.Name = "discoveryBox"
        Me.discoveryBox.TabStop = False
        ' 
        ' discoverStatus
        ' 
        resources.ApplyResources(Me.discoverStatus, "discoverStatus")
        Me.discoverStatus.Name = "discoverStatus"
        ' 
        ' buttonDiscover
        ' 
        resources.ApplyResources(Me.buttonDiscover, "buttonDiscover")
        Me.buttonDiscover.Name = "buttonDiscover"
        Me.buttonDiscover.UseVisualStyleBackColor = True
        ' AddHandler Me.buttonDiscover.Click, AddressOf Me.DiscoverButton_Click
        ' 
        ' usersBox
        ' 
        Me.usersBox.Controls.Add(Me.chatButton)
        Me.usersBox.Controls.Add(Me.userListBox)
        resources.ApplyResources(Me.usersBox, "usersBox")
        Me.usersBox.Name = "usersBox"
        Me.usersBox.TabStop = False
        ' 
        ' chatButton
        ' 
        resources.ApplyResources(Me.chatButton, "chatButton")
        Me.chatButton.Name = "chatButton"
        Me.chatButton.UseVisualStyleBackColor = True
        ' AddHandler Me.chatButton.Click, AddressOf Me.ChatButton_Click
        ' 
        ' userListBox
        ' 
        Me.userListBox.FormattingEnabled = True
        resources.ApplyResources(Me.userListBox, "userListBox")
        Me.userListBox.Name = "userListBox"
        ' AddHandler Me.userListBox.DoubleClick, AddressOf Me.UserListBox_DoubleClick
        ' AddHandler Me.userListBox.KeyDown, AddressOf Me.UserListBox_KeyDown
        ' 
        ' setupBox
        ' 
        Me.setupBox.Controls.Add(Me.buttonSignOut)
        Me.setupBox.Controls.Add(Me.buttonSignOn)
        Me.setupBox.Controls.Add(Me.userNameText)
        Me.setupBox.Controls.Add(Me.userNameLabel)
        resources.ApplyResources(Me.setupBox, "setupBox")
        Me.setupBox.Name = "setupBox"
        Me.setupBox.TabStop = False
        ' 
        ' buttonSignOut
        ' 
        resources.ApplyResources(Me.buttonSignOut, "buttonSignOut")
        Me.buttonSignOut.Name = "buttonSignOut"
        Me.buttonSignOut.UseVisualStyleBackColor = True
        ' AddHandler Me.buttonSignOut.Click, AddressOf Me.ButtonSignOut_Click
        ' 
        ' buttonSignOn
        ' 
        resources.ApplyResources(Me.buttonSignOn, "buttonSignOn")
        Me.buttonSignOn.Name = "buttonSignOn"
        Me.buttonSignOn.UseVisualStyleBackColor = True
        ' AddHandler Me.buttonSignOn.Click, AddressOf Me.ButtonSignOn_Click
        ' 
        ' userNameText
        ' 
        resources.ApplyResources(Me.userNameText, "userNameText")
        Me.userNameText.Name = "userNameText"
        ' AddHandler Me.userNameText.KeyDown, AddressOf Me.UserNameText_KeyDown
        ' 
        ' userNameLabel
        ' 
        resources.ApplyResources(Me.userNameLabel, "userNameLabel")
        Me.userNameLabel.Name = "userNameLabel"
        ' 
        ' statusStrip1
        ' 
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        resources.ApplyResources(Me.statusStrip1, "statusStrip1")
        Me.statusStrip1.Name = "statusStrip1"
        ' 
        ' statusLabel
        ' 
        Me.statusLabel.Name = "statusLabel"
        resources.ApplyResources(Me.statusLabel, "statusLabel")
        ' 
        ' SimpleChat
        ' 
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.setupBox)
        Me.Controls.Add(Me.usersBox)
        Me.Controls.Add(Me.discoveryBox)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SimpleChat"
        Me.discoveryBox.ResumeLayout(False)
        Me.discoveryBox.PerformLayout()
        Me.usersBox.ResumeLayout(False)
        Me.setupBox.ResumeLayout(False)
        Me.setupBox.PerformLayout()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents adhocRadioButton As System.Windows.Forms.RadioButton
    Private WithEvents managedRadioButton As System.Windows.Forms.RadioButton
    Private proxyAddressText As System.Windows.Forms.TextBox
    Private discoveryBox As System.Windows.Forms.GroupBox
    Private usersBox As System.Windows.Forms.GroupBox
    Private WithEvents chatButton As System.Windows.Forms.Button
    Private WithEvents userListBox As System.Windows.Forms.ListBox
    Private WithEvents buttonDiscover As System.Windows.Forms.Button
    Private discoverStatus As System.Windows.Forms.Label
    Private setupBox As System.Windows.Forms.GroupBox
    Private WithEvents buttonSignOn As System.Windows.Forms.Button
    Private WithEvents userNameText As System.Windows.Forms.TextBox
    Private userNameLabel As System.Windows.Forms.Label
    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents buttonSignOut As System.Windows.Forms.Button
End Class