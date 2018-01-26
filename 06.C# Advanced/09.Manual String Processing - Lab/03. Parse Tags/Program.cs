using System;
namespace _03.Parse_Tags
{
    class Program
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            string openTag = "<upcase>";
            string closeTag = "</upcase>";
            int startIndex = inputText.IndexOf(openTag);
            while (startIndex!=-1)
            {
                int endIndex = inputText.IndexOf(closeTag);
                if (endIndex==-1)
                {
                    break;
                }
                string tag = inputText
                    .Substring(startIndex,endIndex-startIndex+closeTag.Length);
                string replaceTag = tag
                    .Replace(openTag,"")
                    .Replace(closeTag,"")
                    .ToUpper();

                inputText = inputText.Replace(tag, replaceTag);
                startIndex = inputText.IndexOf(openTag);
            }
            Console.WriteLine(inputText);
        }
    }
}