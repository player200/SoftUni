namespace _02.KaminoFactory
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int countOfBits = int.Parse(Console.ReadLine());
            int[] bestDna = null;
            int bestLen = -1;
            int startIndex = -1;
            int bestDnaSum = 0;
            int bestSampleIndex = 0;

            int currentSampleIndex = 0;

            string input;
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] currentDna = input
                    .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentLen = 0;
                int currentBestLen = 0;
                int currentEndIndex = 0;

                for (int i = 0; i < currentDna.Length; i++)
                {
                    if (currentDna[i] == 1)
                    {
                        currentLen++;
                        if (currentLen > currentBestLen)
                        {
                            currentEndIndex = i;
                            currentBestLen = currentLen;
                        }

                    }
                    else
                    {
                        currentLen = 0;
                    }
                }

                int currentStartIndex = currentEndIndex - currentBestLen + 1;

                bool isCurrentDnaBetter = false;
                int currentDnaSum = currentDna
                    .Sum();

                if (currentBestLen > bestLen)
                {
                    isCurrentDnaBetter = true;
                }
                else if (currentBestLen == bestLen)
                {
                    if (currentStartIndex < startIndex)
                    {
                        isCurrentDnaBetter = true;
                    }
                    else if (currentStartIndex == startIndex)
                    {
                        if (currentDnaSum > bestDnaSum)
                        {
                            isCurrentDnaBetter = true;
                        }
                    }
                }

                currentSampleIndex++;

                if (isCurrentDnaBetter)
                {
                    bestLen = currentBestLen;
                    startIndex = currentStartIndex;

                    bestDna = currentDna;
                    bestDnaSum = currentDnaSum;
                    bestSampleIndex = currentSampleIndex;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {bestDnaSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}