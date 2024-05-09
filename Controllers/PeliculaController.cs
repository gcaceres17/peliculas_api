using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculas_api.Context;
using peliculas_api.Models;

namespace peliculas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PeliculaController(ApplicationDbContext applicationDbcontext)
        {
            this.context = applicationDbcontext;
        }

        [HttpGet("{idUsuario}")]
        public ActionResult Get(int idUsuario)
        {
            try
            {
                return Ok(context.Pelicula.Select(p => new
                {
                    p.id,
                    p.titulo,
                    p.anio,
                    p.duracion,
                    p.genero,
                    p.director,
                    p.actores,
                    p.sinopsis,
                    p.portada,
                    p.estrellas,
                    p.precio,
                    favorito = p.favorito.Where(f => f.IdUsuario == idUsuario).Select(fa =>
                                                    new { fa.IdPelicula }),
                    carrito = p.carrito.Where(c => c.IdUsuario == idUsuario).Select(ca =>
                                    new { ca.IdPelicula })
                }).ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint mejorado con manejo asincrónico y validación de entrada
        [HttpGet("BuscarPor/{idUsuario}/{valor}")]
        public async Task<IActionResult> GetAsync(string valor, int idUsuario)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return BadRequest("El valor de búsqueda no puede estar vacío.");
            }

            try
            {
                var resultado = await context.Pelicula
                    .Where(p => p.genero.Contains(valor) || p.titulo.Contains(valor) || p.actores.Contains(valor))
                    .Select(p => new {
                        p.id,
                        p.titulo,
                        p.anio,
                        p.duracion,
                        p.genero,
                        p.director,
                        p.actores,
                        p.sinopsis,
                        p.portada,
                        p.estrellas,
                        p.precio,
                        favorito = p.favorito.Where(f => f.IdUsuario == idUsuario).Select(fa =>
                                                    new { fa.IdPelicula }),
                        carrito = p.carrito.Where(c => c.IdUsuario == idUsuario).Select(ca =>
                                        new { ca.IdPelicula })
                    })
                    .ToListAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Aquí podrías agregar logging del error antes de responder
                return StatusCode(500,  ex.Message);
            }
        }

        // Endpoint mejorado con manejo asincrónico y validación de entrada
        [HttpGet("GetDestacadas/{idUsuario}/{valor}")]
        public async Task<IActionResult> GetAsync(int idUsuario, int valor)
        {
            if (valor.CompareTo(0) == 0)
            {
                return BadRequest("El valor de búsqueda no puede ser 0.");

            }
            try
            {
                var result = await context.Pelicula
                    .Where(p => p.estrellas >= valor)
                    .Select(p => new {
                        p.id,
                        p.titulo,
                        p.anio,
                        p.duracion,
                        p.genero,
                        p.director,
                        p.actores,
                        p.sinopsis,
                        p.portada,
                        p.estrellas,
                        p.precio,
                        favorito = p.favorito.Where(f => f.IdUsuario == idUsuario).Select(fa =>
                                                    new { fa.IdPelicula }),
                        carrito = p.carrito.Where(c => c.IdUsuario == idUsuario).Select(ca =>
                                        new { ca.IdPelicula })
                    })
                    .ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
