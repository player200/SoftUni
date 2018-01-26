using System;
class Program
{
    static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        DateModifier modifier = new DateModifier();
        modifier.FindDifference(firstDate, secondDate);
        Console.WriteLine(modifier.DateDifferenceDays);
    }
}
