namespace ShopSmart.Core.Models;

public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public Cliente Cliente { get; set; } = new Cliente();
    public List<DetalleVenta> Detalles { get; set; } = new();
    public decimal Total { get; set; }
}
