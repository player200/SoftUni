using System;
namespace _15.Melrah_Shake
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();
            while (true)
            {
                int firstIndex = text.IndexOf(pattern);
                int lastIndex = text.LastIndexOf(pattern);

                if (firstIndex==-1 || firstIndex==lastIndex)
                {
                    break;
                }
                text = text.Remove(lastIndex, pattern.Length);
                text = text.Remove(firstIndex,pattern.Length);
                Console.WriteLine("Shaked it.");

                if (pattern.Length>1)
                {
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}