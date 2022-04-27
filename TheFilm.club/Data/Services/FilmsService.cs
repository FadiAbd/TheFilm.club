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

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            var filmDetails = _dbContext.Films
                .Include(t => t.Theater)
                .Include(m => m.Maker)
                .Include(af => af.Artists_Films).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await filmDetails;

        }

        public async Task<FilmsViewModel> GetNewFilmValues()
        {
            var respons = new FilmsViewModel()
            {
                Artists = await _dbContext.Artists.OrderBy(n => n.Name).ToListAsync(),
                Theaters = await _dbContext.Theaters.OrderBy(n => n.Name).ToListAsync(),
                Makers = await _dbContext.Makers.OrderBy(n => n.Name).ToListAsync()
        };
            return respons;
        }

       
    }
}
      
            
        
    
