using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using peliculas_api.Context;
using peliculas_api.Models;


namespace peliculas_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly string KeyValue;
        private readonly string issuer;
        private readonly int expirationTime;

        public LoginController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            this.applicationDbContext = applicationDbContext;
            KeyValue = configuration.GetSection("JWT_KEY").GetSection("Key").Value.ToString();
            issuer = configuration.GetSection("JWT_KEY").GetSection("Issuer").Value.ToString();
            expirationTime = Int32.Parse(configuration.GetSection("JWT_KEY").GetSection("ExpirationTime").Value);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([FromBody] Login usuario)
        {
            Usuario usuarioValido = applicationDbContext.Usuario.Where(u => u.Email == usuario.Email && u.Password == usuario.Password).FirstOrDefault();
            if (usuarioValido != null)
            {
                usuarioValido.token = GetJWT(usuarioValido.Email);
            }

            return Ok(usuarioValido);
        }

        public string GetJWT(string email)
        {
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyValue));
            var secureId = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenBody = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTime),
                signingCredentials: secureId
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenBody);

            return token;
        }
    }
}
