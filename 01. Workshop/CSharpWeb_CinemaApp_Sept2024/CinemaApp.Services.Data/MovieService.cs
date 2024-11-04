using System.Globalization;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Services.Data
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie, Guid> movieRepository;

        public MovieService(IRepository<Movie, Guid> movieRepository)
        {
            this.movieRepository = movieRepository;
        }


        public async Task<IEnumerable<AllMoviesViewModel>> GetAllMoviesAsync()
        {
            return await movieRepository
                .GetAllAttached()
                .To<AllMoviesViewModel>()
                .ToArrayAsync();
        }
        public async Task<bool> AddMovieAsync(AddMovieFormModel inputModel)
        {
            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate,
                ReleaseDateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime releseDate);

            if (!isReleaseDateValid)
            {
                return false;
            }

            Movie movie = new Movie();

            AutoMapperConfig.MapperInstance.Map(inputModel, movie);
            movie.ReleaseDate = releseDate;

            await this.movieRepository.AddAsync(movie);

            return true;
        }
    }
}
