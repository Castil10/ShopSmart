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
    private Button _btnCambiarRol = null!;
    private Button _btnLogout = null!;
    private TableLayoutPanel _headerLayout = null!;
    private FlowLayoutPanel _actionsPanel = null!;
    private StatusStrip _statusStrip = null!;
    private ToolStripStatusLabel _statusLabel = null!;
    private ToolStripStatusLabel _dbStatusLabel = null!;
    private FlowLayoutPanel _cardsPanel = null!;

    private void InitializeComponent()
    {
        _menuStrip = new MenuStrip();
        _productosItem = new ToolStripMenuItem();
        _ventasItem = new ToolStripMenuItem();
        _clientesItem = new ToolStripMenuItem();
        _proveedoresItem = new ToolStripMenuItem();
        _reportesItem = new ToolStripMenuItem();
        _headerPanel = new Panel();
        _headerLayout = new TableLayoutPanel();
        _actionsPanel = new FlowLayoutPanel();
        _searchBox = new TextBox();
        _btnSearch = new Button();
        _btnCambiarRol = new Button();
        _welcomeLabel = new Label();
        _subtitleLabel = new Label();
        _cardsPanel = new FlowLayoutPanel();
        _statusStrip = new StatusStrip();
        _statusLabel = new ToolStripStatusLabel();
        _dbStatusLabel = new ToolStripStatusLabel();
        _btnLogout = new Button();
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
        _clientesItem.Click += (_, _) => AbrirClientes();
        //
        // _proveedoresItem
        //
        _proveedoresItem.Name = "_proveedoresItem";
        _proveedoresItem.Size = new System.Drawing.Size(105, 26);
        _proveedoresItem.Text = "Proveedores";
        _proveedoresItem.Click += (_, _) => AbrirProveedores();
        //
        // _reportesItem
        //
        _reportesItem.Name = "_reportesItem";
        _reportesItem.Size = new System.Drawing.Size(82, 26);
        _reportesItem.Text = "Reportes";
        _reportesItem.Click += (_, _) => AbrirReportes();
        //
        // _headerPanel
        //
        _headerPanel.BackColor = System.Drawing.Color.White;
        _headerPanel.Controls.Add(_headerLayout);
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Height = 120;
        _headerPanel.Padding = new Padding(16, 14, 16, 12);

        //
        // _headerLayout
        //
        _headerLayout.ColumnCount = 2;
        _headerLayout.RowCount = 2;
        _headerLayout.Dock = DockStyle.Fill;
        _headerLayout.BackColor = System.Drawing.Color.White;
        _headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        _headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        _headerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _headerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _headerLayout.Controls.Add(_welcomeLabel, 0, 0);
        _headerLayout.Controls.Add(_subtitleLabel, 0, 1);
        _headerLayout.Controls.Add(_actionsPanel, 1, 0);
        _headerLayout.SetRowSpan(_actionsPanel, 2);

        //
        // _actionsPanel
        //
        _actionsPanel.FlowDirection = FlowDirection.LeftToRight;
        _actionsPanel.WrapContents = false;
        _actionsPanel.Dock = DockStyle.Fill;
        _actionsPanel.AutoSize = true;
        _actionsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _actionsPanel.Padding = new Padding(0, 8, 0, 0);
        _actionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _actionsPanel.Controls.Add(_searchBox);
        _actionsPanel.Controls.Add(_btnSearch);
        _actionsPanel.Controls.Add(_btnCambiarRol);
        _actionsPanel.Controls.Add(_btnLogout);
        //
        // _searchBox
        //
        _searchBox.Width = 220;
        _searchBox.PlaceholderText = "Buscar productos, clientes o reportes";
        _searchBox.BorderStyle = BorderStyle.FixedSingle;
        _searchBox.Margin = new Padding(0, 0, 10, 0);
        //
        // _btnSearch
        //
        _btnSearch.AutoSize = true;
        _btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnSearch.Text = "Buscar";
        _btnSearch.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnSearch.ForeColor = System.Drawing.Color.White;
        _btnSearch.FlatStyle = FlatStyle.Flat;
        _btnSearch.FlatAppearance.BorderSize = 0;
        _btnSearch.Cursor = Cursors.Hand;
        _btnSearch.Margin = new Padding(0, 0, 10, 0);
        _btnSearch.Padding = new Padding(12, 8, 12, 8);

        //
        // _btnCambiarRol
        //
        _btnCambiarRol.AutoSize = true;
        _btnCambiarRol.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnCambiarRol.Text = "Cambiar rol";
        _btnCambiarRol.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
        _btnCambiarRol.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
        _btnCambiarRol.FlatStyle = FlatStyle.Flat;
        _btnCambiarRol.FlatAppearance.BorderSize = 0;
        _btnCambiarRol.Cursor = Cursors.Hand;
        _btnCambiarRol.Margin = new Padding(0, 0, 10, 0);
        _btnCambiarRol.Padding = new Padding(12, 8, 12, 8);
        _btnCambiarRol.Click += (_, _) => CambiarRol();
        //
        // _btnLogout
        //
        _btnLogout.AutoSize = true;
        _btnLogout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnLogout.Text = "Salir";
        _btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        _btnLogout.ForeColor = System.Drawing.Color.White;
        _btnLogout.FlatStyle = FlatStyle.Flat;
        _btnLogout.FlatAppearance.BorderSize = 0;
        _btnLogout.Cursor = Cursors.Hand;
        _btnLogout.Padding = new Padding(12, 8, 12, 8);
        _btnLogout.Click += (_, _) => CerrarSesion();
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
