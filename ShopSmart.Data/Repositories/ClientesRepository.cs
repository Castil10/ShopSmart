using Microsoft.Data.SqlClient;
using ShopSmart.Core.Models;

namespace ShopSmart.Data.Repositories;

public class ClientesRepository
{
    private readonly BDConexion _conexion;

    public ClientesRepository(BDConexion conexion)
    {
        _conexion = conexion;
    }

    public IEnumerable<Cliente> GetAll()
    {
        const string query = "SELECT Id, Documento, Nombre, Telefono, Correo, Direccion, Activo FROM Clientes";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return MapCliente(reader);
        }
    }

    public Cliente? GetById(int id)
    {
        const string query = "SELECT Id, Documento, Nombre, Telefono, Correo, Direccion, Activo FROM Clientes WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        return reader.Read() ? MapCliente(reader) : null;
    }

    public int Insert(Cliente cliente)
    {
        const string query = @"INSERT INTO Clientes (Documento, Nombre, Telefono, Correo, Direccion, Activo)
                               VALUES (@Documento, @Nombre, @Telefono, @Correo, @Direccion, @Activo);
                               SELECT SCOPE_IDENTITY();";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
        cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
        cmd.Parameters.AddWithValue("@Activo", cliente.Activo);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return Convert.ToInt32(result);
    }

    public void Update(Cliente cliente)
    {
        const string query = @"UPDATE Clientes SET Documento=@Documento, Nombre=@Nombre, Telefono=@Telefono,
                               Correo=@Correo, Direccion=@Direccion, Activo=@Activo WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", cliente.Id);
        cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
        cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
        cmd.Parameters.AddWithValue("@Activo", cliente.Activo);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        const string query = "DELETE FROM Clientes WHERE Id=@Id";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    private static Cliente MapCliente(SqlDataReader reader)
    {
        return new Cliente
        {
            Id = reader.GetInt32(0),
            Documento = reader.GetString(1),
            Nombre = reader.GetString(2),
            Telefono = reader.GetString(3),
            Correo = reader.GetString(4),
            Direccion = reader.GetString(5),
            Activo = reader.GetBoolean(6)
        };
    }
}
