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
Imports System.Globalization
Imports System.Windows.Data

''' <summary>
''' One way IValueConverter that lets you bind a dependency property to
''' the an object by converting the object's value to a string representation
''' using <code>String.Format</code>
''' </summary>
Public Class StringFormatValueConverter
    Implements IValueConverter

    Private ReadOnly formatString As String

    ''' <summary>
    ''' Creates a new <see cref="StringFormatValueConverter"/>
    ''' </summary>
    ''' <param name="formatString">Format string, it can take zero or one parameters, the first one being replaced by the source value</param>
    Public Sub New(ByVal formatString As String)
        Me.formatString = formatString
    End Sub

    ''' <summary>
    ''' Converts the <paramref name="value"/> to a formatted string using the
    ''' format specified in the constructor.
    ''' </summary>
    ''' <param name="value">The value to format.</param>
    ''' <param name="targetType">The target output type (ignored).</param>
    ''' <param name="parameter">Optional parameter (ignored).</param>
    ''' <param name="culture">The culture to use in the format operation.</param>
    ''' <returns>The formatted string</returns>
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Return String.Format(CultureInfo.CurrentUICulture, Me.formatString, value)
    End Function

    ''' <summary>
    ''' Not supported.
    ''' </summary>
    ''' <param name="value">Ignored.</param>
    ''' <param name="targetType">Ignored.</param>
    ''' <param name="parameter">Ignored.</param>
    ''' <param name="culture">Ignored.</param>
    ''' <returns>No value is returned.</returns>
    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotSupportedException()
    End Function
End Class