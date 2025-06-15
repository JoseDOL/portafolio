using AutenticacionJWT.Autenticacion;
using AutenticacionJWT.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacionJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAutenticacionServicio _autenticacionServicio;
        public AutenticacionController(IAutenticacionServicio autenticacionServicio) 
        {
            _autenticacionServicio = autenticacionServicio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario moodel)
        {
            try
            {
                var token = await _autenticacionServicio.GenerarTokennAsync(moodel.NombreUsuario, moodel.contrasena);
				var value = new { Token= token };
				return Ok(value);
			}
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { result = "Credenciales Inavlidas" });
            }
        }
    }
}
