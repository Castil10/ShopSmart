using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;

namespace ShopSmart.UI;

public partial class FrmLogin : Form
{
    private readonly List<Usuario> _usuariosPermitidos = new()
    {
        new Usuario { NombreUsuario = "admin", Contrasena = "admin" }
    };

    private readonly BDConexion _conexion;

    public FrmLogin(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        InitializeComponent();
        _btnIngresar.Click += OnIngresar;
        _chkMostrar.CheckedChanged += (_, _) => _txtContrasena.UseSystemPasswordChar = !_chkMostrar.Checked;
        KeyDown += FrmLogin_KeyDown;
    }

    private void OnIngresar(object? sender, EventArgs e)
    {
        try
        {
            var usuario = _usuariosPermitidos.FirstOrDefault(u =>
                u.NombreUsuario.Equals(_txtUsuario.Text, StringComparison.OrdinalIgnoreCase)
                && u.Contrasena == _txtContrasena.Text);

            if (usuario is null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    private void FrmLogin_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            OnIngresar(this, EventArgs.Empty);
            e.Handled = true;
        }
    }
}
