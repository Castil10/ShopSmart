using System;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmLogin : Form
{
    private readonly BDConexion _conexion;
    private readonly UsersRepository _usersRepository;

    public FrmLogin(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        _usersRepository = new UsersRepository(_conexion);
        InitializeComponent();
        _btnIngresar.Click += OnIngresar;
        _chkMostrar.CheckedChanged += (_, _) => _txtContrasena.UseSystemPasswordChar = !_chkMostrar.Checked;
        KeyDown += FrmLogin_KeyDown;
        Shown += (_, _) => InicializarRoles();
    }

    private void OnIngresar(object? sender, EventArgs e)
    {
        try
        {
            var nombre = _txtUsuario.Text.Trim();
            var contrasena = _txtContrasena.Text;
            var rolSeleccionado = _cmbRol.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Usuario y contraseña son obligatorios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(rolSeleccionado))
            {
                MessageBox.Show("Selecciona un rol para continuar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = _usersRepository.Get(nombre);

            if (usuario is null || usuario.Contrasena != contrasena)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!usuario.Rol.Equals(rolSeleccionado, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"El usuario pertenece al rol '{usuario.Rol}'. Actualiza el rol seleccionado.", "Rol inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Hide();
            using var principal = new FrmPrincipal(usuario, _conexion);
            principal.ShowDialog();
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InicializarRoles()
    {
        _cmbRol.DataSource = _usersRepository.RolesPermitidos.ToList();
        _cmbRol.SelectedIndex = 0;
    }

    private void FrmLogin_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            OnIngresar(this, EventArgs.Empty);
            e.Handled = true;
        }
    }
}
