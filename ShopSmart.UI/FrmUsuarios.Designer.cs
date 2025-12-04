using System.Drawing;
using System.Windows.Forms;

namespace ShopSmart.UI;

public partial class FrmUsuarios
{
    private TableLayoutPanel _layout = null!;
    private GroupBox _gbFormulario = null!;
    private GroupBox _gbListado = null!;
    private TextBox _txtUsuario = null!;
    private TextBox _txtContrasena = null!;
    private ComboBox _cmbRol = null!;
    private DataGridView _gridUsuarios = null!;
    private Button _btnAgregar = null!;
    private Button _btnActualizar = null!;
    private Button _btnEliminar = null!;
    private Button _btnLimpiar = null!;

    private void InitializeComponent()
    {
        _layout = new TableLayoutPanel();
        _gbFormulario = new GroupBox();
        _gbListado = new GroupBox();
        _txtUsuario = new TextBox();
        _txtContrasena = new TextBox();
        _cmbRol = new ComboBox();
        _gridUsuarios = new DataGridView();
        _btnAgregar = new Button();
        _btnActualizar = new Button();
        _btnEliminar = new Button();
        _btnLimpiar = new Button();

        SuspendLayout();
        _layout.SuspendLayout();
        _gbFormulario.SuspendLayout();
        _gbListado.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridUsuarios).BeginInit();

        // Form
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(920, 520);
        Text = "Gestión de usuarios";
        StartPosition = FormStartPosition.CenterParent;
        Controls.Add(_layout);

        // Layout
        _layout.ColumnCount = 2;
        _layout.RowCount = 1;
        _layout.Dock = DockStyle.Fill;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.Padding = new Padding(12);
        _layout.BackColor = Color.Transparent;
        _layout.Controls.Add(_gbFormulario, 0, 0);
        _layout.Controls.Add(_gbListado, 1, 0);

        // Group formulario
        _gbFormulario.Text = "Formulario";
        _gbFormulario.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _gbFormulario.Dock = DockStyle.Fill;
        _gbFormulario.Padding = new Padding(12);

        var formLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 8,
            BackColor = Color.White
        };
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        formLayout.Padding = new Padding(8);
        formLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

        var lblUsuario = CrearLabel("Usuario");
        var lblContrasena = CrearLabel("Contraseña");
        var lblRol = CrearLabel("Rol");

        _txtUsuario.Dock = DockStyle.Fill;
        _txtUsuario.PlaceholderText = "usuario";
        _txtUsuario.Margin = new Padding(0, 0, 0, 8);
        _txtUsuario.Font = new Font("Segoe UI", 10F);

        _txtContrasena.Dock = DockStyle.Fill;
        _txtContrasena.PlaceholderText = "contraseña segura";
        _txtContrasena.Margin = new Padding(0, 0, 0, 8);
        _txtContrasena.Font = new Font("Segoe UI", 10F);

        _cmbRol.Dock = DockStyle.Fill;
        _cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbRol.Font = new Font("Segoe UI", 10F);

        var botonesLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            Padding = new Padding(0)
        };

        _btnAgregar = CrearBoton("Agregar", Color.FromArgb(33, 150, 243));
        _btnActualizar = CrearBoton("Actualizar", Color.FromArgb(255, 193, 7));
        _btnEliminar = CrearBoton("Eliminar", Color.FromArgb(244, 67, 54));
        _btnLimpiar = CrearBoton("Limpiar", Color.FromArgb(96, 125, 139));

        botonesLayout.Controls.AddRange(new Control[] { _btnAgregar, _btnActualizar, _btnEliminar, _btnLimpiar });

        formLayout.Controls.Add(lblUsuario, 0, 0);
        formLayout.Controls.Add(_txtUsuario, 0, 1);
        formLayout.Controls.Add(lblContrasena, 0, 2);
        formLayout.Controls.Add(_txtContrasena, 0, 3);
        formLayout.Controls.Add(lblRol, 0, 4);
        formLayout.Controls.Add(_cmbRol, 0, 5);
        formLayout.Controls.Add(botonesLayout, 0, 6);

        _gbFormulario.Controls.Add(formLayout);

        // Group listado
        _gbListado.Text = "Usuarios registrados";
        _gbListado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _gbListado.Dock = DockStyle.Fill;
        _gbListado.Padding = new Padding(12);

        _gridUsuarios.Dock = DockStyle.Fill;
        _gridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _gridUsuarios.BackgroundColor = Color.White;
        _gridUsuarios.AllowUserToAddRows = false;
        _gridUsuarios.ReadOnly = true;
        _gridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _gridUsuarios.MultiSelect = false;
        _gridUsuarios.RowHeadersVisible = false;

        _gbListado.Controls.Add(_gridUsuarios);

        _layout.ResumeLayout(false);
        _gbFormulario.ResumeLayout(false);
        _gbListado.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_gridUsuarios).EndInit();
        ResumeLayout(false);
    }

    private static Label CrearLabel(string texto)
    {
        return new Label
        {
            Text = texto,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(55, 71, 79),
            AutoSize = true,
            Margin = new Padding(0, 0, 0, 4)
        };
    }

    private static Button CrearBoton(string texto, Color fondo)
    {
        return new Button
        {
            Text = texto,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            BackColor = fondo,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0 },
            Padding = new Padding(10, 8, 10, 8),
            Margin = new Padding(0, 0, 8, 0),
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point)
        };
    }
}
