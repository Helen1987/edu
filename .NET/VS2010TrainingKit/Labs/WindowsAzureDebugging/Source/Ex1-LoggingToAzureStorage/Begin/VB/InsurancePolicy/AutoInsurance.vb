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

Public Class AutoInsurance
    Public Shared ReadOnly MAXIMUM_VEHICLE_AGE As Integer = 10

    ' (THIS IS NOT A REAL FORMULA)
    Public Shared Function CalculatePremium(ByVal bookValue As Decimal, ByVal manufacturedYear As Integer, ByVal bodyStyleFactor As Decimal, ByVal brakeTypeFactor As Decimal, ByVal safetyEquipmentFactor As Decimal, ByVal antiTheftDeviceFactor As Decimal) As Decimal

        Dim ageFactor As Decimal = (manufacturedYear - DateTime.Today.Year + MAXIMUM_VEHICLE_AGE) * 2000 / bookValue
        Dim coefficient As Decimal = (bodyStyleFactor + brakeTypeFactor + safetyEquipmentFactor + antiTheftDeviceFactor + ageFactor) / 100
        Dim premium As Decimal = bookValue * coefficient

        Return premium

    End Function
End Class