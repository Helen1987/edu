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

<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")>
Public Interface ICalculatorService
    <OperationContract()>
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

    <OperationContract()>
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

    <OperationContract()>
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

    <OperationContract()>
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface
