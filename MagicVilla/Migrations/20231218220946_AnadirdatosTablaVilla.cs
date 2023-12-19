using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class AnadirdatosTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "CreationDate", "Details", "ImagenUrl", "Ocuppants", "Price", "SquareMeters", "UpdateDate", "VillaName" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7301), "", "", 5, 200.0, 50, new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7346), "Villa real" },
                    { 2, "", new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7349), "Detalle de la vista", "", 6, 230.0, 70, new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7351), "Villa con vista a la playa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
