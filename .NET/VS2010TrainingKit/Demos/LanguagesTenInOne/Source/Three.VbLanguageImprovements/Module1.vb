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

Imports System.Runtime.CompilerServices

Module Module1
    Property FailingScore As Integer = 60

    Sub Main()
        Dim scores = {42, 56, 72, 85}

        Dim passing = scores.Where(Function(score)
                                       Return (score >= FailingScore)
                                   End Function).ToList()

        passing.ForEach(Sub(score)
                            Console.WriteLine(score)
                        End Sub)

        Console.ReadKey(True)
    End Sub

    Sub Initializers()
        Dim nameList = New List(Of String) From
        {
            "Jason",
            "Drew",
            "Jonathan",
            "Brian"
        }

        Dim nameDict = New Dictionary(Of Integer, String) From
        {
            {1, "Jason"},
            {2, "Drew"}
        }
    End Sub

#Region "Custom"

    Sub CustomInitializers()
        Dim cust = New List(Of Customer) From
        {
            {1, "Jason", "Olson"},
            {2, "Drew", "Robbins"}
        }
    End Sub

    Class Customer
        Property CustomerId As Integer
        Property FirstName As String
        Property LastName As String
    End Class

    <Extension()>
    Public Sub Add(ByVal list As List(Of Customer),
                   ByVal id As Integer,
                   ByVal firstName As String,
                   ByVal lastName As String)

        list.Add(New Customer With _
        {
            .CustomerId = id,
            .FirstName = firstName,
            .LastName = lastName
        })
    End Sub
#End Region

End Module
