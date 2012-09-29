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

Imports System
Imports System.Windows.Data

''' <summary>
''' Two way <see cref="IValueConverter"/> that lets you bind the inverse of a boolean property
''' to a dependency property
''' </summary>
Public Class NotOperatorValueConverter
    Implements IValueConverter


    ''' <summary>
    ''' Converts the given <paramref name="value"/> to be its inverse
    ''' </summary>
    ''' <param name="value">The <c>bool</c> value to convert.</param>
    ''' <param name="targetType">The type to convert to (ignored).</param>
    ''' <param name="parameter">Optional parameter (ignored).</param>
    ''' <param name="culture">The culture of the conversion (ignored).</param>
    ''' <returns>The inverse of the input <paramref name="value"/>.</returns>
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Return Not DirectCast(value, Boolean)
    End Function

    ''' <summary>
    ''' The inverse of the <see cref="Convert"/>.
    ''' </summary>
    ''' <param name="value">The value to convert back.</param>
    ''' <param name="targetType">The type to convert to (ignored).</param>
    ''' <param name="parameter">Optional parameter (ignored).</param>
    ''' <param name="culture">The culture of the conversion (ignored).</param>
    ''' <returns>The inverse of the input <paramref name="value"/>.</returns>
    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Not DirectCast(value, Boolean)
    End Function
End Class