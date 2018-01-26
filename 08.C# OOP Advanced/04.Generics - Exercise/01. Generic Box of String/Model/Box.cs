public class Box<T>
{
    public Box(T item)
    {
        this.Item = item;
    }
    public T Item { get; }
    public override string ToString()
    {
        return $"{Item.GetType().FullName}: {this.Item}";
    }
}