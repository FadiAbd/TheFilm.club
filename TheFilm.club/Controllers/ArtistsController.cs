using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheFilm.club.Data;
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
    }
}
