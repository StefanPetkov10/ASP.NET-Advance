using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync();

        Task<bool> AddMovieAsync(AddMovieFormModel inputModel);
    }
}
