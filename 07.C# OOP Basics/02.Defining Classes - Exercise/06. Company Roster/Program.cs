using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class Program
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        List<Employee> empl = new List<Employee>();
        for (int row = 0; row < numberOfLines; row++)
        {
            string[] inputLine = Console.ReadLine()
                .Split();
            string name = inputLine[0];
            decimal salary = decimal.Parse(inputLine[1],CultureInfo.InvariantCulture);
            string position = inputLine[2];
            string department = inputLine[3];
            Employee employee = new Employee(name, salary, position, department);
            if (inputLine.Length>4)
            {
                int age;
                if (int.TryParse(inputLine[4],out age))
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = inputLine[4];
                }
                if (inputLine.Length>5)
                {
                    employee.Age = int.Parse(inputLine[5]);
                }
            }
            empl.Add(employee);
        }
        var bestDep = empl
            .GroupBy(x => x.Department,
                     x => new
                     {
                         Name = x.Name,
                         Salary = x.Salary,
                         Email = string.IsNullOrEmpty(x.Email) ? "n/a" : x.Email,
                         Age = x.Age != null ? x.Age.Value : -1
                     },
                     (department, emplos) =>
                     new
                     {
                         Department = department,
                         Emps = emplos.OrderByDescending(e => e.Salary).ToList()
                     })
                     .OrderByDescending(x => x.Emps.Average(e => e.Salary))
                     .First();

        Console.WriteLine($"Highest Average Salary: {bestDep.Department}");
        foreach (var e in bestDep.Emps)
        {
            Console.WriteLine($"{e.Name} {e.Salary:F2} {e.Email} {e.Age}");
        }
    }
}