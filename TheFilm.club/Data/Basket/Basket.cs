using Microsoft.EntityFrameworkCore;
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

        public double GetBasketTotal() => _dbContext.BasketItems.Where(n => n.BasketId ==
        BasketId).Select(n => n.Film.Price * n.Amount).Sum();

    }
}
