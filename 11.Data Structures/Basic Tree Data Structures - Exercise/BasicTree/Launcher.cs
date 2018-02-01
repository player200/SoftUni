using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        int numberOfNodes = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfNodes - 1; i++)
        {
            int[] nodes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int parent = nodes[0];
            int child = nodes[1];

            if (!tree.ContainsKey(parent))
            {
                tree.Add(parent, new Tree<int>(parent));
            }

            if (!tree.ContainsKey(child))
            {
                tree.Add(child, new Tree<int>(child));
            }

            Tree<int> parentNode = tree[parent];
            Tree<int> childNode = tree[child];

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        Tree<int> root = GetNode();

        //To print the root
        //PrintRoot(root);

        //To print the tree
        //PrintTree(root);

        //Print all leafs
        //PrintLeafsInAscendingOrder(root);

        //Print all middle nodes
        //PrintMiddleNodesInAscendingOrder(root);

        //Print deepest node
        //PrintDeepestNode(root);

        //Prints largest path(if there are equal print left one)
        //PrintLongestPath(root);

        //Print paths of sum for given number from console(only int inputs)
        //int neededSum = int.Parse(Console.ReadLine());
        //Console.WriteLine($"Paths of sum {neededSum}:");
        //DFS(root, neededSum);

        //Print subtrees with given sum
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {sum}:");
        SubtreeDFS(root, sum);
    }

    private static int SubtreeDFS(Tree<int> node, int neededSum)
    {
        int currentSum = node.Value;

        foreach (var child in node.Children)
        {
            currentSum += SubtreeDFS(child, neededSum);
        }

        if (neededSum == currentSum)
        {
            List<int> nodesValues = new List<int>();
            GetSubtree(node, nodesValues);
            Console.WriteLine(string.Join(" ", nodesValues));
        }

        return currentSum;
    }

    private static void GetSubtree(Tree<int> node, List<int> collector)
    {
        collector.Add(node.Value);
        foreach (var child in node.Children)
        {
            GetSubtree(child, collector);
        }
    }

    private static void PrintLongestPath(Tree<int> root)
    {
        Tree<int> longestPath = root
            .GetDeepness()
            .OrderByDescending(r => r.Deepness)
            .FirstOrDefault();

        Console.Write("Longest path: ");
        PrintPath(longestPath);
    }

    private static void PrintDeepestNode(Tree<int> root)
    {
        List<Tree<int>> longestDepth = root
            .GetDeepness()
            .OrderByDescending(r => r.Deepness)
            .ToList();

        Console.WriteLine($"Deepest node: {longestDepth[0].Value}");
    }

    private static void DFS(Tree<int> node, int targetSum, int sum = 0)
    {
        sum += node.Value;

        if (sum == targetSum)
        {
            PrintPath(node);
        }

        foreach (var child in node.Children)
        {
            DFS(child, targetSum, sum);
        }
    }

    private static void PrintPath(Tree<int> node)
    {
        Stack<int> path = new Stack<int>();
        Tree<int> start = node;

        path.Push(start.Value);

        while (start.Parent != null)
        {
            start = start.Parent;
            path.Push(start.Value);
        }

        Console.WriteLine(string.Join(" ", path));
    }

    private static void PrintMiddleNodesInAscendingOrder(Tree<int> root)
    {
        Console.WriteLine($"Middle nodes: {string.Join(" ", root.GetMiddleNodes().OrderBy(a => a))}");
    }

    private static void PrintLeafsInAscendingOrder(Tree<int> root)
    {
        Console.WriteLine($"Leaf nodes: {string.Join(" ", root.GetLeafs().OrderBy(a => a))}");
    }

    private static void PrintTree(Tree<int> root)
    {
        root.Print();
    }

    private static void PrintRoot(Tree<int> root)
    {
        Console.WriteLine($"Root node: {root.GetRoot()}");
    }

    public static Tree<int> GetNode()
    {
        return tree
            .FirstOrDefault(x => x.Value.Parent == null)
            .Value;
    }
}