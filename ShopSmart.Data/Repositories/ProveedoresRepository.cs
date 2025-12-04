using Microsoft.Data.SqlClient;
using ShopSmart.Core.Models;

namespace ShopSmart.Data.Repositories;

public class ProveedoresRepository
{
    private readonly BDConexion _conexion;

    public ProveedoresRepository(BDConexion conexion)
    {
        _conexion = conexion;
    }

    public IEnumerable<Proveedor> GetAll()
    {
        const string query = "SELECT Id, Nombre, Telefono, Correo, Direccion, Activo FROM Proveedores";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return MapProveedor(reader);
        }
    }

    public Proveedor? GetById(int id)
    {
        const string query = "SELECT Id, Nombre, Telefono, Correo, Direccion, Activo FROM Proveedores WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        return reader.Read() ? MapProveedor(reader) : null;
    }

    public int Insert(Proveedor proveedor)
    {
        const string query = @"INSERT INTO Proveedores (Nombre, Telefono, Correo, Direccion, Activo)
                               VALUES (@Nombre, @Telefono, @Correo, @Direccion, @Activo);
                               SELECT SCOPE_IDENTITY();";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
        cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
        cmd.Parameters.AddWithValue("@Correo", proveedor.Correo);
        cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
        cmd.Parameters.AddWithValue("@Activo", proveedor.Activo);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public void Update(Proveedor proveedor)
    {
        const string query = @"UPDATE Proveedores SET Nombre=@Nombre, Telefono=@Telefono, Correo=@Correo,
                               Direccion=@Direccion, Activo=@Activo WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", proveedor.Id);
        cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
        cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
        cmd.Parameters.AddWithValue("@Correo", proveedor.Correo);
        cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
        cmd.Parameters.AddWithValue("@Activo", proveedor.Activo);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        const string query = "DELETE FROM Proveedores WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    private static Proveedor MapProveedor(SqlDataReader reader)
    {
        return new Proveedor
        {
            Id = reader.GetInt32(0),
            Nombre = reader.GetString(1),
            Telefono = reader.GetString(2),
            Correo = reader.GetString(3),
            Direccion = reader.GetString(4),
            Activo = reader.GetBoolean(5)
        };
    }
}
