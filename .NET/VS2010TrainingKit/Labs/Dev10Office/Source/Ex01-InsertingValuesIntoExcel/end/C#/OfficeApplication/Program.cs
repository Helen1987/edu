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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace OfficeApplication
{
    static class Program
    {
        static void Main(string[] args)
        {
            var checkAccounts = CreateAccountList();

            checkAccounts.DisplayInExcel((account, cell) =>
            {
                cell.Value2 = account.ID;
                cell.get_Offset(0, 1).Value2 = account.Balance;
                cell.get_Offset(0, 2).Value2 = account.AccountHolder;

                if (account.Balance < 0)
                {
                    cell.Interior.Color = 255;
                    cell.get_Offset(0, 1).Interior.Color = 255;
                    cell.get_Offset(0, 2).Interior.Color = 255;
                }
            });
        }

        private static List<Account> CreateAccountList()
        {
            var checkAccounts = new List<Account> {
                new Account{
                    ID = 1,
                    Balance = 285.93,
                    AccountHolder = "John Doe"
                },
                new Account {
                    ID = 2,
                    Balance = 2349.23,
                    AccountHolder = "Richard Roe"
                },
                new Account {
                    ID = 3,
                    Balance = -39.46,
                    AccountHolder = "I Dunoe"
                }
            };

            return checkAccounts;
        }

        static void DisplayInExcel(this IEnumerable<Account> accounts,
                          Action<Account, Excel.Range> DisplayFunc)
        {
            var x1 = new Excel.Application();

            //see the Note below
            x1.Workbooks.Add();
            x1.Visible = true;
            x1.get_Range("A1").Value2 = "ID";
            x1.get_Range("B1").Value2 = "Balance";
            x1.get_Range("C1").Value2 = "Account Holder";
            x1.get_Range("A2").Select();

            foreach (var ac in accounts)
            {
                DisplayFunc(ac, x1.ActiveCell);
                x1.ActiveCell.get_Offset(1, 0).Select();
            }

            ((Excel.Range)x1.Columns[1]).AutoFit();
            ((Excel.Range)x1.Columns[2]).AutoFit();
            ((Excel.Range)x1.Columns[3]).AutoFit();
        }

    }
}
