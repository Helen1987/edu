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
using System.Web.Mvc;
using MvcMusicStore.ViewModels;
using MvcMusicStore.Models;

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
        ///A test for Index
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void IndexTest()
        {
            StoreController target = new StoreController();
            ActionResult actual;
            actual = target.Index();
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            ViewResult viewResult = (ViewResult)actual;

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(StoreIndexViewModel));

            StoreIndexViewModel model = (StoreIndexViewModel)viewResult.ViewData.Model;

            Assert.AreEqual(10, model.Genres.Count);
            Assert.AreEqual(10, model.NumberOfGenres);
        }

        /// <summary>
        ///A test for Details
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void DetailsTest()
        {
            StoreController target = new StoreController(); 
            int id = 669; 
            ActionResult actual;
            actual = target.Details(id);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            ViewResult viewResult = (ViewResult)actual;

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(Album));

            Album album = (Album) viewResult.ViewData.Model;

            Assert.AreEqual(id, album.AlbumId);
            Assert.AreEqual("Ring My Bell", album.Title);
        }

        /// <summary>
        ///A test for Browse
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void BrowseTest()
        {
            StoreController target = new StoreController(); 
            string genre = "Disco"; 

            ActionResult actual;

            actual = target.Browse(genre);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            ViewResult viewResult = (ViewResult)actual;
            Assert.IsNotNull(viewResult.ViewData.Model);
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(StoreBrowseViewModel));

            StoreBrowseViewModel model = (StoreBrowseViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("Disco", model.Genre.Name);
            Assert.AreEqual(3, model.Albums.Count);
        }
    }
}
