using System.ComponentModel.DataAnnotations;
using CinemaApp.Services.Mapping;

using static CinemaApp.Common.EntityValidationConstants.CinemaMovie;
using static CinemaApp.Common.EntityValidationMessages.CinemaMovie;

namespace CinemaApp.Web.ViewModels.CinemaMovie
{
    using CinemaApp.Data.Models;
    public class SetAvailableTicketsViewModel : IMapTo<CinemaMovie>
    {
        [Required]
        public string CinemaId { get; set; } = null!;

        [Required]
        public string MovieId { get; set; } = null!;

        [Required(ErrorMessage = AvailableTicketsRequiredMessage)]
        [Range(AvailableTicketsMinValue, AvailableTicketsMaxValue, ErrorMessage = AvailableTicketsRangeMessage)]
        public int AvailableTickets { get; set; }
    }
}
