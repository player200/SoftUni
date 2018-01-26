using System;
using System.Globalization;
class Program
{
    static void Main()
    {
        string[] inputTokens = Console.ReadLine().Split(' ');
        string names = $"{inputTokens[0]} {inputTokens[1]}";
        string address = inputTokens[2];
        string town = inputTokens[3];
        Threeuple<string, string,string> namesAdress = new Threeuple<string, string,string>(names, address,town);
        Console.WriteLine(namesAdress);

        inputTokens = Console.ReadLine().Split(' ');
        string name = inputTokens[0];
        int liters = int.Parse(inputTokens[1]);
        bool boolean = false;
        if (inputTokens[2]=="drunk")
        {
            boolean = true;
        }
        Threeuple<string, int,bool> nameLiters = new Threeuple<string, int, bool>(name, liters,boolean);
        Console.WriteLine(nameLiters);

        inputTokens = Console.ReadLine().Split(' ');
        string nameOf = inputTokens[0];
        double doubleParam = double.Parse(inputTokens[1], CultureInfo.InvariantCulture);
        string bankName =inputTokens[2];
        Threeuple<string, double,string> intDouble = new Threeuple<string, double, string>(nameOf, doubleParam,bankName);
        Console.WriteLine(intDouble);
    }
}