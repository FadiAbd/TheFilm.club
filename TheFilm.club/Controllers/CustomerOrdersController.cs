using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheFilm.club.Data.Basket;
using TheFilm.club.Data.Services;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private readonly IFilmsService _filmsService;
        private readonly Basket _basket;
        private readonly IOrdersService _ordersService;
        public CustomerOrdersController(IFilmsService filmsService, Basket basket, IOrdersService ordersService)
        {
            _filmsService = filmsService;
            _basket = basket;
            _ordersService = ordersService;
        }
        [Authorize]
        public IActionResult Basket()
        {
            var items = _basket.GetBasketItems();
            _basket.BasketItems = items;
            var result = new BasketViewModel()
            {
                Basket = _basket,
                BasketTotal = _basket.GetBasketTotal(),
            };
            return View(result);
        }
        [Authorize]
        public async Task<IActionResult> AddItemToBasket(int id)
        {
            var item =await _filmsService.GetFilmByIdAsync(id);
            if (item != null)
            {
                _basket.AddItemToBasket(item);
            }
            return RedirectToAction(nameof(Basket));
        }
        [Authorize]
        public async Task<IActionResult> RemoveItemFromBasket(int id)
        {
            var item = await _filmsService.GetFilmByIdAsync(id);
            if (item != null)
            {
                _basket.RemoveItemFromBasket(item);
            }
            return RedirectToAction(nameof(Basket));
        }
        [Authorize]
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _basket.GetBasketItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _basket.ClearBasketAsync();
            return View("OrderCompleted");
        }

    }
}
