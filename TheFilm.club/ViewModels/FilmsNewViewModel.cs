using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheFilm.club.Models;

namespace TheFilm.club.ViewModels
{
    public class FilmsNewViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Film name")]
        [Required(ErrorMessage ="Name is required!")]
        public string Name { get; set; }

        [Display(Name ="Film Description")]
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Display(Name = "Film price in $")]
        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; }

        [Display(Name = "Film Poster")]
        [Required(ErrorMessage = "The Poster is required!")]
        public string Poster { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required!")]

        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is required!")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Film Category is required!")]
        public FilmCategory FilmCategory { get; set; }

        [Display(Name = "Select artist(s)")]
        [Required(ErrorMessage = "artist(s) is required!")]
        public List<int> ArtistIds { get; set; }

        [Display(Name = "Select theater(s)")]
        [Required(ErrorMessage = "theater(s) is required!")]
        public int TheaterId { get; set; }

        [Display(Name = "Select maker(s)")]
        [Required(ErrorMessage = "maker(s) is required!")]
        public int MakerId { get; set; }

      
    }
}
