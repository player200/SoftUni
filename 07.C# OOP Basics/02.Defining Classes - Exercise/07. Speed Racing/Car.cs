using System;
public class Car
{
    public Car(string model, double fuelAmount,double fuelForKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelForKilometer = fuelForKilometer;
        this.DistanceTraveled = 0;
    }
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelForKilometer { get; set; }
    public int DistanceTraveled { get; set; }

    public void Traveled(int kilometers)
    {
        double fuelNeeded = kilometers * FuelForKilometer;

        if (this.FuelAmount - fuelNeeded >= 0D)
        {
            this.FuelAmount -= fuelNeeded;
            this.DistanceTraveled += kilometers;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
