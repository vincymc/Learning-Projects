using GigHubApp.Models;
using GigHubApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace GigHubApp.Controllers
{
    public class GigsController : Controller
    {
        //private object DateTime;
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context=new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var gigs = _context.Attendances.Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
            
            var attendances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.GigId);
            var viewModel = new GigsViewModel()
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Gigs I'm attending",
                Attendances=attendances
            };
            return View("Gigs",viewModel);
        }
        [HttpPost]
        public ActionResult Search(GigsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Gig
                .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCancelled)
                .Include(g => g.Genre)
                .ToList();
            return View(gigs);
        }
        public ActionResult Details(int id)
        {
            var gig = _context.Gig
                .Include(g=>g.Genre)
                .Include(g=>g.Artist)
                .SingleOrDefault(g => g.Id == id);
            if (gig == null)
                return HttpNotFound();
            var viewModel = new GigDetailsViewModel { Gig = gig };
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                viewModel.IsAttending = _context.Attendances
                    .Any(a => a.AttendeeId == userId && a.GigId == gig.Id);
                viewModel.IsFollowing = _context.Followings
                    .Any(f => f.FollowerId == userId && f.FolloweeId == gig.ArtistId);
            }
            return View("Details",viewModel);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormModel()
            {
                Heading = "Add a Gig",
                Genres = _context.Genres.ToList()
            };
            return View("GigsForm",viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("GigsForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime =viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            //var gig2 = new Gig
            //{
            //    ArtistId = User.Identity.GetUserId(),
            //    DateTime = viewModel.GetDateTime(),
            //    GenreId = viewModel.Genre,
            //    Venue = viewModel.Venue
            //};


            //var gigs = new List<Gig>();
            //gigs.Add(gig);
            //gigs.Add(gig2);          

            //_context.Gig.AddRange(gigs);

            //_context.SaveChanges();
            //var testid = gig.Id;
            //var seconfid = gig2.Id;

            //test.testc(gig);

            _context.Gig.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Mine", "Gigs");
        }

        

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gig.Single(g => g.Id == id && g.ArtistId==userId );
            var viewModel = new GigFormModel()
            {
                Heading = "Edit a Gig",
                Id=gig.Id,
                Genres = _context.Genres.ToList(),
                Venue = gig.Venue,
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time=gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId
            };
            return View("GigsForm",viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("GigsForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var gig = _context.Gig
                .Include(g=>g.Attendances.Select(a=>a.Attendee))
                .Single(g => g.Id == viewModel.Id && g.ArtistId == userId);

            gig.Update(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);

            _context.SaveChanges();
            return RedirectToAction("Mine", "Gigs");
        }
    }
}