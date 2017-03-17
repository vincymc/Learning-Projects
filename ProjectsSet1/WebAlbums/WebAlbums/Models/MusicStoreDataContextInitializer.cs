using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAlbums.Models
{
    public class MusicStoreDataContextInitializer:DropCreateDatabaseAlways<MusicStoreDataContext>
    {
        protected override void Seed(MusicStoreDataContext context)
        {
            Artist artist = new Artist() { Name = "Rasmi" };
            context.Artists.Add(artist);
            context.Albums.Add(new Album { Artist = artist, Title = "Album1", Price = 9.87m });
            context.Albums.Add(new Album { Artist = artist, Title = "Album2", Price = 9.34m });
            context.Artists.Add(new Artist { Name = "Prajakta" });
            context.Artists.Add(new SoloArtist { Name = "Sruthy", Instrument = "Piano" });
            context.SaveChanges();
        }
    }
}