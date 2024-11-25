using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteForCinemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("05008b2a-8e54-4790-b1cc-ab45dc19d000"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("129233a3-f122-4c30-a29e-564dd0a05581"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("800c2151-f30a-45e1-9016-4f4df181302b"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("9635e8f6-9c4a-4ca7-9e23-a569e475f82d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("31f4b8cc-9695-497c-ba06-e50b14a4accd"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9e7b573a-601f-4edc-b4e7-068d8dde0872"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cinemas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("4ad8d81d-5b8d-4efb-8f84-06e4f5a5befd"), "Sofia", "Cinema City" },
                    { new Guid("680bf792-87fb-4aea-9099-645394f069d6"), "Burgas", "Cine Grand" },
                    { new Guid("685b6cd6-a4c8-49b7-942b-97018e724fe8"), "Varna", "Cinema City" },
                    { new Guid("6fc14f02-1d09-4b26-b7e0-51887229fb4a"), "Plovdiv", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("318b284b-f5c5-464c-8331-99f3af0517d2"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("dd828ada-61b0-485c-8fdc-98b8544ece23"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4ad8d81d-5b8d-4efb-8f84-06e4f5a5befd"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("680bf792-87fb-4aea-9099-645394f069d6"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("685b6cd6-a4c8-49b7-942b-97018e724fe8"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6fc14f02-1d09-4b26-b7e0-51887229fb4a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("318b284b-f5c5-464c-8331-99f3af0517d2"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("dd828ada-61b0-485c-8fdc-98b8544ece23"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cinemas");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("05008b2a-8e54-4790-b1cc-ab45dc19d000"), "Burgas", "Cine Grand" },
                    { new Guid("129233a3-f122-4c30-a29e-564dd0a05581"), "Plovdiv", "Cine Grand" },
                    { new Guid("800c2151-f30a-45e1-9016-4f4df181302b"), "Sofia", "Cinema City" },
                    { new Guid("9635e8f6-9c4a-4ca7-9e23-a569e475f82d"), "Varna", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("31f4b8cc-9695-497c-ba06-e50b14a4accd"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("9e7b573a-601f-4edc-b4e7-068d8dde0872"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });
        }
    }
}
