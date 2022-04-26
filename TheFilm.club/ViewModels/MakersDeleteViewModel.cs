using System.ComponentModel.DataAnnotations;

namespace TheFilm.club.ViewModels
{
    public class MakersDeleteViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Picture")]
        [Required(ErrorMessage = " Picture is required")]
        public string Picture { get; set; }

        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Biography { get; set; }
    }
}
