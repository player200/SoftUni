using System;
public class Car : Vehicle
{
    private const double ConsumtionMod = 0.9;
    public Car(double fuelQuantity, double fuelConsumtion, double tankCapasity)
        : base(fuelQuantity, fuelConsumtion + ConsumtionMod,tankCapasity)
    {
    }
    protected override double FuelQuantity
    {
        set
        {
            if (value> this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
            base.FuelQuantity = value;
        }
    }
}