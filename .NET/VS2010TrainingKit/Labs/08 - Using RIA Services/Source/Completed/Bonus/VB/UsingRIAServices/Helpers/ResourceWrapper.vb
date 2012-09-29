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
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Browser


''' <summary>
''' Wraps accessing string resources in a way that Bindings can be set through 
''' XAML (which is not supported when binding to a resource class directly 
''' since they have no public constructors)
''' </summary>
Public NotInheritable Class ResourceWrapper
    Private Shared _applicationStrings As New ApplicationStrings()
    Private Shared _securityQuestions As New SecurityQuestions()

    ''' <summary>
    ''' Gets the <see cref="ApplicationStrings"/>.
    ''' </summary>
    Public ReadOnly Property ApplicationStrings() As ApplicationStrings
        Get
            Return _applicationStrings
        End Get
    End Property

    ''' <summary>
    ''' Gets the <see cref="SecurityQuestions"/>.
    ''' </summary>
    Public ReadOnly Property SecurityQuestions() As SecurityQuestions
        Get
            Return _securityQuestions
        End Get
    End Property
End Class
