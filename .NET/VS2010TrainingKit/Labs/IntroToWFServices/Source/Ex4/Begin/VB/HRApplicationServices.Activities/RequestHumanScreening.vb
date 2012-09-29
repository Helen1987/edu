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

Imports System.Activities
Imports System.Windows.Markup
Imports System.Web.Configuration
Imports System.Net.Mail
Imports HRApplicationServices.Contracts

Public NotInheritable Class RequestHumanScreening
    Inherits CodeActivity
    Implements IUriContext
    ' Define an activity input argument of type string
    Public Property ApplicationRequest As InArgument(Of SubmitJobApplicationRequest)
    Public Property ApplicationID As InArgument(Of Integer)

    Protected Overloads Overrides Sub Execute(ByVal context As CodeActivityContext)
        Dim baseURI As String = WebConfigurationManager.AppSettings("BaseURI")

        If String.IsNullOrEmpty(baseURI) Then
            Throw New InvalidOperationException("No baseURI appSetting found in web.config")
        End If

        Dim smtpClient As New SmtpClient()
        Dim applicant As String = ApplicationRequest.[Get](context).[Resume].Name
        Dim htmlMailText As String = String.Format(My.Resources.ServiceResources.ReviewMailTemplate, applicant, ApplicationID.[Get](context), baseURI)

        Dim msg As New MailMessage("admin@contoso.com", "hr@contoso.com", String.Format(My.Resources.ServiceResources.HumanScreenSubject, applicant), htmlMailText)
        msg.IsBodyHtml = True

        smtpClient.Send(msg)
    End Sub

    Public Property BaseUri As Uri Implements IUriContext.BaseUri
End Class

