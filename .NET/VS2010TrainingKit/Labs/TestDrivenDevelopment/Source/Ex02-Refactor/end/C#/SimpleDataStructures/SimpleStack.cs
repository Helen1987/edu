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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimpleDataStructures
{
    public class SimpleStack
    {
        ArrayList _items;

        public SimpleStack()
        {
            _items = new ArrayList();
        }

        public bool IsEmpty
        {
            get { return _items.Count == 0; }
        }

        public void Push(int p)
        {
            _items.Add(p);
        }

        public int Pop()
        {
            int value = (int)_items[0];
            _items.RemoveAt(0);

            return value;
        }
    }
}
