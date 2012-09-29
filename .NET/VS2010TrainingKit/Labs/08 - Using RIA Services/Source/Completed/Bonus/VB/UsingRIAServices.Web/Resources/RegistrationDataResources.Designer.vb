﻿' ----------------------------------------------------------------------------------
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

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Public Class RegistrationDataResources
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("UsingRIAServices.RegistrationDataResources", GetType(RegistrationDataResources).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Email.
    '''</summary>
    Public Shared ReadOnly Property EmailLabel() As String
        Get
            Return ResourceManager.GetString("EmailLabel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to How do you want your name to be displayed in the application.
    '''</summary>
    Public Shared ReadOnly Property FriendlyNameDescription() As String
        Get
            Return ResourceManager.GetString("FriendlyNameDescription", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Friendly name.
    '''</summary>
    Public Shared ReadOnly Property FriendlyNameLabel() As String
        Get
            Return ResourceManager.GetString("FriendlyNameLabel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Confirm password.
    '''</summary>
    Public Shared ReadOnly Property PasswordConfirmationLabel() As String
        Get
            Return ResourceManager.GetString("PasswordConfirmationLabel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to The password must be 7 characters long and must contain at least one special character e.g. @ or #.
    '''</summary>
    Public Shared ReadOnly Property PasswordDescription() As String
        Get
            Return ResourceManager.GetString("PasswordDescription", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Password.
    '''</summary>
    Public Shared ReadOnly Property PasswordLabel() As String
        Get
            Return ResourceManager.GetString("PasswordLabel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Security answer.
    '''</summary>
    Public Shared ReadOnly Property SecurityAnswerLabel() As String
        Get
            Return ResourceManager.GetString("SecurityAnswerLabel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Security question.
    '''</summary>
    Public Shared ReadOnly Property SecurityQuestionLabel() As String
        Get
            Return ResourceManager.GetString("SecurityQuestionLabel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to User name.
    '''</summary>
    Public Shared ReadOnly Property UserNameLabel() As String
        Get
            Return ResourceManager.GetString("UserNameLabel", resourceCulture)
        End Get
    End Property
End Class
