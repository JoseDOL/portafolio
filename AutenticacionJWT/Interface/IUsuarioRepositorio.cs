using AutenticacionJWT.Models;

namespace AutenticacionJWT.Interface
{
	public interface IUsuarioRepositorio
	{
		Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);	
	}
}
