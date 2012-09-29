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
Imports HRApplicationServices.Data

Public Class SaveJobApplication
    Inherits CodeActivity(Of SubmitJobApplicationResponse)
    Public Property AppRequest As InArgument(Of SubmitJobApplicationRequest)

    Protected Overloads Overrides Function Execute(ByVal context As CodeActivityContext) As SubmitJobApplicationResponse
        Using ctx As New HRApplicationDataEntities()
            Dim request As SubmitJobApplicationRequest = AppRequest.[Get](context)
            Dim app As Applicant = ctx.Applicants.CreateObject()
            app.ApplicantName = request.[Resume].Name
            app.NumberOfReferences = request.[Resume].NumReferences
            app.Education = request.[Resume].Education
            app.RequestID = request.RequestID

            ctx.Applicants.AddObject(app)
            ctx.SaveChanges()
            ctx.Connection.Close()

            Return New SubmitJobApplicationResponse With {
                .ApplicationID = app.ApplicationID,
                .ApplicantName = request.Resume.Name,
                .ResponseText = String.Format(My.Resources.ServiceResources.JobApplicationProcessing, request.Resume.Name, app.ApplicationID)
            }
        End Using
    End Function
End Class

