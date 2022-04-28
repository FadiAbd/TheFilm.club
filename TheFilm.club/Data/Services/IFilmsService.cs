using System.Threading.Tasks;
using TheFilm.club.Data.Repository;
using TheFilm.club.Models;
using TheFilm.club.ViewModels;

namespace TheFilm.club.Data.Services
{
    public interface IFilmsService:IEntityRepository<Film>
    {
        Task<Film> GetFilmByIdAsync(int id);
        Task<FilmsViewModel> NewFilmValues();
        Task AddNewFilmAsync(FilmsNewViewModel viewModel);
        Task UpdateFilmAsync(FilmsNewViewModel viewModel);
    }
}
