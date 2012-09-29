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
Imports HRApplicationServices.Data

Public NotInheritable Class UpdateHireApproved
    Inherits CodeActivity
    Public Property HireApproved As InArgument(Of Boolean)
    Public Property ApplicantID As InArgument(Of Integer)

    Protected Overloads Overrides Sub Execute(ByVal context As CodeActivityContext)
        Using ctx As New HRApplicationDataEntities()
            Dim result As Boolean = HireApproved.[Get](context)
            Dim appID As Integer = ApplicantID.[Get](context)

            Dim query = From a In ctx.Applicants _
                Where a.ApplicationID = appID _
                Select a

            Dim applicant As Applicant = query.FirstOrDefault()
            applicant.HireApproved = result

            ctx.SaveChanges()
        End Using
    End Sub
End Class
