using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class DriverAndTeamEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "PlayerTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverPlayerTeam",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "int", nullable: false),
                    PlayerTeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverPlayerTeam", x => new { x.DriversId, x.PlayerTeamsId });
                    table.ForeignKey(
                        name: "FK_DriverPlayerTeam_Driver_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverPlayerTeam_PlayerTeams_PlayerTeamsId",
                        column: x => x.PlayerTeamsId,
                        principalTable: "PlayerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverPlayerTeam_PlayerTeamsId",
                table: "DriverPlayerTeam",
                column: "PlayerTeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Team_TeamId",
                table: "PlayerTeams",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Team_TeamId",
                table: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "DriverPlayerTeam");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "PlayerTeams");
        }
    }
}
