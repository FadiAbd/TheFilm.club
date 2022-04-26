using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheFilm.club.ViewModels
{
    public class MakersIndexViewModel
    {
        public List<MakerViewModel> Makers = new List<MakerViewModel>();
    }

    public class MakerViewModel
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
