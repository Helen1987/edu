using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.ViewModels;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            // Retrieve the list of genres
            var genres = from genre in storeDB.Genres
                         select genre.Name;

            // Create our view model
            var viewModel = new StoreIndexViewModel
            {
                NumberOfGenres = genres.Count(),
                Genres = genres.ToList()
            };

            ViewBag.Starred = new List<string> { "Rock", "Jazz" };

            return View(viewModel);

        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database

            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

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
            var album = storeDB.Albums.Single(a => a.AlbumId == id);

            return View(album);
        }
    }
}
