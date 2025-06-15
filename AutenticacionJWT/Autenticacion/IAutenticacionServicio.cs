namespace AutenticacionJWT.Autenticacion
{
	public interface IAutenticacionServicio
	{
		Task<string> GenerarTokennAsync(string nombreUsuario, string contrasena);	
	}
}
