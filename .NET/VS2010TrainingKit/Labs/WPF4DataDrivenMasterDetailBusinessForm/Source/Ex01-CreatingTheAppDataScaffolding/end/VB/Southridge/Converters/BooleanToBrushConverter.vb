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

Imports System.Data

<ValueConversion(GetType(Boolean), GetType(Brush))>
Public Class BooleanToBrushConverter
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        Dim inputValue As Boolean
        Dim rowView = TryCast(value, DataRowView)

        If (rowView IsNot Nothing) Then
            inputValue = CBool(rowView.Row(CStr(parameter)))
        Else
            Return Nothing
        End If

        If (inputValue) Then
            Return Brushes.Green
        Else
            Return Brushes.Red
        End If
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Dim b = TryCast(value, Brush)
        If (b IsNot Nothing) Then
            If (b.Equals(Brushes.Red)) Then
                Return False
            End If

            If (b.Equals(Brushes.Green)) Then
                Return True
            End If
        End If

        Return Nothing
    End Function
End Class
