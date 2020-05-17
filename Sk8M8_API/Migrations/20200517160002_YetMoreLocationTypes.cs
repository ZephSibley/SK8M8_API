using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class YetMoreLocationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 487, DateTimeKind.Local).AddTicks(6720), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5436), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5459), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5462) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5465), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5470), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5476), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5479) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5482), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.InsertData(
                table: "LocationType",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { 8L, new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5536), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5539), "Ledge" },
                    { 9L, new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5543), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5545), "Stairset" },
                    { 10L, new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5548), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5551), "Manny Pad" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 324, DateTimeKind.Local).AddTicks(6582), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4359), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4381), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4384) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4387), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4389) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4392), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4398), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4401) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4404), new DateTime(2020, 5, 9, 15, 6, 33, 326, DateTimeKind.Local).AddTicks(4406) });
        }
    }
}
