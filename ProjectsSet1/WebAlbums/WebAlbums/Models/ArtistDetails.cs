using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAlbums.Models
{
    public class ArtistDetails
    {
        [Key]
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public string Bio { get; set; }
        public virtual Artist Artist {get;set;}
    }
}