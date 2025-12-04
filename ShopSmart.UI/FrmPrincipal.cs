using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShopSmart.Core.Models;
using ShopSmart.Data;
using ShopSmart.Data.Repositories;

namespace ShopSmart.UI;

public partial class FrmPrincipal : Form
{
    private Usuario _usuario;
    private readonly BDConexion _conexion;
    private bool _puedeAdministrarUsuarios;
    private HashSet<string> _modulosPermitidos;
    private readonly UsersRepository _usersRepository;

    public FrmPrincipal(Usuario usuario, BDConexion conexion)
    {
        _usuario = usuario;
        _conexion = conexion;
        _usersRepository = new UsersRepository(conexion);
        ActualizarPermisos();
        InitializeComponent();
        ConfigurarDashboard();
    }

    private void AbrirProductos()
    {
        if (!TienePermiso("Productos"))
        {
            MostrarAvisoPermisos();
            return;
        }

        using var form = new FrmProductos(_conexion);
        form.ShowDialog();
    }

    private void AbrirClientes()
    {
        if (!TienePermiso("Clientes"))
        {
            MostrarAvisoPermisos();
            return;
        }

        using var form = new FrmClientes(_conexion);
        form.ShowDialog();
    }

    private void AbrirProveedores()
    {
        if (!TienePermiso("Proveedores"))
        {
            MostrarAvisoPermisos();
            return;
        }

        using var form = new FrmProveedores(_conexion);
        form.ShowDialog();
    }

    private void AbrirVentas()
    {
        if (!TienePermiso("Ventas"))
        {
            MostrarAvisoPermisos();
            return;
        }

        using var form = new FrmVentas(_conexion);
        form.ShowDialog();
    }

    private void AbrirReportes()
    {
        if (!TienePermiso("Reportes"))
        {
            MostrarAvisoPermisos();
            return;
        }

        using var form = new FrmReportes(_conexion);
        form.ShowDialog();
    }

    private void AbrirUsuarios()
    {
        if (!_puedeAdministrarUsuarios)
        {
            MessageBox.Show("Solo administradores o jefes pueden gestionar usuarios.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var form = new FrmUsuarios(_conexion);
        form.ShowDialog();
    }

    private void ActualizarPermisos()
    {
        _puedeAdministrarUsuarios = !_usuario.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase);
        _modulosPermitidos = ObtenerModulosPermitidos(_usuario.Rol);
    }

    private void CambiarRol()
    {
        var roles = _usersRepository.RolesPermitidos.ToList();
        using var dialog = new Form
        {
            Text = "Cambiar rol",
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ClientSize = new Size(320, 170),
            BackColor = Color.FromArgb(245, 247, 250)
        };

        var lbl = new Label
        {
            Text = "Selecciona el nuevo rol para esta sesión",
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 40,
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(12, 10, 12, 6),
            ForeColor = Color.FromArgb(55, 71, 79),
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point)
        };

        var cmbRoles = new ComboBox
        {
            Dock = DockStyle.Top,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Margin = new Padding(12, 0, 12, 8),
            Height = 36,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        };
        cmbRoles.DataSource = roles;
        cmbRoles.SelectedItem = roles.FirstOrDefault(r => r.Equals(_usuario.Rol, StringComparison.OrdinalIgnoreCase));

        var botones = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(12, 6, 12, 12),
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };

        var btnAceptar = new Button
        {
            Text = "Aplicar", BackColor = Color.FromArgb(23, 58, 94), ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat, FlatAppearance = { BorderSize = 0 }, AutoSize = true,
            Padding = new Padding(12, 8, 12, 8), DialogResult = DialogResult.OK
        };
        var btnCancelar = new Button
        {
            Text = "Cancelar", BackColor = Color.FromArgb(136, 152, 170), ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat, FlatAppearance = { BorderSize = 0 }, AutoSize = true,
            Padding = new Padding(12, 8, 12, 8), DialogResult = DialogResult.Cancel
        };

        botones.Controls.Add(btnCancelar);
        botones.Controls.Add(btnAceptar);

        dialog.Controls.Add(botones);
        dialog.Controls.Add(cmbRoles);
        dialog.Controls.Add(lbl);
        dialog.AcceptButton = btnAceptar;
        dialog.CancelButton = btnCancelar;

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var nuevoRol = cmbRoles.SelectedItem?.ToString();
        if (string.IsNullOrWhiteSpace(nuevoRol))
        {
            return;
        }

        if (nuevoRol.Equals(_usuario.Rol, StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("El usuario ya tiene asignado ese rol.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var actualizacion = new Usuario
        {
            NombreUsuario = _usuario.NombreUsuario,
            Contrasena = string.Empty,
            Rol = nuevoRol
        };

        if (!_usersRepository.TryUpdate(actualizacion, out var error))
        {
            MessageBox.Show(error, "No se pudo cambiar el rol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _usuario.Rol = nuevoRol;
        ActualizarPermisos();
        ConfigurarDashboard();
        MessageBox.Show($"Rol actualizado a '{nuevoRol}'.", "Rol cambiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            _dbStatusLabel.Text += $" | Rol: {_usuario.Rol}";
            _btnCambiarRol.Enabled = _puedeAdministrarUsuarios;
        }
        catch
        {
            // ignore if status controls are not initialized yet
        }

        _cardsPanel.Controls.Clear();
        _cardsPanel.Controls.Add(CrearCard("Productos", "Gestiona el catálogo y los precios", AbrirProductos, !TienePermiso("Productos")));
        _cardsPanel.Controls.Add(CrearCard("Ventas", "Registra ventas y calcula totales", AbrirVentas, !TienePermiso("Ventas")));
        _cardsPanel.Controls.Add(CrearCard("Clientes", "Consulta historiales y contactos", AbrirClientes, !TienePermiso("Clientes")));
        _cardsPanel.Controls.Add(CrearCard("Proveedores", "Organiza tus proveedores", AbrirProveedores, !TienePermiso("Proveedores")));
        _cardsPanel.Controls.Add(CrearCard("Reportes", "Visualiza ventas y alertas de stock", AbrirReportes, !TienePermiso("Reportes")));
        _cardsPanel.Controls.Add(CrearCard("Usuarios", "Administra accesos y roles", AbrirUsuarios, !_puedeAdministrarUsuarios || !TienePermiso("Usuarios")));

        _productosItem.Enabled = TienePermiso("Productos");
        _ventasItem.Enabled = TienePermiso("Ventas");
        _clientesItem.Enabled = TienePermiso("Clientes");
        _proveedoresItem.Enabled = TienePermiso("Proveedores");
        _reportesItem.Enabled = TienePermiso("Reportes");
    }

    private Control CrearCard(string titulo, string descripcion, Action onClick, bool deshabilitado = false)
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

        if (deshabilitado)
        {
            actionButton.Enabled = false;
            actionButton.BackColor = Color.FromArgb(189, 189, 189);
            titleLabel.ForeColor = Color.FromArgb(120, 144, 156);
            descLabel.ForeColor = Color.FromArgb(144, 164, 174);
            card.Cursor = Cursors.No;
            card.Click -= Accion;
        }
        // Hover effects to improve interactivity
        card.MouseEnter += (_, _) => card.BackColor = Color.FromArgb(250, 250, 250);
        card.MouseLeave += (_, _) => card.BackColor = Color.White;
        card.Controls.Add(titleLabel);
        card.Controls.Add(descLabel);
        card.Controls.Add(actionButton);
        return card;
    }

    private bool TienePermiso(string modulo)
    {
        return _modulosPermitidos.Contains(modulo);
    }

    private static HashSet<string> ObtenerModulosPermitidos(string rol)
    {
        if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
        {
            return new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Productos", "Ventas", "Clientes", "Proveedores", "Reportes", "Usuarios"
            };
        }

        if (rol.Equals("Jefe", StringComparison.OrdinalIgnoreCase))
        {
            return new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Productos", "Ventas", "Clientes", "Proveedores", "Reportes"
            };
        }

        return new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Productos", "Ventas", "Clientes"
        };
    }

    private void MostrarAvisoPermisos()
    {
        MessageBox.Show("No tienes permisos para acceder a este módulo con tu rol actual.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CerrarSesion()
    {
        Hide();
        using var login = new FrmLogin(_conexion);
        login.ShowDialog();
        Close();
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
                AbrirClientes();
                return;
            }

            var proveedor = proveedoresRepo.GetAll().FirstOrDefault(p =>
                p.Nombre.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                p.Contacto.Contains(q, StringComparison.OrdinalIgnoreCase));
            if (proveedor is not null)
            {
                _statusLabel.Text = $"Proveedor encontrado: {proveedor.Nombre}";
                AbrirProveedores();
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
