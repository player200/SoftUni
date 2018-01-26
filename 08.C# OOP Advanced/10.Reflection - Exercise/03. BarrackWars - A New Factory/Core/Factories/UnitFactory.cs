using System;
public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Type typeUnit = Type.GetType(unitType);
        IUnit unitInstance = (IUnit)Activator.CreateInstance(typeUnit);
        return unitInstance;
    }
}