using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.ParkingLot
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var parking = new SortedSet<string>();
            while (input!="END")
            {
                var index=Regex.Split(input,", ");
                if (index[0]=="IN")
                {
                    parking.Add(index[1]);
                }
                else
                {
                    parking.Remove(index[1]);
                }

                input = Console.ReadLine();
            }
            if (parking.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}