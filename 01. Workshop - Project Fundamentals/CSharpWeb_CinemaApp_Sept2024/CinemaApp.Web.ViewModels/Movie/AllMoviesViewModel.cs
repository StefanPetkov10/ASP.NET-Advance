namespace CinemaApp.Web.ViewModels.Movie
{
    using AutoMapper;
    using CinemaApp.Data.Models;
    using CinemaApp.Services.Mapping;

    public class AllMoviesViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string Duration { get; set; } = null!;

        public void CreateMappings(IProfileExpression configurate)
        {
            configurate.CreateMap<Movie, AllMoviesViewModel>()
                .ForMember(x => x.ReleaseDate, opt =>
                    opt.MapFrom(x => x.ReleaseDate.ToString("MMMM yyyy")));
        }
    }
}
