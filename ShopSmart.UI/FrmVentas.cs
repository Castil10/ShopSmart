using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.DataStructures;
using ShopSmart.Core.Models;
using ShopSmart.Core.Services;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmVentas : Form
{
    private readonly Inventario _inventario = new();
    private readonly ProductosRepository _productosRepository;
    private readonly VentasRepository _ventasRepository;
    private readonly GestorClientes _gestorClientes = new();
    private readonly QueueCustom<DetalleVenta> _carrito = new();
    private readonly BDConexion _conexion;

    public FrmVentas(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        InitializeComponent();
        _productosRepository = new ProductosRepository(_conexion);
        _ventasRepository = new VentasRepository(_conexion);

        _btnBuscar.Click += (_, _) => BuscarProducto();
        _btnAgregar.Click += (_, _) => AgregarAlCarrito();
        _btnGuardar.Click += (_, _) => GuardarVenta();
        _btnQuitar.Click += (_, _) => QuitarSeleccionado();

        CargarCatalogos();
        RefrescarCarrito();
    }

    private void CargarCatalogos()
    {
        foreach (var producto in _productosRepository.GetAll())
        {
            _inventario.AgregarProducto(producto);
        }

        foreach (var cliente in new ClientesRepository(_conexion).GetAll())
        {
            _gestorClientes.Agregar(cliente);
        }

        _cmbClientes.Items.Clear();
        _cmbClientes.Items.AddRange(_gestorClientes.ObtenerTodos().ToArray());
        _cmbClientes.DisplayMember = nameof(Cliente.Nombre);
    }

    private void BuscarProducto()
    {
        var texto = _txtBuscar.Text;
        var resultado = _inventario.RecorrerSecuencial()
            .FirstOrDefault(p => p.Codigo.Equals(texto, StringComparison.OrdinalIgnoreCase) || p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase));

        if (resultado is null)
        {
            MessageBox.Show("Producto no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _txtBuscar.Text = resultado.Codigo;
    }

    private void AgregarAlCarrito()
    {
        var producto = _inventario.BuscarPorCodigo(_txtBuscar.Text);
        if (producto is null)
        {
            MessageBox.Show("Seleccione un producto válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var cantidad = (int)_numCantidad.Value;
        var detalles = ObtenerCarrito();
        var existente = detalles.FirstOrDefault(d => d.Producto.Codigo.Equals(producto.Codigo, StringComparison.OrdinalIgnoreCase));
        if (existente is not null)
        {
            existente.Cantidad += cantidad;
            existente.Subtotal = existente.Cantidad * existente.PrecioUnitario;
        }
        else
        {
            detalles.Add(new DetalleVenta
            {
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio,
                Subtotal = producto.Precio * cantidad
            });
        }

        ReemplazarCarrito(detalles);
        _txtBuscar.Clear();
        _numCantidad.Value = 1;
        RefrescarCarrito();
    }

    private void RefrescarCarrito()
    {
        var detalles = ObtenerCarrito();
        var vista = detalles
            .Select(d => new
            {
                d.Producto.Codigo,
                Producto = d.Producto.Nombre,
                d.Cantidad,
                Precio = d.PrecioUnitario,
                d.Subtotal
            })
            .ToList();

        _grid.DataSource = vista;
        var total = detalles.Sum(d => d.Subtotal);
        _lblTotal.Text = $"Total: ${total:N2}";
    }

    private void GuardarVenta()
    {
        if (_cmbClientes.SelectedItem is not Cliente cliente)
        {
            MessageBox.Show("Seleccione un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var detalles = new List<DetalleVenta>();
        while (true)
        {
            try
            {
                detalles.Add(_carrito.Dequeue());
            }
            catch
            {
                break;
            }
        }

        if (detalles.Count == 0)
        {
            MessageBox.Show("El carrito está vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var total = detalles.Sum(d => d.Subtotal);
        var venta = new Venta
        {
            Cliente = cliente,
            Detalles = detalles,
            Fecha = DateTime.Now,
            Total = total
        };

        try
        {
            var ventaId = _ventasRepository.Insert(venta);
            foreach (var det in detalles)
            {
                det.Producto.StockActual -= det.Cantidad;
                _productosRepository.Update(det.Producto);
            }

            MessageBox.Show($"Venta #{ventaId} registrada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarCarrito();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo guardar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void QuitarSeleccionado()
    {
        if (_grid.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para quitar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var codigo = _grid.SelectedRows[0].Cells["Codigo"].Value?.ToString();
        if (string.IsNullOrWhiteSpace(codigo))
        {
            return;
        }

        var detalles = ObtenerCarrito();
        var restante = detalles.Where(d => !d.Producto.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)).ToList();
        ReemplazarCarrito(restante);
        RefrescarCarrito();
    }

    private List<DetalleVenta> ObtenerCarrito()
    {
        var detalles = new List<DetalleVenta>();
        var temporal = new QueueCustom<DetalleVenta>();

        while (true)
        {
            try
            {
                var item = _carrito.Dequeue();
                detalles.Add(item);
                temporal.Enqueue(item);
            }
            catch
            {
                break;
            }
        }

        while (true)
        {
            try
            {
                _carrito.Enqueue(temporal.Dequeue());
            }
            catch
            {
                break;
            }
        }

        return detalles;
    }

    private void ReemplazarCarrito(IEnumerable<DetalleVenta> detalles)
    {
        while (true)
        {
            try
            {
                _carrito.Dequeue();
            }
            catch
            {
                break;
            }
        }

        foreach (var detalle in detalles)
        {
            _carrito.Enqueue(detalle);
        }
    }
}
