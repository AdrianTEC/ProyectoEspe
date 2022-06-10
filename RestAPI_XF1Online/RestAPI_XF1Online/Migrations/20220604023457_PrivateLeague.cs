using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class PrivateLeague : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrivateLeagueName",
                table: "PlayerTeams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivateLeagueName",
                table: "Players",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PrivateLeagues",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeagueCreatorUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvitationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfParticipants = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateLeagues", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PrivateLeagueName",
                table: "PlayerTeams",
                column: "PrivateLeagueName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PrivateLeagueName",
                table: "Players",
                column: "PrivateLeagueName");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PrivateLeagues_PrivateLeagueName",
                table: "Players",
                column: "PrivateLeagueName",
                principalTable: "PrivateLeagues",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_PrivateLeagues_PrivateLeagueName",
                table: "PlayerTeams",
                column: "PrivateLeagueName",
                principalTable: "PrivateLeagues",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PrivateLeagues_PrivateLeagueName",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_PrivateLeagues_PrivateLeagueName",
                table: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "PrivateLeagues");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_PrivateLeagueName",
                table: "PlayerTeams");

            migrationBuilder.DropIndex(
                name: "IX_Players_PrivateLeagueName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PrivateLeagueName",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "PrivateLeagueName",
                table: "Players");
        }
    }
}
