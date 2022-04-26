using System.ComponentModel.DataAnnotations;

namespace TheFilm.club.ViewModels
{
    public class TheatersEditViewModel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Theater Logo")]
        public string Logo { get; set; }

        [Display(Name = "Theater Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
