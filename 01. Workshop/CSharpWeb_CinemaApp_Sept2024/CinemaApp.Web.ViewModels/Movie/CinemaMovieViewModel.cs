using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Movie
{
    using CinemaApp.Data.Models;

    public class CinemaMovieViewModel : IMapFrom<Movie>
    {
        public string Title { get; set; } = null!;

        public int Duration { get; set; }


    }
}
