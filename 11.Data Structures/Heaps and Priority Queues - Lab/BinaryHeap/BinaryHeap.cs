using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);
        this.HeapifyUp(this.Count - 1);
    }

    public T Peek()
    {
        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.heap[0];

        this.Swap(0, this.Count - 1);
        this.heap.RemoveAt(this.Count-1);
        this.HeapifyDown(0);

        return element;
    }

    private void HeapifyDown(int index)
    {
        while (index < this.Count / 2)
        {
            int childIndex = (index * 2) + 1;
            
            if (childIndex + 1 < this.Count && IsLess(childIndex, childIndex + 1))
            {
                childIndex += 1;
            }

            int compare = this.heap[index].CompareTo(this.heap[childIndex]);

            if (compare < 0)
            {
                this.Swap(childIndex, index);
            }

            index = childIndex;
        }
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && IsLess(Parent(index), index))
        {
            this.Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void Swap(int index, int parantIndex)
    {
        T child = this.heap[index];
        T parent = this.heap[parantIndex];
        this.heap[index] = parent;
        this.heap[parantIndex] = child;
    }

    private bool IsLess(int parentIndex, int index)
    {
        int compare = this.heap[parentIndex].CompareTo(this.heap[index]);

        if (compare >= 0)
        {
            return false;
        }

        return true;
    }

    private int Parent(int index)
    {
        return (index - 1) / 2;
    }
}