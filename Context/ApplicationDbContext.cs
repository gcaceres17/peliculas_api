using Microsoft.EntityFrameworkCore;
using peliculas_api.Models;

namespace peliculas_api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Favorito> Favorito { get; set; }
        public DbSet<Carrito> Carrito{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorito>().HasKey(x => new {x.IdUsuario, x.IdPelicula} );
            modelBuilder.Entity<Favorito>().HasOne(x => x.usuario)
                .WithMany(f => f.favorito)
                .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<Favorito>().HasOne(x => x.pelicula)
                .WithMany(f => f.favorito)
                .HasForeignKey(x => x.IdPelicula);


            modelBuilder.Entity<Carrito>().HasKey(x => new { x.IdUsuario, x.IdPelicula });
            modelBuilder.Entity<Carrito>().HasOne(x => x.usuario)
                .WithMany(c => c.carrito)
                .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<Carrito>().HasOne(x => x.pelicula)
                .WithMany(c => c.carrito)
                .HasForeignKey(x => x.IdPelicula);

        }
    }
}
