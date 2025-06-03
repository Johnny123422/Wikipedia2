using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wikipedia.Migrations
{
    /// <inheritdoc />
    public partial class AdaugaCampImagine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagine",
                table: "Articole",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagine",
                table: "Articole");
        }
    }
}
