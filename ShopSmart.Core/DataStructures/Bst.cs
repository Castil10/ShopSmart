namespace ShopSmart.Core.DataStructures;

/// <summary>
/// Árbol binario de búsqueda usado para indexar productos por su código.
/// </summary>
public class Bst<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node? _root;

    public void Insertar(T value)
    {
        _root = InsertarInterno(_root, value);
    }

    private Node InsertarInterno(Node? node, T value)
    {
        if (node is null)
        {
            return new Node(value);
        }

        var compare = value.CompareTo(node.Data);
        if (compare < 0)
        {
            node.Left = InsertarInterno(node.Left, value);
        }
        else if (compare > 0)
        {
            node.Right = InsertarInterno(node.Right, value);
        }
        else
        {
            node.Data = value;
        }

        return node;
    }

    public T? Buscar(T value)
    {
        var node = _root;
        while (node is not null)
        {
            var compare = value.CompareTo(node.Data);
            if (compare == 0)
            {
                return node.Data;
            }

            node = compare < 0 ? node.Left : node.Right;
        }

        return default;
    }

    public IEnumerable<T> RecorrerEnOrden()
    {
        return RecorrerEnOrdenInterno(_root);
    }

    private IEnumerable<T> RecorrerEnOrdenInterno(Node? node)
    {
        if (node is null)
        {
            yield break;
        }

        foreach (var left in RecorrerEnOrdenInterno(node.Left))
        {
            yield return left;
        }

        yield return node.Data;

        foreach (var right in RecorrerEnOrdenInterno(node.Right))
        {
            yield return right;
        }
    }
}
