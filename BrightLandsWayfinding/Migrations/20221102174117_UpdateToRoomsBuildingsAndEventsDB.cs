using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightLandsWayfinding.Migrations
{
    public partial class UpdateToRoomsBuildingsAndEventsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Offices_OfficeID",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Locations_LocationID",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Stories",
                newName: "BuildingID");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_LocationID",
                table: "Stories",
                newName: "IX_Stories_BuildingID");

            migrationBuilder.RenameColumn(
                name: "OfficeID",
                table: "Step",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Step_OfficeID",
                table: "Step",
                newName: "IX_Step_RoomID");

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoryID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rooms_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_RoomID",
                table: "Event",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CompanyID",
                table: "Rooms",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StoryID",
                table: "Rooms",
                column: "StoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Rooms_RoomID",
                table: "Step",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Buildings_BuildingID",
                table: "Stories",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Rooms_RoomID",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Buildings_BuildingID",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.RenameColumn(
                name: "BuildingID",
                table: "Stories",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_BuildingID",
                table: "Stories",
                newName: "IX_Stories_LocationID");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Step",
                newName: "OfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Step_RoomID",
                table: "Step",
                newName: "IX_Step_OfficeID");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    StoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offices_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Offices_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyID",
                table: "Offices",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_StoryID",
                table: "Offices",
                column: "StoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Offices_OfficeID",
                table: "Step",
                column: "OfficeID",
                principalTable: "Offices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Locations_LocationID",
                table: "Stories",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID");
        }
    }
}
