namespace ShopSmart.Core.DataStructures;

/// <summary>
/// Lista enlazada simple utilizada para recorrer secuencialmente catálogos (productos, clientes, etc.).
/// </summary>
public class SimpleLinkedList<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node? Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node? _head;

    public void InsertarInicio(T data)
    {
        var newNode = new Node(data) { Next = _head };
        _head = newNode;
    }

    public void InsertarFinal(T data)
    {
        var newNode = new Node(data);
        if (_head is null)
        {
            _head = newNode;
            return;
        }

        var current = _head;
        while (current.Next is not null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public bool Eliminar(Predicate<T> match)
    {
        if (_head is null)
        {
            return false;
        }

        if (match(_head.Data))
        {
            _head = _head.Next;
            return true;
        }

        var current = _head;
        while (current.Next is not null)
        {
            if (match(current.Next.Data))
            {
                current.Next = current.Next.Next;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public T? Buscar(Predicate<T> match)
    {
        var current = _head;
        while (current is not null)
        {
            if (match(current.Data))
            {
                return current.Data;
            }

            current = current.Next;
        }

        return default;
    }

    public IEnumerable<T> Recorrer()
    {
        var current = _head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
