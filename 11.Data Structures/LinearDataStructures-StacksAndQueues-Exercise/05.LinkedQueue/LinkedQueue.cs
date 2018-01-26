using System;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = new QueueNode<T>(element, null, null);
            this.tail = this.head;
            this.Count++;
        }
        else if (this.Count == 1)
        {
            this.tail = new QueueNode<T>(element, null, this.tail);
            this.head.NextNode = this.tail;
            this.Count++;
        }
        else
        {
            QueueNode<T> previosTail = this.tail;
            this.tail = new QueueNode<T>(element, null, this.tail);
            previosTail.NextNode = this.tail;
            this.Count++;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T outPutHead = this.head.Value;
        this.head = this.head.NextNode;
        this.head.PrevNode = null;
        this.Count--;

        return outPutHead;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        QueueNode<T> currentElement = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            array[i] = currentElement.Value;
            currentElement = currentElement.NextNode;
        }
        return array;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value, QueueNode<T> nextNode = null, QueueNode<T> prevNote = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
            this.PrevNode = prevNote;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }
    }
}
