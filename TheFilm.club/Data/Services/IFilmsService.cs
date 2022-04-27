using System.Threading.Tasks;
using TheFilm.club.Data.Repository;
using TheFilm.club.Models;

namespace TheFilm.club.Data.Services
{
    public interface IFilmsService:IEntityRepository<Film>
    {
        Task<Film> GetFilmByIdAsync(int id);
    }
}
