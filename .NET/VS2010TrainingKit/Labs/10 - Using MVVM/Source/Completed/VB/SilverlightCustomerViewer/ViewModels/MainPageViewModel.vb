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

Imports System.Collections.ObjectModel
Imports CustomerService.Proxies
Imports SilverlightCustomerViewer.ServiceAgents
Imports SilverlightCustomerViewer.Commanding

Namespace SilverlightCustomerViewer.ViewModels
	Public Class MainPageViewModel
		Inherits ViewModelBase
		Private _CurrentCustomer As Customer
		Private _Customers As ObservableCollection(Of Customer)
		Private _StatusMessage As String

		Public Sub New()
			Me.New(New CustomersServiceAgent())
		End Sub

		Public Sub New(ByVal serviceAgent As ICustomersServiceAgent)
			If Not IsDesignTime Then
				If serviceAgent IsNot Nothing Then
					Me.ServiceAgent = serviceAgent
				End If
				GetCustomers()
				WireCommands()
			End If
		End Sub

		Private Sub WireCommands()
			UpdateCustomerCommand = New RelayCommand(AddressOf UpdateCustomer)
			DeleteCustomerCommand = New RelayCommand(AddressOf DeleteCustomer)
		End Sub

		#Region "Commands"

        Private _UpdateCustomerCommand As RelayCommand
		Public Property UpdateCustomerCommand() As RelayCommand
			Get
                Return _UpdateCustomerCommand
			End Get
			Private Set(ByVal value As RelayCommand)
                _UpdateCustomerCommand = value
			End Set
		End Property

        Private _DeleteCustomerCommand As RelayCommand
		Public Property DeleteCustomerCommand() As RelayCommand
			Get
                Return _DeleteCustomerCommand
			End Get
			Private Set(ByVal value As RelayCommand)
                _DeleteCustomerCommand = value
			End Set
		End Property

		#End Region

		#Region "Properties"

		Private Property ServiceAgent() As ICustomersServiceAgent


		Public Property Customers() As ObservableCollection(Of Customer)
			Get
				Return _Customers
			End Get

			Set(ByVal value As ObservableCollection(Of Customer))
				If _Customers IsNot value Then
					_Customers = value
					OnPropertyChanged("Customers")
				End If
			End Set
		End Property

		Public Property CurrentCustomer() As Customer
			Get
				Return _CurrentCustomer
			End Get

			Set(ByVal value As Customer)
				If _CurrentCustomer IsNot value Then
					_CurrentCustomer = value
					OnPropertyChanged("CurrentCustomer")
					StatusMessage = String.Empty
					UpdateCustomerCommand.IsEnabled = True
					DeleteCustomerCommand.IsEnabled = True
				End If
			End Set
		End Property

		Public Property StatusMessage() As String
			Get
				Return _StatusMessage
			End Get

			Set(ByVal value As String)
				If _StatusMessage <> value Then
					_StatusMessage = value
					OnPropertyChanged("StatusMessage")
				End If
			End Set
		End Property

		#End Region

        Private Sub GetCustomers()
            ServiceAgent.GetCustomers(Sub(s, e) Customers = e.Result)
        End Sub

        Public Sub UpdateCustomer()
            SaveCustomer(ObjectState.Modified)
        End Sub

        Public Sub DeleteCustomer()
            SaveCustomer(ObjectState.Deleted)
            Customers.Remove(CurrentCustomer)
            CurrentCustomer = Nothing
        End Sub

        Private Sub SaveCustomer(ByVal state As ObjectState)
            CurrentCustomer.ChangeTracker.State = state
            ServiceAgent.SaveCustomer(CurrentCustomer, _
                Sub(s, e) StatusMessage = _
                    If(e.Result.Status, "Success!", "Unable to complete operation"))
        End Sub
	End Class
End Namespace
