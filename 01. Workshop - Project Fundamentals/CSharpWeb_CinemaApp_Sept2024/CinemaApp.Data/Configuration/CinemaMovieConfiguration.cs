using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder
                .HasKey(cm => new { cm.CinemaId, cm.MovieId });

            builder
                .Property(cm => cm.IsDeleted)
                .HasDefaultValue(false);

            builder
                .HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.MovieCinemas)
                .HasForeignKey(cm => cm.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
/* private IEnumerable<CinemaMovie> GenerateCinemasMovies()
{
    IEnumerable<CinemaMovie> cinemaMovies = new List<CinemaMovie>()
    {
        new CinemaMovie
        {
            CinemaId = Guid.Parse("d3b8f4b3-3b3b-4b1b-8b1b-3b3b3b3b3b3b"),
            MovieId = Guid.Parse("d3b8f4b3-3b3b-4b1b-8b1b-3b3b3b3b3b3b")
        }
    };
    return cinemaMovies;
}
*/