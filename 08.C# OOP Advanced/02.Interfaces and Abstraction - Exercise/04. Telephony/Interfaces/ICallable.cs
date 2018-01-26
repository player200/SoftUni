using System.Collections.Generic;
public interface ICallable
{
    ICollection<string> Numbers { get; }
    string Call(string number);
}