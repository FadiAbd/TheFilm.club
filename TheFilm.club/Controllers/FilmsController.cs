using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           var allFilms = await _service.GetAllAsync(n => n.Theater);
            return View(allFilms);
        }
        //Get/Films/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var filmDetail = await _service.GetFilmByIdAsync(id);
            return View(filmDetail);
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = await _service.GetNewFilmValues();
            ViewBag.Theaters = new SelectList(viewModel.Theaters,"Id","Name");
            ViewBag.Makers = new SelectList(viewModel.Theaters, "Id", "Name");
            ViewBag.Artists = new SelectList(viewModel.Theaters, "Id", "Name");
            return View();
        }
    }
}
