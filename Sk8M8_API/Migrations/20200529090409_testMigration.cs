using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class testMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 150, DateTimeKind.Local).AddTicks(1108), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8553), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8563) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8574), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8581), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8583) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8586), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8589) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8592), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8594) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8597), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8600) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8603), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8608), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8611) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8614), new DateTime(2020, 5, 29, 10, 4, 9, 151, DateTimeKind.Local).AddTicks(8617) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5536), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5539) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5543), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5545) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5548), new DateTime(2020, 5, 17, 17, 0, 2, 489, DateTimeKind.Local).AddTicks(5551) });
        }
    }
}
