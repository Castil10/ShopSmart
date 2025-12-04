namespace ShopSmart.Core.Models;

/// <summary>
/// Pedido de reposición al proveedor.
/// </summary>
public class Pedido
{
    public int Id { get; set; }
    public Proveedor Proveedor { get; set; } = new Proveedor();
    public List<Producto> Productos { get; set; } = new();
    public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    public string Estado { get; set; } = "Pendiente";
}
