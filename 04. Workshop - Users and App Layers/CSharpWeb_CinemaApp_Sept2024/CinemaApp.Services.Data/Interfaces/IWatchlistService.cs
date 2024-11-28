using CinemaApp.Web.ViewModels.Watchlist;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface IWatchlistService
    {
        Task<IEnumerable<ApplicationUserWatchlistViewModel>> GetUserWatchlistByUserIdAsync(string userId);

        Task<bool> AddMovieToUserWatchListAsync(string? movieId, string userId);

        Task<bool> RemoveMovieFromUserWatchListAsync(string? movieId, string userId);
    }
}
