using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightLandsWayfinding.Migrations
{
    public partial class RecreatedModelsWithProperRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Rooms_RoomID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Rooms_RoomID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Stories_StoryID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Buildings_BuildingID",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Companies_CompanyID",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingID",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoryID",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Rooms_RoomID",
                table: "Companies",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Rooms_RoomID",
                table: "Event",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Stories_StoryID",
                table: "Rooms",
                column: "StoryID",
                principalTable: "Stories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Buildings_BuildingID",
                table: "Stories",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Companies_CompanyID",
                table: "User",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Rooms_RoomID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Rooms_RoomID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Stories_StoryID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Buildings_BuildingID",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Companies_CompanyID",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingID",
                table: "Stories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StoryID",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Rooms_RoomID",
                table: "Companies",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Rooms_RoomID",
                table: "Event",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Stories_StoryID",
                table: "Rooms",
                column: "StoryID",
                principalTable: "Stories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Buildings_BuildingID",
                table: "Stories",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Companies_CompanyID",
                table: "User",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID");
        }
    }
}
