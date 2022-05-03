using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFilm.club.Models;

namespace TheFilm.club.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _dbContext;
        public OrdersService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CustomerOrder>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _dbContext.CustomerOrders.Include(n => n.CustomerOrderItems).ThenInclude(n => n.Film).Where(n => n.UserId ==
            userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<BasketItem> items, string userId, string userEmailAddress)
        {
            var order = new CustomerOrder()
            {
                UserId = userId,
                Email = userEmailAddress,
            };
            await _dbContext.CustomerOrders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new CustomerOrderItem()
                {
                    Amount = item.Amount,
                    Film = item.Film,
                    CustomerOrderId = order.Id,
                    Price = item.Film.Price
                };
            }
        }
    }
}
