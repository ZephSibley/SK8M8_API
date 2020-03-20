using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class LocationTypeSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocationType",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 20, 15, 45, 2, 300, DateTimeKind.Local).AddTicks(1552), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(449), "SkatePark" },
                    { 2L, new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2829), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2842), "Rail" },
                    { 3L, new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2865), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2868), "Ramp" },
                    { 4L, new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2872), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2875), "Plaza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
