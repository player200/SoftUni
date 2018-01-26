using System.IO;
namespace _02.Line_Numbers
{
    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../text.txt"))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 1;
                    while (line != null)
                    {
                        writer.Write($"{lineNumber}: {line}");
                        lineNumber++;
                        writer.WriteLine();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}