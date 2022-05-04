using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using TheFilm.club.Data.Services;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmsService _service;
        public FilmsController(IFilmsService service)
        {
            _service = service;
        }
        [Authorize]
        public async Task <IActionResult> Index()
        {
           var allFilms = await _service.GetAllAsync(n => n.Theater);
            return View(allFilms);
        }
        [Authorize]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allFilms = await _service.GetAllAsync(n => n.Theater);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allFilms.Where(n => n.Name.Contains(searchString) || n.Description.Contains
                (searchString)).ToList();
                return View("Index", filterResult);
            }
            return View("Index",allFilms);
        }
        [Authorize]
        //Get/Films/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var filmDetail = await _service.GetFilmByIdAsync(id);
            return View(filmDetail);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var viewModel = await _service.NewFilmValues();
            ViewBag.Theaters = new SelectList(viewModel.Theaters,"Id","Name");
            ViewBag.Makers = new SelectList(viewModel.Theaters, "Id", "Name");
            ViewBag.Artists = new SelectList(viewModel.Theaters, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(FilmsNewViewModel film)
        {
            if (!ModelState.IsValid)
            {
                var filmsViewModel = await _service.NewFilmValues();
                ViewBag.Cinemas = new SelectList(filmsViewModel.Theaters, "Id", "Name");
                ViewBag.Producers = new SelectList(filmsViewModel.Makers, "Id", "Name");
                ViewBag.Actors = new SelectList(filmsViewModel.Artists, "Id", "Name");
                return View(film);
            }
            await _service.AddNewFilmAsync(film);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var filmDetails = await _service.GetFilmByIdAsync(id);
            if (filmDetails == null) return View("NotFound");
                var result = new FilmsNewViewModel()
                {
                    Id = filmDetails.Id,
                    Name = filmDetails.Name,
                    Description = filmDetails.Description,
                    Price = filmDetails.Price,
                    StartDate = filmDetails.StartDate,
                    EndDate = filmDetails.EndDate,  
                    Poster = filmDetails.Poster,
                    FilmCategory = filmDetails.FilmCategory,
                    TheaterId = filmDetails.TheaterId,
                    MakerId = filmDetails.MakerId,
                    ArtistIds = filmDetails.Artists_Films.Select(n => n.ArtistId).ToList(),

                };
               
            
            var filmsViewModel = await _service.NewFilmValues();
            ViewBag.Theaters = new SelectList(filmsViewModel.Theaters, "Id", "Name");
            ViewBag.Makers = new SelectList(filmsViewModel.Makers, "Id", "Name");
            ViewBag.Artists = new SelectList(filmsViewModel.Artists, "Id", "Name");
            
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id,FilmsNewViewModel film)
        {
            if (id != film.Id) return View("NotFound");
            
            if (!ModelState.IsValid)
            {
                var filmsViewModel = await _service.NewFilmValues();
                ViewBag.Cinemas = new SelectList(filmsViewModel.Theaters, "Id", "Name");
                ViewBag.Producers = new SelectList(filmsViewModel.Makers, "Id", "Name");
                ViewBag.Actors = new SelectList(filmsViewModel.Artists, "Id", "Name");
                return View(film);
            }
            await _service.UpdateFilmAsync(film);
           
            return RedirectToAction(nameof(Index));
        }
    }
}
