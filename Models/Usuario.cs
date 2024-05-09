using System.ComponentModel.DataAnnotations;

namespace peliculas_api.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        public List<Favorito>? favorito { get; set; }

        public List<Carrito>? carrito { get; set; }

        public string? token { get; set; }

    }
}
