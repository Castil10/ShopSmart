using System;
using System.Drawing;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;

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
        _cardsPanel.Controls.Add(CrearCard("Reportes", "Próximamente métricas y gráficos", () => MessageBox.Show("Reportes en construcción", "Reportes")));
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
        // Simple search handling: quick demo search that opens Productos
        try
        {
            _btnSearch.Click += (_, __) =>
            {
                var q = _searchBox.Text?.Trim();
                if (string.IsNullOrEmpty(q))
                {
                    _statusLabel.Text = "Ingrese término de búsqueda";
                    return;
                }

                if (q.Contains("prod", StringComparison.OrdinalIgnoreCase) || q.Contains("producto", StringComparison.OrdinalIgnoreCase))
                {
                    AbrirProductos();
                    return;
                }

                _statusLabel.Text = $"No se encontraron resultados para '{q}'";
            };
        }
        catch
        {
            // ignore if controls not available
        }
    }
}
