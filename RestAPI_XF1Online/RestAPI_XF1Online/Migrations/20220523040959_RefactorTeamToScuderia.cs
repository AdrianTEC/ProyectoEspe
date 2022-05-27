using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class RefactorTeamToScuderia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
            name: "Teams",
            schema: "dbo",
            newName: "Scuderias",
            newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
            name: "Scuderias",
            schema: "dbo",
            newName: "Teams",
            newSchema: "dbo");
        }
    }
}
