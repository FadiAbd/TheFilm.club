using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheFilm.club.Data;
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
    }
}
