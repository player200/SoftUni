using System;

public class Program
{
    public static void Main()
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        string inputInfo;
        while ((inputInfo = Console.ReadLine()) != "search")
        {
            string[] tokens = inputInfo
                .Split('-');
            string name = tokens[0];
            string number = tokens[1];

            phoneBook.Add(name, number);
        }

        string inputName;
        while ((inputName = Console.ReadLine()) != "end")
        {
            if (!phoneBook.ContainsKey(inputName))
            {
                Console.WriteLine($"Contact {inputName} does not exist.");
            }
            else
            {
                Console.WriteLine($"{inputName} -> {phoneBook[inputName]}");
            }
        }
    }
}