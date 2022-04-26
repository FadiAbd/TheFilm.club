using TheFilm.club.Data.Repository;
using TheFilm.club.Models;

namespace TheFilm.club.Data.Services
{
    public class FilmsService : EntityRepository<Film>, IFilmsService
    {
        public FilmsService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
