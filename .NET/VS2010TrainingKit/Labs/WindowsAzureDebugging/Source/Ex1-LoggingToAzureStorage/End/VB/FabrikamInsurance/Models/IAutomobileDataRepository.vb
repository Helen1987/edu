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

Public Interface IAutomobileDataRepository
    Function GetMakes() As IEnumerable(Of KeyValuePair(Of String, String))
    Function GetModels(ByVal makeId As String) As IEnumerable(Of KeyValuePair(Of String, String))
    Function GetBodyStyles() As IEnumerable(Of Factor)
    Function GetBrakeTypes() As IEnumerable(Of Factor)
    Function GetSafetyEquipment() As IEnumerable(Of Factor)
    Function GetAntiTheftDevices() As IEnumerable(Of Factor)
    Function GetBookValue(ByVal makeId As String, ByVal modelId As String) As Decimal
End Interface