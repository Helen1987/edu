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

Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class QuoteViewModel
    ' render support
    Public Property Makes As IEnumerable(Of KeyValuePair(Of String, String))
    Public Property Models As IEnumerable(Of KeyValuePair(Of String, String))
    Public Property BodyStyles As IEnumerable(Of Factor)
    Public Property BrakeTypes As IEnumerable(Of Factor)
    Public Property SafetyEquipment As IEnumerable(Of Factor)
    Public Property AntiTheftDevices As IEnumerable(Of Factor)
    Public Property YearList As IEnumerable(Of Integer)

    Public Property Message As String
    Public Property MonthlyPremium As Decimal
    Public Property YearlyPremium As Decimal

    ' view model data
    <Required(), DisplayName("Make")>
    Public Property MakeId As String
    <Required(), DisplayName("Model")>
    Public Property ModelId As String
    <Required(), DisplayName("Year")>
    Public Property ManufacturedYear As Integer
    <Required(), DisplayName("Body Style")>
    Public Property BodyStyleId As String
    <Required(), DisplayName("Anti-Lock Brakes")>
    Public Property BrakeTypeId As String
    <Required(), DisplayName("Automatic Safety Equipment")>
    Public Property SafetyEquipmentId As String
    <Required(), DisplayName("Anti-Theft Device")>
    Public Property AntiTheftDeviceId As String
End Class
