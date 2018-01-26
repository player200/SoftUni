using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayStack<T>
{
    private const int InitialCapacity = 16;
    private T[] elements;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            Array.Resize(ref this.elements, this.elements.Length * 2);
        }

        this.elements[this.Count++] = element;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        int lastIndex = this.Count - 1;
        T element = this.elements[lastIndex];
        this.elements[lastIndex] = default(T);
        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        LinkedList<T> list = new LinkedList<T>();
        for (int i = 0; i < this.Count; i++)
        {
            list.AddFirst(this.elements[i]);
        }

        return list.ToArray();
    }
}
