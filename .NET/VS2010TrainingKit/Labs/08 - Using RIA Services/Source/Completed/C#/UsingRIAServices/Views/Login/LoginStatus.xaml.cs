// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace UsingRIAServices.LoginUI
{
    using System.Globalization;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// <see cref="UserControl"/> class that shows the current login status and allows login and logout.
    /// </summary>
    public partial class LoginStatus : UserControl
    {
        private readonly AuthenticationService authService = WebContext.Current.Authentication;

        /// <summary>
        /// Creates a new <see cref="LoginStatus"/> instance.
        /// </summary>
        public LoginStatus()
        {
            this.InitializeComponent();

            this.welcomeText.SetBinding(TextBlock.TextProperty, WebContext.Current.CreateOneWayBinding("User.DisplayName", new StringFormatValueConverter(ApplicationStrings.WelcomeMessage)));
            this.authService.LoggedIn += this.Authentication_LoggedIn;
            this.authService.LoggedOut += this.Authentication_LoggedOut;
            this.UpdateLoginState();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginRegistrationWindow loginWindow = new LoginRegistrationWindow();
            loginWindow.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.authService.Logout(logoutOperation =>
            {
                if (logoutOperation.HasError)
                {
                    ErrorWindow.CreateNew(logoutOperation.Error);
                    logoutOperation.MarkErrorAsHandled();
                }
            }, /* userState */ null);
        }

        private void Authentication_LoggedIn(object sender, AuthenticationEventArgs e)
        {
            this.UpdateLoginState();
        }

        private void Authentication_LoggedOut(object sender, AuthenticationEventArgs e)
        {
            this.UpdateLoginState();
        }

        private void UpdateLoginState()
        {
            if (WebContext.Current.User.IsAuthenticated)
            {
                VisualStateManager.GoToState(this, (WebContext.Current.Authentication is WindowsAuthentication) ? "windowsAuth" : "loggedIn", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "loggedOut", true);
            }
        }
    }
}
