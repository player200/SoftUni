public class StandartEmployee:BaseEmployee
{
    private const int WorkHoursPerDay = 40;
    public StandartEmployee(string name):
        base(name, WorkHoursPerDay)
    {
    }
}