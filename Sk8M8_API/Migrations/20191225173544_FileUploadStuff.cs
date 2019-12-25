using Microsoft.EntityFrameworkCore.Migrations;

namespace Sk8M8_API.Migrations
{
    public partial class FileUploadStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VideoId",
                table: "MapMarker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Client",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MapMarker_VideoId",
                table: "MapMarker",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MapMarker_Media_VideoId",
                table: "MapMarker",
                column: "VideoId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapMarker_Media_VideoId",
                table: "MapMarker");

            migrationBuilder.DropIndex(
                name: "IX_MapMarker_VideoId",
                table: "MapMarker");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "MapMarker");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Client");
        }
    }
}
