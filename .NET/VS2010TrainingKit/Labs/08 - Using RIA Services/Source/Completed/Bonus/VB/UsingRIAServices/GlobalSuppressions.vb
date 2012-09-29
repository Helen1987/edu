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

'
'
' This file is used by Code Analysis to maintain SuppressMessage 
' attributes that are applied to this project.
' Project-level suppressions either have no target or are given 
' a specific target and scoped to a namespace, type, member, etc.
'
' To add a suppression to this file, right-click the message in the 
' Error List, point to "Suppress Message(s)", and click 
' "In Project Suppression File".
' You do not need to add suppressions to this file manually.

<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Scope:="member", Target:="UsingRIAServices.Web.User.#Global_System_Security_Principal_IIdentity_Name")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope:="type", Target:="UsingRIAServices.Web.UserRegistrationContext+IUserRegistrationServiceContract")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="Datas", Scope:="member", Target:="UsingRIAServices.Web.UserRegistrationContext.#RegistrationDatas")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope:="member", Target:="UsingRIAServices.Web.UserRegistrationContext.#GetUsersQuery()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope:="member", Target:="UsingRIAServices.Web.UserRegistrationContext.#CreateUser(UsingRIAServices.Web.RegistrationData,System.String,System.Action`1<System.ServiceModel.DomainServices.Client.InvokeOperation`1<UsingRIAServices.Web.CreateUserStatus>>,System.Object)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Scope:="member", Target:="UsingRIAServices.Web.User.#Global_System_Security_Principal_IIdentity_AuthenticationType")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="member", Target:="UsingRIAServices.Web.RegistrationData.#ToLoginParameters()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.Web.RegistrationData.#PasswordConfirmationAccessor")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.Web.RegistrationData.#PasswordAccessor")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Logout", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext+IAuthenticationServiceContract.#EndLogout(System.IAsyncResult)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext+IAuthenticationServiceContract.#EndLogin(System.IAsyncResult)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Logout", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext+IAuthenticationServiceContract.#BeginLogout(System.AsyncCallback,System.Object)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext+IAuthenticationServiceContract.#BeginLogin(System.String,System.String,System.Boolean,System.String,System.AsyncCallback,System.Object)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope:="type", Target:="UsingRIAServices.Web.AuthenticationContext+IAuthenticationServiceContract")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Logout", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext.#LogoutQuery()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext.#LoginQuery(System.String,System.String,System.Boolean,System.String)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope:="member", Target:="UsingRIAServices.Web.AuthenticationContext.#GetUserQuery()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.RegistrationForm.#RegisterForm_AutoGeneratingField(System.Object,System.Windows.Controls.DataFormAutoGeneratingFieldEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.RegistrationForm.#RegisterButton_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.RegistrationForm.#CreateComboBoxWithSecurityQuestions()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.RegistrationForm.#CancelButton_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.RegistrationForm.#BackToLogin_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginStatus.#LogoutButton_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginStatus.#LoginButton_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginStatus.#.ctor()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="type", Target:="UsingRIAServices.LoginUI.LoginStatus")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginRegistrationWindow.#NavigateToLogin()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginRegistrationWindow.#.ctor()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="type", Target:="UsingRIAServices.LoginUI.LoginRegistrationWindow")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginInfo.#ToLoginParameters()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginInfo.#PasswordAccessor")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginInfo.#CurrentLoginOperation")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="LogIn", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginInfo.#CanLogIn")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="type", Target:="UsingRIAServices.LoginUI.LoginInfo")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginForm.#RegisterNow_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginForm.#LoginForm_KeyDown(System.Object,System.Windows.Input.KeyEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginForm.#LoginForm_AutoGeneratingField(System.Object,System.Windows.Controls.DataFormAutoGeneratingFieldEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginForm.#LoginButton_Click(System.Object,System.EventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.LoginUI.LoginForm.#CancelButton_Click(System.Object,System.EventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="type", Target:="UsingRIAServices.LoginUI.LoginForm")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Scope:="member", Target:="UsingRIAServices.TargetNullValueConverter.#Convert(System.Object,System.Type,System.Object,System.Globalization.CultureInfo)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="string", Scope:="member", Target:="UsingRIAServices.StringFormatValueConverter.#.ctor(System.String)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope:="member", Target:="UsingRIAServices.ResourceWrapper.#SecurityQuestions")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope:="member", Target:="UsingRIAServices.ResourceWrapper.#ApplicationStrings")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.MainPage.#ContentFrame_NavigationFailed(System.Object,System.Windows.Navigation.NavigationFailedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.MainPage.#ContentFrame_Navigated(System.Object,System.Windows.Navigation.NavigationEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Scope:="member", Target:="UsingRIAServices.MainPage.#.ctor()")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.ErrorWindow.#OKButton_Click(System.Object,System.Windows.RoutedEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Scope:="member", Target:="UsingRIAServices.ErrorWindow.#.ctor(System.String,System.String)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope:="member", Target:="UsingRIAServices.DataFieldExtensions.#ReplaceTextBox(System.Windows.Controls.DataField,System.Windows.FrameworkElement,System.Windows.DependencyProperty,System.Action`1<System.Windows.Data.Binding>)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope:="member", Target:="UsingRIAServices.DataBindingExtensions.#CreateOneWayBinding(System.ComponentModel.INotifyPropertyChanged,System.String,System.Windows.Data.IValueConverter)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.App.#Application_UnhandledException(System.Object,System.Windows.ApplicationUnhandledExceptionEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope:="member", Target:="UsingRIAServices.App.#Application_Startup(System.Object,System.Windows.StartupEventArgs)")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId:="Login", Scope:="namespace", Target:="UsingRIAServices.LoginUI")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope:="namespace", Target:="UsingRIAServices.Controls")> 
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Scope:="member", Target:="UsingRIAServices.Web.User.#Global_System_Security_Principal_IPrincipal_Identity")> 

