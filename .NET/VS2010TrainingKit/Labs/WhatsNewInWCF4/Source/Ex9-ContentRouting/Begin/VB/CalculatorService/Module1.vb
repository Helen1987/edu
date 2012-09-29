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

Imports System.Net

Module Module1
    Sub Main()
        Console.Title = "Calculator Service"
        Console.WriteLine("Calculator Service Console Host")
        Dim hostName As String = Dns.GetHostName()

        Using host As ServiceHost = HostCalculatorEndpoint(hostName)
            Console.WriteLine("Press <Enter> to exit")
            Console.ReadLine()
            host.Close()
        End Using
    End Sub

    Private Function HostCalculatorEndpoint(ByVal hostName As String) As ServiceHost
        Dim calculatorHost As New ServiceHost(New CalculatorService())

        calculatorHost.Open()

        Console.WriteLine("Calculator Service listening at {0}", calculatorHost.Description.Endpoints(0).Address.ToString())

        Return calculatorHost
    End Function
End Module
