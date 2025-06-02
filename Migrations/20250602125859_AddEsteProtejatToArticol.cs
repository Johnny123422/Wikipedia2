using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wikipedia.Migrations
{
    /// <inheritdoc />
    public partial class AddEsteProtejatToArticol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsteProtejat",
                table: "Articole",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsteProtejat",
                table: "Articole");
        }
    }
}
