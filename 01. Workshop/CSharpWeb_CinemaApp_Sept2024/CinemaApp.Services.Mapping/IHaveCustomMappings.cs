using AutoMapper;

namespace CinemaApp.Services.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configurate);
    }
}
