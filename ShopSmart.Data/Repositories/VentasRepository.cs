using Microsoft.Data.SqlClient;
using ShopSmart.Core.Models;

namespace ShopSmart.Data.Repositories;

public class VentasRepository
{
    private readonly BDConexion _conexion;

    public VentasRepository(BDConexion conexion)
    {
        _conexion = conexion;
    }

    public IEnumerable<Venta> GetAll()
    {
        const string query = "SELECT Id, Fecha, ClienteId, Total FROM Ventas";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return new Venta
            {
                Id = reader.GetInt32(0),
                Fecha = reader.GetDateTime(1),
                Cliente = new Cliente { Id = reader.GetInt32(2) },
                Total = reader.GetDecimal(3)
            };
        }
    }

    public int Insert(Venta venta)
    {
        const string queryVenta = @"INSERT INTO Ventas (Fecha, ClienteId, Total)
                                  VALUES (@Fecha, @ClienteId, @Total);
                                  SELECT SCOPE_IDENTITY();";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(queryVenta, conn);
        cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
        cmd.Parameters.AddWithValue("@ClienteId", venta.Cliente.Id);
        cmd.Parameters.AddWithValue("@Total", venta.Total);
        conn.Open();
        var ventaId = Convert.ToInt32(cmd.ExecuteScalar());

        foreach (var detalle in venta.Detalles)
        {
            InsertDetalle(conn, ventaId, detalle);
        }

        return ventaId;
    }

    private static void InsertDetalle(SqlConnection conn, int ventaId, DetalleVenta detalle)
    {
        const string queryDetalle = @"INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario, Subtotal)
                                     VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario, @Subtotal)";
        using var detalleCmd = new SqlCommand(queryDetalle, conn);
        detalleCmd.Parameters.AddWithValue("@VentaId", ventaId);
        detalleCmd.Parameters.AddWithValue("@ProductoId", detalle.Producto.Id);
        detalleCmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
        detalleCmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
        detalleCmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
        detalleCmd.ExecuteNonQuery();
    }

    // TODO: Reporte de ventas diarias (filtrar por rango de fechas)
    // TODO: Reporte de productos más vendidos
}
