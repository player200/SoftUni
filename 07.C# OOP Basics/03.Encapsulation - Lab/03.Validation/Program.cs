﻿using System;
using System.Collections.Generic;
using System.Globalization;
class Program
{
    static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            try
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        double.Parse(cmdArgs[3],CultureInfo.InvariantCulture));

                persons.Add(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var bonus = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        persons.ForEach(p => p.IncreaseSalary(bonus));
        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
}