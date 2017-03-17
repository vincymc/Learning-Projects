using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAlbums.Models
{
    public class Reviewer
    {
        public int ReviewerID { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}