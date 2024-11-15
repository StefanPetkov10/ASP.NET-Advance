using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService, IManagerService managerService)
            : base(managerService)
        {

            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllMoviesViewModel> allMovies =
                await this.movieService.GetAllMoviesAsync();

            return View(allMovies);
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
        public async Task<IActionResult> Create(AddMovieFormModel inputModel)
        {
            bool isUserManager = await this.IsUserManagerAsync();
            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            // TODO: Add form model + validation
            if (this.ModelState.IsValid == false)
            {
                //Render the same form with user entered values + model errors
                return View(inputModel);
            }

            bool result = await this.movieService.AddMovieAsync(inputModel);

            if (result == false)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate),
                    "Invalid Release Date. The Release Date must be in the following format: MM/yyyy");
                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidIdValid(id, ref movieGuid);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            MovieDetailsViewModel? movie =
                await this.movieService.GetMovieDetailsByIdAsync(movieGuid);

            if (movie == null)
            {
                //Non-existing movie guid
                return RedirectToAction(nameof(Index));
            }

            //if(!this.dbContext.Movies.Any(x => x.Id == guidId))
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            return View(movie);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToProgram(string id)
        {
            bool isUserManager = await this.IsUserManagerAsync();
            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidIdValid(id, ref movieGuid);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaInputModel? viewModel =
                 await this.movieService.AddMovieToCinemaInputModelByIdAsync(movieGuid);

            if (viewModel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaInputModel model)
        {
            bool isUserManager = await this.IsUserManagerAsync();
            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidIdValid(model.Id, ref movieGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool result = await this.movieService
                .AddMovieToCinemasAsync(movieGuid, model);

            if (result == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index), "Cinema");
        }
    }
}
