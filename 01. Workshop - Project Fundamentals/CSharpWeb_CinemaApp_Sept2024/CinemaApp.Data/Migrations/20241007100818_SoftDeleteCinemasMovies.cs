using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteCinemasMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3d3e945f-128c-4e13-8e05-46a9a2a15aeb"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3e6ac8fa-5122-44a1-bd1e-4f83c43a2283"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("899064e2-e58e-4da6-85a5-d9f1a3eace90"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("93f20827-23ec-4d6c-aa6f-99754e73f631"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3abe044b-d202-43d0-ab41-13bb2c31c553"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4c9e16b2-47b5-4397-9985-cae461c4ca13"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CinemasMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("07a8afc9-3adc-46fb-8969-4b39091ee30a"), "Varna", "Cinema City" },
                    { new Guid("74ceb1c0-9ecc-476b-a37d-70a4b6fc2299"), "Sofia", "Cinema City" },
                    { new Guid("a7aeb602-6494-45ea-a780-5ca45d9cf1f7"), "Plovdiv", "Cine Grand" },
                    { new Guid("bd9474cd-c2de-418a-ac1b-f6887e95fe01"), "Burgas", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("449723e5-a8f6-42b2-8a1b-7d70cc6a6b0a"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("cb3df481-5877-4f4e-85a6-a76026ccaaaf"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("07a8afc9-3adc-46fb-8969-4b39091ee30a"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("74ceb1c0-9ecc-476b-a37d-70a4b6fc2299"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("a7aeb602-6494-45ea-a780-5ca45d9cf1f7"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("bd9474cd-c2de-418a-ac1b-f6887e95fe01"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("449723e5-a8f6-42b2-8a1b-7d70cc6a6b0a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("cb3df481-5877-4f4e-85a6-a76026ccaaaf"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CinemasMovies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("3d3e945f-128c-4e13-8e05-46a9a2a15aeb"), "Plovdiv", "Cine Grand" },
                    { new Guid("3e6ac8fa-5122-44a1-bd1e-4f83c43a2283"), "Burgas", "Cine Grand" },
                    { new Guid("899064e2-e58e-4da6-85a5-d9f1a3eace90"), "Varna", "Cinema City" },
                    { new Guid("93f20827-23ec-4d6c-aa6f-99754e73f631"), "Sofia", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("3abe044b-d202-43d0-ab41-13bb2c31c553"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("4c9e16b2-47b5-4397-9985-cae461c4ca13"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });
        }
    }
}
