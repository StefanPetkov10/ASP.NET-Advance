using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.Infrastructure.Extensions;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly ICinemaService cinemaService;
        private readonly IManagerService managerService;
        public CinemaController(ICinemaService cinemaService, IManagerService userManager)
        {
            this.cinemaService = cinemaService;
            this.managerService = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> allCinemas =
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();

            return View(allCinemas);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.managerService.IsUserManagerAsync(userId);
            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddCinemaFormModel inputModel)
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.managerService.IsUserManagerAsync(userId);
            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            if (this.ModelState.IsValid == false)
            {
                return View(inputModel);
            }

            await this.cinemaService.AddCinemaAsync(inputModel);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid cinemaGuid = Guid.Empty;
            bool isIdValid = this.IsGuidIdValid(id, ref cinemaGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel? viewModel = await this.cinemaService
                .GetCinemaDetailsByIdAsync(cinemaGuid);

            // Invalid(non-existing) GUID in the URL
            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            string userId = this.User.GetUserId();
            bool isManager = await this.managerService
                 .IsUserManagerAsync(userId);

            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<CinemaIndexViewModel> cinemas =
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();

            return this.View(cinemas);
        }
    }
}
