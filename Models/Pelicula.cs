using System.ComponentModel.DataAnnotations;

namespace peliculas_api.Models
{
    public class Pelicula
    {

        [Key]
        public int id { get; set; }
        public string titulo { get; set; }

        public int anio { get; set; }

        public int duracion { get; set; }

        public string genero { get; set; }

        public string director { get; set; }

        public string actores { get; set; }

        public string sinopsis { get; set; }

        public string portada { get; set; }

        public byte estrellas { get; set; }

        public decimal precio { get; set; }

        public List<Favorito> favorito { get; set; }

        public List<Carrito> carrito { get; set; }

    }
}
