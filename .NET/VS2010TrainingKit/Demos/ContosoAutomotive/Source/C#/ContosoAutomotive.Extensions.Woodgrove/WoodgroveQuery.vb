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
Imports System.ComponentModel.Composition
Imports ContosoAutomotive.Common

<Export(GetType(ICarQuery))> _
Public Class WoodgroveQuery
    Inherits CarQueryBase

    Public Sub New()
        Me.Name = "Woodgrove Cycles"
        Me.Description = "Who doesn't love a Woodgrove? The fastest thing on two wheels!"
        Me.ImagePath = "Images/woodgrove.jpg"
    End Sub

    Protected Overrides Function RunQuery(ByVal cars As IEnumerable(Of Car)) As IEnumerable(Of Car)

        Dim results As IEnumerable(Of Car)
        results = From c In cars _
                          Where c.Make = "Woodgrove" _
                          AndAlso c.Price >= 50000 _
                          AndAlso c.Year >= 2000 _
                          AndAlso c.Transmission = Transmission.Manual _
                          AndAlso c.SatelliteRadio = True _
                          AndAlso c.MPG >= 20 _
                          AndAlso c.Interior = InteriorType.Suede _
                          AndAlso c.MoonRoof = False _
                          AndAlso c.Mileage <= 40000

        Return results
    End Function
End Class
