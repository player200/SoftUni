using System;
using System.Text;
public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;
    public Worker(string firstName,string lastName, decimal weekSalary, decimal workHoursPerDay):base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }
    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value<1 || value>12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }
    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value<=10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }
    private decimal SalaryPerHour()
    {
        return this.WeekSalary/(5m*this.workHoursPerDay);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour():f2}");
        return sb.ToString();
    }
}