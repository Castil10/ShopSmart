namespace ShopSmart.Core.DataStructures;

/// <summary>
/// Tabla hash simple con encadenamiento para almacenar entidades por clave.
/// </summary>
public class HashTableCustom<TKey, TValue> where TKey : notnull
{
    private readonly LinkedList<KeyValuePair<TKey, TValue>>[] _buckets;
    private readonly IEqualityComparer<TKey> _comparer;

    public HashTableCustom(int capacity = 97, IEqualityComparer<TKey>? comparer = null)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("La capacidad debe ser mayor a cero", nameof(capacity));
        }

        _buckets = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        _comparer = comparer ?? EqualityComparer<TKey>.Default;
    }

    private int GetBucketIndex(TKey key)
    {
        var hash = _comparer.GetHashCode(key) & 0x7FFFFFFF;
        return hash % _buckets.Length;
    }

    public void AddOrUpdate(TKey key, TValue value)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index] ??= new LinkedList<KeyValuePair<TKey, TValue>>();

        var current = bucket.First;
        while (current is not null)
        {
            if (_comparer.Equals(current.Value.Key, key))
            {
                current.Value = new KeyValuePair<TKey, TValue>(key, value);
                return;
            }

            current = current.Next;
        }

        bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
    }

    public bool TryGetValue(TKey key, out TValue? value)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index];
        if (bucket is not null)
        {
            foreach (var pair in bucket)
            {
                if (_comparer.Equals(pair.Key, key))
                {
                    value = pair.Value;
                    return true;
                }
            }
        }

        value = default;
        return false;
    }

    public bool Remove(TKey key)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index];
        if (bucket is null)
        {
            return false;
        }

        var node = bucket.First;
        while (node is not null)
        {
            if (_comparer.Equals(node.Value.Key, key))
            {
                bucket.Remove(node);
                return true;
            }

            node = node.Next;
        }

        return false;
    }

    public IEnumerable<KeyValuePair<TKey, TValue>> Items()
    {
        foreach (var bucket in _buckets)
        {
            if (bucket is null)
            {
                continue;
            }

            foreach (var pair in bucket)
            {
                yield return pair;
            }
        }
    }
}
