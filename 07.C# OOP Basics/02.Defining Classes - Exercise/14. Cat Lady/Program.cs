using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class Program
{
    static void Main()
    {
        List<Cat> cats = new List<Cat>();
        string inputLine;
        while ((inputLine=Console.ReadLine())!="End")
        {
            string[] tokens = inputLine.Split();
            string type = tokens[0];
            string names = tokens[1];
            switch (type)
            {
                case "StreetExtraordinaire":
                    int decibelOfMeows = int.Parse(tokens[2]);
                    cats.Add(new StreetExtraordinaire(names, decibelOfMeows));
                    break;
                case "Siamese":
                    int earSize = int.Parse(tokens[2]);
                    cats.Add(new Siamese(names, earSize));
                    break;
                case "Cymric":
                    double furLenght = double.Parse(tokens[2],CultureInfo.InvariantCulture);
                    cats.Add(new Cymric(names, furLenght));
                    break;
            }
        }
        string name = Console.ReadLine();
        Cat cat = cats.FirstOrDefault(x=>x.Name==name);
        Console.WriteLine(cat.ToString());
    }
}