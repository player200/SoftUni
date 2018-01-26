using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public T Value { get; set; }

    public IList<Tree<T>> Children { get; set; }

    public void Print(int indent = 0)
    {
        this.Print(this, indent);
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();
        this.DFS(this, result);
        return result;
    }

    public IEnumerable<T> OrderBFS()
    {
        Queue<Tree<T>> collector = new Queue<Tree<T>>();
        List<T> result = new List<T>();

        collector.Enqueue(this);

        while (collector.Count > 0)
        {
            Tree<T> current = collector.Dequeue();
            result.Add(current.Value);

            foreach (var child in current.Children)
            {
                collector.Enqueue(child);
            }
        }

        return result;
    }

    private void Print(Tree<T> node, int indent)
    {

        Console.WriteLine($"{new string(' ', indent)}{node.Value}");

        foreach (var child in node.Children)
        {
            child.Print(indent + 2);
        }
    }
    
    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.Children)
        {
            this.DFS(child, result);
        }

        result.Add(tree.Value);
    }
}