using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheFilm.club.Models
{
    public class Theater
    {

        [Key]
        public int Id { get; set; }
        [Display(Name ="Theater Logo" )]
        public string Logo { get; set; }
        [Display(Name = "Theater Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<Film> Films { get; set; }
    }
}
