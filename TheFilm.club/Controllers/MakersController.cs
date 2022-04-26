using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TheFilm.club.Data;
using TheFilm.club.Models;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Controllers
{
    public class MakersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public MakersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var viewModel = new MakersIndexViewModel();
            viewModel.Makers = _dbContext.Makers.Include(n => n.Films)
                .Select(dbPro => new MakerViewModel
                {
                    Id = dbPro.Id,
                    Name = dbPro.Name,
                    Picture = dbPro.Picture,
                    Biography = dbPro.Biography
                }).ToList();
            return View(viewModel);
        }
        //Get/Create
        public IActionResult Create()
        {
            var viewModel = new MakersNewViewModel();

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(MakersNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbPro = new Maker();
                _dbContext.Makers.Add(dbPro);
                dbPro.Name = viewModel.Name;
                dbPro.Picture = viewModel.Picture;
                dbPro.Biography = viewModel.Biography;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
    }
}
