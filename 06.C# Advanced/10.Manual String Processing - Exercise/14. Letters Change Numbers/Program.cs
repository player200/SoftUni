using System;
using System.Linq;
namespace _14.Letters_Change_Numbers
{
    class Program
    {
        static void Main()
        {
            char[] alphaLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] alphaUper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string[] input = Console.ReadLine()
                .Split(new[] {' ','\t' },StringSplitOptions.RemoveEmptyEntries);
            double result = 0;
            double placeWord = 0;
            foreach (var tag in input)
            {
                string number = tag.Substring(1, tag.Length - 2);
                double numberFromString = double.Parse(number);
                if (alphaLower.Contains(tag[0]))
                {
                    for (int i = 0; i < alphaLower.Length; i++)
                    {
                        if (tag[0] == alphaLower[i])
                        {
                            placeWord = i+1;
                            result += placeWord * numberFromString;
                            break;
                        }
                    }
                    if (alphaLower.Contains(tag[tag.Length - 1]))
                    {
                        for (int i = 0; i < alphaLower.Length; i++)
                        {
                            if (tag[tag.Length - 1] == alphaLower[i])
                            {
                                placeWord = i+1;
                                result += placeWord;
                                break;
                            }
                        }
                    }
                    else if (alphaUper.Contains(tag[tag.Length - 1]))
                    {
                        for (int i = 0; i < alphaUper.Length; i++)
                        {
                            if (tag[tag.Length - 1] == alphaUper[i])
                            {
                                placeWord = i+1;
                                result -= placeWord;
                                break;
                            }
                        }
                    }
                }
                else if(alphaUper.Contains(tag[0]))
                {
                    for (int i = 0; i < alphaUper.Length; i++)
                    {
                        if (tag[0] == alphaUper[i])
                        {
                            placeWord = i+1;
                            result += numberFromString / placeWord;
                            break;
                        }
                    }
                    if (alphaLower.Contains(tag[tag.Length - 1]))
                    {
                        for (int i = 0; i < alphaLower.Length; i++)
                        {
                            if (tag[tag.Length - 1] == alphaLower[i])
                            {
                                placeWord = i+1;
                                result += placeWord;
                                break;
                            }
                        }
                    }
                    else if (alphaUper.Contains(tag[tag.Length - 1]))
                    {
                        for (int i = 0; i < alphaUper.Length; i++)
                        {
                            if (tag[tag.Length - 1] == alphaUper[i])
                            {
                                placeWord = i+1;
                                result -= placeWord;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("{0:f2}",result);
        }
    }
}