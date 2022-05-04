using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheFilm.club.Data;
using TheFilm.club.Models;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Controllers
{
    public class TheatersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TheatersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new TheatersIndexViewModel();
            viewModel.Theaters = _dbContext.Theaters
                    .Select(dbCin => new TheaterViewModel
                    {
                        Id = dbCin.Id,
                        Logo = dbCin.Logo,
                        Name = dbCin.Name,
                        Description = dbCin.Description
                    }).ToList();
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var viewModel = new TheatersNewViewModel();

            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(TheatersNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbTheater = new Theater();
                _dbContext.Theaters.Add(dbTheater);
                dbTheater.Name = viewModel.Name;
                dbTheater.Logo = viewModel.Logo;
                dbTheater.Description = viewModel.Description;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var viewModel = new TheatersEditViewModel();
            var dbTheater = _dbContext.Theaters.First(r => r.Id == id);
            viewModel.Logo = dbTheater.Logo;
            viewModel.Name = dbTheater.Name;
            viewModel.Description = dbTheater.Description;

            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, TheatersEditViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var dbCin = _dbContext.Theaters.First(r => r.Id == id);
                dbCin.Logo = viewModel.Logo;
                dbCin.Name = viewModel.Name;
                dbCin.Description = viewModel.Description;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var viewModel = new TheatersDetailsViewModel();
            var dbTheater = _dbContext.Theaters.First(r => r.Id == id);

            viewModel.Logo = dbTheater.Logo;
            viewModel.Name = dbTheater.Name;
            viewModel.Description = dbTheater.Description;


            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {

            var viewModel = new TheaterDeleteViewModel();
            var dbTheater = _dbContext.Theaters.Find(id);
            if (dbTheater == null) return View("NotFoud");
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dbTheater = _dbContext.Theaters.Find(id);
            if (dbTheater == null) return View("NotFound");

            _dbContext.Remove(dbTheater);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
