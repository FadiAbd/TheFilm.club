using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheFilm.club.Models;

namespace TheFilm.club.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Film>().HasKey(am => new
            {
                am.ArtistId,
                am.FilmId
            });

            modelBuilder.Entity<Artist_Film>().HasOne(m => m.Film).WithMany(am => am.Artist_Films).HasForeignKey(m => m.FilmId);
            modelBuilder.Entity<Artist_Film>().HasOne(m => m.Artist).WithMany(am => am.Artist_Films).HasForeignKey(m => m.ArtistId);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Artist_Film> Artist_Films { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Maker> Makers { get; set; }
    }
}
