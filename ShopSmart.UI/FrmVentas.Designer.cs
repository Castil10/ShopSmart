using System.Windows.Forms;

namespace ShopSmart.UI;

public partial class FrmVentas
{
    private Panel _headerPanel = null!;
    private Label _titleLabel = null!;
    private Label _subtitleLabel = null!;
    private FlowLayoutPanel _topLayout = null!;
    private DataGridView _grid = null!;
    private TextBox _txtBuscar = null!;
    private ComboBox _cmbClientes = null!;
    private Button _btnBuscar = null!;
    private Button _btnAgregar = null!;
    private Button _btnGuardar = null!;
    private Label _lblTotal = null!;

    private void InitializeComponent()
    {
        _headerPanel = new Panel();
        _titleLabel = new Label();
        _subtitleLabel = new Label();
        _topLayout = new FlowLayoutPanel();
        _grid = new DataGridView();
        _txtBuscar = new TextBox();
        _cmbClientes = new ComboBox();
        _btnBuscar = new Button();
        _btnAgregar = new Button();
        _btnGuardar = new Button();
        _lblTotal = new Label();
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
        // _topLayout
        //
        _topLayout.Dock = DockStyle.Top;
        _topLayout.Height = 60;
        _topLayout.Padding = new Padding(10, 8, 10, 6);
        _topLayout.AutoSize = true;
        _topLayout.WrapContents = false;
        _topLayout.BackColor = System.Drawing.Color.White;
        _topLayout.Controls.Add(_txtBuscar);
        _topLayout.Controls.Add(_btnBuscar);
        _topLayout.Controls.Add(_cmbClientes);
        _topLayout.Controls.Add(_btnAgregar);
        _topLayout.Controls.Add(_btnGuardar);
        _topLayout.Controls.Add(_lblTotal);
        //
        // _grid
        //
        _grid.Dock = DockStyle.Fill;
        _grid.ReadOnly = true;
        _grid.AutoGenerateColumns = true;
        _grid.BackgroundColor = System.Drawing.Color.White;
        _grid.BorderStyle = BorderStyle.None;
        _grid.EnableHeadersVisualStyles = false;
        _grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        _grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
        _grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(218, 235, 251);
        //
        // _txtBuscar
        //
        _txtBuscar.PlaceholderText = "Código o nombre";
        _txtBuscar.Width = 180;
        _txtBuscar.Margin = new Padding(0, 6, 8, 0);
        _txtBuscar.BorderStyle = BorderStyle.FixedSingle;
        //
        // _cmbClientes
        //
        _cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbClientes.Width = 180;
        _cmbClientes.Margin = new Padding(0, 6, 8, 0);
        //
        // _btnBuscar
        //
        _btnBuscar.Text = "Buscar";
        _btnBuscar.Margin = new Padding(0, 6, 8, 0);
        _btnBuscar.Padding = new Padding(12, 8, 12, 8);
        _btnBuscar.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnBuscar.FlatStyle = FlatStyle.Flat;
        _btnBuscar.FlatAppearance.BorderSize = 0;
        _btnBuscar.ForeColor = System.Drawing.Color.White;
        //
        // _btnAgregar
        //
        _btnAgregar.Text = "Agregar";
        _btnAgregar.Margin = new Padding(0, 6, 8, 0);
        _btnAgregar.Padding = new Padding(12, 8, 12, 8);
        _btnAgregar.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
        _btnAgregar.FlatStyle = FlatStyle.Flat;
        _btnAgregar.FlatAppearance.BorderSize = 0;
        _btnAgregar.ForeColor = System.Drawing.Color.White;
        //
        // _btnGuardar
        //
        _btnGuardar.Text = "Guardar venta";
        _btnGuardar.Margin = new Padding(0, 6, 8, 0);
        _btnGuardar.Padding = new Padding(12, 8, 12, 8);
        _btnGuardar.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnGuardar.FlatStyle = FlatStyle.Flat;
        _btnGuardar.FlatAppearance.BorderSize = 0;
        _btnGuardar.ForeColor = System.Drawing.Color.White;
        //
        // _lblTotal
        //
        _lblTotal.Text = "Total: $0";
        _lblTotal.AutoSize = true;
        _lblTotal.Margin = new Padding(12, 18, 0, 0);
        _lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _lblTotal.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        //
        // FrmVentas
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        ClientSize = new System.Drawing.Size(820, 560);
        Controls.Add(_grid);
        Controls.Add(_topLayout);
        Controls.Add(_headerPanel);
        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Padding = new Padding(14);
        Name = "FrmVentas";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Ventas";
        ResumeLayout(false);
        PerformLayout();
    }
}
