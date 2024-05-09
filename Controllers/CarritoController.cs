using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculas_api.Context;
using peliculas_api.Models;

namespace peliculas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarritoController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost("comprar")]
        public async Task<IActionResult> Comprar([FromBody] List<Carrito> carritos)
        {
            try
            {
                applicationDbContext.Carrito.AddRangeAsync(carritos);
                await applicationDbContext.SaveChangesAsync();

                return Ok(carritos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var obj = await applicationDbContext.Carrito.Select(c => c.IdPelicula).ToListAsync();
                return Ok(obj);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
