﻿using GigHubApp.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHubApp.Controllers
{
    public class FolloweesController : Controller
    {
        // GET: Followee

        private ApplicationDbContext _context;
        public FolloweesController()
        {
            _context=new ApplicationDbContext();
        }
           [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
            
            return View(artists);
        }
    }
    }

