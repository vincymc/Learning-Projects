﻿using GigHubApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHubApp.ViewModels
{
    public class GigsViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}