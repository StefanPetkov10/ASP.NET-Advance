using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly ICinemaService cinemaService;
        public CinemaController(ICinemaService cinemaService, IManagerService managerService)
            : base(managerService)
        {
            this.cinemaService = cinemaService;
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
            bool isUserManager = await this.IsUserManagerAsync();
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
            bool isUserManager = await this.IsUserManagerAsync();
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
            bool isUserManager = await this.IsUserManagerAsync();
            if (!isUserManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<CinemaIndexViewModel> cinemas =
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();

            return this.View(cinemas);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isUserManager = await this.IsUserManagerAsync();
            if (!isUserManager)
            {
                //TODO: Implement notification for error and warning messages
                return this.RedirectToAction(nameof(Index));
            }

            Guid cinemaGuid = Guid.Empty;
            bool isIdValid = this.IsGuidIdValid(id, ref cinemaGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            EditCinemaFormModel? cinemaModel = await this.cinemaService
                .GetCinemaForByIdAsync(cinemaGuid);

            return this.View(cinemaModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditCinemaFormModel formModel)
        {
            bool isUserManager = await this.IsUserManagerAsync();
            if (!isUserManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isUpdated = await this.cinemaService
                .EditCinemaAsync(formModel);

            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the cinema! Please contact admin!");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), "Cinema", new { id = formModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid cinemaGuid = Guid.Empty;
            if (!this.IsGuidIdValid(id, ref cinemaGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteCinemaViewModel? cinemaToDeleteViewModel =
                await this.cinemaService.GetCinemaForDeleteByIdAsync(cinemaGuid);
            if (cinemaToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(cinemaToDeleteViewModel);
        }
    }
}
