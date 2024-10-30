using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder
                .HasKey(um => new { um.ApplicationUserId, um.MovieId });

            builder
                .HasOne(um => um.ApplicationUser)
                .WithMany(u => u.ApplicationUserMovies)
                .HasForeignKey(um => um.ApplicationUserId);

            builder
                .HasOne(um => um.Movie)
                .WithMany(m => m.MovieUsersWishlist)
                .HasForeignKey(um => um.MovieId);
        }
    }
}
