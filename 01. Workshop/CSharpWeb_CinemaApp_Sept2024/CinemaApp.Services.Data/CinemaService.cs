using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Data
{
    public class CinemaService : ICinemaService
    {
        private IRepository<Cinema, Guid> cinemaRepository;

        public CinemaService(IRepository<Cinema, Guid> cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public async Task AddCinemaAsync(AddCinemaFormModel model)
        {
            Cinema cinema = new Cinema();
            AutoMapperConfig.MapperInstance.Map(model, cinema);

            await this.cinemaRepository.AddAsync(cinema);
        }

        public async Task<CinemaDetailsViewModel?> GetCinemaDetailsByIdAsync(Guid id)
        {
            Cinema? cinema = await this.cinemaRepository
               .GetAllAttached()
               .Include(cm => cm.CinemaMovies)
               .ThenInclude(m => m.Movie)
               .FirstOrDefaultAsync(c => c.Id == id);

            // Invalid(non-existing) GUID in the URL
            CinemaDetailsViewModel? viewModel = null;
            if (cinema != null)
            {
                viewModel = new CinemaDetailsViewModel
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

                //AutoMapperConfig.MapperInstance.Map(cinema, viewModel);
            }

            return viewModel;

        }

        public async Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByLocationAsync()
        {
            IEnumerable<CinemaIndexViewModel> allCinemas = await this.cinemaRepository
               .GetAllAttached()
               .OrderBy(c => c.Location)
               .To<CinemaIndexViewModel>()
               .ToArrayAsync();

            return allCinemas;
        }
    }
}
