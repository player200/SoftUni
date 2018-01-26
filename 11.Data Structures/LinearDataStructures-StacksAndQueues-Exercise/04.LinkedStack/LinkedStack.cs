using System;
using System.Collections.Generic;
using System.Linq;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T output = this.firstNode.Value;
        this.firstNode = firstNode.NextNode;
        this.Count--;

        return output;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        Node<T> currentElement = firstNode;
        for (int i = 0; i < this.Count; i++)
        {
            array[i]=currentElement.Value;
            currentElement = currentElement.NextNode;
        }
        return array;
    }

    private class Node<T>
    {
        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public Node<T> NextNode { get; set; }

        public T Value { get; set; }
    }
}