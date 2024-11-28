using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixMissedDbSetApplicationUserMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_Movies_MovieId",
                table: "ApplicationUserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie");

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

            migrationBuilder.RenameTable(
                name: "ApplicationUserMovie",
                newName: "UsersMovies");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserMovie_MovieId",
                table: "UsersMovies",
                newName: "IX_UsersMovies_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies",
                columns: new[] { "ApplicationUserId", "MovieId" });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("09c1f477-7919-4475-a564-e8229423b320"), "Plovdiv", "Cine Grand" },
                    { new Guid("30be3623-d776-42b2-82f3-0a83818d519a"), "Sofia", "Cinema City" },
                    { new Guid("41feddb6-71ce-498d-b02d-6232036abd0a"), "Varna", "Cinema City" },
                    { new Guid("e7f816ee-e5b3-45aa-97de-93804d6ef532"), "Burgas", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("24214383-251b-4b2c-9965-de7d0a59358a"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("722cbacc-fd21-49ea-a0e2-883605641129"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_AspNetUsers_ApplicationUserId",
                table: "UsersMovies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Movies_MovieId",
                table: "UsersMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_AspNetUsers_ApplicationUserId",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Movies_MovieId",
                table: "UsersMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("09c1f477-7919-4475-a564-e8229423b320"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("30be3623-d776-42b2-82f3-0a83818d519a"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("41feddb6-71ce-498d-b02d-6232036abd0a"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("e7f816ee-e5b3-45aa-97de-93804d6ef532"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("24214383-251b-4b2c-9965-de7d0a59358a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("722cbacc-fd21-49ea-a0e2-883605641129"));

            migrationBuilder.RenameTable(
                name: "UsersMovies",
                newName: "ApplicationUserMovie");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMovies_MovieId",
                table: "ApplicationUserMovie",
                newName: "IX_ApplicationUserMovie_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie",
                columns: new[] { "ApplicationUserId", "MovieId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserMovie",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_Movies_MovieId",
                table: "ApplicationUserMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
