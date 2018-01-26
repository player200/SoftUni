using System;
using System.Linq;
class Program
{
    static void Main()
    {
        ListyIterator<string> list = null;
        string inputLine;
        while ((inputLine=Console.ReadLine())!="END")
        {
            var tokens = inputLine.Split();
            string command = tokens[0];
            switch (command)
            {
                case "Create":
                    list = new ListyIterator<string>(tokens.Skip(1));
                    break;
                case "Move":
                    Console.WriteLine(list.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(list.HasNext());
                    break;
                case "Print":
                    Console.WriteLine(list.ToString());
                    break;
                case "PrintAll":
                    Console.WriteLine($"{string.Join(" ", list)}");
                    break;
            }
        }
    }
}