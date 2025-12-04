using System.Windows.Forms;

namespace ShopSmart.UI;

public partial class FrmLogin
{
    private Panel _headerPanel = null!;
    private Label _titleLabel = null!;
    private Label _subtitleLabel = null!;
    private TableLayoutPanel _layout = null!;
    private TextBox _txtUsuario = null!;
    private TextBox _txtContrasena = null!;
    private Button _btnIngresar = null!;
    private CheckBox _chkMostrar = null!;

    private void InitializeComponent()
    {
        _headerPanel = new Panel();
        _titleLabel = new Label();
        _subtitleLabel = new Label();
        _layout = new TableLayoutPanel();
        _txtUsuario = new TextBox();
        _txtContrasena = new TextBox();
        _chkMostrar = new CheckBox();
        _btnIngresar = new Button();
        SuspendLayout();
        _headerPanel.SuspendLayout();
        _layout.SuspendLayout();

        // 
        // FrmLogin
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(236, 239, 244);
        ClientSize = new Size(380, 260);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ShopSmart - Inicio de sesión";
        KeyPreview = true;                 // Para capturar Enter en el KeyDown
        AcceptButton = _btnIngresar;       // Enter dispara el botón
        Controls.Add(_layout);
        Controls.Add(_headerPanel);

        // 
        // _headerPanel
        // 
        _headerPanel.BackColor = Color.White;
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Height = 90;
        _headerPanel.Padding = new Padding(16);
        _headerPanel.Controls.Add(_titleLabel);
        _headerPanel.Controls.Add(_subtitleLabel);

        // 
        // _titleLabel
        // 
        _titleLabel.AutoSize = true;
        _titleLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _titleLabel.ForeColor = Color.FromArgb(23, 58, 94);
        _titleLabel.Location = new Point(18, 16);
        _titleLabel.Text = "Bienvenido a ShopSmart";

        // 
        // _subtitleLabel
        // 
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        _subtitleLabel.ForeColor = Color.FromArgb(96, 125, 139);
        _subtitleLabel.Location = new Point(20, 50);
        _subtitleLabel.Text = "Ingresa con tus credenciales";

        // 
        // _layout
        // 
        _layout.BackColor = Color.White;
        _layout.Dock = DockStyle.Fill;
        _layout.ColumnCount = 1;
        _layout.Padding = new Padding(24, 16, 24, 24);
        _layout.RowCount = 4;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Usuario
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Contraseña
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Mostrar
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Botón
        _layout.Location = new Point(0, _headerPanel.Height);
        _layout.Controls.Add(_txtUsuario, 0, 0);
        _layout.Controls.Add(_txtContrasena, 0, 1);
        _layout.Controls.Add(_chkMostrar, 0, 2);
        _layout.Controls.Add(_btnIngresar, 0, 3);

        // 
        // _txtUsuario
        // 
        _txtUsuario.Dock = DockStyle.Fill;
        _txtUsuario.Margin = new Padding(0, 0, 0, 6);
        _txtUsuario.PlaceholderText = "Usuario";
        _txtUsuario.Font = new Font("Segoe UI", 10F);

        // 
        // _txtContrasena
        // 
        _txtContrasena.Dock = DockStyle.Fill;
        _txtContrasena.Margin = new Padding(0, 0, 0, 6);
        _txtContrasena.PlaceholderText = "Contraseña";
        _txtContrasena.Font = new Font("Segoe UI", 10F);
        _txtContrasena.UseSystemPasswordChar = true;

        // 
        // _chkMostrar
        // 
        _chkMostrar.AutoSize = true;
        _chkMostrar.Dock = DockStyle.Left;
        _chkMostrar.Margin = new Padding(0, 4, 0, 4);
        _chkMostrar.Text = "Mostrar contraseña";

        // 
        // _btnIngresar
        // 
        _btnIngresar.Dock = DockStyle.Top;
        _btnIngresar.Margin = new Padding(0, 8, 0, 0);
        _btnIngresar.Height = 40;
        _btnIngresar.Text = "Ingresar";
        _btnIngresar.BackColor = Color.FromArgb(23, 58, 94);
        _btnIngresar.ForeColor = Color.White;
        _btnIngresar.FlatStyle = FlatStyle.Flat;
        _btnIngresar.FlatAppearance.BorderSize = 0;
        _btnIngresar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

        _headerPanel.ResumeLayout(false);
        _headerPanel.PerformLayout();
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        ResumeLayout(false);
    }
}
