using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Soldier> army = new List<Soldier>();
        King king = new King(Console.ReadLine());
        string[] royalGuards = Console.ReadLine().Split();
        foreach (var guard in royalGuards)
        {
            Soldier royalGuard = new RoyalGuard(guard);
            army.Add(royalGuard);
            king.UnderAttack += royalGuard.KingUnderAttack;
        }
        string[] footmen = Console.ReadLine().Split();
        foreach (var guard in footmen)
        {
            Soldier footman = new Footman(guard);
            army.Add(footman);
            king.UnderAttack += footman.KingUnderAttack;
        }
        string[] command = Console.ReadLine().Split();
        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Kill":
                    Soldier soldier = army.FirstOrDefault(s => s.Name == command[1]);
                    king.UnderAttack -= soldier.KingUnderAttack;
                    army.Remove(soldier);
                    break;
                case "Attack":
                    king.OnAttack();
                    break;
            }
            command = Console.ReadLine().Split();
        }
    }
}