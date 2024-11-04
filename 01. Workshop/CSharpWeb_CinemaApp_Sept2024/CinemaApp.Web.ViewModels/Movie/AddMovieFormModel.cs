using System.ComponentModel.DataAnnotations;
using CinemaApp.Services.Mapping;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.EntityValidationMessages.Movie;

namespace CinemaApp.Web.ViewModels.Movie
{
    using AutoMapper;
    using CinemaApp.Data.Models;

    public class AddMovieFormModel : IMapTo<Movie>, IHaveCustomMappings
    {
        public AddMovieFormModel()
        {
            this.ReleaseDate = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }

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

        public void CreateMappings(IProfileExpression configurate)
        {
            configurate.CreateMap<Movie, AddMovieFormModel>()
                .ForMember(dest => dest.ReleaseDate, opt =>
                    opt.Ignore());
        }
    }
}
