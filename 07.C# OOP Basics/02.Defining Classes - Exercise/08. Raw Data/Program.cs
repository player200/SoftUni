using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class Program
{
    static void Main()
    {
        int carNumber = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < carNumber; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string model = tokens[0];
            int engineSpeed = int.Parse(tokens[1]);
            int enginePower = int.Parse(tokens[2]);
            int cargoWeight = int.Parse(tokens[3]);
            string cargoType = tokens[4];
            double tireOnePressure = double.Parse(tokens[5],CultureInfo.InvariantCulture);
            int tireOneAge = int.Parse(tokens[6]);
            double tireTwoPressure = double.Parse(tokens[7], CultureInfo.InvariantCulture);
            int tireTwoAge = int.Parse(tokens[8]);
            double tireThreePressure = double.Parse(tokens[9], CultureInfo.InvariantCulture);
            int tireThreeAge = int.Parse(tokens[10]);
            double tireFourPressure = double.Parse(tokens[11], CultureInfo.InvariantCulture);
            int tireFourAge = int.Parse(tokens[12]);

            List<Tire> tires = new List<Tire>();
            tires.Add(new Tire(tireOneAge,tireOnePressure));
            tires.Add(new Tire(tireTwoAge, tireTwoPressure));
            tires.Add(new Tire(tireThreeAge, tireThreePressure));
            tires.Add(new Tire(tireFourAge, tireFourPressure));

            cars.Add(new Car(
                model,
                new Engine(engineSpeed,enginePower),
                new Cargo(cargoWeight,cargoType),
                tires));
        }
        string type = Console.ReadLine();
        if (type== "fragile")
        {
            var car = cars.Where(x=>x.Cargo.Type==type &&x.Tires.Any(z=>z.Pressure<1));
            foreach (var c in car)
            {
                Console.WriteLine($"{c.Model}");
            }
        }
        else if (type == "flamable")
        {
            var car = cars.Where(x => x.Cargo.Type == type && x.Engine.Power>250);
            foreach (var c in car)
            {
                Console.WriteLine($"{c.Model}");
            }
        }
    }
}