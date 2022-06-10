using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class PlayerNotificationsNullableLeague : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerNotifications_PrivateLeagues_PrivateLeagueName",
                table: "PlayerNotifications");

            migrationBuilder.AlterColumn<string>(
                name: "PrivateLeagueName",
                table: "PlayerNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerNotifications_PrivateLeagues_PrivateLeagueName",
                table: "PlayerNotifications",
                column: "PrivateLeagueName",
                principalTable: "PrivateLeagues",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerNotifications_PrivateLeagues_PrivateLeagueName",
                table: "PlayerNotifications");

            migrationBuilder.AlterColumn<string>(
                name: "PrivateLeagueName",
                table: "PlayerNotifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerNotifications_PrivateLeagues_PrivateLeagueName",
                table: "PlayerNotifications",
                column: "PrivateLeagueName",
                principalTable: "PrivateLeagues",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
