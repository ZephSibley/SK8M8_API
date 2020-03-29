using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class UsernameEmailUniqueness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Client_Email",
                table: "Client",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_Username",
                table: "Client",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Client_Email",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_Username",
                table: "Client");

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

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2146), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2151), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2154) });

            migrationBuilder.UpdateData(
                table: "LocationType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2157), new DateTime(2020, 3, 23, 20, 23, 42, 807, DateTimeKind.Local).AddTicks(2159) });
        }
    }
}
