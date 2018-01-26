using System;
using System.Globalization;
class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carInfo[1], CultureInfo.InvariantCulture)
            , double.Parse(carInfo[2], CultureInfo.InvariantCulture)
            , double.Parse(carInfo[3], CultureInfo.InvariantCulture));

        string[] truckInfo = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(truckInfo[1], CultureInfo.InvariantCulture)
            , double.Parse(truckInfo[2], CultureInfo.InvariantCulture)
            , double.Parse(truckInfo[3], CultureInfo.InvariantCulture));

        string[] busInfo = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(busInfo[1], CultureInfo.InvariantCulture)
            , double.Parse(busInfo[2], CultureInfo.InvariantCulture)
            , double.Parse(busInfo[3], CultureInfo.InvariantCulture));

        var numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            try
            {
                string[] inputs = Console.ReadLine().Split();
                if (inputs[1] == "Car")
                {
                    Command(car, inputs[0], double.Parse(inputs[2], CultureInfo.InvariantCulture));
                }
                else if (inputs[1] == "Bus")
                {
                    Command(bus, inputs[0], double.Parse(inputs[2], CultureInfo.InvariantCulture));
                }
                else
                {
                    Command(truck, inputs[0], double.Parse(inputs[2], CultureInfo.InvariantCulture));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
    private static void Command(Vehicle vehicle, string command,double parameter)
    {
        switch (command)
        {
            case "Drive":
                Console.WriteLine(vehicle.Driving(parameter));
                break;
            case "Refuel":
                vehicle.Refuel(parameter);
                break;
            case "DriveEmpty":
                Console.WriteLine(vehicle.Driving(parameter, false));
                break;
        }
    }
}