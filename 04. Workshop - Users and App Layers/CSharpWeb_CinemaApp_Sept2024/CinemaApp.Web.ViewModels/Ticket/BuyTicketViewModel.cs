using System.ComponentModel.DataAnnotations;
using CinemaApp.Services.Mapping;
using static CinemaApp.Common.EntityValidationConstants.Ticket;
using static CinemaApp.Common.EntityValidationMessages.Ticket;

namespace CinemaApp.Web.ViewModels.Ticket
{
    using CinemaApp.Data.Models;
    public class BuyTicketViewModel : IMapTo<Ticket>
    {
        [Required]
        public string CinemaId { get; set; } = null!;

        [Required]
        public string MovieId { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = IncorrectPriceMessage)]
        public decimal Price { get; set; }

        [Range(CountMinValue, CountMaxValue, ErrorMessage = IncorrectCountMessage)]
        public int Count { get; set; }
    }
}
