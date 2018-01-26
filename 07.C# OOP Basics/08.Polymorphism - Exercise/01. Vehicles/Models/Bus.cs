using System;
public class Bus : Vehicle
{
    private const double ConsumtionMod = 1.4;
    public Bus(double fuelQuantity, double fuelConsumtion ,double tankCapasity)
        : base(fuelQuantity, fuelConsumtion,tankCapasity)
    {
    }
    protected override double FuelQuantity
    {
        set
        {
            if (value>this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
            base.FuelQuantity = value;
        }
    }
    protected override bool Drive(double distance, bool isAcOn)
    {
        var requeredFuel = 0.0;
        if (isAcOn)
        {
            requeredFuel = distance * (this.FuelConsumtion+ConsumtionMod);
        }
        else
        {
            requeredFuel = distance * this.FuelConsumtion;
        }
        if (requeredFuel<=this.FuelQuantity)
        {
            this.FuelQuantity -= requeredFuel;
            return true;
        }
        return false;
    }
}