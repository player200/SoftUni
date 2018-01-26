using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.Radioactive_Bunnies
{
    class Program
    {
        private static int PlayerRow = 0;
        private static int PlayerCol = 0;
        private static bool HasEscaped = false;
        private static bool IsDead = false;
        static void Main()
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = inputArgs[0];
            int m = inputArgs[1];

            char[][] lair = new char[n][];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                lair[i] = input.ToCharArray();
                if (input.Contains('P'))
                {
                    var indxCol = input.IndexOf('P');
                    PlayerRow = i;
                    PlayerCol = indxCol;
                }
            }
            HandleMoves(lair);
            PrintLair(lair);
            if (IsDead || !HasEscaped)
            {
                Console.WriteLine($"dead: {PlayerRow} {PlayerCol}");
            }
            else
            {
                Console.WriteLine($"won: {PlayerRow} {PlayerCol}");
            }
        }

        private static void PrintLair(char[][] lair)
        {
            for (int i = 0; i < lair.Length; i++)
            {
                Console.WriteLine(string.Join("", lair[i]));
            }
        }

        private static void HandleMoves(char[][] lair)
        {
            string moves = Console.ReadLine();

            for (int i = 0; i < moves.Length; i++)
            {
                if (IsDead || (HasEscaped && !IsDead))
                {
                    break;
                }

                switch (moves[i])
                {
                    case 'U':
                        MoveUP(lair);
                        break;

                    case 'D':
                        MoveDown(lair);
                        break;

                    case 'L':
                        MoveLeft(lair);
                        break;

                    case 'R':
                        MoveRight(lair);
                        break;
                }
                MultiplyBunnies(lair);
            }
        }

        private static void MultiplyBunnies(char[][] lair)
        {
            List<int[]> bunnies = new List<int[]>();

            for (int r = 0; r < lair.Length; r++)
            {
                for (int c = 0; c < lair[0].Length; c++)
                {
                    if (lair[r][c] == 'B')
                    {
                        bunnies.Add(new int[] { r, c });
                    }
                }
            }

            foreach (var bunny in bunnies)
            {
                SpreadBunny(lair, bunny[0], bunny[1]);
            }
        }

        private static void SpreadBunny(char[][] lair, int r, int c)
        {
            if (r > 0)//UpperBunny
            {
                if (lair[r - 1][c] == 'P')
                {
                    IsDead = true;
                    HasEscaped = false;
                }
                lair[r - 1][c] = 'B';
            }

            if (r < lair.Length - 1)//BottomBunny
            {
                if (lair[r + 1][c] == 'P')
                {
                    IsDead = true;
                    HasEscaped = false;
                }
                lair[r + 1][c] = 'B';
            }

            if (c > 0)//LeftBunny
            {
                if (lair[r][c - 1] == 'P')
                {
                    IsDead = true;
                    HasEscaped = false;
                }
                lair[r][c - 1] = 'B';
            }

            if (c < lair[0].Length - 1)//RightBunny
            {
                if (lair[r][c + 1] == 'P')
                {
                    IsDead = true;
                    HasEscaped = false;
                }
                lair[r][c + 1] = 'B';
            }
        }

        private static void MoveRight(char[][] lair)
        {
            if (PlayerCol == lair[0].Length - 1)
            {
                lair[PlayerRow][PlayerCol] = '.';
                HasEscaped = true;
            }
            else if (lair[PlayerRow][PlayerCol + 1] == 'B')
            {
                IsDead = true;
                lair[PlayerRow][PlayerCol] = '.';
                PlayerCol += 1;
            }
            else
            {
                lair[PlayerRow][PlayerCol] = '.';
                lair[PlayerRow][PlayerCol + 1] = 'P';
                PlayerCol += 1;
            }
        }

        private static void MoveLeft(char[][] lair)
        {
            if (PlayerCol == 0)
            {
                lair[PlayerRow][PlayerCol] = '.';
                HasEscaped = true;
            }
            else if (lair[PlayerRow][PlayerCol - 1] == 'B')
            {
                IsDead = true;
                lair[PlayerRow][PlayerCol] = '.';
                PlayerCol -= 1;
            }
            else
            {
                lair[PlayerRow][PlayerCol] = '.';
                lair[PlayerRow][PlayerCol - 1] = 'P';
                PlayerCol -= 1;
            }
        }

        private static void MoveDown(char[][] lair)
        {
            if (PlayerRow == lair.Length - 1)
            {
                lair[PlayerRow][PlayerCol] = '.';
                HasEscaped = true;
            }
            else if (lair[PlayerRow + 1][PlayerCol] == 'B')
            {
                IsDead = true;
                lair[PlayerRow][PlayerCol] = '.';
                PlayerRow += 1;
            }
            else
            {
                lair[PlayerRow][PlayerCol] = '.';
                lair[PlayerRow + 1][PlayerCol] = 'P';
                PlayerRow += 1;
            }
        }

        private static void MoveUP(char[][] lair)
        {
            if (PlayerRow == 0)
            {
                lair[PlayerRow][PlayerCol] = '.';
                HasEscaped = true;
            }
            else if (lair[PlayerRow - 1][PlayerCol] == 'B')
            {
                IsDead = true;
                lair[PlayerRow][PlayerCol] = '.';
                PlayerRow -= 1;
            }
            else
            {
                lair[PlayerRow][PlayerCol] = '.';
                lair[PlayerRow - 1][PlayerCol] = 'P';
                PlayerRow -= 1;
            }
        }
    }
}