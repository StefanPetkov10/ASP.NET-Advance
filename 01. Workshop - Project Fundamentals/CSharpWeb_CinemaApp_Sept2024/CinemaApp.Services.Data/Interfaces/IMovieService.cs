using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync();

        Task<bool> AddMovieAsync(AddMovieFormModel inputModel);

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(Guid id);

        Task<AddMovieToCinemaInputModel?> AddMovieToCinemaInputModelByIdAsync(Guid id);

        Task<bool> AddMovieToCinemasAsync(Guid movieId, AddMovieToCinemaInputModel model);
    }
}
