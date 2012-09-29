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

Imports HRApplicationServices.Data
Imports System.Activities
Public Class HireApproval
    Inherits System.Web.UI.Page
    Dim applicant As Applicant
    Dim appID As Integer = -1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetApplicant()
        End If
    End Sub

    Private Sub SendHumanScreenComplete(ByVal hire As Boolean)
        ' TODO: Implement this method
    End Sub

    Private Sub GetApplicant()
        appID = GetAppIDFromRequest()

        If appID = -1 Then
            Dim s As String = GetRedirectString("HRMessage.aspx?MsgID=ErrInvalidAppID")
            Response.Redirect(s, True)
        Else
            Using ctx As New HRApplicationDataEntities()
                Dim query = From a In ctx.Applicants _
                    Where a.ApplicationID = appID _
                    Select a

                applicant = query.FirstOrDefault()

                If applicant Is Nothing Then
                    Response.Redirect(GetRedirectString("HRMessage.aspx?MsgID=ErrUnknownAppID"), True)
                Else
                    Me.LabelAppID.Text = appID.ToString()
                    Me.LabelName.Text = applicant.ApplicantName
                    Me.LabelEducation.Text = applicant.Education
                    Me.LabelReferences.Text = applicant.NumberOfReferences.ToString()
                    Me.LabelRequestID.Text = applicant.RequestID.ToString()
                End If
            End Using
        End If
    End Sub

    Protected Sub ButtonHire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonHire.Click
        SendHumanScreenComplete(True)

        ' Redirect to message page
        Response.Redirect(GetRedirectString("HRMessage.aspx?MsgID=AppIDStatusUpdated&AppID={0}&Status={1}", LabelAppID.Text, "Hire"), True)
    End Sub

    Protected Sub ButtonNoHire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonNoHire.Click
        SendHumanScreenComplete(False)

        ' Redirect to message page
        Response.Redirect(GetRedirectString("HRMessage.aspx?MsgID=AppIDStatusUpdated&AppID={0}&Status={1}", LabelAppID.Text, "Hire"), True)
    End Sub

    Private Function GetRedirectString(ByVal UriFormat As String, ByVal ParamArray args As Object()) As String
        Return Server.UrlPathEncode(String.Format(UriFormat, args))
    End Function

    Private Function GetAppIDFromRequest() As Integer
        Dim appIDArg As String = Request.QueryString("AppID")

        If Not String.IsNullOrEmpty(appIDArg) Then
            Try
                Return Convert.ToInt32(appIDArg)
            Catch generatedExceptionName As FormatException
                Return -1
            End Try
        Else
            Return -1
        End If
    End Function
End Class