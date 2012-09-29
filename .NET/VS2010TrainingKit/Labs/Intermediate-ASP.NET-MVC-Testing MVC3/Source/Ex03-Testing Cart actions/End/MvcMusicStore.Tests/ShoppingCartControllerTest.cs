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
using System.Web.Mvc;
using MvcMusicStore.Models;
using System.Collections.Generic;
using System.Transactions;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Tests
{
    
    
    /// <summary>
    ///This is a test class for ShoppingCartControllerTest and is intended
    ///to contain all ShoppingCartControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShoppingCartControllerTest
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
            using (TransactionScope ts = new TransactionScope())
            {
                Album album1 = this.GetAlbum(669);
                Album album2 = this.GetAlbum(668);

                ICartIdProvider provider = new TestCartIdProvider();
                ShoppingCart cart = ShoppingCart.GetCart(provider);

                cart.AddToCart(album1);
                cart.AddToCart(album2);
                cart.AddToCart(album2);

                ShoppingCartController target = new ShoppingCartController(provider);
                ActionResult actual;
                actual = target.Index();

                Assert.IsNotNull(actual);
                Assert.IsInstanceOfType(actual, typeof(ViewResult));

                ViewResult viewResult = (ViewResult)actual;

                Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ShoppingCartViewModel));

                ShoppingCartViewModel model = (ShoppingCartViewModel)viewResult.ViewData.Model;

                Assert.AreEqual(2, model.CartItems.Count);
                Assert.AreEqual(3, model.CartItems.Sum(it => it.Count));
            }
        }

        /// <summary>
        ///A test for AddToCart
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void AddToCartTest()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ICartIdProvider provider = new TestCartIdProvider();
                ShoppingCartController target = new ShoppingCartController(provider);
                int id = 669;
                ActionResult actual;
                actual = target.AddToCart(id);

                Assert.IsNotNull(actual);

                ShoppingCart cart = ShoppingCart.GetCart(provider);

                List<Cart> items = cart.GetCartItems();

                Assert.IsNotNull(items);
                Assert.AreEqual(1, items.Count);
                Assert.AreEqual(id, items[0].AlbumId);
                Assert.AreEqual(1, items[0].Count);
            }
        }

        /// <summary>
        ///A test for RemoveFromCart
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MvcMusicStore.mdf")]
        [DeploymentItem("MvcMusicStore_log.ldf")]
        public void RemoveFromCartTest()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                Album album1 = this.GetAlbum(669);
                Album album2 = this.GetAlbum(668);

                ICartIdProvider provider = new TestCartIdProvider();
                ShoppingCart cart = ShoppingCart.GetCart(provider);

                cart.AddToCart(album1);
                cart.AddToCart(album2);
                cart.AddToCart(album2);

                ShoppingCartController target = new ShoppingCartController(provider);
                int id = cart.GetCartItems().First().RecordId;
                ActionResult actual;
                actual = target.RemoveFromCart(id);

                Assert.IsNotNull(actual);
                Assert.IsInstanceOfType(actual, typeof(JsonResult));

                JsonResult jsonResult = (JsonResult)actual;

                Assert.IsInstanceOfType(jsonResult.Data, typeof(ShoppingCartRemoveViewModel));

                ShoppingCartRemoveViewModel model = (ShoppingCartRemoveViewModel)jsonResult.Data;

                Assert.AreEqual(2, model.CartCount);
                Assert.AreEqual(id, model.DeleteId);
            }
        }

        private Album GetAlbum(int id)
        {
            MusicStoreEntities storeDB = new MusicStoreEntities();
            return storeDB.Albums.Single(a => a.AlbumId == id);
        }
    }
}
