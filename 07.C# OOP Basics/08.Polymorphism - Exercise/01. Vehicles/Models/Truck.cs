public class Truck : Vehicle
{
    private const double ConsumtionMod = 1.6;
    private const double FuelCost = 0.95;
    public Truck(double fuelQuantity, double fuelConsumtion, double tankCapasity) :
        base(fuelQuantity, fuelConsumtion+ConsumtionMod,tankCapasity)
    {
    }
    public override void Refuel(double fuelAmount)
    {
        base.Refuel(fuelAmount* FuelCost);
    }
}