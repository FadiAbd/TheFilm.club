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
        //Get/Edit
        public IActionResult Edit(int id)
        {
            var viewModel = new MakersEditViewModel();
            var dbPro = _dbContext.Makers.First(r => r.Id == id);
            viewModel.Picture = dbPro.Picture;
            viewModel.Name = dbPro.Name;
            viewModel.Biography = dbPro.Biography;

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, MakersEditViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var dbPro = _dbContext.Makers.First(r => r.Id == id);
                dbPro.Picture = viewModel.Picture;
                dbPro.Name = viewModel.Name;
                dbPro.Biography = viewModel.Biography;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = new MakersDetailsViewModel();
            var dbAct = _dbContext.Makers.First(r => r.Id == id);

            viewModel.Picture = dbAct.Picture;
            viewModel.Name = dbAct.Name;
            viewModel.Biography = dbAct.Biography;


            return View(viewModel);
        }
    }
}
