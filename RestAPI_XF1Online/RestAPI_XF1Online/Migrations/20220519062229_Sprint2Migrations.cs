using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class Sprint2Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ActualState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayerUsername",
                        column: x => x.PlayerUsername,
                        principalTable: "Players",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rankings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionshipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerTeamId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rankings_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rankings_PlayerTeams_PlayerTeamId",
                        column: x => x.PlayerTeamId,
                        principalTable: "PlayerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PlayerUsername",
                table: "PlayerTeams",
                column: "PlayerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ChampionshipId",
                table: "Races",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_ChampionshipId",
                table: "Rankings",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_PlayerTeamId",
                table: "Rankings",
                column: "PlayerTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Rankings");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
