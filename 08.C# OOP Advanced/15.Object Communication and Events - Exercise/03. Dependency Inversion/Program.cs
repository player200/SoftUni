using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
        {
            { '+', new AdditionStrategy()},
            { '-', new SubtractionStrategy()},
            { '*', new MultiplyStrategy()},
            { '/', new DivideStrategy()},
        };
        PrimitiveCalculator calculator = new PrimitiveCalculator(strategies['+'], strategies);
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            string[] tokens = inputLine.Split();
            if (tokens[0] == "mode")
            {
                calculator.ChangeStrategy(char.Parse(tokens[1]));
            }
            else
            {
                Console.WriteLine(calculator.PerformCalculation(int.Parse(tokens[0]), int.Parse(tokens[1])));
            }
        }
    }
}