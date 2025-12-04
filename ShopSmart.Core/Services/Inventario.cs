using System.Linq;
using ShopSmart.Core.DataStructures;
using ShopSmart.Core.Models;

namespace ShopSmart.Core.Services;

/// <summary>
/// Gestiona productos usando BST para búsquedas rápidas y lista enlazada para recorridos secuenciales.
/// </summary>
public class Inventario
{
    private readonly Bst<Producto> _productosPorCodigo = new();
    private readonly SimpleLinkedList<Producto> _productosLista = new();

    public void AgregarProducto(Producto producto)
    {
        var existente = BuscarPorCodigo(producto.Codigo);
        if (existente is null)
        {
            _productosPorCodigo.Insertar(producto);
            _productosLista.InsertarFinal(producto);
            return;
        }

        existente.Nombre = producto.Nombre;
        existente.Descripcion = producto.Descripcion;
        existente.Precio = producto.Precio;
        existente.StockActual = producto.StockActual;
        existente.StockMinimo = producto.StockMinimo;
        existente.Activo = producto.Activo;
    }

    public Producto? BuscarPorCodigo(string codigo)
    {
        var buscador = new Producto { Codigo = codigo };
        return _productosPorCodigo.Buscar(buscador);
    }

    public IEnumerable<Producto> ObtenerEnOrden() => _productosPorCodigo.RecorrerEnOrden();

    public IEnumerable<Producto> RecorrerSecuencial() => _productosLista.Recorrer();

    public IEnumerable<Producto> ProductosConStockBajo()
    {
        return _productosLista
            .Recorrer()
            .Where(p => p.StockActual <= p.StockMinimo);
    }

    public bool EliminarPorCodigo(string codigo)
    {
        // Eliminación en BST no implementada para mantener el ejemplo simple.
        return _productosLista.Eliminar(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    }
}
