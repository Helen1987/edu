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
Imports System.ComponentModel

Namespace DataBinding
	Public Class CustomerContainer
		Implements INotifyPropertyChanged

		Private Const IMAGE As String = "Images/blue.png"
		Private _States As ObservableCollection(Of State)
		Private _Customers As ObservableCollection(Of Customer)
		Private _CurrentCustomer As Customer
		Private _CurrentState As State
		Private _FilteredCustomers As ObservableCollection(Of Customer)


		Public Sub New()
			States = New ObservableCollection(Of State) From {
				New State With {.Name="View All"},
				New State With {.Name="Arizona", .Abbreviation="AZ"},
				New State With {.Name="California", .Abbreviation="CA"},
				New State With {.Name="Nevada", .Abbreviation="NV"}}

			Customers = New ObservableCollection(Of Customer) From {
				New Customer With {.Name="John Doe", .City="Phoenix", .State="Arizona", .IsGold=True, .Birthday = New Date(1950,5,10), .ImageUrl=IMAGE},
				New Customer With {.Name="Jane Doe", .City="Tempe", .State="Arizona", .Birthday = New Date(1970,4,13), .ImageUrl=IMAGE},
				New Customer With {.Name="Johnny Doe", .City="San Diego", .State="California", .Birthday = New Date(1980,8,26), .ImageUrl=IMAGE},
				New Customer With {.Name="James Doe", .City="Las Vegas", .State="Nevada", .IsGold=True, .Birthday = New Date(1956,8,30), .ImageUrl=IMAGE},
				New Customer With {.Name="Gina Doe", .City="Anaheim", .State="California", .Birthday = New Date(1984,2,28), .ImageUrl=IMAGE}}
			FilteredCustomers = Customers
		End Sub


		#Region "Properties"

		Public Property FilteredCustomers() As ObservableCollection(Of Customer)
			Get
				Return _FilteredCustomers
			End Get

			Set(ByVal value As ObservableCollection(Of Customer))
				If _FilteredCustomers IsNot value Then
					_FilteredCustomers = value
					OnPropertyChanged("FilteredCustomers")
				End If
			End Set
		End Property

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

		Public Property States() As ObservableCollection(Of State)
			Get
				Return _States
			End Get

			Set(ByVal value As ObservableCollection(Of State))
				If _States IsNot value Then
					_States = value
					OnPropertyChanged("States")
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
				End If
			End Set
		End Property

		Public Property CurrentState() As State
			Get
				Return _CurrentState
			End Get

			Set(ByVal value As State)
				If _CurrentState IsNot value Then
					_CurrentState = value
					OnPropertyChanged("CurrentState")
					FilterCustomersByState()
				End If
			End Set
		End Property

		#End Region

		Private Sub FilterCustomersByState()
			If CurrentState IsNot Nothing Then
				If CurrentState.Name <> "View All" Then
					Dim customers = Me.Customers.Where(Function(c) c.State = CurrentState.Name)
					FilteredCustomers = New ObservableCollection(Of Customer)(customers)
				Else
					FilteredCustomers = Customers
				End If
			End If
		End Sub


		#Region "INotifyPropertyChanged Members"

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Protected Sub OnPropertyChanged(ByVal propName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
		End Sub

		#End Region
	End Class
End Namespace
