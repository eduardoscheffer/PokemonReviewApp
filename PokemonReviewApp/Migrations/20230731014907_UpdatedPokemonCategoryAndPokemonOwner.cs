using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokemonReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPokemonCategoryAndPokemonOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 7, 30, 22, 49, 7, 113, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 7, 30, 22, 49, 7, 113, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 7, 30, 22, 49, 7, 113, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.InsertData(
                table: "PokemonCategories",
                columns: new[] { "CategoryId", "PokemonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PokemonOwners",
                columns: new[] { "OwnerId", "PokemonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 7, 30, 18, 2, 44, 710, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 7, 30, 18, 2, 44, 710, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 7, 30, 18, 2, 44, 710, DateTimeKind.Local).AddTicks(3668));
        }
    }
}
