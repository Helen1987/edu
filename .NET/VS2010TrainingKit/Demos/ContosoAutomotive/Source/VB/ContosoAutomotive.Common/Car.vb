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

Public Class Car
    Public Property Year As Integer
    Public Property Make As String
    Public Property Model As String
    Public Property Transmission As Transmission
    Public Property Color As String
    Public Property Interior As InteriorType
    Public Property Mileage As Integer
    Public Property MPG As Integer
    Public Property Price As Integer
    Public Property SatelliteRadio As Boolean
    Public Property MoonRoof As Boolean
    Public Property HeatedSeats As Boolean
    Public Property GPS As Boolean

    Public Sub Deserialize(ByVal csv As String)
        Dim dataParts = csv.Split(","c)

        Me.Year = Integer.Parse(dataParts(0))
        Me.Make = dataParts(1)
        Me.Model = dataParts(2)
        Me.Transmission = CType(System.Enum.Parse(GetType(Transmission), dataParts(3)), Transmission)
        Me.Color = dataParts(4)
        Me.Interior = CType(System.Enum.Parse(GetType(InteriorType), dataParts(5)), InteriorType)
        Me.Mileage = Integer.Parse(dataParts(6))
        Me.MPG = Integer.Parse(dataParts(7))
        Me.Price = Integer.Parse(dataParts(8))
        Me.SatelliteRadio = If((dataParts(9) = "0"), False, True)
        Me.MoonRoof = If((dataParts(10) = "0"), False, True)
        Me.HeatedSeats = If((dataParts(11) = "0"), False, True)
        Me.GPS = If((dataParts(12) = "0"), False, True)
    End Sub

    Public Function Serialize() As String
        Return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                             Me.Year, Me.Make, Me.Model, Me.Transmission, Me.Color, Me.Interior, Me.Mileage, Me.MPG,
                             Me.Price, Me.SatelliteRadio, Me.MoonRoof, Me.HeatedSeats, Me.GPS)
    End Function
End Class