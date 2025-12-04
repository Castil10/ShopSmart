using Microsoft.Data.SqlClient;
using ShopSmart.Core.Models;

namespace ShopSmart.Data.Repositories;

public class ProductosRepository
{
    private readonly BDConexion _conexion;

    public ProductosRepository(BDConexion conexion)
    {
        _conexion = conexion;
    }

    public IEnumerable<Producto> GetAll()
    {
        const string query = "SELECT Id, Codigo, Nombre, Descripcion, Precio, StockActual, StockMinimo, Activo FROM Productos";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return MapProducto(reader);
        }
    }

    public Producto? GetById(int id)
    {
        const string query = "SELECT Id, Codigo, Nombre, Descripcion, Precio, StockActual, StockMinimo, Activo FROM Productos WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        return reader.Read() ? MapProducto(reader) : null;
    }

    public int Insert(Producto producto)
    {
        const string query = @"INSERT INTO Productos (Codigo, Nombre, Descripcion, Precio, StockActual, StockMinimo, Activo)
                               VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @StockActual, @StockMinimo, @Activo);
                               SELECT SCOPE_IDENTITY();";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
        cmd.Parameters.AddWithValue("@Precio", producto.Precio);
        cmd.Parameters.AddWithValue("@StockActual", producto.StockActual);
        cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
        cmd.Parameters.AddWithValue("@Activo", producto.Activo);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public void Update(Producto producto)
    {
        const string query = @"UPDATE Productos SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion,
                               Precio=@Precio, StockActual=@StockActual, StockMinimo=@StockMinimo, Activo=@Activo
                               WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", producto.Id);
        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
        cmd.Parameters.AddWithValue("@Precio", producto.Precio);
        cmd.Parameters.AddWithValue("@StockActual", producto.StockActual);
        cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
        cmd.Parameters.AddWithValue("@Activo", producto.Activo);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        const string query = "DELETE FROM Productos WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    // TODO: Reporte de productos con stock bajo (StockActual <= StockMinimo)
    public IEnumerable<Producto> GetProductosConStockBajo()
    {
        const string query = "SELECT Id, Codigo, Nombre, Descripcion, Precio, StockActual, StockMinimo, Activo FROM Productos WHERE StockActual <= StockMinimo";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return MapProducto(reader);
        }
    }

    private static Producto MapProducto(SqlDataReader reader)
    {
        return new Producto
        {
            Id = reader.GetInt32(0),
            Codigo = reader.GetString(1),
            Nombre = reader.GetString(2),
            Descripcion = reader.GetString(3),
            Precio = reader.GetDecimal(4),
            StockActual = reader.GetInt32(5),
            StockMinimo = reader.GetInt32(6),
            Activo = reader.GetBoolean(7)
        };
    }
}
