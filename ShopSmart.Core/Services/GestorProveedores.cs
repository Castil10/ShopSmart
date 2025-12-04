using ShopSmart.Core.DataStructures;
using ShopSmart.Core.Models;

namespace ShopSmart.Core.Services;

public class GestorProveedores
{
    private readonly HashTableCustom<string, Proveedor> _proveedores = new();

    public void Agregar(Proveedor proveedor)
    {
        _proveedores.AddOrUpdate(proveedor.Nombre, proveedor);
    }

    public Proveedor? BuscarPorNombre(string nombre)
    {
        return _proveedores.TryGetValue(nombre, out var proveedor) ? proveedor : null;
    }

    public bool Eliminar(string nombre)
    {
        return _proveedores.Remove(nombre);
    }

    public IEnumerable<Proveedor> ObtenerTodos()
    {
        return _proveedores.Items().Select(x => x.Value);
    }
}
