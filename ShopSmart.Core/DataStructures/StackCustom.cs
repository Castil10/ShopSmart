namespace ShopSmart.Core.DataStructures;

/// <summary>
/// Pila utilizada para operaciones deshacibles.
/// </summary>
public class StackCustom<T>
{
    private readonly List<T> _items = new();

    public void Push(T item) => _items.Add(item);

    public T Pop()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La pila está vacía");
        }

        var item = _items[^1];
        _items.RemoveAt(_items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La pila está vacía");
        }

        return _items[^1];
    }

    public int Count => _items.Count;
}
