using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheFilm.club.Models
{
    public class Artist_Film
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

    }
}
