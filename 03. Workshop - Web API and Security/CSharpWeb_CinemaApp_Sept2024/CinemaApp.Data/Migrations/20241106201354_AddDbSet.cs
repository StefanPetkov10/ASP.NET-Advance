using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_AspNetUsers_UserId",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3ab441af-d450-47e5-8526-4f68f190d392"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4ed54923-086b-4f8c-8a02-e9415cd85497"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("8885f849-904b-4119-aef0-b5caeb4a2884"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("cb674835-5bcf-4970-aa24-4661f05df530"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9b4bda78-9a8f-454c-a462-2c774bf4db7f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bc6b7b95-fc2c-4038-a5af-4c768ac1d6b7"));

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_UserId",
                table: "Managers",
                newName: "IX_Managers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_UserId",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

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

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_UserId",
                table: "Manager",
                newName: "IX_Manager_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("3ab441af-d450-47e5-8526-4f68f190d392"), "Plovdiv", "Cine Grand" },
                    { new Guid("4ed54923-086b-4f8c-8a02-e9415cd85497"), "Burgas", "Cine Grand" },
                    { new Guid("8885f849-904b-4119-aef0-b5caeb4a2884"), "Varna", "Cinema City" },
                    { new Guid("cb674835-5bcf-4970-aa24-4661f05df530"), "Sofia", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("9b4bda78-9a8f-454c-a462-2c774bf4db7f"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("bc6b7b95-fc2c-4038-a5af-4c768ac1d6b7"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_AspNetUsers_UserId",
                table: "Manager",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
