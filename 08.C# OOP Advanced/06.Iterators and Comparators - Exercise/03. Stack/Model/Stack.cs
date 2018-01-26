using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Stack<T>
{
    public Stack()
    {
        this.Stacks = new List<T>();
    }
    public IList<T> Stacks { get; private set; }
    public void Pop()
    {
        if (this.Stacks.Count > 0)
        {
            this.Stacks.RemoveAt(this.Stacks.Count - 1);
        }
        else
        {
            throw new ArgumentException("No elements");
        }
    }
    public void Push(params T[] items)
    {
        foreach (var item in items)
        {
            this.Stacks.Add(item);
        }
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in this.Stacks.Reverse())
        {
            sb.AppendLine($"{item}");
        }
        foreach (var item in this.Stacks.Reverse())
        {
            sb.AppendLine($"{item}");
        }
        return $"{sb.ToString().Trim()}";
    }
}