using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManagerSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("3778e671-7913-4e93-b41a-0a595a0f6967"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("85fd35e8-597d-4b12-aca3-b58ae557a8ba"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("b5aa9abb-b6d8-4b9f-8cbd-abea26885764"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("f5e7198e-dd20-4222-9e46-443dc6af0ab6"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("48ef84ca-0d4f-4671-8e5f-56b59f99f41b"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("977237a1-6e0c-4236-afb0-be684c98e0c1"));

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Manager_UserId",
                table: "Manager",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

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

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("3778e671-7913-4e93-b41a-0a595a0f6967"), "Plovdiv", "Cine Grand" },
                    { new Guid("85fd35e8-597d-4b12-aca3-b58ae557a8ba"), "Sofia", "Cinema City" },
                    { new Guid("b5aa9abb-b6d8-4b9f-8cbd-abea26885764"), "Varna", "Cinema City" },
                    { new Guid("f5e7198e-dd20-4222-9e46-443dc6af0ab6"), "Burgas", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("48ef84ca-0d4f-4671-8e5f-56b59f99f41b"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("977237a1-6e0c-4236-afb0-be684c98e0c1"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });
        }
    }
}
