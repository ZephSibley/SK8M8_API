using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class LocationAndIdIndexing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 379, DateTimeKind.Local).AddTicks(4193), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(884), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(906), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(912), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(918), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(923), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(929), new DateTime(2020, 5, 9, 12, 13, 57, 381, DateTimeKind.Local).AddTicks(931) });

            migrationBuilder.CreateIndex(
                name: "IX_MapMarker_Point",
                table: "MapMarker",
                column: "Point");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Geolocation",
                table: "Client",
                column: "Geolocation");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Id",
                table: "Client",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MapMarker_Point",
                table: "MapMarker");

            migrationBuilder.DropIndex(
                name: "IX_Client_Geolocation",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_Id",
                table: "Client");

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 353, DateTimeKind.Local).AddTicks(5457), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(1681) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2492), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2502) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2514), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2517) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2520), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2525), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2531), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2533) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2536), new DateTime(2020, 3, 29, 12, 1, 30, 355, DateTimeKind.Local).AddTicks(2539) });
        }
    }
}
