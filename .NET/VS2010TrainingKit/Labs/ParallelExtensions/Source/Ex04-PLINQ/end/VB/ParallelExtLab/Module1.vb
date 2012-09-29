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
Imports System.Threading.Tasks

Module Module1
    Private employeeData As EmployeeList

    Sub Main(ByVal args() As String)
        employeeData = New EmployeeList()

        Console.WriteLine("Payroll process started at {0}", DateTime.Now)
        Dim sw = Stopwatch.StartNew()

        ' Methods to call
        ' Ex1Task1_ParallelizeLongRunningService()
        ' Ex1Task1_UseParallelForMethod()
        ' Ex1Task1_StandardForEach()
        ' Ex1Task1_ParallelForEach()
        ' Ex1Task1_WalkTree()
        ' Ex2Task1_NativeParallelTasks()
        ' Ex2Task2_WaitHandling()
        ' Ex2Task2_WaitHandlingWaitAll()
        ' Ex2Task3_TaskIsCompleted()
        ' Ex2Task4_ContinueWith()
        ' Ex3Task1_TaskReturnValue()
        ' Ex4Task1_PLINQ()
        ' Ex4Task1_PLINQAsParallel()
        ' Ex4Task2_Extensions()
        ' Ex4Task2_ConvertToParallelExtensions()
        Ex4Task3_PLINQComprehensionSyntax()

        
        Console.WriteLine("Payroll finished at {0} and took {1}", DateTime.Now, sw.Elapsed.TotalSeconds)
        Console.WriteLine()
        Console.ReadLine()
    End Sub

    Private Sub Ex1Task1_ParallelizeLongRunningService()
        Console.WriteLine("Non-parallelized for loop")

        For i = 0 To employeeData.Count - 1
            Console.WriteLine("Starting process for employee id {0}", employeeData(i).EmployeeID)
            Dim span As Decimal = PayrollServices.GetPayrollDeduction(employeeData(i))
            Console.WriteLine("Completed process for employee id {0}" & "process took {1} seconds", employeeData(i).EmployeeID, span)
            Console.WriteLine()
        Next i
    End Sub

    Private Sub Ex1Task1_UseParallelForMethod()
        Parallel.For(0, employeeData.Count,
                     Sub(i)
                         Console.WriteLine("Starting process for employee id {0}", employeeData(i).EmployeeID)
                         Dim span As Decimal = PayrollServices.GetPayrollDeduction(employeeData(i))
                         Console.WriteLine("Completed process for employee id {0}", employeeData(i).EmployeeID)
                         Console.WriteLine()
                     End Sub)
    End Sub

    Private Sub Ex1Task1_StandardForEach()
        For Each employee As Employee In employeeData
            Console.WriteLine("Starting process for employee id {0}", employee.EmployeeID)
            Dim span As Decimal = PayrollServices.GetPayrollDeduction(employee)
            Console.WriteLine("Completed process for employee id {0}", employee.EmployeeID)
            Console.WriteLine()
        Next employee
    End Sub

    Private Sub Ex1Task1_ParallelForEach()
        Parallel.ForEach(employeeData,
                         Sub(ed)
                             Console.WriteLine("Starting process for employee id {0}", ed.EmployeeID)
                             Dim span As Decimal = PayrollServices.GetPayrollDeduction(ed)
                             Console.WriteLine("Completed process for employee id {0}", ed.EmployeeID)
                             Console.WriteLine()
                         End Sub)
    End Sub

    Private Sub Ex1Task1_WalkTree()
        Dim employeeHierarchy As New EmployeeHierarchy()
        WalkTree(employeeHierarchy)
    End Sub

    Private Sub WalkTree(ByVal node As Tree(Of Employee))
        If node Is Nothing Then
            Return
        End If

        If node.Data IsNot Nothing Then
            Dim emp As Employee = node.Data
            Console.WriteLine("Starting process for employee id {0}", emp.EmployeeID)
            Dim span As Decimal = PayrollServices.GetPayrollDeduction(emp)
            Console.WriteLine("Completed process for employee id {0}", emp.EmployeeID)
            Console.WriteLine()
        End If

        Parallel.Invoke(Sub() WalkTree(node.Left), Sub() WalkTree(node.Right))
    End Sub

    Private Sub Ex2Task1_NativeParallelTasks()
        Dim task1 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(0)))
        Dim task2 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(1)))
        Dim task3 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(2)))
    End Sub

    Private Sub Ex2Task2_WaitHandling()
        Dim task1 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(0)))
        Dim task2 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(1)))
        Dim task3 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(2)))

        task1.Wait()
        task2.Wait()
        task3.Wait()
    End Sub

    Private Sub Ex2Task2_WaitHandlingWaitAll()
        Dim task1 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(0)))
        Dim task2 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(1)))
        Dim task3 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(2)))

        Task.WaitAll(task1, task2, task3)
    End Sub

    Private Sub Ex2Task3_TaskIsCompleted()
        Dim task1 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(0)))

        Do While Not task1.IsCompleted
            Thread.Sleep(1000)
            Console.WriteLine("Waiting on task 1")
        Loop

        Dim task2 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(1)))
        Do While Not task2.IsCompleted
            Thread.Sleep(1000)
            Console.WriteLine("Waiting on task 2")
        Loop

        Dim task3 As Task = Task.Factory.StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(2)))
        Do While Not task3.IsCompleted
            Thread.Sleep(1000)
            Console.WriteLine("Waiting on task 3")
        Loop
    End Sub

    Private Sub Ex2Task4_ContinueWith()
        Dim task3 As Task = Task.Factory _
                            .StartNew(Sub() PayrollServices.GetPayrollDeduction(employeeData(0))) _
                            .ContinueWith(Sub() PayrollServices.GetPayrollDeduction(employeeData(1))) _
                            .ContinueWith(Sub() PayrollServices.GetPayrollDeduction(employeeData(2)))

        task3.Wait()
    End Sub

    Private Sub Ex3Task1_TaskReturnValue()
        Console.WriteLine("Calling parallel task with return value")
        Dim data As Task(Of Decimal) = Task.Factory.StartNew(Function() PayrollServices.GetPayrollDeduction(employeeData(0)))
        Console.WriteLine("Parallel task returned with value of {0}", data.Result)
    End Sub

    Private Sub Ex4Task1_PLINQ()
        Dim q = Enumerable.Select(
                    Enumerable.OrderBy(
                        Enumerable.Where(
                            employeeData,
                            Function(x) x.EmployeeID Mod 2 = 0),
                            Function(x) x.EmployeeID),
                            Function(x) PayrollServices.GetEmployeeInfo(x)) _
                .ToList()

        For Each e In q
            Console.WriteLine(e)
        Next e
    End Sub

    Private Sub Ex4Task1_PLINQAsParallel()
        Dim q = ParallelEnumerable.Select(
                    ParallelEnumerable.OrderBy(
                        ParallelEnumerable.Where(
                            employeeData.AsParallel(),
                            Function(x) x.EmployeeID Mod 2 = 0),
                            Function(x) x.EmployeeID),
                            Function(x) PayrollServices.GetEmployeeInfo(x)) _
                .ToList()

        For Each e In q
            Console.WriteLine(e)
        Next e
    End Sub

    Private Sub Ex4Task2_Extensions()
        Dim q = employeeData _
                    .Where(Function(x) x.EmployeeID Mod 2 = 0) _
                    .OrderBy(Function(x) x.EmployeeID) _
                    .Select(Function(x) PayrollServices.GetEmployeeInfo(x)) _
                    .ToList()

        For Each e In q
            Console.WriteLine(e)
        Next e
    End Sub

    Private Sub Ex4Task2_ConvertToParallelExtensions()
        Dim q = employeeData.AsParallel() _
                    .Where(Function(x) x.EmployeeID Mod 2 = 0) _
                    .OrderBy(Function(x) x.EmployeeID) _
                    .Select(Function(x) PayrollServices.GetEmployeeInfo(x)) _
                    .ToList()

        For Each e In q
            Console.WriteLine(e)
        Next e
    End Sub

    Private Sub Ex4Task3_PLINQComprehensionSyntax()
        Dim q = From e In employeeData.AsParallel()
                Where e.EmployeeID Mod 2 = 0
                Order By e.EmployeeID
                Select PayrollServices.GetEmployeeInfo(e)

        For Each e In q
            Console.WriteLine(e)
        Next e
    End Sub
End Module
