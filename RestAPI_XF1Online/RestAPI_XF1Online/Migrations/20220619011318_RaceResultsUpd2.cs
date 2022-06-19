using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class RaceResultsUpd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Races_RaceId",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_RaceId",
                table: "RaceResults");

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "RaceResults",
                newName: "Carrera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Carrera",
                table: "RaceResults",
                newName: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RaceId",
                table: "RaceResults",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Races_RaceId",
                table: "RaceResults",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
