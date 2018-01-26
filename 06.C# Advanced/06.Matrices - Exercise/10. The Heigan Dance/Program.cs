using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.The_Heigan_Dance
{
    class Program
    {
        private static int CloudDOTleft;
        private static decimal PlayerHP = 18500M;
        private static decimal BossHP = 3000000M;
        private static decimal PlayerDPT;
        private static int PlayerRow = 7;
        private static int PlayerCol = 7;
        private static bool CloudKill = false;
        static void Main()
        {
            PlayerDPT = decimal.Parse(Console.ReadLine());
            int[][] chamber = new int[15][];

            InitializeChamber(chamber);
            ManageBattle(chamber);
        }

        private static void ManageBattle(int[][] chamber)
        {
            while (true)
            {
                string[] spellArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string spellType = spellArgs[0];
                int spellRow = int.Parse(spellArgs[1]);
                int spellCol = int.Parse(spellArgs[2]);

                var killSource = string.Empty;
                CloudKill = false;
                ApplyCloudDOT();
                HitBoss();
                if (PlayerHP <= 0 && BossHP < 0)
                {
                    Console.WriteLine("Heigan: Defeated!");
                    if (CloudKill)
                    {
                        killSource = "Plague Cloud";
                    }
                    else
                    {
                        if (spellType == "Cloud")
                        {
                            killSource = "Plague Cloud";
                        }
                        else if (spellType == "Eruption")
                        {
                            killSource = "Eruption";
                        }
                    }
                    Console.WriteLine($"Player: Killed by {killSource}");
                    Console.WriteLine($"Final position: {PlayerRow}, {PlayerCol}");
                    break;
                }
                if (BossHP <= 0)
                {
                    Console.WriteLine("Heigan: Defeated!");
                    Console.WriteLine($"Player: {PlayerHP}");
                    Console.WriteLine($"Final position: {PlayerRow}, {PlayerCol}");
                    break;
                }
                CastSpell(chamber, spellType, spellRow, spellCol);
                if (PlayerHP <= 0)
                {
                    Console.WriteLine($"Heigan: {BossHP:F2}");

                    if (spellType == "Cloud" || CloudKill)
                    {
                        killSource = "Plague Cloud";
                    }
                    else
                    {
                        killSource = "Eruption";
                    }
                    Console.WriteLine($"Player: Killed by {killSource}");
                    Console.WriteLine($"Final position: {PlayerRow}, {PlayerCol}");
                    break;
                }
            }
        }

        private static void CastSpell(int[][] chamber, string spellType, int spellRow, int spellCol)
        {
            List<int[]> affectedCells = new List<int[]>();
            for (int r = Math.Max(spellRow - 1, 0); r <= Math.Min(spellRow + 1, chamber.Length - 1); r++)
            {
                for (int c = Math.Max(spellCol - 1, 0); c <= Math.Min(spellCol + 1, chamber[0].Length - 1); c++)
                {
                    affectedCells.Add(new int[] { r, c });
                    chamber[r][c] = -1;
                }
            }
            CheckPlayer(spellType, chamber);
            CleanBattleField(chamber, affectedCells);
        }

        private static void PrintChamber(int[][] chamber)
        {
            for (int r = 0; r < chamber.Length; r++)
            {
                Console.WriteLine(string.Join(" ", chamber[r]));
            }
        }

        private static void CleanBattleField(int[][] chamber, List<int[]> affectedCells)
        {
            foreach (var cell in affectedCells)
            {
                chamber[cell[0]][cell[1]] = 0;
            }
            chamber[PlayerRow][PlayerCol] = 69;
        }

        private static void CheckPlayer(string spellType, int[][] chamber)
        {
            if (chamber[PlayerRow][PlayerCol] == -1)
            {
                if (PlayerRow > 0)
                {
                    if (chamber[PlayerRow - 1][PlayerCol] != -1)
                    {
                        PlayerRow--;
                        return;
                    }
                }
                if (PlayerCol < chamber[0].Length - 1)
                {
                    if (chamber[PlayerRow][PlayerCol + 1] != -1)
                    {
                        PlayerCol++;
                        return;
                    }
                }
                if (PlayerRow < chamber.Length - 1)
                {
                    if (chamber[PlayerRow + 1][PlayerCol] != -1)
                    {
                        PlayerRow++;
                        return;
                    }
                }
                if (PlayerCol > 0)
                {
                    if (chamber[PlayerRow][PlayerCol - 1] != -1)
                    {
                        PlayerCol--;
                        return;
                    }
                }
                
                if (spellType == "Cloud")
                {
                    PlayerHP -= 3500;
                    CloudDOTleft++;
                }
                else
                {
                    PlayerHP -= 6000;
                }
            }
        }

        private static void HitBoss()
        {
            BossHP -= PlayerDPT;
        }

        private static void ApplyCloudDOT()
        {
            if (CloudDOTleft > 0)
            {
                for (int i = 0; i < CloudDOTleft; i++)
                {
                    PlayerHP -= 3500;
                }
                CloudDOTleft = 0;
                if (PlayerHP <= 0)
                {
                    CloudKill = true;
                }
            }
        }

        private static void InitializeChamber(int[][] chamber)
        {
            for (int r = 0; r < chamber.Length; r++)
            {
                chamber[r] = new int[15];
            }

            chamber[7][7] = 69;
        }
    }
}