using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmPrincipal : Form
{
    private readonly Usuario _usuario;
    private readonly BDConexion _conexion;

    public FrmPrincipal(Usuario usuario, BDConexion conexion)
    {
        _usuario = usuario;
        _conexion = conexion;
        InitializeComponent();
        ConfigurarDashboard();
    }

    private void AbrirProductos()
    {
        using var form = new FrmProductos(_conexion);
        form.ShowDialog();
    }

    private void AbrirVentas()
    {
        using var form = new FrmVentas(_conexion);
        form.ShowDialog();
    }

    private void AbrirReportes()
    {
        using var form = new FrmReportes(_conexion);
        form.ShowDialog();
    }

    private void ConfigurarDashboard()
    {
        Text = $"ShopSmart - Gestión Retail | Bienvenido {_usuario.NombreUsuario}";
        _welcomeLabel.Text = $"Hola, {_usuario.NombreUsuario}";
        _subtitleLabel.Text = "Administra tu negocio de forma rápida";

        // Update status strip
        try
        {
            _statusLabel.Text = $"Usuario: {_usuario.NombreUsuario}";
            _dbStatusLabel.Text = _conexion is null ? "DB: No configurada" : "DB: Conectada";
        }
        catch
        {
            // ignore if status controls are not initialized yet
        }

        _cardsPanel.Controls.Clear();
        _cardsPanel.Controls.Add(CrearCard("Productos", "Gestiona el catálogo y los precios", AbrirProductos));
        _cardsPanel.Controls.Add(CrearCard("Ventas", "Registra ventas y calcula totales", AbrirVentas));
        _cardsPanel.Controls.Add(CrearCard("Clientes", "Consulta historiales y contactos", () => new FrmClientes(_conexion).ShowDialog()));
        _cardsPanel.Controls.Add(CrearCard("Proveedores", "Organiza tus proveedores", () => new FrmProveedores(_conexion).ShowDialog()));
        _cardsPanel.Controls.Add(CrearCard("Reportes", "Visualiza ventas y alertas de stock", AbrirReportes));
    }

    private Control CrearCard(string titulo, string descripcion, Action onClick)
    {
        var card = new Panel
        {
            Width = 260,
            Height = 150,
            BackColor = Color.White,
            Padding = new Padding(14),
            Margin = new Padding(10),
            BorderStyle = BorderStyle.FixedSingle
        };

        var titleLabel = new Label
        {
            Text = titulo,
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(23, 58, 94),
            AutoSize = true
        };

        var descLabel = new Label
        {
            Text = descripcion,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(96, 125, 139),
            AutoSize = false,
            Height = 52,
            Width = 220,
            Top = 34
        };

        var actionButton = new Button
        {
            Text = "Abrir",
            BackColor = Color.FromArgb(23, 58, 94),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Padding = new Padding(12, 8, 12, 8),
            AutoSize = true,
            Top = 92,
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left
        };

        actionButton.FlatAppearance.BorderSize = 0;

        void Accion(object? _, EventArgs __) => onClick();

        actionButton.Click += Accion;
        card.Click += Accion;
        // Hover effects to improve interactivity
        card.MouseEnter += (_, _) => card.BackColor = Color.FromArgb(250, 250, 250);
        card.MouseLeave += (_, _) => card.BackColor = Color.White;
        card.Controls.Add(titleLabel);
        card.Controls.Add(descLabel);
        card.Controls.Add(actionButton);
        return card;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ConfigurarBusquedaRapida();
    }

    private void ConfigurarBusquedaRapida()
    {
        try
        {
            _btnSearch.Click += (_, __) => EjecutarBusqueda();
            _searchBox.KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    args.Handled = true;
                    EjecutarBusqueda();
                }
            };
        }
        catch
        {
            // ignore if controls not available
        }
    }

    private void EjecutarBusqueda()
    {
        var q = _searchBox.Text?.Trim();
        if (string.IsNullOrWhiteSpace(q))
        {
            _statusLabel.Text = "Ingrese término de búsqueda";
            return;
        }

        try
        {
            var productosRepo = new ProductosRepository(_conexion);
            var clientesRepo = new ClientesRepository(_conexion);
            var proveedoresRepo = new ProveedoresRepository(_conexion);

            var producto = productosRepo.GetAll().FirstOrDefault(p =>
                p.Codigo.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                p.Nombre.Contains(q, StringComparison.OrdinalIgnoreCase));

            if (producto is not null)
            {
                _statusLabel.Text = $"Producto encontrado: {producto.Nombre}";
                AbrirProductos();
                return;
            }

            var cliente = clientesRepo.GetAll().FirstOrDefault(c =>
                c.Nombre.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                c.Identificacion.Contains(q, StringComparison.OrdinalIgnoreCase));
            if (cliente is not null)
            {
                _statusLabel.Text = $"Cliente encontrado: {cliente.Nombre}";
                new FrmClientes(_conexion).ShowDialog();
                return;
            }

            var proveedor = proveedoresRepo.GetAll().FirstOrDefault(p =>
                p.Nombre.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                p.Contacto.Contains(q, StringComparison.OrdinalIgnoreCase));
            if (proveedor is not null)
            {
                _statusLabel.Text = $"Proveedor encontrado: {proveedor.Nombre}";
                new FrmProveedores(_conexion).ShowDialog();
                return;
            }

            if (q.Contains("venta", StringComparison.OrdinalIgnoreCase))
            {
                AbrirVentas();
                return;
            }

            if (q.Contains("reporte", StringComparison.OrdinalIgnoreCase))
            {
                AbrirReportes();
                return;
            }

            _statusLabel.Text = $"No se encontraron resultados para '{q}'";
        }
        catch (Exception ex)
        {
            _statusLabel.Text = $"No se pudo completar la búsqueda: {ex.Message}";
        }
    }
}
