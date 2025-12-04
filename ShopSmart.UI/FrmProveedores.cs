using System;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmProveedores : Form
{
    private readonly ProveedoresRepository _repo;
    private readonly BDConexion _conexion;

    public FrmProveedores(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        InitializeComponent();
        _repo = new ProveedoresRepository(_conexion);
        _btnGuardar.Click += (_, _) => Guardar();
        Refrescar();
    }

    private void Guardar()
    {
        var proveedor = new Proveedor
        {
            Nombre = _txtNombre.Text,
            Telefono = _txtTelefono.Text,
            Correo = _txtCorreo.Text,
            Direccion = _txtDireccion.Text,
            Activo = true
        };

        try
        {
            proveedor.Id = _repo.Insert(proveedor);
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
