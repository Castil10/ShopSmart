using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using ShopSmart.Core.Models;
using ShopSmart.Data;

namespace ShopSmart.UI;

internal static class Program
{
    public static BDConexion Conexion { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var configuration = BuildConfiguration();
        Conexion = CrearConexion(configuration);

        if (!ProbarConexion(Conexion))
        {
            MessageBox.Show(
                "No se pudo abrir la conexión con la base de datos.\n" +
                "Verifica el servidor y la cadena de conexión en appsettings.json.",
                "Error de conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        // SIEMPRE empezar por el login
        Application.Run(new FrmLogin(Conexion));
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }

    private static BDConexion CrearConexion(IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:ShopSmartDB"]
                               ?? "Server=.\\SQLEXPRESS;Database=ShopSmartDB;Trusted_Connection=True;Encrypt=False;";

        return new BDConexion(connectionString);
    }

    private static bool ProbarConexion(BDConexion conexion)
    {
        try
        {
            using var conn = conexion.CrearConexion();
            conn.Open();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
