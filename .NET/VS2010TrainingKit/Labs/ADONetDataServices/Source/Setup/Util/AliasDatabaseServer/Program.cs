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
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace AliasDatabaseServer
{
    static class Program
    {
        private enum ErrorValues
        {
            Success,
            AlreadyExists,
            NotCreatedWrongServerOrUser,
            NotCreatedUnknown,
            NotDeletedWrongServerOrUser,
            NotDeletedUnknown,
            Help
        }

        // Return values table
        // 0 Success
        // 1 Alias already exists
        // 2 Alias not created, wrong server or not admin user
        // 3 Alias not created, unknown reason
        // 4 Alias not deleted, wrong server or not admin user
        // 5 Alias not deleted, unknown reason

        private const string DefaultHostname = @"default";
        private static string serverInstanceName;
        private static string aliasName;
        private static bool lastArgumentWasDelete;
        private static int returnValue; //used for batch processing

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            
            //args = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            ParseParameters(args);

            // check parameters and show help
            if (args.Length == 0 || (args.Length > 2 && (!lastArgumentWasDelete)))
            {
                Console.WriteLine(@"Usage: AliasDatabaseServer [ServerInstanceName] AliasName [/delete]");
                Console.WriteLine("\nOptions\n /drop     will delete the alias corresponding to AliasName");
                Console.WriteLine("\n" + @"Example: AliasDatabasServer \\localhost\MYSQLSERVER MyAlias" + "\n");
                Console.WriteLine(string.Format(@"If not specified [ServerInstanceName] = '{0}'", DefaultHostname));
                Console.ReadKey();
                return (int)ErrorValues.Help;
            }
            else
            {

                ManagedComputer computer = new ManagedComputer();

                if (!string.IsNullOrEmpty(serverInstanceName) && serverInstanceName == "default")
                {
                    if (computer.ServerInstances.Contains("SQLEXPRESS"))
                    {
                        serverInstanceName = @"MSSQL\SQLEXPRESS";
                    }
                    else if (computer.ServerInstances.Contains("SQLEXPRESS"))
                    {
                        serverInstanceName = @"MSSQLSERVER";
                    }
                    else
                    {
                        serverInstanceName = computer.ServerInstances[0].Name;
                    }
                }

                if (lastArgumentWasDelete)
                {
                    DeleteAlias(computer, serverInstanceName, aliasName);
                }
                else
                {
                    CreateAlias(computer, serverInstanceName, aliasName);
                }

                return returnValue;
            }
        }

        public static void CreateAlias(ManagedComputer computer, string serverInstance, string aliasName)
        {
            if (computer.ServerAliases.Contains(aliasName))
            {
                string aliasExistMessage = string.Format("{0} alias already exists. Not creating the alias.", aliasName);
                Console.WriteLine(aliasExistMessage);
                returnValue = (int)ErrorValues.Success;
            }
            else
            {
                ServerAlias alias = RetrievePreparedServerAlias(computer, serverInstance, aliasName);

                try
                {
                    alias.Create();
                    Console.WriteLine("An alias has been created");
                }
                catch (FailedOperationException)
                {
                    Console.WriteLine(@"The alias creation failed, please check that you specified
                                        the correct server instance name or that you have enough permissions");

                    returnValue = (int)ErrorValues.NotCreatedWrongServerOrUser;
                }
                catch
                {
                    Console.WriteLine("The alias creation failed");
                    returnValue = (int)ErrorValues.NotCreatedUnknown;
                }
            }
        }

        public static void DeleteAlias(ManagedComputer computer, string serverInstance, string aliasName)
        {
            ServerAlias alias = RetrievePreparedServerAlias(computer, serverInstance, aliasName);

            if (computer.ServerAliases.Contains(aliasName))
            {
                try
                {
                    alias.Drop();
                    Console.WriteLine(string.Format("The alias {0} has been deleted", aliasName));
                }
                catch (FailedOperationException)
                {
                    Console.WriteLine("The alias deletion failed, please check that you specified the correct server instance name");
                    returnValue = (int)ErrorValues.NotDeletedWrongServerOrUser;
                }
                catch
                {
                    Console.WriteLine("The alias deletion failed");
                    returnValue = (int)ErrorValues.NotDeletedUnknown;
                }
            }
            else
            {
                Console.WriteLine("Alias not found in the database");
            }
        }

        private static void ParseParameters(string[] args)
        {
            serverInstanceName = string.Empty;
            aliasName = string.Empty;

            lastArgumentWasDelete = (args.Length > 1 && args.Length <= 3 && args[args.Length - 1].ToLower() == @"/delete");

            if ((args.Length == 2 && (!lastArgumentWasDelete)) || (args.Length == 3 && lastArgumentWasDelete))
            {
                serverInstanceName = args[0];
                aliasName = args[1];
            }
            else
            {
                serverInstanceName = DefaultHostname;
                aliasName = args[0];
            }
        }


        private static ServerAlias RetrievePreparedServerAlias(ManagedComputer computer, string serverInstance, string aliasName)
        {
            ServerAlias alias = new ServerAlias(computer, aliasName);
            alias.ProtocolName = "np";
            alias.ServerName = ".";

            string instanceName = ParseInstanceNameFromFullName(serverInstance);

            if (serverInstance.IndexOf('\\') < 0)
            {
                alias.ConnectionString = @"sql\query";
            }
            else
            {
                alias.ConnectionString = String.Format("MSSQL${0}\\sql\\query", instanceName);
            }

            return alias;
        }

        private static string ParseInstanceNameFromFullName(string serverInstance)
        {
            string instanceName = String.Empty;
            if (serverInstance.IndexOf("\\") >= 0)
                instanceName = serverInstance.Substring(serverInstance.IndexOf('\\') + 1, serverInstance.Length - (serverInstance.IndexOf('\\') + 1));
            return instanceName;
        }

    }
}

