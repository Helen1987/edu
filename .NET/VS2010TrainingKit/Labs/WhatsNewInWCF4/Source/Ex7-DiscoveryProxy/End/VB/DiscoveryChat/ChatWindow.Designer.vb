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

Partial Public Class ChatWindow
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

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
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ChatWindow))
        Me.chatBox = New System.Windows.Forms.ListBox()
        Me.chatText = New System.Windows.Forms.TextBox()
        Me.sendMessage = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' chatBox
        ' 
        Me.chatBox.FormattingEnabled = True
        resources.ApplyResources(Me.chatBox, "chatBox")
        Me.chatBox.Name = "chatBox"
        ' 
        ' chatText
        ' 
        resources.ApplyResources(Me.chatText, "chatText")
        Me.chatText.Name = "chatText"
        '        Me.chatText.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ChatText_KeyDown)
        ' 
        ' sendMessage
        ' 
        resources.ApplyResources(Me.sendMessage, "sendMessage")
        Me.sendMessage.Name = "sendMessage"
        Me.sendMessage.UseVisualStyleBackColor = True
        '        Me.sendMessage.Click += New System.EventHandler(Me.SendMessage_Click)
        ' 
        ' label1
        ' 
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Name = "label1"
        ' 
        ' ChatWindow
        ' 
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.sendMessage)
        Me.Controls.Add(Me.chatText)
        Me.Controls.Add(Me.chatBox)
        Me.MaximizeBox = False
        Me.Name = "ChatWindow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private chatBox As System.Windows.Forms.ListBox
    Private WithEvents chatText As System.Windows.Forms.TextBox
    Private WithEvents sendMessage As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
End Class