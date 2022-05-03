using System.Collections.Generic;
using System.Threading.Tasks;
using TheFilm.club.Models;

namespace TheFilm.club.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<BasketItem> items, string userId, string userEmailAddress);
        Task<List<CustomerOrder>> GetOrdersByUserIdAsync(string userId);
    }
}
