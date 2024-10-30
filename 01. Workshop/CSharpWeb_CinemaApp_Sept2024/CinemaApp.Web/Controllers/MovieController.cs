using System.Globalization;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Common.EntityValidationConstants.Movie;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly CinemaDbContext dbContext;

        public MovieController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> allMovies = await this.dbContext
                .Movies
                .ToArrayAsync();

            return View(allMovies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieFromModel inputModel)
        {
            // TODO: Add form model + validation
            if (this.ModelState.IsValid == false)
            {
                //Render the same form with user entered values + model errors
                return View(inputModel);
            }

            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate,
                ReleaseDateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime releseDate);

            if (!isReleaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate),
                    "Invalid Release Date. The Release Date must be in the following format: MM/yyyy");
            }

            Movie movie = new Movie
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releseDate,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl
            };

            await this.dbContext.Movies.AddAsync(movie);
            await this.dbContext.SaveChangesAsync();

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

            Movie? movie = await this.dbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == movieGuid);

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
        public async Task<IActionResult> AddToProgram(string id)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidIdValid(id, ref movieGuid);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await this.dbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == movieGuid);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaInputModel viewModel = new AddMovieToCinemaInputModel
            {
                Id = id!,
                MovieTitle = movie.Title,
                Cinemas = await this.dbContext.Cinemas
                .Include(cm => cm.CinemaMovies)
                .ThenInclude(m => m.Movie)
                    .Select(c => new CinemaCheckBoxItemInputModel
                    {
                        Id = c.Id.ToString(),
                        Name = c.Name,
                        Location = c.Location,
                        //IsSelected = false
                        IsSelected = c.CinemaMovies
                        .Any(cm => cm.MovieId == movieGuid)
                    })
                    .ToArrayAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaInputModel model)
        {
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

            Movie? movie = await this.dbContext
                .Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);
            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            ICollection<CinemaMovie> entitiesToAdd = new List<CinemaMovie>();
            foreach (CinemaCheckBoxItemInputModel cinemaInputModel in model.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaGuidValid = this.IsGuidIdValid(cinemaInputModel.Id, ref cinemaGuid);
                if (!isCinemaGuidValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid cinema selected!");
                    return this.View(model);
                }

                Cinema? cinema = await this.dbContext
                    .Cinemas
                    .FirstOrDefaultAsync(c => c.Id == cinemaGuid);
                if (cinema == null)
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid cinema selected!");
                    return this.View(model);
                }

                CinemaMovie? cinemaMovie = await this.dbContext
                    .CinemasMovies
                    .FirstOrDefaultAsync(cm => cm.MovieId == movieGuid &&
                                               cm.CinemaId == cinemaGuid);

                if (cinemaInputModel.IsSelected)
                {
                    if (cinemaMovie == null)
                    {
                        entitiesToAdd.Add(new CinemaMovie()
                        {
                            Cinema = cinema,
                            Movie = movie
                        });
                    }
                    else
                    {
                        cinemaMovie.IsDeleted = false;
                    }
                }
                else
                {
                    if (cinemaMovie != null)
                    {
                        cinemaMovie.IsDeleted = true;
                    }
                }

                await this.dbContext.SaveChangesAsync();
            }

            await this.dbContext.CinemasMovies.AddRangeAsync(entitiesToAdd);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index), "Cinema");
        }
    }
}
