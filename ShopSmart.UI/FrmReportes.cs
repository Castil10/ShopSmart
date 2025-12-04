using System;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmReportes : Form
{
    private readonly BDConexion _conexion;
    private readonly VentasRepository _ventasRepository;
    private readonly ProductosRepository _productosRepository;

    public FrmReportes(BDConexion? conexion = null)
    {
        _conexion = conexion ?? Program.Conexion;
        _ventasRepository = new VentasRepository(_conexion);
        _productosRepository = new ProductosRepository(_conexion);
        InitializeComponent();
        CargarReportes();
    }

    private void CargarReportes()
    {
        CargarVentasDiarias();
        CargarStockBajo();
    }

    private void CargarVentasDiarias()
    {
        var ventas = _ventasRepository.GetAll().ToList();
        var resumen = ventas
            .GroupBy(v => v.Fecha.Date)
            .OrderByDescending(g => g.Key)
            .Select(g => new
            {
                Fecha = g.Key.ToString("dd/MM/yyyy"),
                Ventas = g.Count(),
                Total = g.Sum(v => v.Total)
            })
            .ToList();

        _ventasDiariasGrid.DataSource = resumen;
        _ventasTotalesLabel.Text = $"Ventas totales: ${ventas.Sum(v => v.Total):N2}";
        _movimientosLabel.Text = $"Movimientos registrados: {ventas.Count}";
        _ultimaVentaLabel.Text = ventas.Any()
            ? $"Última venta: {ventas.Max(v => v.Fecha):dd/MM/yyyy HH:mm}"
            : "No hay ventas registradas";
    }

    private void CargarStockBajo()
    {
        var productos = _productosRepository.GetAll()
            .Where(p => p.StockActual <= p.StockMinimo || p.StockActual < 5)
            .Select(p => new
            {
                p.Codigo,
                Producto = p.Nombre,
                Stock = p.StockActual,
                Mínimo = p.StockMinimo
            })
            .ToList();

        _stockGrid.DataSource = productos;
    }
}
