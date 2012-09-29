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

<Export(GetType(ICarQuery))>
Public Class TailspinQuery
    Inherits CarQueryBase

    Public Sub New()
        Me.Name = "Tailspin Motorsport"
        Me.Description = "Life in the fast lane. You can't live without the best: Tailspin."
        Me.ImagePath = "Images/tailspin.jpg"
    End Sub

    Protected Overloads Overrides Function RunQuery(ByVal cars As IEnumerable(Of Car)) As IEnumerable(Of Car)
        Dim results = From c In cars _
                    Where c.Make = "Tailspin" _
                    AndAlso c.Model = "Tempor" _
                    AndAlso c.Price <= 40000 _
                    AndAlso c.Year >= 2005 _
                    AndAlso c.Transmission = Transmission.Automatic _
                    AndAlso c.SatelliteRadio = True _
                    AndAlso c.MoonRoof = True _
                    AndAlso c.MPG >= 25 _
                    AndAlso c.Mileage <= 10000 _
                    AndAlso c.Interior = InteriorType.Suede _
                    Select c

        Return results
    End Function
End Class
