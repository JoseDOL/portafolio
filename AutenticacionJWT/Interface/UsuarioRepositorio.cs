using AutenticacionJWT.Models;

namespace AutenticacionJWT.Interface
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{
		private readonly List<Usuario> _usuarios = new List<Usuario>
		{
			new Usuario{ Id = 1, NombreUsuario = "admin", contrasena = "admin123", Rol = "Administrador" },
			new Usuario{ Id = 2, NombreUsuario = "Usuario", contrasena = "user123", Rol = "Usuario" }
		};
		public Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
		{
			var usuario = _usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
			return Task.FromResult(usuario);
		}
	}
}
