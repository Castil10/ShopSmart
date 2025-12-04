using System.Windows.Forms;

namespace ShopSmart.UI;


public partial class FrmProductos
{
    private Panel _headerPanel = null!;
    private Label _titleLabel = null!;
    private Label _subtitleLabel = null!;
    private Panel _formContainer = null!;
    private TableLayoutPanel _formLayout = null!;
    private DataGridView _grid = null!;
    private TextBox _txtCodigo = null!;
    private TextBox _txtNombre = null!;
    private NumericUpDown _numPrecio = null!;
    private NumericUpDown _numStock = null!;
    private NumericUpDown _numStockMinimo = null!;
    private CheckBox _chkActivo = null!;
    private Button _btnGuardar = null!;
    private Button _btnEliminar = null!;


    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        _headerPanel = new Panel();
        _titleLabel = new Label();
        _subtitleLabel = new Label();
        _formContainer = new Panel();
        _formLayout = new TableLayoutPanel();
        _txtCodigo = new TextBox();
        _txtNombre = new TextBox();
        _numPrecio = new NumericUpDown();
        _numStock = new NumericUpDown();
        _numStockMinimo = new NumericUpDown();
        _chkActivo = new CheckBox();
        _btnGuardar = new Button();
        _btnEliminar = new Button();
        _grid = new DataGridView();
        _headerPanel.SuspendLayout();
        _formContainer.SuspendLayout();
        _formLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_numPrecio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_numStock).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_numStockMinimo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();
        // 
        // _headerPanel
        // 
        _headerPanel.BackColor = Color.White;
        _headerPanel.Controls.Add(_titleLabel);
        _headerPanel.Controls.Add(_subtitleLabel);
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Location = new Point(14, 14);
        _headerPanel.Name = "_headerPanel";
        _headerPanel.Padding = new Padding(16, 12, 16, 8);
        _headerPanel.Size = new Size(832, 82);
        _headerPanel.TabIndex = 2;
        // 
        // _titleLabel
        // 
        _titleLabel.AutoSize = true;
        _titleLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _titleLabel.ForeColor = Color.FromArgb(23, 58, 94);
        _titleLabel.Location = new Point(28, 20);
        _titleLabel.Name = "_titleLabel";
        _titleLabel.Size = new Size(213, 32);
        _titleLabel.TabIndex = 0;
        _titleLabel.Text = "Gestión productos";
        // 
        // _subtitleLabel
        // 
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _subtitleLabel.ForeColor = Color.FromArgb(96, 125, 139);
        _subtitleLabel.Location = new Point(30, 54);
        _subtitleLabel.Name = "_subtitleLabel";
        _subtitleLabel.Size = new Size(300, 23);
        _subtitleLabel.TabIndex = 1;
        _subtitleLabel.Text = "Controla inventario y precios de venta";
        // 
        // _formContainer
        // 
        _formContainer.BackColor = Color.White;
        _formContainer.Controls.Add(_formLayout);
        _formContainer.Dock = DockStyle.Top;
        _formContainer.Location = new Point(14, 96);
        _formContainer.Name = "_formContainer";
        _formContainer.Padding = new Padding(12);
        _formContainer.Size = new Size(832, 170);
        _formContainer.TabIndex = 1;
        // 
        // _formLayout
        // 
        _formLayout.BackColor = Color.White;
        _formLayout.ColumnCount = 3;
        _formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        _formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        _formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        _formLayout.Controls.Add(_txtCodigo, 0, 0);
        _formLayout.Controls.Add(_txtNombre, 1, 0);
        _formLayout.Controls.Add(_numPrecio, 2, 0);
        _formLayout.Controls.Add(_numStock, 0, 1);
        _formLayout.Controls.Add(_numStockMinimo, 1, 1);
        _formLayout.Controls.Add(_chkActivo, 2, 1);
        _formLayout.Controls.Add(_btnGuardar, 0, 2);
        _formLayout.Controls.Add(_btnEliminar, 1, 2);
        _formLayout.Dock = DockStyle.Fill;
        _formLayout.Location = new Point(12, 12);
        _formLayout.Margin = new Padding(0);
        _formLayout.Name = "_formLayout";
        _formLayout.Padding = new Padding(4);
        _formLayout.RowCount = 3;
        _formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        _formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        _formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
        _formLayout.Size = new Size(808, 146);
        _formLayout.TabIndex = 0;
        // 
        // _txtCodigo
        // 
        _txtCodigo.BorderStyle = BorderStyle.FixedSingle;
        _txtCodigo.Dock = DockStyle.Fill;
        _txtCodigo.Location = new Point(12, 10);
        _txtCodigo.Margin = new Padding(8, 6, 8, 6);
        _txtCodigo.Name = "_txtCodigo";
        _txtCodigo.PlaceholderText = "Código";
        _txtCodigo.Size = new Size(248, 30);
        _txtCodigo.TabIndex = 0;
        // 
        // _txtNombre
        // 
        _txtNombre.BorderStyle = BorderStyle.FixedSingle;
        _txtNombre.Dock = DockStyle.Fill;
        _txtNombre.Location = new Point(276, 10);
        _txtNombre.Margin = new Padding(8, 6, 8, 6);
        _txtNombre.Name = "_txtNombre";
        _txtNombre.PlaceholderText = "Nombre";
        _txtNombre.Size = new Size(256, 30);
        _txtNombre.TabIndex = 1;
        // 
        // _numPrecio
        // 
        _numPrecio.BorderStyle = BorderStyle.FixedSingle;
        _numPrecio.DecimalPlaces = 2;
        _numPrecio.Dock = DockStyle.Fill;
        _numPrecio.Location = new Point(548, 10);
        _numPrecio.Margin = new Padding(8, 6, 8, 6);
        _numPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        _numPrecio.Name = "_numPrecio";
        _numPrecio.Size = new Size(248, 30);
        _numPrecio.TabIndex = 2;
        // 
        // _numStock
        // 
        _numStock.BorderStyle = BorderStyle.FixedSingle;
        _numStock.Dock = DockStyle.Fill;
        _numStock.Location = new Point(12, 55);
        _numStock.Margin = new Padding(8, 6, 8, 6);
        _numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        _numStock.Name = "_numStock";
        _numStock.Size = new Size(248, 30);
        _numStock.TabIndex = 3;
        // 
        // _numStockMinimo
        // 
        _numStockMinimo.BorderStyle = BorderStyle.FixedSingle;
        _numStockMinimo.Dock = DockStyle.Fill;
        _numStockMinimo.Location = new Point(276, 55);
        _numStockMinimo.Margin = new Padding(8, 6, 8, 6);
        _numStockMinimo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        _numStockMinimo.Name = "_numStockMinimo";
        _numStockMinimo.Size = new Size(256, 30);
        _numStockMinimo.TabIndex = 4;
        // 
        // _chkActivo
        // 
        _chkActivo.Checked = true;
        _chkActivo.CheckState = CheckState.Checked;
        _chkActivo.Dock = DockStyle.Left;
        _chkActivo.Location = new Point(543, 52);
        _chkActivo.Name = "_chkActivo";
        _chkActivo.Padding = new Padding(6);
        _chkActivo.Size = new Size(104, 39);
        _chkActivo.TabIndex = 5;
        _chkActivo.Text = "Activo";
        // 
        // _btnGuardar
        // 
        _btnGuardar.AutoSize = true;
        _btnGuardar.BackColor = Color.FromArgb(23, 58, 94);
        _btnGuardar.FlatAppearance.BorderSize = 0;
        _btnGuardar.FlatStyle = FlatStyle.Flat;
        _btnGuardar.ForeColor = Color.White;
        _btnGuardar.Location = new Point(12, 104);
        _btnGuardar.Margin = new Padding(8, 10, 8, 6);
        _btnGuardar.Name = "_btnGuardar";
        _btnGuardar.Padding = new Padding(14, 8, 14, 8);
        _btnGuardar.Size = new Size(185, 32);
        _btnGuardar.TabIndex = 6;
        _btnGuardar.Text = "Guardar producto";
        _btnGuardar.UseVisualStyleBackColor = false;
        // 
        // _btnEliminar
        // 
        _btnEliminar.AutoSize = true;
        _btnEliminar.BackColor = Color.FromArgb(230, 57, 70);
        _btnEliminar.FlatAppearance.BorderSize = 0;
        _btnEliminar.FlatStyle = FlatStyle.Flat;
        _btnEliminar.ForeColor = Color.White;
        _btnEliminar.Location = new Point(276, 104);
        _btnEliminar.Margin = new Padding(8, 10, 8, 6);
        _btnEliminar.Name = "_btnEliminar";
        _btnEliminar.Padding = new Padding(14, 8, 14, 8);
        _btnEliminar.Size = new Size(212, 32);
        _btnEliminar.TabIndex = 7;
        _btnEliminar.Text = "Eliminar seleccionado";
        _btnEliminar.UseVisualStyleBackColor = false;
        // 
        // _grid
        // 
        dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 252);
        _grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _grid.BackgroundColor = Color.White;
        _grid.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(23, 58, 94);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(23, 58, 94);
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        _grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _grid.ColumnHeadersHeight = 29;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = SystemColors.Window;
        dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(218, 235, 251);
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        _grid.DefaultCellStyle = dataGridViewCellStyle3;
        _grid.Dock = DockStyle.Fill;
        _grid.EnableHeadersVisualStyles = false;
        _grid.Location = new Point(14, 266);
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersWidth = 51;
        _grid.Size = new Size(832, 240);
        _grid.TabIndex = 0;
        // 
        // FrmProductos
        // 
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(860, 520);
        Controls.Add(_grid);
        Controls.Add(_formContainer);
        Controls.Add(_headerPanel);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "FrmProductos";
        Padding = new Padding(14);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Productos";
        _headerPanel.ResumeLayout(false);
        _headerPanel.PerformLayout();
        _formContainer.ResumeLayout(false);
        _formLayout.ResumeLayout(false);
        _formLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_numPrecio).EndInit();
        ((System.ComponentModel.ISupportInitialize)_numStock).EndInit();
        ((System.ComponentModel.ISupportInitialize)_numStockMinimo).EndInit();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
    }
}
