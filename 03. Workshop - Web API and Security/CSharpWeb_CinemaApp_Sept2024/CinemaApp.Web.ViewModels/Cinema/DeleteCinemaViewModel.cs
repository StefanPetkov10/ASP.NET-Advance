using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Cinema
{
    using CinemaApp.Data.Models;

    public class DeleteCinemaViewModel : IMapFrom<Cinema>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
