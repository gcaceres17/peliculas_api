namespace peliculas_api.Models
{
    public class Carrito
    {
        public int IdUsuario { get; set; }

        public int IdPelicula { get; set; }

        public Usuario? usuario { get; set; }
        public Pelicula? pelicula { get; set; }
    }
}
