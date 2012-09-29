﻿// ----------------------------------------------------------------------------------
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDataStructures.Tests
{
    [TestClass]
    public class SimpleStackTests
    {
        [TestMethod]
        public void ThenItShouldBeEmpty()
        {
            SimpleStack theStack = new SimpleStack();

            Assert.IsTrue(theStack.IsEmpty);
        }

        [TestMethod]
        public void ThenShouldBeAbleToPushAnItemOntoTheStack()
        {
            var theStack = new SimpleStack();
            theStack.Push(1);

            Assert.IsFalse(theStack.IsEmpty);
        }

        [TestMethod]
        public void ThenShouldBeAbleToPushAndPopAnItemFromTheStack()
        {
            var theStack = new SimpleStack();
            theStack.Push(1);

            int poppedItem = theStack.Pop();

            Assert.AreEqual(1, poppedItem);
        }
    }
}
