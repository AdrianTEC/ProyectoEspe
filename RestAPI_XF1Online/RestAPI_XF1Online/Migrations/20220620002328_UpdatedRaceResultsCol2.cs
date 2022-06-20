﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    public partial class UpdatedRaceResultsCol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Drivers_CodigoXFIAXFIA_Code",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Scuderias_ConstructorXFIA_Code",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_CodigoXFIAXFIA_Code",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_ConstructorXFIA_Code",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "CodigoXFIAXFIA_Code",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "ConstructorXFIA_Code",
                table: "RaceResults");

            migrationBuilder.AddColumn<string>(
                name: "CodigoXFIA",
                table: "RaceResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Constructor",
                table: "RaceResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoXFIA",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Constructor",
                table: "RaceResults");

            migrationBuilder.AddColumn<string>(
                name: "CodigoXFIAXFIA_Code",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstructorXFIA_Code",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_CodigoXFIAXFIA_Code",
                table: "RaceResults",
                column: "CodigoXFIAXFIA_Code");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_ConstructorXFIA_Code",
                table: "RaceResults",
                column: "ConstructorXFIA_Code");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Drivers_CodigoXFIAXFIA_Code",
                table: "RaceResults",
                column: "CodigoXFIAXFIA_Code",
                principalTable: "Drivers",
                principalColumn: "XFIA_Code");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Scuderias_ConstructorXFIA_Code",
                table: "RaceResults",
                column: "ConstructorXFIA_Code",
                principalTable: "Scuderias",
                principalColumn: "XFIA_Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
