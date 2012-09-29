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

Imports ContosoAutomotive.Common

<ValueConversion(GetType(QueryStatus), GetType(Brush))>
Public Class StatusToColorConverter
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        If targetType IsNot GetType(Brush) Then
            Return Nothing
        End If

        Dim status = CType(value, QueryStatus)

        If status = QueryStatus.Running Then
            Return Brushes.Yellow
        ElseIf status = QueryStatus.Finished Then
            Return Brushes.LightGreen
        Else
            Return Brushes.Gray
        End If
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        If targetType IsNot GetType(QueryStatus) Then
            Return Nothing
        End If

        Dim color = CType(value, Brush)
        If color Is Brushes.Yellow Then
            Return QueryStatus.Running
        ElseIf color Is Brushes.LightGreen Then
            Return QueryStatus.Finished
        Else
            Return QueryStatus.NotStarted
        End If
    End Function
End Class
