using System.Windows.Forms;

namespace ShopSmart.UI;

public partial class FrmProveedores
{
    private Panel _headerPanel = null!;
    private Label _titleLabel = null!;
    private Label _subtitleLabel = null!;
    private Panel _formContainer = null!;
    private TableLayoutPanel _layout = null!;
    private DataGridView _grid = null!;
    private TextBox _txtNombre = null!;
    private TextBox _txtTelefono = null!;
    private TextBox _txtCorreo = null!;
    private TextBox _txtDireccion = null!;
    private Button _btnGuardar = null!;
    private Panel _nombrePanel = null!;
    private Panel _telefonoPanel = null!;
    private Panel _correoPanel = null!;
    private Panel _direccionPanel = null!;
    private Label _lblNombre = null!;
    private Label _lblTelefono = null!;
    private Label _lblCorreo = null!;
    private Label _lblDireccion = null!;

    private void InitializeComponent()
    {
        _headerPanel = new Panel();
        _titleLabel = new Label();
        _subtitleLabel = new Label();
        _formContainer = new Panel();
        _layout = new TableLayoutPanel();
        _grid = new DataGridView();
        _txtNombre = new TextBox();
        _txtTelefono = new TextBox();
        _txtCorreo = new TextBox();
        _txtDireccion = new TextBox();
        _btnGuardar = new Button();
        _nombrePanel = new Panel();
        _telefonoPanel = new Panel();
        _correoPanel = new Panel();
        _direccionPanel = new Panel();
        _lblNombre = new Label();
        _lblTelefono = new Label();
        _lblCorreo = new Label();
        _lblDireccion = new Label();
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
        _titleLabel.Size = new System.Drawing.Size(209, 32);
        _titleLabel.Text = "Gestión proveedores";
        //
        // _subtitleLabel
        //
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _subtitleLabel.Location = new System.Drawing.Point(14, 42);
        _subtitleLabel.Name = "_subtitleLabel";
        _subtitleLabel.Size = new System.Drawing.Size(265, 23);
        _subtitleLabel.Text = "Controla tus proveedores aliados";
        //
        // _formContainer
        //
        _formContainer.BackColor = System.Drawing.Color.White;
        _formContainer.Controls.Add(_layout);
        _formContainer.Dock = DockStyle.Top;
        _formContainer.Height = 190;
        _formContainer.Padding = new Padding(12);
        //
        // _layout
        //
        _layout.ColumnCount = 3;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        _layout.RowCount = 3;
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.Dock = DockStyle.Fill;
        _layout.Height = 110;
        _layout.Padding = new Padding(4);
        _layout.BackColor = System.Drawing.Color.White;
        _layout.Margin = new Padding(0);
        _layout.Controls.Add(_nombrePanel, 0, 0);
        _layout.Controls.Add(_telefonoPanel, 1, 0);
        _layout.Controls.Add(_correoPanel, 2, 0);
        _layout.Controls.Add(_direccionPanel, 0, 1);
        _layout.SetColumnSpan(_direccionPanel, 3);
        _layout.Controls.Add(_btnGuardar, 0, 2);
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
        // _nombrePanel
        //
        _nombrePanel.Dock = DockStyle.Fill;
        _nombrePanel.Margin = new Padding(8, 6, 8, 6);
        _nombrePanel.Controls.Add(_txtNombre);
        _nombrePanel.Controls.Add(_lblNombre);
        //
        // _lblNombre
        //
        _lblNombre.AutoSize = true;
        _lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _lblNombre.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _lblNombre.Location = new System.Drawing.Point(0, 0);
        _lblNombre.Text = "Nombre";
        //
        // _txtNombre
        //
        _txtNombre.PlaceholderText = "Ej. Lácteos S.A.";
        _txtNombre.Dock = DockStyle.Bottom;
        _txtNombre.Margin = new Padding(0, 6, 0, 0);
        _txtNombre.BorderStyle = BorderStyle.FixedSingle;
        _txtNombre.Size = new System.Drawing.Size(232, 30);
        //
        // _telefonoPanel
        //
        _telefonoPanel.Dock = DockStyle.Fill;
        _telefonoPanel.Margin = new Padding(8, 6, 8, 6);
        _telefonoPanel.Controls.Add(_txtTelefono);
        _telefonoPanel.Controls.Add(_lblTelefono);
        //
        // _lblTelefono
        //
        _lblTelefono.AutoSize = true;
        _lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _lblTelefono.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _lblTelefono.Location = new System.Drawing.Point(0, 0);
        _lblTelefono.Text = "Teléfono";
        //
        // _txtTelefono
        //
        _txtTelefono.PlaceholderText = "Ej. +57 1234567";
        _txtTelefono.Dock = DockStyle.Bottom;
        _txtTelefono.Margin = new Padding(0, 6, 0, 0);
        _txtTelefono.BorderStyle = BorderStyle.FixedSingle;
        _txtTelefono.Size = new System.Drawing.Size(240, 30);
        //
        // _correoPanel
        //
        _correoPanel.Dock = DockStyle.Fill;
        _correoPanel.Margin = new Padding(8, 6, 8, 6);
        _correoPanel.Controls.Add(_txtCorreo);
        _correoPanel.Controls.Add(_lblCorreo);
        //
        // _lblCorreo
        //
        _lblCorreo.AutoSize = true;
        _lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _lblCorreo.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _lblCorreo.Location = new System.Drawing.Point(0, 0);
        _lblCorreo.Text = "Correo";
        //
        // _txtCorreo
        //
        _txtCorreo.PlaceholderText = "contacto@empresa.com";
        _txtCorreo.Dock = DockStyle.Bottom;
        _txtCorreo.Margin = new Padding(0, 6, 0, 0);
        _txtCorreo.BorderStyle = BorderStyle.FixedSingle;
        _txtCorreo.Size = new System.Drawing.Size(232, 30);
        //
        // _direccionPanel
        //
        _direccionPanel.Dock = DockStyle.Fill;
        _direccionPanel.Margin = new Padding(8, 6, 8, 6);
        _direccionPanel.Controls.Add(_txtDireccion);
        _direccionPanel.Controls.Add(_lblDireccion);
        //
        // _lblDireccion
        //
        _lblDireccion.AutoSize = true;
        _lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _lblDireccion.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _lblDireccion.Location = new System.Drawing.Point(0, 0);
        _lblDireccion.Text = "Dirección";
        //
        // _txtDireccion
        //
        _txtDireccion.PlaceholderText = "Calle, número, ciudad";
        _txtDireccion.Dock = DockStyle.Bottom;
        _txtDireccion.Margin = new Padding(0, 6, 0, 0);
        _txtDireccion.BorderStyle = BorderStyle.FixedSingle;
        _txtDireccion.Size = new System.Drawing.Size(488, 30);
        //
        // _btnGuardar
        //
        _btnGuardar.Text = "Guardar proveedor";
        _btnGuardar.AutoSize = true;
        _btnGuardar.Margin = new Padding(8, 10, 8, 6);
        _btnGuardar.Padding = new Padding(14, 8, 14, 8);
        _btnGuardar.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _btnGuardar.FlatStyle = FlatStyle.Flat;
        _btnGuardar.FlatAppearance.BorderSize = 0;
        _btnGuardar.ForeColor = System.Drawing.Color.White;
        //
        // FrmProveedores
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        ClientSize = new System.Drawing.Size(820, 460);
        Controls.Add(_grid);
        Controls.Add(_formContainer);
        Controls.Add(_headerPanel);
        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Padding = new Padding(14);
        Name = "FrmProveedores";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Proveedores";
        ResumeLayout(false);
    }
}
