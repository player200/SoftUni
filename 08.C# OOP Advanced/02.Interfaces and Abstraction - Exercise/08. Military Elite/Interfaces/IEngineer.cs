using System.Collections.Generic;
public interface IEngineer : ISpecialisedSoldier
{
    IList<IRepair> Parts { get; }
}