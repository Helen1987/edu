// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace ParallelExtLab
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        private static EmployeeList employeeData;

        static void Main(string[] args)
        {
            employeeData = new EmployeeList();

            Console.WriteLine("Payroll process started at {0}", DateTime.Now);
            var sw = Stopwatch.StartNew();

            // Methods to call
            // Ex1Task1_ParallelizeLongRunningService();
            // Ex1Task1_UseParallelForMethod();
            // Ex1Task1_StandardForEach();
            // Ex1Task1_ParallelForEach();
            // Ex1Task1_WalkTree();
            // Ex2Task1_NativeParallelTasks();
            // Ex2Task2_WaitHandling();
            // Ex2Task2_WaitHandlingWaitAll();
            // Ex2Task3_TaskIsCompleted();
            // Ex2Task4_ContinueWith();
            // Ex3Task1_TaskReturnValue();
            // Ex4Task1_PLINQ();
            // Ex4Task1_PLINQAsParallel();
            // Ex4Task2_Extensions();
            // Ex4Task2_ConvertToParallelExtensions();
            Ex4Task3_PLINQComprehensionSyntax();

            Console.WriteLine("Payroll finished at {0} and took {1}",
                                  DateTime.Now, sw.Elapsed.TotalSeconds);
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void Ex1Task1_ParallelizeLongRunningService()
        {
            Console.WriteLine("Non-parallelized for loop");

            for (int i = 0; i < employeeData.Count; i++)
            {
                Console.WriteLine("Starting process for employee id {0}",
                    employeeData[i].EmployeeID);
                decimal span =
                    PayrollServices.GetPayrollDeduction(employeeData[i]);
                Console.WriteLine("Completed process for employee id {0}" +
                    "process took {1} seconds",
                    employeeData[i].EmployeeID, span);
                Console.WriteLine();
            }
        }

        private static void Ex1Task1_UseParallelForMethod()
        {
            Parallel.For(0, employeeData.Count, i =>
            {
                Console.WriteLine("Starting process for employee id {0}",
                                   employeeData[i].EmployeeID);
                decimal span =
                    PayrollServices.GetPayrollDeduction(employeeData[i]);
                Console.WriteLine("Completed process for employee id {0}",
                                  employeeData[i].EmployeeID);
                Console.WriteLine();
            });
        }

        private static void Ex1Task1_StandardForEach()
        {
            foreach (Employee employee in employeeData)
            {
                Console.WriteLine("Starting process for employee id {0}",
                    employee.EmployeeID);
                decimal span =
                    PayrollServices.GetPayrollDeduction(employee);
                Console.WriteLine("Completed process for employee id {0}",
                    employee.EmployeeID);
                Console.WriteLine();
            }
        }

        private static void Ex1Task1_ParallelForEach()
        {
            Parallel.ForEach(employeeData, ed =>
            {
                Console.WriteLine("Starting process for employee id {0}",
                    ed.EmployeeID);
                decimal span = PayrollServices.GetPayrollDeduction(ed);
                Console.WriteLine("Completed process for employee id {0}",
                    ed.EmployeeID);
                Console.WriteLine();
            });
        }

        private static void Ex1Task1_WalkTree()
        {
            EmployeeHierarchy employeeHierarchy = new EmployeeHierarchy();
            WalkTree(employeeHierarchy);
        }

        private static void WalkTree(Tree<Employee> node)
        {
            if (node == null)
                return;

            if (node.Data != null)
            {
                Employee emp = node.Data;
                Console.WriteLine("Starting process for employee id {0}",
                    emp.EmployeeID);
                decimal span = PayrollServices.GetPayrollDeduction(emp);
                Console.WriteLine("Completed process for employee id {0}",
                    emp.EmployeeID);
                Console.WriteLine();
            }

            Parallel.Invoke(delegate { WalkTree(node.Left); }, delegate { WalkTree(node.Right); });
        }

        private static void Ex2Task1_NativeParallelTasks()
        {
            Task task1 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[0]); });
            Task task2 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[1]); });
            Task task3 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[2]); });
        }

        private static void Ex2Task2_WaitHandling()
        {
            Task task1 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[0]); });
            Task task2 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[1]); });
            Task task3 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[2]); });

            task1.Wait();
            task2.Wait();
            task3.Wait();
        }

        private static void Ex2Task2_WaitHandlingWaitAll()
        {
            Task task1 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[0]); });
            Task task2 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[1]); });
            Task task3 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[2]); });

            Task.WaitAll(task1, task2, task3);
        }

        private static void Ex2Task3_TaskIsCompleted()
        {
            Task task1 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[0]); });

            while (!task1.IsCompleted)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting on task 1");
            }

            Task task2 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[1]); });
            while (!task2.IsCompleted)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting on task 2");
            }

            Task task3 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[2]); });
            while (!task3.IsCompleted)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting on task 3");
            }
        }

        private static void Ex2Task4_ContinueWith()
        {
            Task task3 = Task.Factory.StartNew(delegate
            { PayrollServices.GetPayrollDeduction(employeeData[0]); })
                .ContinueWith(delegate
                { PayrollServices.GetPayrollDeduction(employeeData[1]); })
                .ContinueWith(delegate
                { PayrollServices.GetPayrollDeduction(employeeData[2]); });

            task3.Wait();
        }

        private static void Ex3Task1_TaskReturnValue()
        {
            Console.WriteLine("Calling parallel task with return value");
            var data = Task.Factory.StartNew(() =>
              PayrollServices.GetPayrollDeduction(employeeData[0]));
            Console.WriteLine("Parallel task returned with value of {0}",
                data.Result);
        }

        static void Ex4Task1_PLINQ()
        {
            var q = Enumerable.Select(
                      Enumerable.OrderBy(
                        Enumerable.Where(employeeData,
                        x => x.EmployeeID % 2 == 0),
                        x => x.EmployeeID),
                      x => PayrollServices.GetEmployeeInfo(x))
                      .ToList();

            foreach (var e in q)
            {
                Console.WriteLine(e);
            }
        }

        static void Ex4Task1_PLINQAsParallel()
        {
            var q = ParallelEnumerable.Select(
                    ParallelEnumerable.OrderBy(
                      ParallelEnumerable.Where(employeeData.AsParallel(),
                        x => x.EmployeeID % 2 == 0),
                      x => x.EmployeeID),
                    x => PayrollServices.GetEmployeeInfo(x))
                  .ToList();

            foreach (var e in q)
            {
                Console.WriteLine(e);
            }
        }

        private static void Ex4Task2_Extensions()
        {
            var q = employeeData.
                Where(x => x.EmployeeID % 2 == 0).OrderBy(x => x.EmployeeID)
                .Select(x => PayrollServices.GetEmployeeInfo(x))
                .ToList();

            foreach (var e in q)
            {
                Console.WriteLine(e);
            }
        }

        private static void Ex4Task2_ConvertToParallelExtensions()
        {
            var q = employeeData.AsParallel()
                .Where(x => x.EmployeeID % 2 == 0).OrderBy(x => x.EmployeeID)
                .Select(x => PayrollServices.GetEmployeeInfo(x))
                .ToList();

            foreach (var e in q)
            {
                Console.WriteLine(e);
            }
        }

        private static void Ex4Task3_PLINQComprehensionSyntax()
        {
            var q = from e in employeeData.AsParallel()
                    where e.EmployeeID % 2 == 0
                    orderby e.EmployeeID
                    select PayrollServices.GetEmployeeInfo(e);

            foreach (var e in q)
            {
                Console.WriteLine(e);
            }
        }
    }
}
