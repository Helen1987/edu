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

Namespace BarrierDemo
	Friend Class Program
		Private Shared sync As Barrier
		Private Shared token As CancellationToken

		Shared Sub Main(ByVal args() As String)
			Dim source = New CancellationTokenSource()
			token = source.Token
            sync = New Barrier(3)

            Dim charlie = New Thread(Sub() DriveToBoston("Charlie", TimeSpan.FromSeconds(1)))
            charlie.Start()
            Dim mac = New Thread(Sub() DriveToBoston("Mac", TimeSpan.FromSeconds(2)))
            mac.Start()
            Dim dennis = New Thread(Sub() DriveToBoston("Dennis", TimeSpan.FromSeconds(3)))
            dennis.Start()

            'source.Cancel()

            charlie.Join()
            mac.Join()
            dennis.Join()

            Console.ReadKey()
        End Sub

        Private Shared Sub DriveToBoston(ByVal name As String, ByVal timeToGasStation As TimeSpan)
            Try
                Console.WriteLine("[{0}] Leaving House", name)

                ' Perform some work
                Thread.Sleep(timeToGasStation)
                Console.WriteLine("[{0}] Arrived at Gas Station", name)

                ' Need to sync here
                sync.SignalAndWait(token)

                ' Perform some more work
                Console.WriteLine("[{0}] Leaving for Boston", name)
            Catch e1 As OperationCanceledException
                Console.WriteLine("[{0}] Caravan was cancelled! Going home!", name)
            End Try
        End Sub
    End Class
End Namespace
