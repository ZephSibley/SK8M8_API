using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class MoreLocationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 805, DateTimeKind.Local).AddTicks(3885), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2112), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2121) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2135), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2141), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2143) });

            migrationBuilder.InsertData(
                table: "LocationType",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { 5L, new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2146), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2149), "Pump track" },
                    { 6L, new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2151), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2154), "Dirt track" },
                    { 7L, new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2157), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2159), "Skate path" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 45, 2, 300, DateTimeKind.Local).AddTicks(1552), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(449) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2829), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2842) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2865), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2868) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2872), new DateTime(2020, 3, 20, 15, 45, 2, 303, DateTimeKind.Local).AddTicks(2875) });
        }
    }
}
