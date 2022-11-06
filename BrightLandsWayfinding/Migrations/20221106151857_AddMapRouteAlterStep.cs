using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightLandsWayfinding.Migrations
{
    public partial class AddMapRouteAlterStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Rooms_RoomID",
                table: "Step");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Step",
                newName: "MapRouteID");

            migrationBuilder.RenameIndex(
                name: "IX_Step_RoomID",
                table: "Step",
                newName: "IX_Step_MapRouteID");

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocationID = table.Column<int>(type: "int", nullable: false),
                    EndLocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Routes_Rooms_EndLocationID",
                        column: x => x.EndLocationID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Routes_Rooms_StartLocationID",
                        column: x => x.StartLocationID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EndLocationID",
                table: "Routes",
                column: "EndLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartLocationID",
                table: "Routes",
                column: "StartLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Routes_MapRouteID",
                table: "Step",
                column: "MapRouteID",
                principalTable: "Routes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Routes_MapRouteID",
                table: "Step");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.RenameColumn(
                name: "MapRouteID",
                table: "Step",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Step_MapRouteID",
                table: "Step",
                newName: "IX_Step_RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Rooms_RoomID",
                table: "Step",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
