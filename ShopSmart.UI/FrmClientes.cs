using System;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmClientes : Form
{
    private readonly ClientesRepository _repo;
    private readonly BDConexion _conexion;

    public FrmClientes(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        InitializeComponent();
        _repo = new ClientesRepository(_conexion);
        _btnGuardar.Click += (_, _) => Guardar();
        Refrescar();
    }

    private void Guardar()
    {
        var cliente = new Cliente
        {
            Documento = _txtDocumento.Text,
            Nombre = _txtNombre.Text,
            Telefono = _txtTelefono.Text,
            Correo = _txtCorreo.Text,
            Direccion = _txtDireccion.Text,
            Activo = true
        };

        try
        {
            cliente.Id = _repo.Insert(cliente);
            Refrescar();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Refrescar()
    {
        _grid.DataSource = _repo.GetAll().ToList();
    }
}
