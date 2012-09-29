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

Imports System.ServiceModel
Imports CalculatorService

	<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single, ConcurrencyMode:=ConcurrencyMode.Multiple)> _
	Public Class RoundingCalculatorService
    Implements ICalculatorService

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements CalculatorService.ICalculatorService.Add
        ShowOp("Add")
        Return Math.Round(n1 + n2, 1)
    End Function

    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements CalculatorService.ICalculatorService.Subtract
        ShowOp("Subtract")
        Return Math.Round(n1 - n2, 1)
    End Function

    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements CalculatorService.ICalculatorService.Multiply
        ShowOp("Multiply")
        Return Math.Round(n1 * n2, 1)
    End Function

    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements CalculatorService.ICalculatorService.Divide
        ShowOp("Divide")
        Return Math.Round(n1 / n2, 1)
    End Function

    Private Sub ShowOp(ByVal operation As String)
        Dim msg As String = String.Format("Rounding Calc: {0}", operation)

        Debug.WriteLine(msg)
        Console.WriteLine(msg)
    End Sub
End Class
