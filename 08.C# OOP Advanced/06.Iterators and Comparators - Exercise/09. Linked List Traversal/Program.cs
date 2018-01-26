using System;
using System.Linq;
class Program
{
    static void Main()
    {
        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "Add":
                    linkedList.Add(int.Parse(tokens[1]));
                    break;
                case "Remove":
                    int number = int.Parse(tokens[1]);
                    int removeIndex = linkedList.FirstIndexOf(number);
                    if (removeIndex > -1)
                    {
                        linkedList.Remove(linkedList.FirstIndexOf(number));
                    }
                    break;
            }
        }
        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}