using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TheFilm.club.Data.Repository;

namespace TheFilm.club.Models
{
    public class Film : IEntity
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime  EndDate{ get; set; }
        public FilmCategory FilmCategory { get; set; }
        //Relationships
        public List<Artist_Film> Artist_Films { get; set; }
        //Theater
        public int TheaterId { get; set; }

        [ForeignKey("TheaterId")]
        public Theater Theater { get; set; }

        //Maker
        public int MakerId { get; set; }

        [ForeignKey("MakerId")]
        public Maker Maker { get; set; }
    }
}
