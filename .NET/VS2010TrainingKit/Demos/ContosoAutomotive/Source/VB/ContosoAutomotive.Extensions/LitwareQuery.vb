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

<Export(GetType(ICarQuery))> _
Public Class LitwareQuery
    Inherits CarQueryBase

    Public Sub New()
        Me.Name = "Litware Limousines"
        Me.Description = "Grab a Litware. We can make an absolutely steal off these party favorites."
        Me.ImagePath = "Images/litware.jpg"
    End Sub

    Protected Overrides Function RunQuery(ByVal cars As IEnumerable(Of Car)) As IEnumerable(Of Car)
        Dim results As IEnumerable(Of Car) = From c In cars _
                                          Where c.Make = "Litware" _
                                            AndAlso c.Model = "Purus Limo" _
                                            AndAlso c.Price <= 20000 _
                                            AndAlso c.Year >= 2000 _
                                            AndAlso c.Transmission = Transmission.Automatic _
                                            AndAlso c.MPG >= 20 _
                                            AndAlso c.Mileage <= 30000 _
                                            AndAlso c.Interior = InteriorType.Cloth _
                                          Select c

        Return results
    End Function
End Class