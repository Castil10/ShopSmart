using System;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmUsuarios : Form
{
    private readonly UsersRepository _usersRepository;
    private readonly BindingSource _bindingSource = new();

    public FrmUsuarios(BDConexion conexion)
    {
        _usersRepository = new UsersRepository(conexion);
        InitializeComponent();
        Shown += (_, _) => InicializarDatos();
        _gridUsuarios.SelectionChanged += GridUsuarios_SelectionChanged;
        _btnAgregar.Click += (_, _) => GuardarUsuario(accion: "agregar");
        _btnActualizar.Click += (_, _) => GuardarUsuario(accion: "actualizar");
        _btnEliminar.Click += (_, _) => EliminarUsuario();
        _btnLimpiar.Click += (_, _) => LimpiarFormulario();
    }

    private void InicializarDatos()
    {
        _cmbRol.DataSource = _usersRepository.RolesPermitidos.ToList();
        _cmbRol.SelectedIndex = 0;
        RefrescarUsuarios();
    }

    private void RefrescarUsuarios()
    {
        var datos = _usersRepository.GetAll()
            .Select(u => new { u.NombreUsuario, u.Rol })
            .ToList();
        _bindingSource.DataSource = datos;
        _gridUsuarios.DataSource = _bindingSource;
        _gridUsuarios.Columns[0].HeaderText = "Usuario";
        _gridUsuarios.Columns[1].HeaderText = "Rol";
        _gridUsuarios.ClearSelection();
    }

    private void GuardarUsuario(string accion)
    {
        bool permitiendoContrasenaVacia = accion.Equals("actualizar", StringComparison.OrdinalIgnoreCase);
        if (!ValidarCampos(out var usuario, out var mensajeError, permitiendoContrasenaVacia))
        {
            MessageBox.Show(mensajeError, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        bool ok = accion == "agregar"
            ? _usersRepository.TryAdd(usuario, out mensajeError)
            : _usersRepository.TryUpdate(usuario, out mensajeError);

        if (!ok)
        {
            MessageBox.Show(mensajeError, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        RefrescarUsuarios();
        MessageBox.Show("Usuario guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LimpiarFormulario();
    }

    private void EliminarUsuario()
    {
        var usuario = _txtUsuario.Text.Trim();
        if (string.IsNullOrWhiteSpace(usuario))
        {
            MessageBox.Show("Seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirmar = MessageBox.Show(
            $"¿Deseas eliminar al usuario '{usuario}'?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmar != DialogResult.Yes)
        {
            return;
        }

        if (!_usersRepository.TryDelete(usuario, out var error))
        {
            MessageBox.Show(error, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        RefrescarUsuarios();
        LimpiarFormulario();
        MessageBox.Show("Usuario eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private bool ValidarCampos(out Usuario usuario, out string mensajeError, bool permitirContrasenaVacia = false)
    {
        mensajeError = string.Empty;
        usuario = new Usuario();

        var nombre = _txtUsuario.Text.Trim();
        var contrasena = _txtContrasena.Text.Trim();
        var rol = _cmbRol.SelectedItem?.ToString() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(nombre))
        {
            mensajeError = "El nombre de usuario es obligatorio.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(contrasena))
        {
            if (!permitirContrasenaVacia)
            {
                mensajeError = "La contraseña es obligatoria.";
                return false;
            }
        }

        if (!string.IsNullOrWhiteSpace(contrasena) && contrasena.Length < 4)
        {
            mensajeError = "La contraseña debe tener al menos 4 caracteres.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(rol))
        {
            mensajeError = "Selecciona un rol.";
            return false;
        }

        usuario = new Usuario
        {
            NombreUsuario = nombre,
            Contrasena = contrasena,
            Rol = rol
        };
        return true;
    }

    private void GridUsuarios_SelectionChanged(object? sender, EventArgs e)
    {
        if (_gridUsuarios.CurrentRow?.DataBoundItem is not null)
        {
            var fila = (dynamic)_gridUsuarios.CurrentRow.DataBoundItem;
            _txtUsuario.Text = fila.NombreUsuario;
            _cmbRol.SelectedItem = fila.Rol;
            _txtContrasena.Clear();
        }
    }

    private void LimpiarFormulario()
    {
        _txtUsuario.Clear();
        _txtContrasena.Clear();
        if (_cmbRol.Items.Count > 0)
        {
            _cmbRol.SelectedIndex = 0;
        }
        _gridUsuarios.ClearSelection();
    }
}
