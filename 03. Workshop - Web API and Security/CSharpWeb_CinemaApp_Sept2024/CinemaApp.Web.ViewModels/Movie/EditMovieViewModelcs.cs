
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CinemaApp.Services.Mapping;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.EntityValidationMessages.Movie;

namespace CinemaApp.Web.ViewModels.Movie
{
    using CinemaApp.Data.Models;

    public class EditMovieFormModel : IMapFrom<Movie>, IMapTo<Movie>, IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreRequiredMessage)]
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateRequiredMessage)]
        public string ReleaseDate { get; set; } = null!;

        [Required(ErrorMessage = DurationRangeMessage)]
        [Range(DurationMinValue, DurationMaxValue)]
        public int Duration { get; set; }

        [Required(ErrorMessage = DirectorRequiredMessage)]
        [MinLength(DirectorMinLength)]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, EditMovieFormModel>()
                .ForMember(d => d.ReleaseDate, opt => opt.MapFrom(s => s.ReleaseDate.ToString(ReleaseDateFormat)));

            configuration.CreateMap<EditMovieFormModel, Movie>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ReleaseDate, opt => opt.Ignore());
        }
    }
}

