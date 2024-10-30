using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.EntityValidationMessages.Movie;
namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieFromModel
    {

        public AddMovieFromModel()
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
    }
}
