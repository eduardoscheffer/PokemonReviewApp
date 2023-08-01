using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokemonReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grass" },
                    { 2, "Fire" },
                    { 3, "Water" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kanto" },
                    { 2, "Johto" },
                    { 3, "Hoenn" }
                });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 30, 18, 2, 44, 710, DateTimeKind.Local).AddTicks(3658), "Pikachu" },
                    { 2, new DateTime(2023, 7, 30, 18, 2, 44, 710, DateTimeKind.Local).AddTicks(3667), "Bulbasaur" },
                    { 3, new DateTime(2023, 7, 30, 18, 2, 44, 710, DateTimeKind.Local).AddTicks(3668), "Squirtle" }
                });

            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ash", "Ketchum" },
                    { 2, "Misty", "Ketshup" },
                    { 3, "Brock", "Mustard" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "CountryId", "FirstName", "Gym", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Ragnar", "Gym1", "Lothbrock" },
                    { 2, 2, "Lagertha", "Gym2", "Lothbrock" },
                    { 3, 3, "Ivar", "Gym3", "Boneless" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "PokemonId", "Rating", "ReviewerId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, 1, 9, 1, "Text 1", "Title1" },
                    { 2, 2, 10, 2, "Text 2", "Title2" },
                    { 3, 3, 7, 3, "Text 3", "Title3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
