using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TheFilm.club.Data.Repository;
using TheFilm.club.Models;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Data.Services
{
    public class FilmsService : EntityRepository<Film>, IFilmsService
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmsService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddNewFilmAsync(FilmsNewViewModel viewModel)
        {
            var newFilm = new Film()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Poster = viewModel.Poster,
                TheaterId = viewModel.TheaterId,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                FilmCategory = viewModel.FilmCategory,
                MakerId = viewModel.MakerId
            };
            await _dbContext.Films.AddAsync(newFilm);
            await _dbContext.SaveChangesAsync();

            foreach (var artistId in viewModel.ArtistIds)
            {
                var newArtistFilm = new Artist_Film()
                {
                   ArtistId = artistId,
                   FilmId = newFilm.Id
                };
                await _dbContext.Artists_Films.AddAsync(newArtistFilm);
            }
            await _dbContext.SaveChangesAsync();
        }

    

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            var filmDetails = _dbContext.Films
                .Include(t => t.Theater)
                .Include(m => m.Maker)
                .Include(af => af.Artists_Films).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await filmDetails;

        }

        public async Task<FilmsViewModel> NewFilmValues()
        {
            var respons = new FilmsViewModel()
            {
                Artists = await _dbContext.Artists.OrderBy(n => n.Name).ToListAsync(),
                Theaters = await _dbContext.Theaters.OrderBy(n => n.Name).ToListAsync(),
                Makers = await _dbContext.Makers.OrderBy(n => n.Name).ToListAsync()
        };
            return respons;
        }

        public async Task UpdateFilmAsync(FilmsNewViewModel viewModel)
        {
            var dbFilm = await _dbContext.Films.FirstOrDefaultAsync(n => n.Id == viewModel.Id);
             if (dbFilm != null)
             {


                dbFilm.Name = viewModel.Name;
                dbFilm.Description = viewModel.Description;
                dbFilm.Price = viewModel.Price;
                dbFilm.Poster = viewModel.Poster;
                dbFilm.TheaterId = viewModel.TheaterId;
                dbFilm.StartDate = viewModel.StartDate;
                dbFilm.EndDate = viewModel.EndDate;
                dbFilm.FilmCategory = viewModel.FilmCategory;
                dbFilm.MakerId = viewModel.MakerId;
                await _dbContext.SaveChangesAsync();
             }
             // Remove artists
             var ArtistsDb = _dbContext.Artists_Films.Where(n => n.FilmId == viewModel.Id).ToList();
             _dbContext.Artists_Films.RemoveRange(ArtistsDb);
             await _dbContext.SaveChangesAsync();
             //Add Film Artist
            foreach (var artistId in viewModel.ArtistIds)
            {
                var newArtistFilm = new Artist_Film()
                {
                    ArtistId = artistId,
                    FilmId = viewModel.Id
                };
                await _dbContext.Artists_Films.AddAsync(newArtistFilm);
            }
            await _dbContext.SaveChangesAsync();
        }

    }
}

      
            
        
    
