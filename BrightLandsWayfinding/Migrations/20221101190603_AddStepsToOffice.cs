using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightLandsWayfinding.Migrations
{
    public partial class AddStepsToOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Step_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_OfficeID",
                table: "Step",
                column: "OfficeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step");
        }
    }
}
