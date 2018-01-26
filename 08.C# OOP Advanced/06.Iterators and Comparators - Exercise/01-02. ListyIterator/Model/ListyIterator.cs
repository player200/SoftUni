using System.Collections.Generic;
using System.Collections;
public class ListyIterator<T>: IEnumerable<T>
{
    private int index;
    public ListyIterator(IEnumerable<T> list)
    {
        this.List = new List<T>();
        foreach (var item in list)
        {
            this.List.Add(item);
        }
        this.index = 0;
    }
    public IList<T> List { get;private set; }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.List.Count; i++)
        {
            yield return this.List[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public bool Move()
    {
        if (this.index + 1 < this.List.Count)
        {
            this.index++;
            return true;
        }
        return false;
    }
    public bool HasNext()
    {
        if (this.index+1<this.List.Count)
        {
            return true;
        }
        return false;
    }
    public override string ToString()
    {
        if (this.List.Count<1)
        {
            return "Invalid Operation!";
        }
        return $"{this.List[this.index]}";
    }
}