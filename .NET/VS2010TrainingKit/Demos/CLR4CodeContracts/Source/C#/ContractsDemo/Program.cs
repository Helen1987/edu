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
using System.Text;
using System.Diagnostics.Contracts;

namespace ContractsDemo
{
    [ContractVerification(true)]
    class Program
    {
        static void Main(string[] args)
        {
                var password = GetPassword(-1);
                Console.WriteLine(password.Length);
            

            Console.ReadKey();
        }

        #region Header
        /// <param name="userId">Should be greater than 0</param>
        /// <returns>non-null string</returns>
        #endregion
        static string GetPassword(int userId)
        {
            Contract.Requires(userId >= 0, "UserId must be");
            Contract.Ensures(Contract.Result<string>() != null);

            if (userId == 0)
            {
                // Made some code to log behavior

                // User doesn't exist
                return null;
            }
            else if (userId > 0)
            {
                return "Password";
            }

            return null;
        }
    }
}
