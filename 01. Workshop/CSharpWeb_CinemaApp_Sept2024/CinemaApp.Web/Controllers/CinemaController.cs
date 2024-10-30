using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly CinemaDbContext dbContext;
        public CinemaController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> allCinemas = await this.dbContext
               .Cinemas
               .Select(c => new CinemaIndexViewModel()
               {
                   Id = c.Id.ToString(),
                   Name = c.Name,
                   Location = c.Location
               })
               .OrderBy(c => c.Location)
               .ToArrayAsync();

            return View(allCinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCinemaFromModel inputModel)
        {
            if (this.ModelState.IsValid == false)
            {
                return View(inputModel);
            }

            Cinema cinema = new Cinema
            {
                Name = inputModel.Name,
                Location = inputModel.Location
            };

            await this.dbContext.Cinemas.AddAsync(cinema);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid cinemaGuidId = Guid.Empty;
            bool IsCinemaIdValid = this.IsGuidIdValid(id, ref cinemaGuidId);

            if (!IsCinemaIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Cinema? cinema = await this.dbContext.Cinemas
               .Include(cm => cm.CinemaMovies)
               .ThenInclude(m => m.Movie)
               .FirstOrDefaultAsync(c => c.Id == cinemaGuidId);

            // Invalid(non-existing) GUID in the URL
            if (cinema == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel
            {
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies
                    .Where(cm => cm.IsDeleted == false)
                    .Select(cm => new CinemaMovieViewModel
                    {
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration
                    })
                    .ToArray()
            };

            return this.View(cinemaDetailsViewModel);
        }
    }
}
