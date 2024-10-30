using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.ApplicationConstants;
using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        // Fluent API
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            builder
                .Property(m => m.ReleaseDate)
                .IsRequired();

            builder
                .Property(m => m.Director)
                .IsRequired()
                .HasMaxLength(DirectorMaxLength);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(m => m.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength)
                .HasDefaultValue(noImageUrl);

            builder
                .HasData(this.SeedMovies());
        }

        private List<Movie> SeedMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Title = "The Matrix",
                    Genre = "Action",
                    ReleaseDate = new DateTime(1999, 3, 31),
                    Director = "Lana Wachowski, Lilly Wachowski",
                    Duration = 136,
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers."
                },
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    Director = "Frank Darabont",
                    Duration = 142,
                    Description = "Two imprisoned"
                }
            };
        }

    }
}

