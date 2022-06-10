using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class PrivateLeagueUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_PrivateLeagues_PrivateLeagueName",
                table: "PlayerTeams");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_PrivateLeagueName",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "PrivateLeagueName",
                table: "PlayerTeams");

            migrationBuilder.AddColumn<string>(
                name: "PrivateLeagueName",
                table: "Rankings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_PrivateLeagueName",
                table: "Rankings",
                column: "PrivateLeagueName");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_PrivateLeagues_PrivateLeagueName",
                table: "Rankings",
                column: "PrivateLeagueName",
                principalTable: "PrivateLeagues",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_PrivateLeagues_PrivateLeagueName",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_PrivateLeagueName",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "PrivateLeagueName",
                table: "Rankings");

            migrationBuilder.AddColumn<string>(
                name: "PrivateLeagueName",
                table: "PlayerTeams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PrivateLeagueName",
                table: "PlayerTeams",
                column: "PrivateLeagueName");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_PrivateLeagues_PrivateLeagueName",
                table: "PlayerTeams",
                column: "PrivateLeagueName",
                principalTable: "PrivateLeagues",
                principalColumn: "Name");
        }
    }
}
