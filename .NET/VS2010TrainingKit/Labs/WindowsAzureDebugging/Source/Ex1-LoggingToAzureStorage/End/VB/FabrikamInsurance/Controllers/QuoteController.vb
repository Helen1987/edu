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

Imports InsurancePolicy

<HandleError()>
Public Class QuoteController
    Inherits Controller
    Private repository As IAutomobileDataRepository

    Public Sub New()
        Me.New(New AutomobileDataRepository())
    End Sub

    Public Sub New(ByVal repository As IAutomobileDataRepository)
        Me.repository = repository
    End Sub

    Public Function About() As ActionResult
        System.Diagnostics.Trace.TraceInformation("About called...")
        Return View()
    End Function

    Public Function Calculator() As ActionResult
        System.Diagnostics.Trace.TraceInformation("Calculator called...")
        Dim model As New QuoteViewModel()
        PopulateViewModel(model, Nothing)
        Return View(model)
    End Function

    <HttpPost()>
    Public Function Calculator(ByVal model As QuoteViewModel) As ActionResult
        PopulateViewModel(model, model.MakeId)

        If ModelState.IsValid Then
            Dim bookValue As Decimal = Me.repository.GetBookValue(model.MakeId, model.ModelId)
            Dim bodyStyleFactor As Decimal = model.BodyStyles.Where(Function(item) item.Id = model.BodyStyleId).FirstOrDefault().Value
            Dim brakeTypeFactor As Decimal = model.BrakeTypes.Where(Function(item) item.Id = model.BrakeTypeId).FirstOrDefault().Value
            Dim safetyEquipmentFactor As Decimal = model.SafetyEquipment.Where(Function(item) item.Id = model.SafetyEquipmentId).FirstOrDefault().Value
            Dim antiTheftDeviceFactor As Decimal = model.AntiTheftDevices.Where(Function(item) item.Id = model.AntiTheftDeviceId).FirstOrDefault().Value
            Dim premium As Decimal = AutoInsurance.CalculatePremium(bookValue, model.ManufacturedYear, bodyStyleFactor, brakeTypeFactor, safetyEquipmentFactor, antiTheftDeviceFactor)
            model.MonthlyPremium = premium / 12
            model.YearlyPremium = premium
        End If

        Return View(model)
    End Function

    Private Sub PopulateViewModel(ByVal model As QuoteViewModel, ByVal makeId As String)
        model.Makes = Me.repository.GetMakes()
        model.Models = Me.repository.GetModels(makeId)
        model.BodyStyles = Me.repository.GetBodyStyles()
        model.BrakeTypes = Me.repository.GetBrakeTypes()
        model.SafetyEquipment = Me.repository.GetSafetyEquipment()
        model.AntiTheftDevices = Me.repository.GetAntiTheftDevices()
        model.YearList = Enumerable.Range(DateTime.Today.Year - AutoInsurance.MAXIMUM_VEHICLE_AGE + 1, AutoInsurance.MAXIMUM_VEHICLE_AGE)
    End Sub

    <HttpPost()>
    Public Function GetModels(ByVal id As String) As ActionResult
        Return Json(Me.repository.GetModels(id))
    End Function

    Protected Overrides Sub OnException(ByVal filterContext As ExceptionContext)
        System.Diagnostics.Trace.TraceError(filterContext.Exception.Message)
    End Sub
End Class