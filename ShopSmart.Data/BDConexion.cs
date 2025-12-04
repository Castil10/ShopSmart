using Microsoft.Data.SqlClient;

namespace ShopSmart.Data;

public class BDConexion
{
    private readonly string _connectionString;

    public BDConexion(string? connectionString = null)
    {
        _connectionString = connectionString ?? "Server=localhost;Database=ShopSmartDB;Trusted_Connection=True;Encrypt=False;";
    }

    public SqlConnection CrearConexion()
    {
        return new SqlConnection(_connectionString);
    }
}
