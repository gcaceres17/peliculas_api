using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace peliculas_api.Migrations
{
    /// <inheritdoc />
    public partial class CarritoAndFavoritoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    IdPelicula = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => new { x.IdUsuario, x.IdPelicula });
                    table.ForeignKey(
                        name: "FK_Carrito_Pelicula_IdPelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorito",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    IdPelicula = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorito", x => new { x.IdUsuario, x.IdPelicula });
                    table.ForeignKey(
                        name: "FK_Favorito_Pelicula_IdPelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorito_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdPelicula",
                table: "Carrito",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_Favorito_IdPelicula",
                table: "Favorito",
                column: "IdPelicula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Favorito");
        }
    }
}
