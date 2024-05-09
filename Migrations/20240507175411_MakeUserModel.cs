using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace peliculas_api.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "Usuario");
        }
    }
}
