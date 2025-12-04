namespace ShopSmart.Core.Models;

/// <summary>
/// Acción simple para registrar operaciones deshacibles.
/// </summary>
public class AccionSistema
{
    public string Descripcion { get; set; } = string.Empty;
    public Action? Deshacer { get; set; }
}
