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
using System.Collections.ObjectModel;

namespace WPFTaskPane
{
    public class SnippetDataSource
    {
        private ObservableCollection<Snippet> m_snippets = new SafeObservableCollection<Snippet>();

        public ObservableCollection<Snippet> GetSnippets()
        {
            Action loadDelegate = new Action(delegate()
            {
                m_snippets.Add(new Snippet("Header", "Header information", "This is the header"));
                m_snippets.Add(new Snippet("Footer", "Footer information", "This is the footer"));
            });
            loadDelegate.BeginInvoke(null, null);

            return m_snippets;
        }
    }
}
