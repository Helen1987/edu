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

Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel.Composition
Imports ContosoAutomotive.Common

<QueryMetadata(Name:="Fabrikam Motor Company",
        Description:="Low Mileage, Low Price FMCs that have wonderful resell value.",
        ImagePath:="Images/fabrikam.jpg")>
Public Class FabrikamQuery
    Inherits CarQueryBase

    Protected Overrides Function RunQuery(ByVal cars As IEnumerable(Of Car)) As IEnumerable(Of Car)
        Dim results = From c In cars _
                    Where c.Make = "Fabrikam" _
                    AndAlso (c.Model = "Amet 23" Or c.Model = "Amet 34" Or c.Model = "Amet 45") _
                    AndAlso c.Price <= 40000 _
                    AndAlso c.Year >= 1995 _
                    AndAlso c.Transmission = Transmission.Manual _
                    AndAlso c.SatelliteRadio = True _
                    AndAlso c.MoonRoof = True _
                    AndAlso c.Mpg >= 25 _
                    AndAlso c.Mileage <= 60000 _
                    AndAlso c.Interior = InteriorType.Leather _
                    Select c

        Return results
    End Function
End Class