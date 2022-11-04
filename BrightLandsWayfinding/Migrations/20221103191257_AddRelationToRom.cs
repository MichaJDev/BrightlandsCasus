using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightLandsWayfinding.Migrations
{
    public partial class AddRelationToRom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Companies_CompanyID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CompanyID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RoomID",
                table: "Companies",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Rooms_RoomID",
                table: "Companies",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Rooms_RoomID",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RoomID",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CompanyID",
                table: "Rooms",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Companies_CompanyID",
                table: "Rooms",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID");
        }
    }
}
