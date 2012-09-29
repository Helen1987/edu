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
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace RunAs
{
    class Program
    {
        static int Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string parameters = String.Empty;
            if (args.Length > 1)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].Contains(" ")) builder.Append("\"");
                    builder.Append(args[i]);
                    if (args[i].Contains(" ")) builder.Append("\"");
                    builder.Append(" ");
                }
                parameters = builder.ToString(0, builder.Length-1);
            }
            
            Console.WriteLine("Executing {0} {1}. Environment Dir: {2}", args[0], parameters, Environment.CurrentDirectory);
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.UseShellExecute = false;
            if (parameters != String.Empty)
            {
                startInfo.Arguments = parameters;
            }
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            startInfo.LoadUserProfile = true;
            startInfo.FileName = args[0];
            Process p;
            try
            {
                p = Process.Start(startInfo);
                Console.WriteLine(p.StandardOutput.ReadToEnd());                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return 1;
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return p.ExitCode;
        }
    }
}

