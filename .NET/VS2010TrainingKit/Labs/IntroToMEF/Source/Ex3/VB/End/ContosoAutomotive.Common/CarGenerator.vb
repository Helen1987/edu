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

Public Class CarGenerator
    Private random As Random
    Private makes As List(Of String)
    Private models As Dictionary(Of String, List(Of String))
    Private colors As List(Of String)
    Private interior As List(Of String)
    Private transmission As List(Of String)

    Public Sub New()
        Me.random = New Random()
        Me.PopulateLookups()
    End Sub

    Public Function Generate() As Car
        Dim year = random.Next(1990, 2008)
        Dim makeIndex = random.Next(0, makes.Count)
        Dim modelIndex = random.Next(0, models(makes(makeIndex)).Count)
        Dim transmissionIndex = random.Next(0, transmission.Count)
        Dim exteriorColorIndex = random.Next(0, colors.Count)
        Dim interiorMaterialIndex = random.Next(0, interior.Count)
        Dim mileage = random.Next(5000, 95000)
        Dim mpg = random.Next(10, 40)
        Dim price = random.Next(15000, 70000)
        Dim satelliteRadio = random.Next(0, 2)
        Dim moonRoof = random.Next(0, 2)
        Dim heatedSeats = random.Next(0, 2)
        Dim gps = random.Next(0, 2)

        Dim car = New Car()
        car.Year = year
        car.Make = makes(makeIndex)
        car.Model = models(makes(makeIndex))(modelIndex)
        car.Transmission = CType(System.Enum.Parse(GetType(Transmission), transmission(transmissionIndex), True), Transmission)
        car.Color = colors(exteriorColorIndex)
        car.Interior = CType(System.Enum.Parse(GetType(InteriorType), interior(interiorMaterialIndex), True), InteriorType)
        car.Mileage = mileage
        car.Mpg = mpg
        car.Price = price
        car.SatelliteRadio = If((satelliteRadio = 0), False, True)
        car.MoonRoof = If((moonRoof = 0), False, True)
        car.HeatedSeats = If((heatedSeats = 0), False, True)
        car.Gps = If((gps = 0), False, True)

        Return car
    End Function

    Private Sub PopulateLookups()
        Me.makes = New List(Of String)() From {"Coho", "Wingtip", "Fabrikam", "Litware", "Tailspin", "Woodgrove"}

        Me.models = New Dictionary(Of String, List(Of String))() From {
                {"Coho", New List(Of String)() From {"Lorem", "Ipsum", "L93", "IP123"}},
                {"Wingtip", New List(Of String)() From {"Lacinia", "Vitae", "Aliqua"}},
                {"Fabrikam", New List(Of String)() From {"Amet 23", "Amet 34", "Amet 45", "Amet 56", "Amet 67", "Amet 78", "Amet 89"}},
                {"Woodgrove", New List(Of String)() From {"Torquent LS", "Torquent RS"}},
                {"Litware", New List(Of String)() From {"Purus Limo", "Purus Sedan", "Dolor Limo", "Dolor Sedan"}},
                {"Tailspin", New List(Of String)() From {"Tempor", "Elit", "Elit LS", "Enim RS"}}}

        Me.colors = New List(Of String) From {"Black", "Blue", "Bronze", "Burgundy", "Charcoal", "Crimson", "Dark Blue", "Dark Gray", "Dark Green", "Gray", "Green", "Light Blue", "Light Green", "Light Silver", "Maroon", "Purple", "Red", "Silver", "Tan", "Teal", "White", "Yellow"}

        Me.transmission = New List(Of String)() From {"Manual", "Automatic"}

        Me.interior = New List(Of String)() From {"Leather", "Cloth", "Suede"}
    End Sub
End Class