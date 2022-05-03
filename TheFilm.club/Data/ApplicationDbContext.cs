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
            modelBuilder.Entity<Artist_Film>().HasKey(af => new
            {
                af.ArtistId,
                af.FilmId
            });

            modelBuilder.Entity<Artist_Film>().HasOne(f => f.Film).WithMany(af => af.Artists_Films).HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<Artist_Film>().HasOne(f => f.Artist).WithMany(af => af.Artists_Films).HasForeignKey(f => f.ArtistId);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Artist_Film> Artists_Films { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders{ get; set; }
        public DbSet<CustomerOrderItem> CustomerOrderItems { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
       



    }
}
