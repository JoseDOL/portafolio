
using AutenticacionJWT.Interface;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace AutenticacionJWT.Autenticacion
{
	public class AutenticacionServicio : IAutenticacionServicio
	{
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		private readonly string _claveSecreta;

		public AutenticacionServicio (IUsuarioRepositorio usuarioRepositorio, IConfiguration config)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_claveSecreta = config ["Jwt:ClaveSecreta"];
		}

		public async Task<string>  GenerarTokennAsync(string nombreUsuario, string contrasena)
		{
			var usuario = await _usuarioRepositorio.ObtenerPorNombreUsuarioAsync(nombreUsuario);
			if (usuario == null || usuario.contrasena != contrasena) 
			{
				throw new UnauthorizedAccessException("Credenciales inválidas");
			}

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, usuario.NombreUsuario),
				new Claim(ClaimTypes.Role, usuario.Rol)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: "MiApi",
				audience: "MiCliente",
				claims: claims,
				expires: DateTime.Now.AddMinutes(5),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
