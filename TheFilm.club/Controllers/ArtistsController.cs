using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheFilm.club.Data;
using TheFilm.club.Models;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ArtistsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new ArtistsIndexViewModel();
            viewModel.Artists = _dbContext.Artists
                .Select(dbArt => new ArtistViewModel
                {
                    Id = dbArt.Id,
                    Name = dbArt.Name,
                    Picture = dbArt.Picture,
                    Biography = dbArt.Biography
                }).ToList();
            return View(viewModel);
        }
        [Authorize(Roles="Admin")]
        //Get
        public IActionResult Create()
        {
            var viewModel = new ArtistsNewViewModel();

            return View(viewModel);
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public IActionResult Create(ArtistsNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbAct = new Artist();
                _dbContext.Artists.Add(dbAct);
                dbAct.Name = viewModel.Name;
                dbAct.Picture = viewModel.Picture;
                dbAct.Biography = viewModel.Biography;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        //Get/Edit
        public IActionResult Edit(int id)
        {
            var viewModel = new ArtistsEditViewModel();
            var dbAct = _dbContext.Artists.First(r => r.Id == id);
            viewModel.Picture = dbAct.Picture;
            viewModel.Name = dbAct.Name;
            viewModel.Biography = dbAct.Biography;

            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(int id, ArtistsEditViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var dbAct = _dbContext.Artists.First(r => r.Id == id);
                dbAct.Picture = viewModel.Picture;
                dbAct.Name = viewModel.Name;
                dbAct.Biography = viewModel.Biography;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize]
        //Get/Details
        public IActionResult Details(int id)
        {
            var viewModel = new ArtistsDetailsViewModel();
            var dbAct = _dbContext.Artists.First(r => r.Id == id);
            viewModel.Picture = dbAct.Picture;
            viewModel.Name = dbAct.Name;
            viewModel.Biography = dbAct.Biography;

            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        //Get/Delete/Id
        public ActionResult Delete(int id)
        {
            var viewModel = new ArtistsDeleteViewModel();
            var dbAct = _dbContext.Artists.Find(id);
            if (dbAct == null) return View("NotFound");
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dbDel = _dbContext.Artists.Find(id);
            if (dbDel == null) return View("NotFound");

            _dbContext.Remove(dbDel);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
