using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wikipedia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domenii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domenii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPublicare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DomeniuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articole_Domenii_DomeniuId",
                        column: x => x.DomeniuId,
                        principalTable: "Domenii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articole_DomeniuId",
                table: "Articole",
                column: "DomeniuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articole");

            migrationBuilder.DropTable(
                name: "Domenii");
        }
    }
}
