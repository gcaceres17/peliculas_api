﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using peliculas_api.Context;

#nullable disable

namespace peliculas_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240504194644_MakeUsuarioAndPeliculaOptional")]
    partial class MakeUsuarioAndPeliculaOptional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("peliculas_api.Models.Carrito", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<int>("IdPelicula")
                        .HasColumnType("integer");

                    b.HasKey("IdUsuario", "IdPelicula");

                    b.HasIndex("IdPelicula");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("peliculas_api.Models.Favorito", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<int>("IdPelicula")
                        .HasColumnType("integer");

                    b.HasKey("IdUsuario", "IdPelicula");

                    b.HasIndex("IdPelicula");

                    b.ToTable("Favorito");
                });

            modelBuilder.Entity("peliculas_api.Models.Pelicula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("actores")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("anio")
                        .HasColumnType("integer");

                    b.Property<string>("director")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("duracion")
                        .HasColumnType("integer");

                    b.Property<byte>("estrellas")
                        .HasColumnType("smallint");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("portada")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("precio")
                        .HasColumnType("numeric");

                    b.Property<string>("sinopsis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("peliculas_api.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("peliculas_api.Models.Carrito", b =>
                {
                    b.HasOne("peliculas_api.Models.Pelicula", "pelicula")
                        .WithMany("carrito")
                        .HasForeignKey("IdPelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("peliculas_api.Models.Usuario", "usuario")
                        .WithMany("carrito")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pelicula");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("peliculas_api.Models.Favorito", b =>
                {
                    b.HasOne("peliculas_api.Models.Pelicula", "pelicula")
                        .WithMany("favorito")
                        .HasForeignKey("IdPelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("peliculas_api.Models.Usuario", "usuario")
                        .WithMany("favorito")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pelicula");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("peliculas_api.Models.Pelicula", b =>
                {
                    b.Navigation("carrito");

                    b.Navigation("favorito");
                });

            modelBuilder.Entity("peliculas_api.Models.Usuario", b =>
                {
                    b.Navigation("carrito");

                    b.Navigation("favorito");
                });
#pragma warning restore 612, 618
        }
    }
}
