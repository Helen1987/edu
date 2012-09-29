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

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Activities
Imports HelloWorkflow.Activities
Imports System.Activities.Statements

Namespace HelloWorkflow.Activities.Tests

    Public NotInheritable Class PreOnlyWorkflow
        Inherits Activity(Of String)
        Public Const PreMsg As String = "Pre Activity Called"

        Public Sub New()
            MyBase.Implementation = New Func(Of Activity)(AddressOf CreateBody)
        End Sub

        Private Function CreateBody() As Activity
            Return New PrePostSequence()
        End Function
    End Class
End Namespace