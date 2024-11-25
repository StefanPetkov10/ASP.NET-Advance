using System.Globalization;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Services.Data
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly IRepository<Movie, Guid> movieRepository;
        private readonly IRepository<Cinema, Guid> cinemaRepository;
        private readonly IRepository<CinemaMovie, object> cinemaMovieRepository;
        public MovieService(IRepository<Movie, Guid> movieRepository,
                                IRepository<Cinema, Guid> cinemaRepository,
                                IRepository<CinemaMovie, object> cinemaMovieRepository)
        {
            this.movieRepository = movieRepository;
            this.cinemaRepository = cinemaRepository;
            this.cinemaMovieRepository = cinemaMovieRepository;
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

        public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(Guid id)
        {
            Movie? movie = await this.movieRepository
                 .GetByIdAsync(id);

            MovieDetailsViewModel viewModel = new MovieDetailsViewModel();

            if (movie != null)
            {
                AutoMapperConfig.MapperInstance.Map(movie, viewModel);
            }

            return viewModel;
        }

        public async Task<AddMovieToCinemaInputModel?> AddMovieToCinemaInputModelByIdAsync(Guid id)
        {
            Movie? movie = await this.movieRepository
                .GetByIdAsync(id);
            AddMovieToCinemaInputModel? viewModel = null;

            if (movie != null)
            {
                viewModel = new AddMovieToCinemaInputModel
                {
                    Id = id.ToString()!,
                    MovieTitle = movie.Title,
                    Cinemas = await this.cinemaRepository
                   .GetAllAttached()
                   .Include(cm => cm.CinemaMovies)
                   .ThenInclude(m => m.Movie)
                   .Where(c => c.IsDeleted == false)
                       .Select(c => new CinemaCheckBoxItemInputModel
                       {
                           Id = c.Id.ToString(),
                           Name = c.Name,
                           Location = c.Location,
                           //IsSelected = false
                           IsSelected = c.CinemaMovies
                           .Any(cm => cm.MovieId == id &&
                                      cm.IsDeleted == false)
                       })
                       .ToArrayAsync()
                };
            }
            return viewModel;
        }
        public async Task<bool> AddMovieToCinemasAsync(Guid movieId, AddMovieToCinemaInputModel model)
        {
            Movie? movie = await this.movieRepository
                .GetByIdAsync(movieId);

            if (movie == null)
            {
                return false;
            }

            ICollection<CinemaMovie> entitiesToAdd = new List<CinemaMovie>();
            foreach (CinemaCheckBoxItemInputModel cinemaInputModel in model.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaGuidValid = this.IsGuidIdValid(cinemaInputModel.Id, ref cinemaGuid);
                if (!isCinemaGuidValid)
                {
                    return false;
                }

                Cinema? cinema = await this.cinemaRepository
                    .GetByIdAsync(cinemaGuid);

                if (cinema == null || cinema.IsDeleted)
                {
                    return false;
                }

                CinemaMovie? cinemaMovie = await this.cinemaMovieRepository
                    .FirstOrDefaultAsync(cm => cm.CinemaId == cinemaGuid &&
                                             cm.MovieId == movieId);

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
            }
            await this.cinemaMovieRepository.AddRangeAsync(entitiesToAdd.ToArray());
            return true;
        }
    }
}
