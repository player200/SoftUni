﻿using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 2;
    private T[] arr;

    public ReversedList(int capacity = DefaultCapacity)
    {
        this.arr = new T[capacity];
        this.Count = 0;
        this.Capacity = capacity;
    }

    public int Count { get; private set; }

    public int Capacity { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.arr[this.Count - 1 - index];
        }
        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.arr[this.Count - 1 - index] = value;
        }
    }

    public void Add(T item)
    {

        if (this.Count >= this.Capacity)
        {
            Array.Resize(ref this.arr, this.Capacity * 2);
            this.Capacity *= 2;
        }

        this.arr[this.Count++] = item;
    }

    public T RemoveAt(int index)
    {

        T element = this[index];
        this.ShiftLeft(this.Count - 1 - index);
        this.Count--;

        return element;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.arr[i] = this.arr[i + 1];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}