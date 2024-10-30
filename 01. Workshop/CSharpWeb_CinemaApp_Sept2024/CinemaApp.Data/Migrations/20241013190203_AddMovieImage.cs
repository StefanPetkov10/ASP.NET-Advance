using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("1541d333-2f03-4419-9466-a518024b36a1"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("55b89aa5-2d07-4908-b9cd-d491cfbdc59c"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("971d8af6-69ea-47e9-8410-fd6d5c776e25"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("eb1de18e-7959-4542-8164-c37b47fc2f52"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8407e2ca-a3e0-4b23-95bc-8d130003beb2"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f1b1ffdc-c2a3-4d63-b6d2-f69e720cf565"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "~/images/no-image.jpg");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("07ad9a06-b20e-4f61-9c27-7e0d86bc264a"), "Sofia", "Cinema City" },
                    { new Guid("2f07f29a-6ee7-4c3d-b00c-18f580449423"), "Varna", "Cinema City" },
                    { new Guid("6a29ff6c-9ff1-48d5-a3ce-5384e31224e7"), "Burgas", "Cine Grand" },
                    { new Guid("fc415845-b6b9-47ae-8800-e9cb34508e0a"), "Plovdiv", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("47025da5-7ab5-4975-9c34-cf861fbff260"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("d31167f2-c401-46ee-b183-f74c4caf5dcc"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("07ad9a06-b20e-4f61-9c27-7e0d86bc264a"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("2f07f29a-6ee7-4c3d-b00c-18f580449423"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6a29ff6c-9ff1-48d5-a3ce-5384e31224e7"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("fc415845-b6b9-47ae-8800-e9cb34508e0a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("47025da5-7ab5-4975-9c34-cf861fbff260"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d31167f2-c401-46ee-b183-f74c4caf5dcc"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("1541d333-2f03-4419-9466-a518024b36a1"), "Plovdiv", "Cine Grand" },
                    { new Guid("55b89aa5-2d07-4908-b9cd-d491cfbdc59c"), "Varna", "Cinema City" },
                    { new Guid("971d8af6-69ea-47e9-8410-fd6d5c776e25"), "Sofia", "Cinema City" },
                    { new Guid("eb1de18e-7959-4542-8164-c37b47fc2f52"), "Burgas", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("8407e2ca-a3e0-4b23-95bc-8d130003beb2"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("f1b1ffdc-c2a3-4d63-b6d2-f69e720cf565"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });
        }
    }
}
