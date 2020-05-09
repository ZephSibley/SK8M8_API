using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class MarkerStars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientMarkerStar",
                columns: table => new
                {
                    ClientId = table.Column<long>(nullable: false),
                    MapMarkerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMarkerStar", x => new { x.ClientId, x.MapMarkerId });
                    table.ForeignKey(
                        name: "FK_ClientMarkerStar_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientMarkerStar_MapMarker_MapMarkerId",
                        column: x => x.MapMarkerId,
                        principalTable: "MapMarker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ClientMarkerStar_MapMarkerId",
                table: "ClientMarkerStar",
                column: "MapMarkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientMarkerStar");

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
        }
    }
}
