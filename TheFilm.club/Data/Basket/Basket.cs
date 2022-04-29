using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TheFilm.club.Models;

namespace TheFilm.club.Data.Basket
{
    public class Basket
    {
        public ApplicationDbContext _dbContext { get; set; }
        public string BasketId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public Basket(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public List<BasketItem> GetBasketItems()
        {
            return BasketItems ?? (BasketItems = _dbContext.BasketItems.Where(n => n.BasketId ==
            BasketId).Include(n => n.Film).ToList());
        }

        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var dbContext = services.GetService<ApplicationDbContext>();

            string basketId = session.GetString("BasketId") ?? Guid.NewGuid().ToString();
            session.SetString("BasketId", basketId);
            return new Basket(dbContext)
            {
                BasketId = basketId,
            };
        }

        public void AddItemToBasket(Film film)
        {
            var basketItem = _dbContext.BasketItems.FirstOrDefault(n => n.Film.Id == film.Id && n.BasketId == BasketId);

            if (basketItem == null)
            {
                basketItem = new BasketItem()
                {
                    BasketId = BasketId,
                    Film = film,
                    Amount = 1
                };
                _dbContext.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.Amount++; 
            }
            _dbContext.SaveChanges();
        }

        public void RemoveItemFromBasket(Film film)
        {
            var basketItem = _dbContext.BasketItems.FirstOrDefault(n => n.Film.Id == film.Id && n.BasketId == BasketId);

            if (basketItem != null)
            {
                if (basketItem.Amount > 1)
                {
                    basketItem.Amount--;
                }
                else
                {
                    _dbContext.BasketItems.Remove(basketItem);
                }
               
            }
            _dbContext.SaveChanges();
        }
        public double GetBasketTotal() => _dbContext.BasketItems.Where(n => n.BasketId ==
        BasketId).Select(n => n.Film.Price * n.Amount).Sum();



    }
}
