using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static CinemaApp.Common.ErrorMessages.Watchlist;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService watchlistService;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(IWatchlistService watchlistService, UserManager<ApplicationUser> userManager)
        {
            this.watchlistService = watchlistService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = this.userManager.GetUserId(this.User)!;
            if (String.IsNullOrEmpty(userId))
            {
                return RedirectToAction("/Identity/Account/Login");
            }

            IEnumerable<ApplicationUserWatchlistViewModel> watchlist =
                await this.watchlistService.GetUserWatchlistByUserIdAsync(userId);

            return this.View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(this.User)!;
            if (String.IsNullOrEmpty(userId))
            {
                return RedirectToAction("/Identity/Account/Login");
            }

            bool result = await this.watchlistService
                .AddMovieToUserWatchListAsync(movieId, userId);
            if (!result)
            {
                //TODO: Imolement a way to transfer the Error Message to the View
                ViewData["ErrorMessage"] = AddToWatchlistNotSuccessfulMessage;
                return this.RedirectToAction("Index", "Movie");
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(this.User)!;
            if (String.IsNullOrEmpty(userId))
            {
                return RedirectToAction("/Identity/Account/Login");
            }

            bool result = await this.watchlistService
                .RemoveMovieFromUserWatchListAsync(movieId, userId);

            if (!result)
            {
                //TODO: Imolement a way to transfer the Error Message to the View
                return this.RedirectToAction("Index", "Movie");
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
