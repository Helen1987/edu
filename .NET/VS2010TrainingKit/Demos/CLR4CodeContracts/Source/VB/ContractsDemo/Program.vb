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

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Diagnostics.Contracts

Namespace ContractsDemo
	<ContractVerification(True)> _
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
            Dim password = GetPassword(-1)
            Console.WriteLine(password.Length)

			Console.ReadKey()
		End Sub

        Private Shared Function GetPassword(ByVal userId As Integer) As String
            Contract.Requires(userId >= 0)
            Contract.Ensures(Contract.Result(Of String)() IsNot Nothing)

            If userId = 0 Then
                ' Made some code to log behavior

                ' User doesn't exist
                Return Nothing
            ElseIf userId > 0 Then
                Return "Password"
            End If

            Return Nothing
        End Function
	End Class
End Namespace
