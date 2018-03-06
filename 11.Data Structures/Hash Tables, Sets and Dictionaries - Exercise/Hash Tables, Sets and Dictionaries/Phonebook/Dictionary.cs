using System.Collections;
using System.Collections.Generic;

public class Dictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private HashTable<TKey, TValue> table;

    public Dictionary()
    {
        this.table = new HashTable<TKey, TValue>();
    }

    public int Count
    {
        get
        {
            return this.table.Count;
        }
    }

    public int Capacity
    {
        get
        {
            return this.table.Capacity;
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.table.Get(key);
        }
        set
        {
            this.table.AddOrReplace(key, value);
        }
    }

    public void Add(TKey key, TValue value)
    {
        this.table.Add(key, value);
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        return this.table.AddOrReplace(key, value);
    }

    public TValue Get(TKey key)
    {
        return this.table.Get(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return this.table.TryGetValue(key, out value);
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        return this.table.Find(key);
    }

    public bool ContainsKey(TKey key)
    {
        return this.table.ContainsKey(key);
    }

    public bool Remove(TKey key)
    {
        return this.table.Remove(key);
    }

    public void Clear()
    {
        this.table.Clear();
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.table.Keys;
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.table.Values;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        return this.table.GetEnumerator();
    }
}