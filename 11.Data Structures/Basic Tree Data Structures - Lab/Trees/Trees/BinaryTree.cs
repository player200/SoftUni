using System;

public class BinaryTree<T>
{
    public BinaryTree(
        T value,
        BinaryTree<T> leftChild = null,
        BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public T Value { get; set; }

    public BinaryTree<T> LeftChild { get; set; }

    public BinaryTree<T> RightChild { get; set; }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        this.PrintIndentedPreOrder(this, indent);
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this, action);
    }

    public void EachPostOrder(Action<T> action)
    {
        this.EachPostOrder(this, action);
    }

    private void PrintIndentedPreOrder(BinaryTree<T> node, int indent)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine($"{new string(' ', indent)}{node.Value}");
        this.PrintIndentedPreOrder(node.LeftChild, indent + 2);
        this.PrintIndentedPreOrder(node.RightChild, indent + 2);
    }

    private void EachInOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.LeftChild, action);
        action(node.Value);
        this.EachInOrder(node.RightChild, action);
    }

    private void EachPostOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachPostOrder(node.LeftChild, action);
        this.EachPostOrder(node.RightChild, action);
        action(node.Value);
    }
}
