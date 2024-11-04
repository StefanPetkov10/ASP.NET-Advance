using AutoMapper;
using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Movie
{
    using CinemaApp.Data.Models;
    public class MovieDetailsViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string Duration { get; set; } = null!;

        public string Description { get; set; } = null!;

        public void CreateMappings(IProfileExpression configurate)
        {
            configurate.CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(x => x.ReleaseDate, opt =>
                    opt.MapFrom(x => x.ReleaseDate.ToString("MMMM yyyy")));
        }
    }
}
