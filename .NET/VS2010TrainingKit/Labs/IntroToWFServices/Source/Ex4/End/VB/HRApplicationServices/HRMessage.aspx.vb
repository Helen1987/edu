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

Public Class HRMessage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MsgID As String = Request.QueryString("MsgID")

        If Not String.IsNullOrEmpty(MsgID) Then
            Select Case MsgID
                Case "AppIDStatusUpdated"
                    Me.LabelError.Text = String.Format(My.Resources.WebResources.AppIDStatusUpdated, Request.QueryString("AppID"), Request.QueryString("Status"))
                    Exit Select
                Case Else
                    Me.LabelError.Text = My.Resources.WebResources.ResourceManager.GetString(MsgID)
                    Exit Select
            End Select
        End If

    End Sub
End Class