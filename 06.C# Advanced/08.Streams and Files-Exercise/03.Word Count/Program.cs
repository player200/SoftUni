using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _03.Word_Count
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> dictionaryWord = new Dictionary<string, int>();

            using (StreamReader readWords=new StreamReader("../../words.txt"))
            {
                string line ="";
                while ((line = readWords.ReadLine())!=null)
                {
                    string[] words = Regex.Split(line.ToLower(), @"\W");
                    foreach (var word in words)
                    {
                        dictionaryWord[word] = 0;
                    }
                }
                using (StreamReader readText = new StreamReader("../../text.txt"))
                {
                    string text = "";
                    while ((text = readText.ReadLine())!=null)
                    {
                        string[] textItem = Regex.Split(text.ToLower(), @"\W");
                        foreach (var item in textItem)
                        {
                            if (dictionaryWord.ContainsKey(item))
                            {
                                dictionaryWord[item]++;
                            }
                        }
                    }
                }
                using (StreamWriter resultWriter=new StreamWriter("../../result.txt"))
                {
                    var result = dictionaryWord.OrderByDescending(d=>d.Value);
                    foreach (var word in result)
                    {
                        resultWriter.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}