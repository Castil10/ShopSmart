using ShopSmart.Core.Models;
using ShopSmart.Data;
using System.Windows.Forms;

namespace ShopSmart.UI;


public partial class FrmPrincipal
{
    private MenuStrip _menuStrip = null!;
    private ToolStripMenuItem _productosItem = null!;
    private ToolStripMenuItem _ventasItem = null!;
    private ToolStripMenuItem _clientesItem = null!;
    private ToolStripMenuItem _proveedoresItem = null!;
    private ToolStripMenuItem _reportesItem = null!;
    private Panel _headerPanel = null!;
    private Label _welcomeLabel = null!;
    private Label _subtitleLabel = null!;
    private TextBox _searchBox = null!;
    private Button _btnSearch = null!;
    private StatusStrip _statusStrip = null!;
    private ToolStripStatusLabel _statusLabel = null!;
    private ToolStripStatusLabel _dbStatusLabel = null!;
    private FlowLayoutPanel _cardsPanel = null!;

    public FrmPrincipal(Usuario usuario, BDConexion conexion)
    {
        _usuario = usuario;
        _conexion = conexion;

        InitializeComponent();

        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;

        Text = $"ShopSmart - Panel principal ({_usuario.NombreUsuario})";

        ConstruirDashboard();
    }

    private void ConstruirDashboard()
    {
        throw new NotImplementedException();
    }

    private void InitializeComponent()
    {
        _menuStrip = new MenuStrip();
        _productosItem = new ToolStripMenuItem();
        _ventasItem = new ToolStripMenuItem();
        _clientesItem = new ToolStripMenuItem();
        _proveedoresItem = new ToolStripMenuItem();
        _reportesItem = new ToolStripMenuItem();
        _headerPanel = new Panel();
        _searchBox = new TextBox();
        _btnSearch = new Button();
        _welcomeLabel = new Label();
        _subtitleLabel = new Label();
        _cardsPanel = new FlowLayoutPanel();
        _statusStrip = new StatusStrip();
        _statusLabel = new ToolStripStatusLabel();
        _dbStatusLabel = new ToolStripStatusLabel();
        SuspendLayout();
        //
        // _menuStrip
        //
        _menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
        _menuStrip.Items.AddRange(new ToolStripItem[] { _productosItem, _ventasItem, _clientesItem, _proveedoresItem, _reportesItem });
        _menuStrip.Location = new System.Drawing.Point(0, 0);
        _menuStrip.Name = "_menuStrip";
        _menuStrip.Size = new System.Drawing.Size(900, 30);
        _menuStrip.TabIndex = 0;
        _menuStrip.Text = "menuStrip1";
        //
        // _productosItem
        //
        _productosItem.Name = "_productosItem";
        _productosItem.Size = new System.Drawing.Size(90, 26);
        _productosItem.Text = "Productos";
        _productosItem.Click += (_, _) => AbrirProductos();
        //
        // _ventasItem
        //
        _ventasItem.Name = "_ventasItem";
        _ventasItem.Size = new System.Drawing.Size(65, 26);
        _ventasItem.Text = "Ventas";
        _ventasItem.Click += (_, _) => AbrirVentas();
        //
        // _clientesItem
        //
        _clientesItem.Name = "_clientesItem";
        _clientesItem.Size = new System.Drawing.Size(79, 26);
        _clientesItem.Text = "Clientes";
        _clientesItem.Click += (_, _) => new FrmClientes().ShowDialog();
        //
        // _proveedoresItem
        //
        _proveedoresItem.Name = "_proveedoresItem";
        _proveedoresItem.Size = new System.Drawing.Size(105, 26);
        _proveedoresItem.Text = "Proveedores";
        _proveedoresItem.Click += (_, _) => new FrmProveedores().ShowDialog();
        //
        // _reportesItem
        //
        _reportesItem.Name = "_reportesItem";
        _reportesItem.Size = new System.Drawing.Size(82, 26);
        _reportesItem.Text = "Reportes";
        _reportesItem.DropDownItems.Add("Ventas diarias (TODO)");
        _reportesItem.DropDownItems.Add("Stock bajo (TODO)");
        _reportesItem.DropDownItems.Add("Productos más vendidos (TODO)");
        //
        // _headerPanel
        //
        _headerPanel.BackColor = System.Drawing.Color.White;
        _headerPanel.Controls.Add(_welcomeLabel);
        _headerPanel.Controls.Add(_subtitleLabel);
        _headerPanel.Controls.Add(_searchBox);
        _headerPanel.Controls.Add(_btnSearch);
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Height = 120;
        _headerPanel.Padding = new Padding(20, 18, 20, 16);
        //
        // _searchBox
        //
        _searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _searchBox.Location = new System.Drawing.Point(600, 22);
        _searchBox.Size = new System.Drawing.Size(200, 28);
        _searchBox.PlaceholderText = "Buscar productos, clientes...";
        //
        // _btnSearch
        //
        _btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnSearch.Location = new System.Drawing.Point(808, 20);
        _btnSearch.Size = new System.Drawing.Size(70, 32);
        _btnSearch.Text = "Buscar";
        _btnSearch.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnSearch.ForeColor = System.Drawing.Color.White;
        _btnSearch.FlatStyle = FlatStyle.Flat;
        _btnSearch.FlatAppearance.BorderSize = 0;
        // _welcomeLabel
        //
        _welcomeLabel.AutoSize = true;
        _welcomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _welcomeLabel.Location = new System.Drawing.Point(14, 16);
        _welcomeLabel.Name = "_welcomeLabel";
        _welcomeLabel.Size = new System.Drawing.Size(283, 41);
        _welcomeLabel.Text = "Bienvenido a POS";
        //
        // _subtitleLabel
        //
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _subtitleLabel.Location = new System.Drawing.Point(17, 62);
        _subtitleLabel.Name = "_subtitleLabel";
        _subtitleLabel.Size = new System.Drawing.Size(299, 25);
        _subtitleLabel.Text = "Selecciona un módulo para continuar";
        //
        // _cardsPanel
        //
        _cardsPanel.Dock = DockStyle.Fill;
        _cardsPanel.FlowDirection = FlowDirection.LeftToRight;
        _cardsPanel.WrapContents = true;
        _cardsPanel.Padding = new Padding(12);
        _cardsPanel.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        _cardsPanel.AutoScroll = true;
        //
        // _statusStrip
        //
        _statusStrip.Items.AddRange(new ToolStripItem[] { _statusLabel, _dbStatusLabel });
        _statusStrip.Dock = DockStyle.Bottom;
        _statusLabel.Text = "Usuario: -";
        _dbStatusLabel.Text = "DB: Desconocida";
        //
        // FrmPrincipal
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        ClientSize = new System.Drawing.Size(900, 640);
        Controls.Add(_cardsPanel);
        Controls.Add(_statusStrip);
        Controls.Add(_headerPanel);
        Controls.Add(_menuStrip);
        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        MainMenuStrip = _menuStrip;
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ShopSmart Heladería";
        ResumeLayout(false);
        PerformLayout();
    }
}
