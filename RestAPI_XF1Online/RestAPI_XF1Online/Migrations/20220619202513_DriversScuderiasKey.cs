using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class DriversScuderiasKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverPlayerTeam_Drivers_DriversId",
                table: "DriverPlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Scuderias_ScuderiaId",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scuderias",
                table: "Scuderias");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_ScuderiaId",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Scuderias");

            migrationBuilder.DropColumn(
                name: "ScuderiaId",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriversId",
                table: "DriverPlayerTeam");

            migrationBuilder.AlterColumn<string>(
                name: "XFIA_Code",
                table: "Scuderias",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ScuderiaXFIA_Code",
                table: "PlayerTeams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "XFIA_Code",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DriversXFIA_Code",
                table: "DriverPlayerTeam",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scuderias",
                table: "Scuderias",
                column: "XFIA_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "XFIA_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam",
                columns: new[] { "DriversXFIA_Code", "PlayerTeamsId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_ScuderiaXFIA_Code",
                table: "PlayerTeams",
                column: "ScuderiaXFIA_Code");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverPlayerTeam_Drivers_DriversXFIA_Code",
                table: "DriverPlayerTeam",
                column: "DriversXFIA_Code",
                principalTable: "Drivers",
                principalColumn: "XFIA_Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Scuderias_ScuderiaXFIA_Code",
                table: "PlayerTeams",
                column: "ScuderiaXFIA_Code",
                principalTable: "Scuderias",
                principalColumn: "XFIA_Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverPlayerTeam_Drivers_DriversXFIA_Code",
                table: "DriverPlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Scuderias_ScuderiaXFIA_Code",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scuderias",
                table: "Scuderias");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_ScuderiaXFIA_Code",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam");

            migrationBuilder.DropColumn(
                name: "ScuderiaXFIA_Code",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "DriversXFIA_Code",
                table: "DriverPlayerTeam");

            migrationBuilder.AlterColumn<string>(
                name: "XFIA_Code",
                table: "Scuderias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Scuderias",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ScuderiaId",
                table: "PlayerTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "XFIA_Code",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DriversId",
                table: "DriverPlayerTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scuderias",
                table: "Scuderias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverPlayerTeam",
                table: "DriverPlayerTeam",
                columns: new[] { "DriversId", "PlayerTeamsId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_ScuderiaId",
                table: "PlayerTeams",
                column: "ScuderiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverPlayerTeam_Drivers_DriversId",
                table: "DriverPlayerTeam",
                column: "DriversId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Scuderias_ScuderiaId",
                table: "PlayerTeams",
                column: "ScuderiaId",
                principalTable: "Scuderias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
