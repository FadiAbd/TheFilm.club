using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheFilm.club.ViewModels
{
    public class ArtistsIndexViewModel
    {
        public List<ArtistViewModel> Artists = new List<ArtistViewModel>();
    }
    public class ArtistViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture")]
        [Required]
        public string Picture { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        [Required]
        public string Biography { get; set; }
    }
}
