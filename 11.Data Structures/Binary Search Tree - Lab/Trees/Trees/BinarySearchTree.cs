using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    public BinarySearchTree()
    {
    }

    private BinarySearchTree(Node root)
    {
        this.PreOrderCopy(root);
    }

    public void Insert(T value)
    {
        this.root = this.Insert(value, this.root);
    }

    public bool Contains(T value)
    {
        Node current = this.FindElement(value);

        return current != null;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node current = this.root;
        Node parent = null;
        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }

        if (parent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.FindElement(item);

        if (current==null)
        {
            return null;
        }

        return new BinarySearchTree<T>(current);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void Range(Node root, Queue<T> queue, T startRange, T endRange)
    {
        if (root == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(root.Value);
        int nodeInHigherRange = endRange.CompareTo(root.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(root.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(root.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(root.Right, queue, startRange, endRange);
        }
    }

    private void PreOrderCopy(Node current)
    {
        if (current == null)
        {
            return;
        }

        this.Insert(current.Value);
        this.PreOrderCopy(current.Left);
        this.PreOrderCopy(current.Right);
    }

    private Node Insert(T element, Node root)
    {
        if (root == null)
        {
            root = new Node(element);
        }
        else if (element.CompareTo(root.Value) < 0)
        {
            root.Left = this.Insert(element, root.Left);
        }
        else if (element.CompareTo(root.Value) > 0)
        {
            root.Right = this.Insert(element, root.Right);
        }

        root.Count = 1 + this.Count(root.Left) + this.Count(root.Right);

        return root;
    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void EachInOrder(Node root, Action<T> action)
    {
        if (root == null)
        {
            return;
        }

        this.EachInOrder(root.Left, action);
        action(root.Value);
        this.EachInOrder(root.Right, action);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public int Count { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {

    }
}
