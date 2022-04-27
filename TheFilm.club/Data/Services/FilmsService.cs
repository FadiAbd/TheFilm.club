using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TheFilm.club.Data.Repository;
using TheFilm.club.Models;

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
    }
}
