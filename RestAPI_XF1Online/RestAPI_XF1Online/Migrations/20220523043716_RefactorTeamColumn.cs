using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class RefactorTeamColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Teams_TeamId",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Scuderias");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "PlayerTeams",
                newName: "ScuderiaId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeams",
                newName: "IX_PlayerTeams_ScuderiaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scuderias",
                table: "Scuderias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Scuderias_ScuderiaId",
                table: "PlayerTeams",
                column: "ScuderiaId",
                principalTable: "Scuderias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Scuderias_ScuderiaId",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scuderias",
                table: "Scuderias");

            migrationBuilder.RenameTable(
                name: "Scuderias",
                newName: "Teams");

            migrationBuilder.RenameColumn(
                name: "ScuderiaId",
                table: "PlayerTeams",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeams_ScuderiaId",
                table: "PlayerTeams",
                newName: "IX_PlayerTeams_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Teams_TeamId",
                table: "PlayerTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
