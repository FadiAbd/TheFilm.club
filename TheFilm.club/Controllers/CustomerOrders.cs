using Microsoft.AspNetCore.Mvc;
using TheFilm.club.Data.Basket;
using TheFilm.club.Data.Services;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Controllers
{
    public class CustomerOrders : Controller
    {
        private readonly IFilmsService _filmsService;
        private readonly Basket _basket;
        public CustomerOrders(IFilmsService filmsService, Basket basket)
        {
            _filmsService = filmsService;
            _basket = basket;
        }
       
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
    }
}
