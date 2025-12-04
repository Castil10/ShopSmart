namespace ShopSmart.Core.Models;

public class Usuario
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public string Rol { get; set; } = "Administrador";
}
