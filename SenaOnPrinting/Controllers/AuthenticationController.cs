using BusinessCape.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Newtonsoft.Json.Linq;
using DataCape.Models;

namespace SenaOnPrinting.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string secret_key;

        private readonly AuthenticationService _service;
        private bool result;

        public AuthenticationController(AuthenticationService service, IConfiguration configuration)
        {
            _service = service;
            secret_key = configuration["Jwt:SecretKey"];
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Dictionary<string, string> data_form)
        {
            string email = data_form.GetValueOrDefault("email", "");
            string password = data_form.GetValueOrDefault("password", "");
            result = _service.Authenticate(email, password);
            if (result)
            {
                var secret = Encoding.ASCII.GetBytes(secret_key);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));                

                var token_descriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.Today.AddDays(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                };

                var token_handler = new JwtSecurityTokenHandler();
                var token_configuration = token_handler.CreateToken(token_descriptor);

                string _token = token_handler.WriteToken(token_configuration);

                return StatusCode(StatusCodes.Status200OK, new { message = "Inicio de Sesion Exitoso", token = _token});
            } else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Inicio de Sesion Incorrecto, intente de nuevo", token = "" });
            }
        }
        [HttpDelete]
        [Route("logout")]
        public IActionResult Logout(string token)
        {
            return null;
        }
    }
}
