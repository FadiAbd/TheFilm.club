using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheFilm.club.Data.Services;

namespace TheFilm.club.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmsService _service;
        public FilmsController(IFilmsService service)
        {
            _service = service;
        }
        public async Task <IActionResult> Index()
        {
           var allFilms = await _service.GetAllAsync();
            return View(allFilms);
        }
    }
}
