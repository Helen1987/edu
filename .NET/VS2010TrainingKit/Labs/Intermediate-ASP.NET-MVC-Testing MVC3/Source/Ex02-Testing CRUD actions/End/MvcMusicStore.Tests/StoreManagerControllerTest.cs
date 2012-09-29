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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MvcMusicStore.Models;
using System.Web.Mvc;
using System.Transactions;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Tests
{
    
    
    /// <summary>
    ///This is a test class for StoreManagerControllerTest and is intended
    ///to contain all StoreManagerControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StoreManagerControllerTest
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
        ///A test for Create
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void CreateTest()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                StoreManagerController target = new StoreManagerController();
                Album album = new Album()
                {
                    GenreId = 1,
                    ArtistId = 1,
                    Title = "New Album",
                    Price = 10,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                };
                ActionResult actual;
                actual = target.Create(album);

                Assert.IsTrue(album.AlbumId != 0);

                MusicStoreEntities storeDB = new MusicStoreEntities();

                var newAlbum = storeDB.Albums.SingleOrDefault(a => a.AlbumId == album.AlbumId);

                Assert.AreEqual(album.GenreId, newAlbum.GenreId);
                Assert.AreEqual(album.ArtistId, newAlbum.ArtistId);
                Assert.AreEqual(album.Title, newAlbum.Title);
                Assert.AreEqual(album.Price, newAlbum.Price);
                Assert.AreEqual(album.AlbumArtUrl, newAlbum.AlbumArtUrl);
            }
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void DeleteTest()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                StoreManagerController target = new StoreManagerController();
                int id = 669;
                ActionResult actual;
                actual = target.Delete(id, null);
                Assert.IsNotNull(actual);

                MusicStoreEntities storeDB = new MusicStoreEntities();

                var album = storeDB.Albums.SingleOrDefault(a => a.AlbumId == id);

                Assert.IsNull(album);
            }
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void EditTest()
        {
            StoreManagerController target = new StoreManagerController();
            int id = 669;
            ActionResult actual;
            actual = target.Edit(id);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            ViewResult viewResult = (ViewResult)actual;

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(StoreManagerViewModel));

            StoreManagerViewModel model = (StoreManagerViewModel)viewResult.ViewData.Model;

            Assert.AreEqual(id, model.Album.AlbumId);
            Assert.AreEqual("Ring My Bell", model.Album.Title);
            Assert.AreEqual(10, model.Genres.Count());
        }
    }
}
