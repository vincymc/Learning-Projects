using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAlbums.Models;
using WebAlbums.Models.Repositories;


namespace WebAlbums.Controllers
{
    public class ArtistsController : Controller
    {
       // MusicStoreContext context = new MusicStoreContext();
       ArtistRepository repository= new ArtistRepository();
        public ActionResult Details(int Id)
        {
            Artist artist = repository.Get(Id);
            if (artist == null) return HttpNotFound();
            return View(artist);
        }
        // GET: Artists
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            repository.Add(artist);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}