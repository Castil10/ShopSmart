using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using ShopSmart.Core.Models;

namespace ShopSmart.Data.Repositories;

public class UsersRepository
{
    private static readonly string[] _rolesPermitidos = { "Administrador", "Jefe", "Vendedor" };
    private readonly BDConexion _conexion;

    public UsersRepository(BDConexion conexion)
    {
        _conexion = conexion;
        AsegurarAdminPorDefecto();
    }

    public IReadOnlyCollection<string> RolesPermitidos => _rolesPermitidos;

    public IEnumerable<Usuario> GetAll()
    {
        const string query = "SELECT NombreUsuario, Contrasena, Rol FROM Usuarios ORDER BY NombreUsuario";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return MapUsuario(reader);
        }
    }

    public Usuario? Get(string username)
    {
        const string query = "SELECT NombreUsuario, Contrasena, Rol FROM Usuarios WHERE NombreUsuario = @Nombre";
        using var conn = _conexion.CrearConexion();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Nombre", username);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        return reader.Read() ? MapUsuario(reader) : null;
    }

    public bool TryAdd(Usuario usuario, out string error)
    {
        if (!Validar(usuario, out error))
        {
            return false;
        }

        const string existeQuery = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Nombre";
        const string insertQuery = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol) VALUES (@Nombre, @Contrasena, @Rol)";

        using var conn = _conexion.CrearConexion();
        using var existeCmd = new SqlCommand(existeQuery, conn);
        using var insertCmd = new SqlCommand(insertQuery, conn);

        existeCmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
        insertCmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
        insertCmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
        insertCmd.Parameters.AddWithValue("@Rol", usuario.Rol);

        conn.Open();
        var count = (int)(existeCmd.ExecuteScalar() ?? 0);
        if (count > 0)
        {
            error = "Ya existe un usuario con ese nombre.";
            return false;
        }

        insertCmd.ExecuteNonQuery();
        return true;
    }

    public bool TryUpdate(Usuario usuario, out string error)
    {
        if (!Validar(usuario, out error, allowEmptyPassword: true))
        {
            return false;
        }

        const string obtenerQuery = "SELECT NombreUsuario, Contrasena, Rol FROM Usuarios WHERE NombreUsuario = @Nombre";
        const string updateQuery = "UPDATE Usuarios SET Contrasena = @Contrasena, Rol = @Rol WHERE NombreUsuario = @Nombre";
        using var conn = _conexion.CrearConexion();
        using var obtenerCmd = new SqlCommand(obtenerQuery, conn);
        using var updateCmd = new SqlCommand(updateQuery, conn);

        obtenerCmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
        updateCmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
        updateCmd.Parameters.AddWithValue("@Rol", usuario.Rol);

        conn.Open();
        using var reader = obtenerCmd.ExecuteReader();
        if (!reader.Read())
        {
            error = "Usuario no encontrado.";
            return false;
        }

        var actual = MapUsuario(reader);
        reader.Close();

        if (string.IsNullOrWhiteSpace(usuario.Contrasena))
        {
            usuario.Contrasena = actual.Contrasena;
        }

        if (EsUltimoAdministrador(conn, actual.NombreUsuario) && !usuario.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
        {
            error = "Debe existir al menos un administrador.";
            return false;
        }

        updateCmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
        updateCmd.ExecuteNonQuery();
        return true;
    }

    public bool TryDelete(string username, out string error)
    {
        error = string.Empty;
        const string obtenerQuery = "SELECT Rol FROM Usuarios WHERE NombreUsuario = @Nombre";
        const string deleteQuery = "DELETE FROM Usuarios WHERE NombreUsuario = @Nombre";

        using var conn = _conexion.CrearConexion();
        using var obtenerCmd = new SqlCommand(obtenerQuery, conn);
        using var deleteCmd = new SqlCommand(deleteQuery, conn);

        obtenerCmd.Parameters.AddWithValue("@Nombre", username);
        deleteCmd.Parameters.AddWithValue("@Nombre", username);

        conn.Open();
        var rol = obtenerCmd.ExecuteScalar()?.ToString();
        if (rol is null)
        {
            error = "Usuario no encontrado.";
            return false;
        }

        if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase) && EsUltimoAdministrador(conn, username))
        {
            error = "No se puede eliminar el último administrador.";
            return false;
        }

        deleteCmd.ExecuteNonQuery();
        return true;
    }

    private bool Validar(Usuario usuario, out string error, bool allowEmptyPassword = false)
    {
        error = string.Empty;
        if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
        {
            error = "El usuario es obligatorio.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(usuario.Contrasena))
        {
            if (!allowEmptyPassword)
            {
                error = "La contraseña es obligatoria.";
                return false;
            }
        }
        else if (usuario.Contrasena.Length < 4)
        {
            error = "La contraseña debe tener al menos 4 caracteres.";
            return false;
        }

        if (!_rolesPermitidos.Contains(usuario.Rol, StringComparer.OrdinalIgnoreCase))
        {
            error = "Rol inválido.";
            return false;
        }

        return true;
    }

    private static Usuario MapUsuario(SqlDataReader reader)
    {
        return new Usuario
        {
            NombreUsuario = reader.GetString(0),
            Contrasena = reader.GetString(1),
            Rol = reader.GetString(2)
        };
    }

    private static bool EsUltimoAdministrador(SqlConnection conn, string usuarioActual)
    {
        const string countAdmins = "SELECT COUNT(*) FROM Usuarios WHERE Rol = 'Administrador' AND NombreUsuario <> @Nombre";
        using var cmd = new SqlCommand(countAdmins, conn);
        cmd.Parameters.AddWithValue("@Nombre", usuarioActual);
        var restantes = (int)(cmd.ExecuteScalar() ?? 0);
        return restantes == 0;
    }

    private void AsegurarAdminPorDefecto()
    {
        const string query = @"IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = 'admin')
                               BEGIN
                                   INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol)
                                   VALUES ('admin', 'admin', 'Administrador')
                               END";
        try
        {
            using var conn = _conexion.CrearConexion();
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        {
            // Evitamos romper el flujo de la UI si la base no está lista.
        }
    }
}
