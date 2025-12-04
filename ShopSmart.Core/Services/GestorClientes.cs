using ShopSmart.Core.DataStructures;
using ShopSmart.Core.Models;

namespace ShopSmart.Core.Services;

/// <summary>
/// Administra clientes en una tabla hash para búsquedas rápidas por documento.
/// </summary>
public class GestorClientes
{
    private readonly HashTableCustom<string, Cliente> _clientes = new();

    public void Agregar(Cliente cliente)
    {
        _clientes.AddOrUpdate(cliente.Documento, cliente);
    }

    public Cliente? Buscar(string documento)
    {
        return _clientes.TryGetValue(documento, out var cliente) ? cliente : null;
    }

    public bool Eliminar(string documento)
    {
        return _clientes.Remove(documento);
    }

    public IEnumerable<Cliente> ObtenerTodos()
    {
        return _clientes.Items().Select(x => x.Value);
    }
}
