using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace peliculas_api.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    anio = table.Column<int>(type: "integer", nullable: false),
                    duracion = table.Column<int>(type: "integer", nullable: false),
                    genero = table.Column<string>(type: "text", nullable: false),
                    director = table.Column<string>(type: "text", nullable: false),
                    actores = table.Column<string>(type: "text", nullable: false),
                    sinopsis = table.Column<string>(type: "text", nullable: false),
                    portada = table.Column<string>(type: "text", nullable: false),
                    estrellas = table.Column<byte>(type: "smallint", nullable: false),
                    precio = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelicula");
        }
    }
}
