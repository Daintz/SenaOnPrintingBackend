using BusinessCape.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Newtonsoft.Json.Linq;
using DataCape.Models;
using PersistenceCape.Interfaces;
using PersistenceCape.EmailConfiguration;
using NuGet.Common;
using Microsoft.AspNetCore.Authorization;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string secret_key;

        private readonly AuthenticationService _service;

        //private readonly IAppPermissionService _appPermissionService;

        private readonly IEmailRepository _emailRepository;

        private bool result;

        public AuthenticationController(AuthenticationService service, IConfiguration configuration, IEmailRepository emailRepository)
        {
            _service = service;
            secret_key = configuration["Jwt:SecretKey"];
            _emailRepository = emailRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> data_form)
        {            
            string email = data_form.GetValueOrDefault("email", "");
            string password = data_form.GetValueOrDefault("password", "");
            var user = await _service.Authenticate(email, password);            

            if (user != null)
            {
                //HashSet<String> appPermissions = await _appPermissionService.GetPermissionsAsync(user.Id);
                var secret = Encoding.ASCII.GetBytes(secret_key);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Names));
                claims.AddClaim(new Claim(ClaimTypes.Email, email));
                claims.AddClaim(new Claim("role", user.RoleId.ToString()));
                //claims.AddClaim(new Claim("permissions", appPermissions.ToString()));


                var token_descriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.Today.AddDays(8),
                    Audience = "http://localhost:7262/",
                    Issuer = "http://localhost:7262/",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                };

                var token_handler = new JwtSecurityTokenHandler();
                var token_configuration = token_handler.CreateToken(token_descriptor);

                string _token = token_handler.WriteToken(token_configuration);

                return StatusCode(StatusCodes.Status200OK, new { message = "Inicio de Sesion Exitoso", token = _token});
            } else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Credenciales incorrectas, intente de nuevo", token = "" });
            }
        }
        [HttpDelete]
        [Route("logout")]
        public IActionResult Logout(string token)
        {
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("forgot_password")]
        public async Task<IActionResult> ForgotPassword([FromBody] Dictionary<string, string> recovery_email)
        {            
            string email = recovery_email.GetValueOrDefault("email", "");
            var user = await _service.ForgotPassword(email);
            if (user != null && user.ForgotPasswordToken != null)
            {
                var token = user.ForgotPasswordToken;
                var subject = "SENAonPrinting - Recuperar contraseña";
                var forgotPasswordLink = $"http://localhost:5173/restaurar_contraseña?token={token}&email={email}";                
                var message = new Message(new string[] { user.Email }, subject, forgotPasswordLink);

                _emailRepository.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK, new { message = "Correo de restauracion de contraseña ha sido exitosamente enviado, por favor revise su bandeja de entrada" });
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { message = "La direccion de correo proporcionada no se encuentra en el sistema." });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("recovery_password")]
        public async Task<IActionResult> RecoveryPassword([FromBody] Dictionary<string, string> recovery_data)
        {
            string email = recovery_data.GetValueOrDefault("email", "");
            string token = recovery_data.GetValueOrDefault("token", "");
            string password = recovery_data.GetValueOrDefault("password", "");
            string confirmPassword = recovery_data.GetValueOrDefault("confirmPassword", "");
            var result = await _service.RecoveryPassword(email, token, password, confirmPassword);
            if (result)
            {                
                return StatusCode(StatusCodes.Status200OK, new { message = "Contraseña restaurada con exito" });                
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { messaqe = "Ocurrio un problema con la restauracion de la contraseña" });
            }
        }
    }
}
