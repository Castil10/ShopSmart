using System;
using System.Collections.Generic;
using System.Linq;
using ShopSmart.Core.Models;

namespace ShopSmart.Data.Repositories;

public class UsersRepository
{
    private static readonly string[] _rolesPermitidos = { "Administrador", "Jefe", "Vendedor" };

    private static readonly List<Usuario> _usuarios = new()
    {
        new Usuario { NombreUsuario = "admin", Contrasena = "admin", Rol = "Administrador" },
        new Usuario { NombreUsuario = "jefe", Contrasena = "jefe123", Rol = "Jefe" },
        new Usuario { NombreUsuario = "ventas", Contrasena = "ventas123", Rol = "Vendedor" }
    };

    public UsersRepository(BDConexion conexion)
    {
    }

    public IReadOnlyCollection<string> RolesPermitidos => _rolesPermitidos;

    public IEnumerable<Usuario> GetAll()
    {
        return _usuarios.Select(Clone).ToList();
    }

    public Usuario? Get(string username)
    {
        return _usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase)) is { } usuario
            ? Clone(usuario)
            : null;
    }

    public bool TryAdd(Usuario usuario, out string error)
    {
        if (!Validar(usuario, out error))
        {
            return false;
        }

        if (_usuarios.Any(u => u.NombreUsuario.Equals(usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase)))
        {
            error = "Ya existe un usuario con ese nombre.";
            return false;
        }

        _usuarios.Add(Clone(usuario));
        return true;
    }

    public bool TryUpdate(Usuario usuario, out string error)
    {
        if (!Validar(usuario, out error, allowEmptyPassword: true))
        {
            return false;
        }

        var existente = _usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase));
        if (existente is null)
        {
            error = "Usuario no encontrado.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(usuario.Contrasena))
        {
            usuario.Contrasena = existente.Contrasena;
        }

        if (EsUltimoAdministrador(existente) && !usuario.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
        {
            error = "Debe existir al menos un administrador.";
            return false;
        }

        existente.Contrasena = usuario.Contrasena;
        existente.Rol = usuario.Rol;
        return true;
    }

    public bool TryDelete(string username, out string error)
    {
        error = string.Empty;
        var usuario = _usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (usuario is null)
        {
            error = "Usuario no encontrado.";
            return false;
        }

        if (EsUltimoAdministrador(usuario))
        {
            error = "No se puede eliminar el último administrador.";
            return false;
        }

        _usuarios.Remove(usuario);
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

    private static Usuario Clone(Usuario usuario)
    {
        return new Usuario
        {
            NombreUsuario = usuario.NombreUsuario,
            Contrasena = usuario.Contrasena,
            Rol = usuario.Rol
        };
    }

    private static bool EsUltimoAdministrador(Usuario usuario)
    {
        return usuario.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)
            && _usuarios.Count(u => u.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) == 1;
    }
}
