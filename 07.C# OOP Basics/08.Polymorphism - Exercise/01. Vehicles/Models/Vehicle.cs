using System;
public abstract class Vehicle
{
    public Vehicle(double fuelQuantity ,double fuelConsumtion,double tankCapasity)
    {
        this.TankCapacity = tankCapasity;
        this.FuelConsumtion = fuelConsumtion;
        this.FuelQuantity = fuelQuantity;
    }
    protected virtual double FuelQuantity { get; set; }
    protected double FuelConsumtion { get; set; }
    protected virtual double TankCapacity { get; set; }
    protected virtual bool Drive(double distance, bool isAcOn)
    {
        var neededFuel = distance * FuelConsumtion;
        if (neededFuel<=FuelQuantity)
        {
            this.FuelQuantity -=neededFuel;
            return true;
        }
        return false;
    }
    public string Driving(double distance, bool isAcOn)
    {
        if (this.Drive(distance,isAcOn))
        {
            return $"{this.GetType().Name} travelled {distance} km";
        }
        return $"{this.GetType().Name} needs refueling";
    }
    public string Driving(double distance)
    {
        return this.Driving(distance,true);
    }
    public virtual void Refuel(double fuelAmount)
    {
        if (fuelAmount<=0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        this.FuelQuantity += fuelAmount;
    }
    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}