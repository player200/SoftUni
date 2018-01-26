using System;
using System.Globalization;
class Program
{
    static void Main()
    {
        string[] inputTokens = Console.ReadLine().Split(' ');
        string names = $"{inputTokens[0]} {inputTokens[1]}";
        string address = inputTokens[2];
        Tuple<string ,string> namesAdress = new Tuple<string, string>(names, address);
        Console.WriteLine(namesAdress);

        inputTokens = Console.ReadLine().Split(' ');
        string name = inputTokens[0];
        int liters = int.Parse(inputTokens[1]);
        Tuple<string,int> nameLiters = new Tuple<string, int>(name, liters);
        Console.WriteLine(nameLiters);

        inputTokens = Console.ReadLine().Split(' ');
        int intParam = int.Parse(inputTokens[0]);
        double doubleParam = double.Parse(inputTokens[1],CultureInfo.InvariantCulture);
        Tuple<int , double> intDouble = new Tuple<int, double>(intParam, doubleParam);
        Console.WriteLine(intDouble);
    }
}