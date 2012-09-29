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
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;

namespace ContosoRealtor
{
    [Export(typeof(ILogger))]
    public class Logger : ILogger, IPartImportsSatisfiedNotification
    {
        StreamWriter _log;

        [Import("LogPath")]
        string LogPath { get; set; }

        public void OnImportsSatisfied()
        {
            _log = new StreamWriter(File.Open(LogPath, FileMode.Create, FileAccess.Write, FileShare.Read));
        }

        public void WriteLine(string format, params object[] args)
        {
            _log.WriteLine("{0} {1}", DateTime.Now, string.Format(format, args));
            _log.Flush();
        }
    }
}
