using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAlbums.Models.Repositories
{
    public class ArtistRepository: Repository<Artist>
    {
        public List<Artist> GetByName(string name)
        {
            return DataSet.Where(a => a.Name.Contains(name)).ToList();
        }
        public List<SoloArtist> GetSoloArtists()
        {
            return DataSet.OfType<SoloArtist>().ToList();
        }
    }
}