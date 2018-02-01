using System;
using System.Collections.Generic;
using System.Linq;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public T Value { get; set; }

    public List<Tree<T>> Children { get; set; }

    public Tree<T> Parent { get; set; }

    public int Deepness { get; private set; }

    public void Print(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}{this.Value}");
        foreach (var child in this.Children)
        {
            child.Print(indent + 2);
        }
    }

    public T GetRoot()
    {
        if (this.Value == null)
        {
            throw new InvalidCastException();
        }

        return this.Value;
    }

    public List<T> GetLeafs()
    {
        var leafNodes = new List<T>();

        this.GetLeafs(this, leafNodes);

        return leafNodes;
    }

    public List<T> GetMiddleNodes()
    {
        var leafNodes = new List<T>();

        this.GetMiddleNodes(this, leafNodes);

        return leafNodes;
    }

    public List<Tree<T>> GetDeepness(int deepness = 0)
    {
        List<Tree<T>> nodesWithDeepness = new List<Tree<T>>();

        this.GetDeepness(this, deepness, nodesWithDeepness);

        return nodesWithDeepness;
    }

    private void GetDeepness(Tree<T> node, int deepness, List<Tree<T>> collector)
    {
        if (node == null)
        {
            return;
        }

        node.Deepness = deepness;
        collector.Add(node);

        foreach (var child in node.Children)
        {
            child.GetDeepness(child, deepness + 1, collector);
        }
    }


    private void GetLeafs(Tree<T> node, List<T> leafNodes)
    {
        if (node == null)
        {
            return;
        }

        if (node.Children.Count == 0)
        {
            leafNodes.Add(node.Value);
        }

        foreach (var child in node.Children)
        {
            child.GetLeafs(child, leafNodes);
        }
    }

    private void GetMiddleNodes(Tree<T> node, List<T> leafNodes)
    {
        if (node == null)
        {
            return;
        }

        if (node.Children.Count > 0 && node.Parent != null)
        {
            leafNodes.Add(node.Value);
        }

        if (node.Children.Any())
        {
            foreach (var child in node.Children)
            {
                child.GetMiddleNodes(child, leafNodes);
            }
        }
    }
}