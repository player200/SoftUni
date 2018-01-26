using System;
class Program
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split();
        var urls = Console.ReadLine().Split();
        var phone = new Smartphone(numbers,urls);
        Console.WriteLine(phone.ToString());
    }
}