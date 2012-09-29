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

Public Class AutomobileDataRepository
    Implements IAutomobileDataRepository
    Private Shared automobileData As XElement

    Shared Sub New()
        AutomobileDataRepository.automobileData = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/AutomobileData.xml"))
    End Sub

    Public Function GetMakes() As IEnumerable(Of KeyValuePair(Of String, String)) Implements IAutomobileDataRepository.GetMakes
        Return From make In AutomobileDataRepository.automobileData.Element("automobiles").Elements("make")
               Order By make.Attribute("name").Value
               Select New KeyValuePair(Of String, String)(make.Attribute("id").Value, make.Attribute("name").Value)
    End Function

    Public Function GetModels(ByVal makeId As String) As IEnumerable(Of KeyValuePair(Of String, String)) Implements IAutomobileDataRepository.GetModels
        Return From make In AutomobileDataRepository.automobileData.Element("automobiles").Elements("make"), model In make.Elements("model")
               Where make.Attribute("id").Value = makeId
               Order By model.Value
               Select New KeyValuePair(Of String, String)(model.Attribute("id").Value, model.Value)
    End Function

    Public Function GetBodyStyles() As IEnumerable(Of Factor) Implements IAutomobileDataRepository.GetBodyStyles
        Return GetOptionList("bodystyles")
    End Function

    Public Function GetBrakeTypes() As IEnumerable(Of Factor) Implements IAutomobileDataRepository.GetBrakeTypes
        Return GetOptionList("braketypes")
    End Function

    Public Function GetSafetyEquipment() As IEnumerable(Of Factor) Implements IAutomobileDataRepository.GetSafetyEquipment
        Return GetOptionList("safetyequipment")
    End Function

    Public Function GetAntiTheftDevices() As IEnumerable(Of Factor) Implements IAutomobileDataRepository.GetAntiTheftDevices
        Return GetOptionList("antitheftdevices")
    End Function

    Public Function GetBookValue(ByVal makeId As String, ByVal modelId As String) As Decimal Implements IAutomobileDataRepository.GetBookValue
        Dim bookValue = (From make In AutomobileDataRepository.automobileData.Element("automobiles").Elements("make"), model In make.Elements("model")
                         Where make.Attribute("id").Value = makeId AndAlso model.Attribute("id").Value = modelId
                         Select model.Attribute("bookValue").Value).FirstOrDefault()

        Return If(bookValue IsNot Nothing, Convert.ToDecimal(bookValue), -1)
    End Function

    Private Function GetOptionList(ByVal name As String) As IEnumerable(Of Factor)
        Return From item In AutomobileDataRepository.automobileData.Element(name).Elements("option")
               Order By item.Attribute("id").Value
               Select New Factor With {.Id = item.Attribute("id").Value, .Name = item.Value, .Value = Convert.ToDecimal(item.Attribute("factor").Value)}
    End Function
End Class