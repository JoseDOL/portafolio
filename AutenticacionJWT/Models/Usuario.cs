namespace AutenticacionJWT.Models
{
	public class Usuario
	{
		public int Id { get; set; }
		public string NombreUsuario { get; set; }
		public string contrasena { get; set; }
		public string Rol {get; set; }
	}
}
