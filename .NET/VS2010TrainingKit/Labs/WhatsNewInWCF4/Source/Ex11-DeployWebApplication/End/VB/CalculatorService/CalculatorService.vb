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

<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single, ConcurrencyMode:=ConcurrencyMode.Multiple)>
Public Class CalculatorService
    Implements ICalculatorService
    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorService.Add
        ShowOp("Add")
        Return n1 + n2
    End Function

    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorService.Subtract
        ShowOp("Subtract")
        Return n1 - n2
    End Function

    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorService.Multiply
        ShowOp("Multiply")
        Return n1 * n2
    End Function

    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorService.Divide
        ShowOp("Divide")
        Return n1 / n2
    End Function

    Private Sub ShowOp(ByVal operation As String)
        Dim msg As String = String.Format("Regular Calc: {0}", operation)

        Debug.WriteLine(msg)
        Console.WriteLine(msg)
    End Sub
End Class
