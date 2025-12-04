using System;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Core.Services;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmProductos : Form
{
    private readonly Inventario _inventario = new();
    private readonly ProductosRepository _repo;
    private readonly BDConexion _conexion;

    public FrmProductos(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        InitializeComponent();
        _repo = new ProductosRepository(_conexion);
        _btnGuardar.Click += (_, _) => GuardarProducto();
        _btnEliminar.Click += (_, _) => EliminarProductoSeleccionado();
        CargarDatosIniciales();
    }

    private void CargarDatosIniciales()
    {
        foreach (var producto in _repo.GetAll())
        {
            _inventario.AgregarProducto(producto);
        }

        ActualizarGrid();
    }

    private void ActualizarGrid()
    {
        _grid.DataSource = _inventario.RecorrerSecuencial().ToList();
    }

    private void GuardarProducto()
    {
        try
        {
            var producto = new Producto
            {
                Codigo = _txtCodigo.Text,
                Nombre = _txtNombre.Text,
                Precio = _numPrecio.Value,
                StockActual = (int)_numStock.Value,
                StockMinimo = (int)_numStockMinimo.Value,
                Activo = _chkActivo.Checked
            };

            var existente = _inventario.BuscarPorCodigo(producto.Codigo);
            if (existente is null)
            {
                producto.Id = _repo.Insert(producto);
                _inventario.AgregarProducto(producto);
            }
            else
            {
                producto.Id = existente.Id;
                _repo.Update(producto);
                _inventario.AgregarProducto(producto);
            }

            ActualizarGrid();
            MessageBox.Show("Producto guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void EliminarProductoSeleccionado()
    {
        if (_grid.CurrentRow?.DataBoundItem is not Producto producto)
        {
            MessageBox.Show("Seleccione un producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            _repo.Delete(producto.Id);
            _inventario.EliminarPorCodigo(producto.Codigo);
            ActualizarGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
