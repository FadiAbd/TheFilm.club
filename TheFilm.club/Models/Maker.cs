using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TheFilm.club.Models
{
    public class Maker
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string Picture { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50 , MinimumLength = 3, ErrorMessage ="Full Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Biography { get; set; }

        public List<Film> Films { get; set; }
    }
}
