public class PartTimeEmployee:BaseEmployee
{
    private const int WorkHoursPerDay = 20;
    public PartTimeEmployee(string name):
        base(name, WorkHoursPerDay)
    {
    }
}