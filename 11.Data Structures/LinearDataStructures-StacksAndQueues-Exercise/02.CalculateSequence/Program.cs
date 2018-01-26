namespace _02.CalculateSequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Queue<int> collector = new Queue<int>();
            collector.Enqueue(number);

            Queue<int> resultNumbers = new Queue<int>();
            int lastNumber = collector.Peek();
            while (resultNumbers.Count <= 50)
            {
                lastNumber = collector.Peek();

                if (resultNumbers.Count==0)
                {
                    resultNumbers.Enqueue(collector.Dequeue());
                }
                else
                {
                    collector.Dequeue();
                }

                collector.Enqueue(lastNumber + 1);
                resultNumbers.Enqueue(lastNumber + 1);

                collector.Enqueue(2*lastNumber + 1);
                resultNumbers.Enqueue(2 * lastNumber + 1);

                collector.Enqueue(lastNumber + 2);
                resultNumbers.Enqueue(lastNumber + 2);

            }

            string outPutResult = "";
            for (int i = 0; i < 50; i++)
            {
                if (outPutResult!= "")
                {
                  outPutResult = outPutResult + ", " + resultNumbers.Dequeue();
                }
                else
                {
                    outPutResult = resultNumbers.Dequeue().ToString();
                }
            }

            Console.WriteLine(outPutResult.Trim());
        }
    }
}