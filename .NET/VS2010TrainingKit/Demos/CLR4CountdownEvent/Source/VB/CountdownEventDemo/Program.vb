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
Imports System.Linq
Imports System.Text
Imports System.Threading

Namespace CountdowBnEventDemo
    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            Dim customers = Enumerable.Range(1, 20)

            Using countdown As CountdownEvent = New CountdownEvent(1)
                For Each customer As Integer In customers
                    Dim currentCustomer As Integer = customer

                    countdown.AddCount()
                    ThreadPool.QueueUserWorkItem(Sub()
                                                     BuySomeStuff(currentCustomer)
                                                     countdown.Signal()
                                                 End Sub)
                Next customer

                countdown.Signal()
                countdown.Wait()
            End Using

            Console.WriteLine("All Customers finished shopping...")
            Console.ReadKey()
        End Sub

        Private Shared Sub BuySomeStuff(ByVal customer As Integer)
            ' Fake work
            Thread.SpinWait(20000000)

            Console.WriteLine("Customer {0} finished", customer)
        End Sub
    End Class
End Namespace
