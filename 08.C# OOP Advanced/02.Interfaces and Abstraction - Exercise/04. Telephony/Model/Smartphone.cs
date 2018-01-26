using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Smartphone:ICallable,IWeb
{
    public Smartphone(ICollection<string> numbers, ICollection<string> urls)
    {
        this.Numbers = new List<string>(numbers);
        this.Url = new List<string>(urls);
    }
    public ICollection<string> Numbers { get; }
    public ICollection<string> Url { get; }
    public string Call(string num)
    {
        if (num.All(c => char.IsDigit(c)))
        {
            return $"Calling... {num}";
        }
        return "Invalid number!";
    }
    public string Browse(string web)
    {
        if (!web.Any(c => char.IsDigit(c)))
        {
            return $"Browsing: {web}!";
        }
        return "Invalid URL!";
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var number in this.Numbers)
        {
            sb.AppendLine(this.Call(number));
        }
        foreach (var url in this.Url)
        {
            sb.AppendLine(this.Browse(url));
        }
        return sb.ToString().Trim();
    }
}