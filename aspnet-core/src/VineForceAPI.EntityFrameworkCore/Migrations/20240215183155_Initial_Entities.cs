using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VineForceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCountry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppState",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppState_AppCountry_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AppCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppState_CountryId",
                table: "AppState",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppState");

            migrationBuilder.DropTable(
                name: "AppCountry");
        }
    }
}
