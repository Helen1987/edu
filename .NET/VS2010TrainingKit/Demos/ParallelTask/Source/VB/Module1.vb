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
Imports System.Diagnostics
Imports System.Threading.Tasks

Module Module1

    Sub Main()
        Console.WriteLine("MTID={0}", Thread.CurrentThread.ManagedThreadId)

        'RunTasks()
        'RunThreads()
        RunPool()

        ' More work
        Console.ReadKey(True)
    End Sub

    Private Sub DoSomeWork(ByVal state As Object)
        Dim loops = CInt(state) * 25000000

        Dim i = 0
        While i < loops
            i = i + 1
            i = i - 1
            i = i * 1

            i = i + 1
        End While
        


        Console.WriteLine("TID={0}, state={1}", Thread.CurrentThread.ManagedThreadId, state)
    End Sub

    Private Sub RunThreads()
        Dim sw = Stopwatch.StartNew()

        Console.WriteLine("Running Threads...")
        Dim t1 = New Thread(AddressOf DoSomeWork)
        t1.Start(3)
        Dim t2 = New Thread(AddressOf DoSomeWork)
        t2.Start(6)
        Dim t3 = New Thread(AddressOf DoSomeWork)
        t3.Start(9)
        Dim t4 = New Thread(AddressOf DoSomeWork)
        t4.Start(12)
        Dim t5 = New Thread(AddressOf DoSomeWork)
        t5.Start(15)
        Dim t6 = New Thread(AddressOf DoSomeWork)
        t6.Start(18)
        Dim t7 = New Thread(AddressOf DoSomeWork)
        t7.Start(21)
        Dim t8 = New Thread(AddressOf DoSomeWork)
        t8.Start(24)

        t1.Join()
        t2.Join()
        t3.Join()
        t4.Join()
        t5.Join()
        t6.Join()
        t7.Join()
        t8.Join()

        sw.Stop()
        Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds)
    End Sub

    Private Sub RunPool()
        ' No *EASY* way to measure
        Console.WriteLine("Running Pool...")

        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 3)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 6)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 9)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 12)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 15)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 18)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 21)
        ThreadPool.QueueUserWorkItem(AddressOf DoSomeWork, 24)
    End Sub

    Private Sub RunTasks()
        Dim sw = Stopwatch.StartNew()

        Console.WriteLine("Running Tasks...")
        Dim t1 = Task.Factory.StartNew(AddressOf DoSomeWork, 3)
        Dim t2 = Task.Factory.StartNew(AddressOf DoSomeWork, 6)
        Dim t3 = Task.Factory.StartNew(AddressOf DoSomeWork, 9)
        Dim t4 = Task.Factory.StartNew(AddressOf DoSomeWork, 12)
        Dim t5 = Task.Factory.StartNew(AddressOf DoSomeWork, 15)
        Dim t6 = Task.Factory.StartNew(AddressOf DoSomeWork, 18)
        Dim t7 = Task.Factory.StartNew(AddressOf DoSomeWork, 21)
        Dim t8 = Task.Factory.StartNew(AddressOf DoSomeWork, 24)

        t1.Wait()
        t2.Wait()
        t3.Wait()
        t4.Wait()
        t5.Wait()
        t6.Wait()
        t7.Wait()
        t8.Wait()

        sw.Stop()
        Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds)
    End Sub

End Module
