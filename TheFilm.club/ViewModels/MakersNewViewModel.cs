using System.ComponentModel.DataAnnotations;

namespace TheFilm.club.ViewModels
{
    public class MakersNewViewModel
    {
        public string Picture { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Biography")]
        [Required]
        public string Biography { get; set; }
    }
}
