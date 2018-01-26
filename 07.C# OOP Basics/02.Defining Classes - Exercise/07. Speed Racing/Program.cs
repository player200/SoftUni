using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class Program
{
    static void Main()
    {
        int carsNumber = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < carsNumber; i++)
        {
            string[] car = Console.ReadLine()
                .Split();
            string model = car[0];
            double fuelAmount = double.Parse(car[1],CultureInfo.InvariantCulture);
            double fuelForKilometer = double.Parse(car[2], CultureInfo.InvariantCulture);
            cars.Add(new Car(model, fuelAmount, fuelForKilometer));
        }
        string inputLine;
        while ((inputLine=Console.ReadLine())!="End")
        {
            string[] tokens = inputLine.Split();
            string model = tokens[1];
            int kilos = int.Parse(tokens[2]);

            Car car = cars.First(x=>x.Model==model);
            car.Traveled(kilos);
        }
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}