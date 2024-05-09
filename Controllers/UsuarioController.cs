using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peliculas_api.Context;
using peliculas_api.Models;

namespace peliculas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UsuarioController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                applicationDbContext.Usuario.Add(usuario);
                await applicationDbContext.SaveChangesAsync();
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
