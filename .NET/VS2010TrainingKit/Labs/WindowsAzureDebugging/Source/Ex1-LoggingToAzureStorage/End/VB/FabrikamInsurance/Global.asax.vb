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

Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Quote", .action = "Calculator", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        CloudStorageAccount.SetConfigurationSettingPublisher(Sub(configName, configSetter) configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)))

        ConfigureTraceListener()

        AddHandler RoleEnvironment.Changed, AddressOf RoleEnvironmentChanged

        AreaRegistration.RegisterAllAreas()
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Protected Sub Application_Error()
        Dim lastError = Server.GetLastError()
        System.Diagnostics.Trace.TraceError(lastError.Message)
    End Sub

    Private Sub RoleEnvironmentChanged(ByVal sender As Object, ByVal e As RoleEnvironmentChangedEventArgs)
        ' configure trace listener for any changes to EnableTableStorageTraceListener 
        If e.Changes.OfType(Of RoleEnvironmentConfigurationSettingChange)().Any(Function(change) change.ConfigurationSettingName = "EnableTableStorageTraceListener") Then
            ConfigureTraceListener()
        End If
    End Sub

    Private Shared Sub ConfigureTraceListener()
        Dim enableTraceListener As Boolean = False
        Dim enableTraceListenerSetting As String = RoleEnvironment.GetConfigurationSettingValue("EnableTableStorageTraceListener")
        If Boolean.TryParse(enableTraceListenerSetting, enableTraceListener) Then
            If enableTraceListener Then
                Dim listener As New AzureDiagnostics.TableStorageTraceListener("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString") With {.Name = "TableStorageTraceListener"}
                System.Diagnostics.Trace.Listeners.Add(listener)
                System.Diagnostics.Trace.AutoFlush = True
            Else
                System.Diagnostics.Trace.Listeners.Remove("TableStorageTraceListener")
            End If
        End If
    End Sub
End Class
