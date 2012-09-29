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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore.ViewModels;
using MvcMusicStore.Models;
using MvcMusicStore.Services;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private IStoreService service;

        public StoreController(IStoreService service)
        {
            this.service = service;
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            // Create list of genres
            var genres = this.service.GetGenreNames();

            // Create your view model
            var viewModel = new StoreIndexViewModel
            {
                Genres = genres.ToList(),
                NumberOfGenres = genres.Count()
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            var genreModel = this.service.GetGenreByName(genre);

            var viewModel = new StoreBrowseViewModel()
            {
                Genre = genreModel,
                Albums = genreModel.Albums.ToList()
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = this.service.GetAlbum(id);

            return View(album);
        }
    }
}
