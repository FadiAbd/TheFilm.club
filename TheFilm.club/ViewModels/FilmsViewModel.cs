using System.Collections.Generic;
using TheFilm.club.Models;

namespace TheFilm.club.ViewModels
{
    public class FilmsViewModel
    {
        public FilmsViewModel()
        {
           Makers = new List<Maker>();
           Theaters = new List<Theater>();
           Artists = new List<Artist>();
        }
        
        public List<Maker> Makers { get; set; }
        public List<Theater>Theaters { get; set; }
        public List<Artist> Artists { get; set; }

    }
}
