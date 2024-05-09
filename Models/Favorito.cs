namespace peliculas_api.Models
{
    public class Favorito
    {
        public int IdUsuario { get; set; }

        public int IdPelicula { get; set;}

        public Usuario? usuario { get; set; }
        public Pelicula? pelicula { get; set; }
    }
}
