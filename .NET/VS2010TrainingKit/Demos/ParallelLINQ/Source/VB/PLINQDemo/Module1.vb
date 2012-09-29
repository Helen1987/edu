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

Imports System.Threading

Module Module1

    Sub Main()
        Dim numbers As IEnumerable(Of Integer) = Enumerable.Range(1, 1000)

        'Remove AsParallel() Function in PLINQ query to see the difference in speed
        Dim results As IEnumerable(Of Integer) = From n In numbers.AsParallel()
                                                 Where IsDivisibleByFive(n)
                                                 Select n

        Dim sw = Stopwatch.StartNew()
        Dim resultsList = results.ToList()
        Console.WriteLine("{0} items", resultsList.Count())
        sw.Stop()

        Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds)

        Console.WriteLine()
        Console.WriteLine("Finished...")
        Console.ReadKey(True)
    End Sub

    Private Function IsDivisibleByFive(ByVal i As Integer) As Boolean
        Thread.SpinWait(2000000)

        Return i Mod 5 = 0
    End Function
End Module
