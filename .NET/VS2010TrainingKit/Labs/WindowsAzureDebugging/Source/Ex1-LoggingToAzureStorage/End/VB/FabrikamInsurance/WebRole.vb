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

Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure

Public Class WebRole
    Inherits RoleEntryPoint
    Public Overrides Function OnStart() As Boolean
        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging

        Return MyBase.OnStart()
    End Function

    Private Sub RoleEnvironmentChanging(ByVal sender As Object, ByVal e As RoleEnvironmentChangingEventArgs)
        ' for any configuration setting change except EnableTableStorageTraceListener
        If e.Changes.OfType(Of RoleEnvironmentConfigurationSettingChange)().Any(Function(change) change.ConfigurationSettingName <> "EnableTableStorageTraceListener") Then
            ' Set e.Cancel to true to restart this role instance
            e.Cancel = True
        End If
    End Sub
End Class