using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peliculas_api.Context;
using peliculas_api.Models;

namespace peliculas_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public FavoritoController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet("{idUsuario}")]
        public ActionResult Get(int idUsuario)
        {
            try
            {
                return Ok(applicationDbContext.Favorito.Where(p => p.IdUsuario == idUsuario).Select(p => p.pelicula));

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> Agregar([FromBody] Favorito favorito)
        {
            try
            {
                applicationDbContext.Add(favorito);
                await applicationDbContext.SaveChangesAsync();
                return Ok(favorito);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] Favorito favorito)
        {
            try
            {
                applicationDbContext.Remove(favorito);
                await applicationDbContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
