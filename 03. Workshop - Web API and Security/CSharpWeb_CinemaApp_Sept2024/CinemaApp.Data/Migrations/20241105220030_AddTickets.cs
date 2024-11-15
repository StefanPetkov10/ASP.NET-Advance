using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("18e906ff-7643-4245-8e13-157049f3d4a8"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("64d1598a-7c6d-4188-858b-2bcb3257b377"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("e4f5e0da-661d-4c48-a259-0b389e9f5a53"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("fe013a3d-a472-4d0f-ac47-701d362bd370"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("447c6d6c-49ab-4056-9fb8-faa1539006c0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bb99e177-35f5-4d20-977b-12acc5858b81"));

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaId",
                table: "Tickets",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieId",
                table: "Tickets",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

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

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("18e906ff-7643-4245-8e13-157049f3d4a8"), "Sofia", "Cinema City" },
                    { new Guid("64d1598a-7c6d-4188-858b-2bcb3257b377"), "Burgas", "Cine Grand" },
                    { new Guid("e4f5e0da-661d-4c48-a259-0b389e9f5a53"), "Varna", "Cinema City" },
                    { new Guid("fe013a3d-a472-4d0f-ac47-701d362bd370"), "Plovdiv", "Cine Grand" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("447c6d6c-49ab-4056-9fb8-faa1539006c0"), "Two imprisoned", "Frank Darabont", 142, "Drama", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("bb99e177-35f5-4d20-977b-12acc5858b81"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Action", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });
        }
    }
}
