using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class LastScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastScore",
                table: "Scuderias",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "RaceResults",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LastScore",
                table: "Drivers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastScore",
                table: "Scuderias");

            migrationBuilder.DropColumn(
                name: "LastScore",
                table: "Drivers");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "RaceResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
