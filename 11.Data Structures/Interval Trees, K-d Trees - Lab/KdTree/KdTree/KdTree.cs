using System;

public class KdTree
{
    private const int K = 2;
    private Node root;

    public class Node
    {
        public Node(Point2D point)
        {
            this.Point = point;
        }

        public Point2D Point { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }

    public Node Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(Point2D point)
    {
        Node node = this.Search(this.root, point, 0);
        return node != null;
    }

    public void Insert(Point2D point)
    {
        this.root = this.Insert(this.root, point, 0);
    }
    
    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private Node Search(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = Compare(point, node.Point, depth);
        if (cmp < 0)
        {
            return Search(node.Left, point, depth + 1);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, point, depth + 1);
        }

        return node;
    }

    private Node Insert(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return new Node(point);
        }

        int compare = depth % K;
        if (compare == 0)
        {
            int compareX = node.Point.X.CompareTo(point.X);
            if (compareX > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareX <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        else
        {
            int compareY = node.Point.Y.CompareTo(point.Y);
            if (compareY > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareY <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }

        return node;
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }

    private int Compare(Point2D first, Point2D second, int depth)
    {
        int cmp = 0;
        if (depth % K == 0)
        {
            cmp = first.X.CompareTo(second.X);
            if (cmp == 0)
            {
                cmp = first.Y.CompareTo(second.Y);
            }

            return cmp;
        }
        else
        {
            cmp = first.Y.CompareTo(second.Y);
            if (cmp == 0)
            {
                cmp = first.X.CompareTo(second.X);
            }
        }

        return cmp;
    }
}
