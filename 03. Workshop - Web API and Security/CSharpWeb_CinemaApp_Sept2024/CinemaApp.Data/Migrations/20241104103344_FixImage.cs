using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "/images/no-image.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true,
                oldDefaultValue: "~/images/no-image.jpg");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "~/images/no-image.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true,
                oldDefaultValue: "/images/no-image.jpg");

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
        }
    }
}
