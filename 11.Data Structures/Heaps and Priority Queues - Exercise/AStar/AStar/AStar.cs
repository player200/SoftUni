using System;
using System.Collections.Generic;

public class AStar
{
    private PriorityQueue<Node> Open { get; set; }

    private Dictionary<Node, Node> Parent { get; set; }

    private Dictionary<Node, int> Cost { get; set; }

    private char[,] Map { get; set; }

    public AStar(char[,] map)
    {
        this.Map = map;
        this.Open = new PriorityQueue<Node>();
        this.Parent = new Dictionary<Node, Node>();
        this.Cost = new Dictionary<Node, int>();
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaX = Math.Abs(current.Col - goal.Col);
        var deltaY = Math.Abs(current.Row - goal.Row);

        return deltaY + deltaX;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        this.Open.Enqueue(start);
        this.Parent[start] = null;
        this.Cost[start] = 0;

        while (this.Open.Count != 0)
        {
            Node current = this.Open.Dequeue();

            if (current.Equals(goal))
            {
                break;
            }

            List<Node> neighbors = this.GetNeighbors(current);

            int newCost = this.Cost[current] + 1;
            foreach (Node neighbor in neighbors)
            {
                if (!this.Cost.ContainsKey(neighbor) || newCost < this.Cost[neighbor])
                {
                    this.Cost[neighbor] = newCost;
                    neighbor.F = newCost + GetH(current, goal);
                    this.Open.Enqueue(neighbor);
                    this.Parent[neighbor] = current;
                }
            }
        }

        var path = this.FoundPath(start, goal);

        return path;
    }

    private List<Node> FoundPath(Node start, Node goal)
    {
        List<Node> path = new List<Node>();
        Node currentNode = goal;
        if (this.Parent.ContainsKey(goal))
        {
            path.Add(goal);
            while (!Equals(this.Parent[currentNode], this.Parent[start]))
            {
                path.Add(this.Parent[currentNode]);
                currentNode = this.Parent[currentNode];
            }

            path.Reverse();
        }
        else
        {
            path.Add(start);
        }
        return path;
    }

    private List<Node> GetNeighbors(Node current)
    {
        List<Node> neighbors = new List<Node>();

        int rowCurrent = current.Row;
        int colCurrent = current.Col;

        if (this.IsTheCellCheckable(rowCurrent - 1, colCurrent))
        {
            neighbors.Add(new Node(rowCurrent - 1, colCurrent));
        }
        if (this.IsTheCellCheckable(rowCurrent + 1, colCurrent))
        {
            neighbors.Add(new Node(rowCurrent + 1, colCurrent));
        }
        if (this.IsTheCellCheckable(rowCurrent, colCurrent - 1))
        {
            neighbors.Add(new Node(rowCurrent, colCurrent - 1));
        }
        if (this.IsTheCellCheckable(rowCurrent, colCurrent + 1))
        {
            neighbors.Add(new Node(rowCurrent, colCurrent + 1));
        }

        return neighbors;
    }

    private bool IsTheCellCheckable(int row, int col)
    {
        return row >= 0 && row < this.Map.GetLength(0) && col >= 0 && col < this.Map.GetLength(1) && this.Map[row, col] != 'W';
    }
}