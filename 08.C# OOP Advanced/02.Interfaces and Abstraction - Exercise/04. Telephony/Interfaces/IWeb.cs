using System.Collections.Generic;
public interface IWeb
{
    ICollection<string> Url { get; }
    string Browse(string url);
}