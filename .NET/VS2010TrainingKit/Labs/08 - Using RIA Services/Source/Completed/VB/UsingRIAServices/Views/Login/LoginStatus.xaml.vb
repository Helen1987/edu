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

Imports System.Globalization
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Controls

Namespace LoginUI
    ''' <summary>
    ''' <see cref="UserControl"/> class that shows the current login status and allows login and logout.
    ''' </summary>
    Partial Public Class LoginStatus
        Inherits UserControl
        Private WithEvents authService As AuthenticationService = WebContext.Current.Authentication

        ''' <summary>
        ''' Creates a new <see cref="LoginStatus"/> instance.
        ''' </summary>
        Public Sub New()
            Me.InitializeComponent()

            Me.welcomeText.SetBinding(TextBlock.TextProperty, WebContext.Current.CreateOneWayBinding("User.DisplayName", New StringFormatValueConverter(ApplicationStrings.WelcomeMessage)))
            Me.UpdateLoginState()
        End Sub

        Private Sub LoginButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim loginWindow As New LoginRegistrationWindow()
            loginWindow.Show()
        End Sub

        Private Sub LogoutButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.authService.Logout(AddressOf Me.HandleLogoutOperationErrors, Nothing)
        End Sub

        Private Sub HandleLogoutOperationErrors(ByVal logoutOperation As LogoutOperation)
            If logoutOperation.HasError Then
                ErrorWindow.CreateNew(logoutOperation.Error)
                logoutOperation.MarkErrorAsHandled()
            End If
        End Sub

        Private Sub Authentication_LoggedIn(ByVal sender As Object, ByVal e As AuthenticationEventArgs) Handles authService.LoggedIn
            Me.UpdateLoginState()
        End Sub

        Private Sub Authentication_LoggedOut(ByVal sender As Object, ByVal e As AuthenticationEventArgs) Handles authService.LoggedOut
            Me.UpdateLoginState()
        End Sub

        Private Sub UpdateLoginState()
            If WebContext.Current.User.IsAuthenticated Then
                VisualStateManager.GoToState(Me, If((TypeOf (WebContext.Current.Authentication) Is WindowsAuthentication), "windowsAuth", "loggedIn"), True)
            Else
                VisualStateManager.GoToState(Me, "loggedOut", True)
            End If
        End Sub
    End Class
End Namespace