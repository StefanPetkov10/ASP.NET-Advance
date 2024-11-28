using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CinemaApp.Services.Mapping;
using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Web.ViewModels.Cinema
{
    using CinemaApp.Data.Models;
    public class EditCinemaFormModel : IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Cinema, EditCinemaFormModel>();

            configuration
                .CreateMap<EditCinemaFormModel, Cinema>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
