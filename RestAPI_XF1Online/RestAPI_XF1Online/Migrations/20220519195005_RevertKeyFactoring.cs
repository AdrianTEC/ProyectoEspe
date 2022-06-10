using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class RevertKeyFactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverPlayerTeam_PlayerTeams_PlayerTeamsName",
                table: "DriverPlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Players_PlayerUsername",
                table: "PlayerTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_PlayerTeams_PlayerTeamName",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_PlayerTeamName",
                table: "Rankings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTeams",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam");

            migrationBuilder.DropIndex(
                name: "IX_DriverPlayerTeam_PlayerTeamsName",
                table: "DriverPlayerTeam");

            migrationBuilder.DropColumn(
                name: "PlayerTeamName",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "PlayerTeamsName",
                table: "DriverPlayerTeam");

            migrationBuilder.AddColumn<int>(
                name: "PlayerTeamId",
                table: "Rankings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerUsername",
                table: "PlayerTeams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayerTeams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlayerTeams",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PlayerTeamsId",
                table: "DriverPlayerTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTeams",
                table: "PlayerTeams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam",
                columns: new[] { "DriversId", "PlayerTeamsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_PlayerTeamId",
                table: "Rankings",
                column: "PlayerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPlayerTeam_PlayerTeamsId",
                table: "DriverPlayerTeam",
                column: "PlayerTeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverPlayerTeam_PlayerTeams_PlayerTeamsId",
                table: "DriverPlayerTeam",
                column: "PlayerTeamsId",
                principalTable: "PlayerTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Players_PlayerUsername",
                table: "PlayerTeams",
                column: "PlayerUsername",
                principalTable: "Players",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_PlayerTeams_PlayerTeamId",
                table: "Rankings",
                column: "PlayerTeamId",
                principalTable: "PlayerTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverPlayerTeam_PlayerTeams_PlayerTeamsId",
                table: "DriverPlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Players_PlayerUsername",
                table: "PlayerTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_PlayerTeams_PlayerTeamId",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_PlayerTeamId",
                table: "Rankings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTeams",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam");

            migrationBuilder.DropIndex(
                name: "IX_DriverPlayerTeam_PlayerTeamsId",
                table: "DriverPlayerTeam");

            migrationBuilder.DropColumn(
                name: "PlayerTeamId",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "PlayerTeamsId",
                table: "DriverPlayerTeam");

            migrationBuilder.AddColumn<string>(
                name: "PlayerTeamName",
                table: "Rankings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerUsername",
                table: "PlayerTeams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayerTeams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PlayerTeamsName",
                table: "DriverPlayerTeam",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTeams",
                table: "PlayerTeams",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam",
                columns: new[] { "DriversId", "PlayerTeamsName" });

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_PlayerTeamName",
                table: "Rankings",
                column: "PlayerTeamName");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPlayerTeam_PlayerTeamsName",
                table: "DriverPlayerTeam",
                column: "PlayerTeamsName");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverPlayerTeam_PlayerTeams_PlayerTeamsName",
                table: "DriverPlayerTeam",
                column: "PlayerTeamsName",
                principalTable: "PlayerTeams",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Players_PlayerUsername",
                table: "PlayerTeams",
                column: "PlayerUsername",
                principalTable: "Players",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_PlayerTeams_PlayerTeamName",
                table: "Rankings",
                column: "PlayerTeamName",
                principalTable: "PlayerTeams",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
