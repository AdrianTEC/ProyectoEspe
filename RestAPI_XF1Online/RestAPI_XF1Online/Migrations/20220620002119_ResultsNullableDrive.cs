using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class ResultsNullableDrive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Drivers_CodigoXFIAXFIA_Code",
                table: "RaceResults");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoXFIAXFIA_Code",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Drivers_CodigoXFIAXFIA_Code",
                table: "RaceResults",
                column: "CodigoXFIAXFIA_Code",
                principalTable: "Drivers",
                principalColumn: "XFIA_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Drivers_CodigoXFIAXFIA_Code",
                table: "RaceResults");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoXFIAXFIA_Code",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Drivers_CodigoXFIAXFIA_Code",
                table: "RaceResults",
                column: "CodigoXFIAXFIA_Code",
                principalTable: "Drivers",
                principalColumn: "XFIA_Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
