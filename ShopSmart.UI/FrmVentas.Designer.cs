using System.Windows.Forms;

namespace ShopSmart.UI;

public partial class FrmVentas
{
    private Panel _headerPanel = null!;
    private Label _titleLabel = null!;
    private Label _subtitleLabel = null!;
    private TableLayoutPanel _mainLayout = null!;
    private TableLayoutPanel _filtersLayout = null!;
    private DataGridView _grid = null!;
    private TextBox _txtBuscar = null!;
    private ComboBox _cmbClientes = null!;
    private Button _btnBuscar = null!;
    private Button _btnAgregar = null!;
    private Button _btnGuardar = null!;
    private Button _btnQuitar = null!;
    private Label _lblTotal = null!;
    private NumericUpDown _numCantidad = null!;
    private Label _lblProductoTitle = null!;
    private Label _lblClienteTitle = null!;
    private Panel _footerPanel = null!;

    private void InitializeComponent()
    {
        _headerPanel = new Panel();
        _titleLabel = new Label();
        _subtitleLabel = new Label();
        _mainLayout = new TableLayoutPanel();
        _filtersLayout = new TableLayoutPanel();
        _txtBuscar = new TextBox();
        _cmbClientes = new ComboBox();
        _btnBuscar = new Button();
        _btnAgregar = new Button();
        _btnGuardar = new Button();
        _btnQuitar = new Button();
        _lblTotal = new Label();
        _numCantidad = new NumericUpDown();
        _lblProductoTitle = new Label();
        _lblClienteTitle = new Label();
        _grid = new DataGridView();
        _footerPanel = new Panel();
        SuspendLayout();
        //
        // _headerPanel
        //
        _headerPanel.BackColor = System.Drawing.Color.White;
        _headerPanel.Controls.Add(_titleLabel);
        _headerPanel.Controls.Add(_subtitleLabel);
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Height = 82;
        _headerPanel.Padding = new Padding(16, 12, 16, 8);
        //
        // _titleLabel
        //
        _titleLabel.AutoSize = true;
        _titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _titleLabel.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _titleLabel.Location = new System.Drawing.Point(12, 8);
        _titleLabel.Name = "_titleLabel";
        _titleLabel.Size = new System.Drawing.Size(178, 32);
        _titleLabel.Text = "Gestión ventas";
        //
        // _subtitleLabel
        //
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _subtitleLabel.Location = new System.Drawing.Point(14, 42);
        _subtitleLabel.Name = "_subtitleLabel";
        _subtitleLabel.Size = new System.Drawing.Size(276, 23);
        _subtitleLabel.Text = "Busca productos y arma tus pedidos";
        //
        // _mainLayout
        //
        _mainLayout.ColumnCount = 1;
        _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _mainLayout.RowCount = 3;
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _mainLayout.Dock = DockStyle.Fill;
        _mainLayout.Padding = new Padding(10, 6, 10, 10);
        _mainLayout.Controls.Add(_filtersLayout, 0, 0);
        _mainLayout.Controls.Add(_grid, 0, 1);
        _mainLayout.Controls.Add(_footerPanel, 0, 2);
        _mainLayout.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        //
        // _filtersLayout
        //
        _filtersLayout.BackColor = System.Drawing.Color.White;
        _filtersLayout.ColumnCount = 6;
        _filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
        _filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        _filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        _filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _filtersLayout.RowCount = 2;
        _filtersLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _filtersLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _filtersLayout.Dock = DockStyle.Top;
        _filtersLayout.Padding = new Padding(12, 10, 12, 8);
        _filtersLayout.AutoSize = true;
        _filtersLayout.Controls.Add(_lblProductoTitle, 0, 0);
        _filtersLayout.Controls.Add(_lblClienteTitle, 2, 0);
        _filtersLayout.Controls.Add(_txtBuscar, 0, 1);
        _filtersLayout.Controls.Add(_btnBuscar, 1, 1);
        _filtersLayout.Controls.Add(_cmbClientes, 2, 1);
        _filtersLayout.Controls.Add(_numCantidad, 3, 1);
        _filtersLayout.Controls.Add(_btnAgregar, 4, 1);
        _filtersLayout.Controls.Add(_btnGuardar, 5, 0);
        _filtersLayout.Controls.Add(_btnQuitar, 5, 1);
        //
        // _lblProductoTitle
        //
        _lblProductoTitle.AutoSize = true;
        _lblProductoTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _lblProductoTitle.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _lblProductoTitle.Margin = new Padding(0, 0, 0, 4);
        _lblProductoTitle.Text = "Producto o código";
        //
        // _lblClienteTitle
        //
        _lblClienteTitle.AutoSize = true;
        _lblClienteTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _lblClienteTitle.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _lblClienteTitle.Margin = new Padding(12, 0, 0, 4);
        _lblClienteTitle.Text = "Cliente y cantidad";
        //
        // _txtBuscar
        //
        _txtBuscar.PlaceholderText = "Código o nombre";
        _txtBuscar.Width = 150;
        _txtBuscar.Margin = new Padding(0, 2, 10, 0);
        _txtBuscar.BorderStyle = BorderStyle.FixedSingle;
        //
        // _cmbClientes
        //
        _cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbClientes.Width = 150;
        _cmbClientes.Margin = new Padding(12, 2, 10, 0);
        //
        // _numCantidad
        //
        _numCantidad.Minimum = 1;
        _numCantidad.Maximum = 500;
        _numCantidad.Value = 1;
        _numCantidad.Margin = new Padding(0, 2, 8, 0);
        _numCantidad.Width = 110;
        _numCantidad.TextAlign = HorizontalAlignment.Center;
        //
        // _btnBuscar
        //
        _btnBuscar.Text = "Buscar";
        _btnBuscar.Margin = new Padding(0, 2, 8, 0);
        _btnBuscar.Padding = new Padding(12, 8, 12, 8);
        _btnBuscar.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnBuscar.FlatStyle = FlatStyle.Flat;
        _btnBuscar.FlatAppearance.BorderSize = 0;
        _btnBuscar.ForeColor = System.Drawing.Color.White;
        _btnBuscar.AutoSize = true;
        _btnBuscar.Cursor = Cursors.Hand;
        //
        // _btnAgregar
        //
        _btnAgregar.Text = "Agregar";
        _btnAgregar.Margin = new Padding(0, 2, 8, 0);
        _btnAgregar.Padding = new Padding(12, 8, 12, 8);
        _btnAgregar.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
        _btnAgregar.FlatStyle = FlatStyle.Flat;
        _btnAgregar.FlatAppearance.BorderSize = 0;
        _btnAgregar.ForeColor = System.Drawing.Color.White;
        _btnAgregar.AutoSize = true;
        _btnAgregar.Cursor = Cursors.Hand;
        //
        // _btnGuardar
        //
        _btnGuardar.Text = "Guardar venta";
        _btnGuardar.Margin = new Padding(12, 0, 0, 4);
        _btnGuardar.Padding = new Padding(12, 8, 12, 8);
        _btnGuardar.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnGuardar.FlatStyle = FlatStyle.Flat;
        _btnGuardar.FlatAppearance.BorderSize = 0;
        _btnGuardar.ForeColor = System.Drawing.Color.White;
        _btnGuardar.AutoSize = true;
        _btnGuardar.Anchor = AnchorStyles.Right;
        _btnGuardar.Cursor = Cursors.Hand;
        //
        // _btnQuitar
        //
        _btnQuitar.Text = "Quitar seleccionado";
        _btnQuitar.Margin = new Padding(12, 0, 0, 2);
        _btnQuitar.Padding = new Padding(12, 8, 12, 8);
        _btnQuitar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        _btnQuitar.FlatStyle = FlatStyle.Flat;
        _btnQuitar.FlatAppearance.BorderSize = 0;
        _btnQuitar.ForeColor = System.Drawing.Color.White;
        _btnQuitar.AutoSize = true;
        _btnQuitar.Anchor = AnchorStyles.Right;
        _btnQuitar.Cursor = Cursors.Hand;
        //
        // _grid
        //
        _grid.Dock = DockStyle.Fill;
        _grid.ReadOnly = true;
        _grid.AutoGenerateColumns = false;
        _grid.BackgroundColor = System.Drawing.Color.White;
        _grid.BorderStyle = BorderStyle.None;
        _grid.EnableHeadersVisualStyles = false;
        _grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        _grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
        _grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(218, 235, 251);
        _grid.RowHeadersVisible = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.Margin = new Padding(0, 12, 0, 8);
        _grid.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { Name = "Codigo", HeaderText = "Código", DataPropertyName = "Codigo", FillWeight = 18 },
            new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", DataPropertyName = "Producto", FillWeight = 34 },
            new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad", FillWeight = 16 },
            new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio", DataPropertyName = "Precio", FillWeight = 16, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } },
            new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", DataPropertyName = "Subtotal", FillWeight = 16, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } },
        });
        //
        // _footerPanel
        //
        _footerPanel.Dock = DockStyle.Fill;
        _footerPanel.Height = 52;
        _footerPanel.Padding = new Padding(6, 6, 6, 4);
        _footerPanel.BackColor = System.Drawing.Color.White;
        _footerPanel.Controls.Add(_lblTotal);
        //
        // _lblTotal
        //
        _lblTotal.Text = "Total: $0";
        _lblTotal.AutoSize = true;
        _lblTotal.Margin = new Padding(10, 12, 0, 0);
        _lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _lblTotal.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        //
        // FrmVentas
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        ClientSize = new System.Drawing.Size(860, 580);
        Controls.Add(_mainLayout);
        Controls.Add(_headerPanel);
        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Padding = new Padding(14);
        Name = "FrmVentas";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Ventas";
        ResumeLayout(false);
    }
}
