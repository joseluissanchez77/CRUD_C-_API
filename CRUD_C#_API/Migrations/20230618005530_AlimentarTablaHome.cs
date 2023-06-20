using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_C__API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Homes",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Description", "ImageUrl", "Name", "Occupants", "Price", "SquareMeters", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8489), "Conjunto residencial", "", "Villas club", 2, 200.0, 30.0, new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8529) },
                    { 2, "", new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8532), "Conjunto residencial", "", "Villas españa", 2, 300.0, 50.0, new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8533) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
