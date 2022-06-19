using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class RaceResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    CodigoXFIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    PosicionCalificacion = table.Column<int>(type: "int", nullable: false),
                    Q1 = table.Column<bool>(type: "bit", nullable: false),
                    Q2 = table.Column<bool>(type: "bit", nullable: false),
                    Q3 = table.Column<bool>(type: "bit", nullable: false),
                    SinCalificarCalificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescalificadoCalificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosicionCarrera = table.Column<int>(type: "int", nullable: false),
                    VueltaMasRapida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GanoACompaneroEquipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinCalificarCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescalificadoCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceResults_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RaceId",
                table: "RaceResults",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceResults");
        }
    }
}
