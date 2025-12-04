namespace ShopSmart.Core.DataStructures;

/// <summary>
/// Cola utilizada para gestionar pedidos pendientes.
/// </summary>
public class QueueCustom<T>
{
    private readonly LinkedList<T> _items = new();

    public void Enqueue(T item) => _items.AddLast(item);

    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La cola está vacía");
        }

        var value = _items.First!.Value;
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La cola está vacía");
        }

        return _items.First!.Value;
    }

    public int Count => _items.Count;
}
