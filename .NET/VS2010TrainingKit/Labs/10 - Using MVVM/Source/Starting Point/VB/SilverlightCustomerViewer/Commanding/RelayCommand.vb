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

Imports System.Windows.Input

Namespace SilverlightCustomerViewer.Commanding
	Public Class RelayCommand
        Implements ICommand

        Private ReadOnly _handler As Action
        Private _isEnabled As Boolean

        Public Sub New(ByVal handler As Action)
            _handler = handler
        End Sub

        Public Property IsEnabled() As Boolean
            Get
                Return _isEnabled
            End Get
            Set(ByVal value As Boolean)
                If value <> _isEnabled Then
                    _isEnabled = value
                    RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return IsEnabled
        End Function

        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            _handler()
        End Sub

        Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements System.Windows.Input.ICommand.CanExecuteChanged

    End Class
End Namespace
