using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketsAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
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
                keyValue: new Guid("dd828ada-61b0-485c-8fdc-98b8544ece23"));*/

            migrationBuilder.AddColumn<int>(
                name: "AvailableTickets",
                table: "CinemasMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            /* migrationBuilder.InsertData(
                 table: "Cinemas",
                 columns: new[] { "Id", "Location", "Name" },
                 values: new object[,]
                 {
                     { new Guid("3612b684-e637-4a74-8f8a-e8e751056403"), "Plovdiv", "Cine Grand" },
                     { new Guid("3a719310-1341-47f4-9949-9abaae36d47d"), "Varna", "Cinema City" },
                     { new Guid("c178670f-8231-4b9d-a4e3-a24b82563fb3"), "Sofia", "Cinema City" },
                     { new Guid("ffd900d4-c052-4f12-aa2b-d3ba1892e910"), "Burgas", "Cine Grand" }
                 });

             migrationBuilder.InsertData(
                 table: "Movies",
                 columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                 values: new object[,]
                 {
                     { new Guid("3b0ff749-3677-47e8-9316-9e077da40b3c"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                     { new Guid("b9b666ed-859b-4196-a03e-faafc157847b"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                 });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3612b684-e637-4a74-8f8a-e8e751056403"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3a719310-1341-47f4-9949-9abaae36d47d"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("c178670f-8231-4b9d-a4e3-a24b82563fb3"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("ffd900d4-c052-4f12-aa2b-d3ba1892e910"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3b0ff749-3677-47e8-9316-9e077da40b3c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b9b666ed-859b-4196-a03e-faafc157847b"));*/

            migrationBuilder.DropColumn(
                name: "AvailableTickets",
                table: "CinemasMovies");

            /* migrationBuilder.InsertData(
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
                 });*/
        }
    }
}
