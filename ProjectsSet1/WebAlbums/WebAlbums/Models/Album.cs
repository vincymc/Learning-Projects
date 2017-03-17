using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebAlbums.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        [Required]
        [StringLength (100,MinimumLength =2)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<Reviewer> Reviewers { get; set; }
    }
   
}