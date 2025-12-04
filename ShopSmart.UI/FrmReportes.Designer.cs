using System.Windows.Forms;

namespace ShopSmart.UI;

public partial class FrmReportes
{
    private Panel _headerPanel = null!;
    private Label _titleLabel = null!;
    private Label _subtitleLabel = null!;
    private TableLayoutPanel _layout = null!;
    private DataGridView _ventasDiariasGrid = null!;
    private DataGridView _stockGrid = null!;
    private Label _ventasLabel = null!;
    private Label _stockLabel = null!;
    private FlowLayoutPanel _resumePanel = null!;
    private Label _ventasTotalesLabel = null!;
    private Label _movimientosLabel = null!;
    private Label _ultimaVentaLabel = null!;

    private void InitializeComponent()
    {
        _headerPanel = new Panel();
        _titleLabel = new Label();
        _subtitleLabel = new Label();
        _layout = new TableLayoutPanel();
        _ventasDiariasGrid = new DataGridView();
        _stockGrid = new DataGridView();
        _ventasLabel = new Label();
        _stockLabel = new Label();
        _resumePanel = new FlowLayoutPanel();
        _ventasTotalesLabel = new Label();
        _movimientosLabel = new Label();
        _ultimaVentaLabel = new Label();
        SuspendLayout();
        //
        // _headerPanel
        //
        _headerPanel.BackColor = System.Drawing.Color.White;
        _headerPanel.Dock = DockStyle.Top;
        _headerPanel.Height = 98;
        _headerPanel.Padding = new Padding(18, 14, 18, 10);
        _headerPanel.Controls.Add(_titleLabel);
        _headerPanel.Controls.Add(_subtitleLabel);
        //
        // _titleLabel
        //
        _titleLabel.AutoSize = true;
        _titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _titleLabel.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _titleLabel.Location = new System.Drawing.Point(10, 10);
        _titleLabel.Text = "Reportes y métricas";
        //
        // _subtitleLabel
        //
        _subtitleLabel.AutoSize = true;
        _subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        _subtitleLabel.Location = new System.Drawing.Point(12, 46);
        _subtitleLabel.Text = "Monitorea las ventas diarias y detecta alertas de stock";
        //
        // _resumePanel
        //
        _resumePanel.Dock = DockStyle.Top;
        _resumePanel.Height = 70;
        _resumePanel.FlowDirection = FlowDirection.LeftToRight;
        _resumePanel.Padding = new Padding(12, 6, 12, 4);
        _resumePanel.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        _resumePanel.WrapContents = false;
        _resumePanel.Controls.Add(_ventasTotalesLabel);
        _resumePanel.Controls.Add(_movimientosLabel);
        _resumePanel.Controls.Add(_ultimaVentaLabel);
        //
        // _ventasTotalesLabel
        //
        _ventasTotalesLabel.AutoSize = true;
        _ventasTotalesLabel.Margin = new Padding(8, 12, 18, 0);
        _ventasTotalesLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _ventasTotalesLabel.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        //
        // _movimientosLabel
        //
        _movimientosLabel.AutoSize = true;
        _movimientosLabel.Margin = new Padding(8, 12, 18, 0);
        _movimientosLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _movimientosLabel.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        //
        // _ultimaVentaLabel
        //
        _ultimaVentaLabel.AutoSize = true;
        _ultimaVentaLabel.Margin = new Padding(8, 12, 18, 0);
        _ultimaVentaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        _ultimaVentaLabel.ForeColor = System.Drawing.Color.FromArgb(96, 125, 139);
        //
        // _layout
        //
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        _layout.Dock = DockStyle.Fill;
        _layout.Padding = new Padding(12);
        _layout.RowCount = 2;
        _layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        _layout.Controls.Add(_ventasLabel, 0, 0);
        _layout.Controls.Add(_stockLabel, 1, 0);
        _layout.Controls.Add(_ventasDiariasGrid, 0, 1);
        _layout.Controls.Add(_stockGrid, 1, 1);
        //
        // _ventasLabel
        //
        _ventasLabel.AutoSize = true;
        _ventasLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _ventasLabel.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _ventasLabel.Margin = new Padding(8, 6, 0, 4);
        _ventasLabel.Text = "Ventas diarias";
        //
        // _stockLabel
        //
        _stockLabel.AutoSize = true;
        _stockLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        _stockLabel.ForeColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _stockLabel.Margin = new Padding(8, 6, 0, 4);
        _stockLabel.Text = "Productos con stock bajo";
        //
        // _ventasDiariasGrid
        //
        _ventasDiariasGrid.Dock = DockStyle.Fill;
        _ventasDiariasGrid.BackgroundColor = System.Drawing.Color.White;
        _ventasDiariasGrid.BorderStyle = BorderStyle.None;
        _ventasDiariasGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _ventasDiariasGrid.EnableHeadersVisualStyles = false;
        _ventasDiariasGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _ventasDiariasGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        _ventasDiariasGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(218, 235, 251);
        _ventasDiariasGrid.ReadOnly = true;
        _ventasDiariasGrid.RowHeadersVisible = false;
        _ventasDiariasGrid.Margin = new Padding(8, 0, 10, 8);
        //
        // _stockGrid
        //
        _stockGrid.Dock = DockStyle.Fill;
        _stockGrid.BackgroundColor = System.Drawing.Color.White;
        _stockGrid.BorderStyle = BorderStyle.None;
        _stockGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _stockGrid.EnableHeadersVisualStyles = false;
        _stockGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(23, 58, 94);
        _stockGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        _stockGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(218, 235, 251);
        _stockGrid.ReadOnly = true;
        _stockGrid.RowHeadersVisible = false;
        _stockGrid.Margin = new Padding(8, 0, 8, 8);
        //
        // FrmReportes
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        ClientSize = new System.Drawing.Size(960, 620);
        Controls.Add(_layout);
        Controls.Add(_resumePanel);
        Controls.Add(_headerPanel);
        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Name = "FrmReportes";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Reportes";
        ResumeLayout(false);
    }
}
