using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class PlayerNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifiedPlayerUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateLeagueName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvitedPlayerUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerNotifications_Players_InvitedPlayerUsername",
                        column: x => x.InvitedPlayerUsername,
                        principalTable: "Players",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_PlayerNotifications_Players_NotifiedPlayerUsername",
                        column: x => x.NotifiedPlayerUsername,
                        principalTable: "Players",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerNotifications_PrivateLeagues_PrivateLeagueName",
                        column: x => x.PrivateLeagueName,
                        principalTable: "PrivateLeagues",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerNotifications_InvitedPlayerUsername",
                table: "PlayerNotifications",
                column: "InvitedPlayerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerNotifications_NotifiedPlayerUsername",
                table: "PlayerNotifications",
                column: "NotifiedPlayerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerNotifications_PrivateLeagueName",
                table: "PlayerNotifications",
                column: "PrivateLeagueName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerNotifications");
        }
    }
}
