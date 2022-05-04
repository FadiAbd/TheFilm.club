using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TheFilm.club.Models;

namespace TheFilm.club.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedRoles(dbContext);
            SeedUsers(userManager);
        }
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            AddUserIfNotExists(userManager, "admin@mail.com", "Hejsan123#", new string[] { "Admin"});
            AddUserIfNotExists(userManager, "user@mail.com", "Hejsan123#", new string[] { "User" });


        }
        private static void AddUserIfNotExists(UserManager<IdentityUser> userManager, string userName, string password, string[] roles)
        {
            if (userManager.FindByEmailAsync(userName).Result != null) return;
            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(user, password).Result;
            var r = userManager.AddToRolesAsync(user, roles).Result;

        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
            {
                dbContext.Roles.Add(new IdentityRole { Name = "Admin" , NormalizedName = "Admin" });
              
            }
             role = dbContext.Roles.FirstOrDefault(r => r.Name == "User");
            if (role == null)
            {
                dbContext.Roles.Add(new IdentityRole { Name = "User", NormalizedName = "User" });
               
            }
            dbContext.SaveChanges();
        }

       
    }
}
