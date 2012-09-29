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
Imports HRApplicationServices.Contracts
Imports System.Web.Configuration
Imports System.Net.Mail

Public NotInheritable Class NotifyApplicant
    Inherits CodeActivity
    Public Property Hire As InArgument(Of Boolean)
    Public Property [Resume] As InArgument(Of ApplicantResume)

    Protected Overloads Overrides Sub Execute(ByVal context As CodeActivityContext)
        Dim hire__1 As Boolean = Hire.[Get](context)
        Dim resume__2 As ApplicantResume = [Resume].[Get](context)
        Dim baseURI As String = WebConfigurationManager.AppSettings("BaseURI")

        If String.IsNullOrEmpty(baseURI) Then
            Throw New InvalidOperationException("No baseURI appSetting found in web.config")
        End If

        Dim htmlMailText As String

        If hire__1 Then
            htmlMailText = String.Format(My.Resources.ServiceResources.GenericMailTemplate, My.Resources.ServiceResources.HireHeading, String.Format(My.Resources.ServiceResources.OfferText, resume__2.Name), baseURI)
        Else
            htmlMailText = String.Format(My.Resources.ServiceResources.GenericMailTemplate, My.Resources.ServiceResources.NoHireHeading, String.Format(My.Resources.ServiceResources.NoHireText, resume__2.Name), baseURI)
        End If

        Dim smtpClient As New SmtpClient()

        Dim msg As New MailMessage("admin@contoso.com", resume__2.Email, String.Format(My.Resources.ServiceResources.ApplicationMailSubject), htmlMailText)
        msg.IsBodyHtml = True

        smtpClient.Send(msg)
    End Sub
End Class
