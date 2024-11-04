using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly ICinemaService cinemaService;
        public CinemaController(ICinemaService cinemaService)
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
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCinemaFormModel inputModel)
        {
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
    }
}
