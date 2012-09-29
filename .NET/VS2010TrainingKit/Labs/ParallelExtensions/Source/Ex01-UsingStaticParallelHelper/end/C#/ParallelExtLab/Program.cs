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
            Ex1Task1_WalkTree();

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
    }
}
