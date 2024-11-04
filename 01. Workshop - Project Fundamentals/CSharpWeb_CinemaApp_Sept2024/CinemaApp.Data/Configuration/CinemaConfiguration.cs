using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Data.Configuration
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLength);

            builder
                .HasData(this.SeedCinemas());
        }

        private IEnumerable<Cinema> GenerateCinemas()
        {
            IEnumerable<Cinema> cinemas = new List<Cinema>();

            for (int i = 0; i < 4; i++)
            {
                Cinema cinema = new Cinema
                {
                    Name = i % 2 == 0 ? "Cinema City" : "Cine Grand",
                    Location = i switch
                    {
                        0 => "Sofia",
                        1 => "Plovdiv",
                        2 => "Varna",
                        3 => "Burgas",
                        _ => "Invalid location"
                    }
                };

                cinemas.Append(cinema);
            }

            return cinemas;
        }
        private List<Cinema> SeedCinemas()
        {
            return new List<Cinema>
            {
                new Cinema
                {
                    Name = "Cinema City",
                    Location = "Sofia"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Plovdiv"
                },
                new Cinema
                {
                    Name = "Cinema City",
                    Location = "Varna"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Burgas"
                }
            };
        }
    }
}
