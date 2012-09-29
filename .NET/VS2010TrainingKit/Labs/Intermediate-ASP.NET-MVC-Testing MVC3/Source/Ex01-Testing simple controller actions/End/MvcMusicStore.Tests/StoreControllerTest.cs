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

using MvcMusicStore.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace MvcMusicStore.Tests
{
    
    
    /// <summary>
    ///This is a test class for StoreControllerTest and is intended
    ///to contain all StoreControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StoreControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Browse
        ///</summary>
        [TestMethod()]
        public void BrowseTest()
        {
            StoreController target = new StoreController(); 
            string genre = "Disco";
            string expected = "Store.Browse, Genre = Disco";
            string actual;
            actual = target.Browse(genre);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Details
        ///</summary>
        [TestMethod()]
        public void DetailsTest()
        {
            StoreController target = new StoreController(); 
            int id = 5;
            string expected = "Store.Details, ID = 5";
            string actual;
            actual = target.Details(id);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            StoreController target = new StoreController(); 
            string expected = "Hello from Store.Index()";
            string actual;
            actual = target.Index();
            Assert.AreEqual(expected, actual);
        }
    }
}
