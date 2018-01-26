using System;
using System.Collections.Generic;
using System.Linq;
namespace Problem11_ParkingSystem
{
    class Program
    {
        private static int rows;
        private static int cols;

        private static void Main()
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            rows = inputArgs[0];
            cols = inputArgs[1];

            var parking = new Dictionary<int, HashSet<int>>();

            string command = Console.ReadLine();

            while (command != "stop")
            {
                var parkArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = parkArgs[0];
                int spotRow = parkArgs[1];
                int spotCol = parkArgs[2];

                var steps = 1;
                bool hasParked = false;

                if (parking.ContainsKey(spotRow))
                {
                    if (parking[spotRow].Contains(spotCol))
                    {
                        for (int moves = 1; moves < cols; moves++)
                        {
                            if ((spotCol - moves) > 0 && !parking[spotRow].Contains(spotCol - moves))
                            {
                                steps += (spotCol - moves);
                                var rowSteps = entryRow - spotRow;
                                if (rowSteps < 0)
                                {
                                    rowSteps *= -1;
                                }
                                steps += rowSteps;
                                Console.WriteLine(steps);
                                parking[spotRow].Add(spotCol - moves);
                                command = Console.ReadLine();
                                hasParked = true;
                                break;
                            }
                            if ((spotCol + moves) < cols && !parking[spotRow].Contains(spotCol + moves))
                            {
                                steps += (spotCol + moves);
                                var rowSteps = entryRow - spotRow;
                                if (rowSteps < 0)
                                {
                                    rowSteps *= -1;
                                }
                                steps += rowSteps;
                                Console.WriteLine(steps);
                                parking[spotRow].Add(spotCol + moves);
                                command = Console.ReadLine();
                                hasParked = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        parking[spotRow].Add(spotCol);

                        steps += spotCol;
                        var rowSteps = entryRow - spotRow;
                        if (rowSteps < 0)
                        {
                            rowSteps *= -1;
                        }
                        steps += rowSteps;
                        hasParked = true;
                        Console.WriteLine(steps);
                        command = Console.ReadLine();
                    }
                }
                else
                {
                    parking[spotRow] = new HashSet<int>() { spotCol };

                    steps += spotCol;
                    var rowSteps = entryRow - spotRow;
                    if (rowSteps < 0)
                    {
                        rowSteps *= -1;
                    }
                    steps += rowSteps;
                    hasParked = true;
                    Console.WriteLine(steps);
                    command = Console.ReadLine();
                }
                if (!hasParked)
                {
                    Console.WriteLine($"Row {spotRow} full");
                    command = Console.ReadLine();
                }
            }
        }
    }
}