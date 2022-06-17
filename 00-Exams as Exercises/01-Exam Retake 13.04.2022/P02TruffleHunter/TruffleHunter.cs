using System;
using System.Collections.Generic;

namespace P02TruffleHunter
{
    internal class TruffleHunter
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[,] forest = new string[number, number];
            for (int row = 0; row < number; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < number; col++)
                {
                    forest[row, col] = input[col];
                }
            }
            string token = string.Empty;
            Dictionary<string, int> truffles = new Dictionary<string, int>()
            {
                {"B", 0 },
                {"S", 0 },
                {"W", 0 }
            };
            int boarTruffles = 0;
            while ((token = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = token.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string participant = tokens[0];
                int currrenRow = int.Parse(tokens[1]);
                int currrenCol = int.Parse(tokens[2]);
                if (participant == "Collect")
                {
                    if (forest[currrenRow, currrenCol] != "-")
                    {
                        truffles[forest[currrenRow, currrenCol]]++;
                        forest[currrenRow, currrenCol] = "-";
                    }
                }
                else if (participant == "Wild_Boar")
                {
                    string direction = tokens[3];
                    boarTruffles += BoarMove(forest, currrenRow, currrenCol, direction);

                }
            }
            Console.WriteLine($"Peter manages to harvest {truffles["B"]} black, {truffles["S"]} summer, and {truffles["W"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");
            PrintMatrix(forest);
        }

        private static void PrintMatrix(string[,] forest)
        {
            int number = forest.GetLength(0);
            for (int row = 0; row < number; row++)
            {
                string[] output = new string[forest.GetLength(0)];
                for (int col = 0; col < number; col++)
                {
                    output[col] = forest[row, col];
                }
                Console.WriteLine(string.Join(" ", output));
            }
        }

        private static int BoarMove(string[,] forest, int currrenRow, int currrenCol, string direction)
        {
            int boarNewTruffles = 0;
            if (direction == "up")
            {
                for (int row = currrenRow; row >= 0; row -= 2)
                {
                    if (forest[row, currrenCol] != "-")
                    {
                        boarNewTruffles++;
                        forest[row, currrenCol] = "-";
                    }

                }
            }
            else if (direction == "down")
            {
                for (int row = currrenRow; row < forest.GetLength(0); row += 2)
                {
                    if (forest[row, currrenCol] != "-")
                    {
                        boarNewTruffles++;
                        forest[row, currrenCol] = "-";
                    }

                }
            }
            else if (direction == "left")
            {
                for (int col = currrenCol; col >= 0; col -= 2)
                {
                    if (forest[currrenRow, col] != "-")
                    {
                        boarNewTruffles++;
                        forest[currrenRow, col] = "-";
                    }

                }
            }
            else if (direction == "right")
            {
                for (int col = currrenCol; col < forest.GetLength(0); col += 2)
                {
                    if (forest[currrenRow, col] != "-")
                    {
                        boarNewTruffles++;
                        forest[currrenRow, col] = "-";
                    }

                }
            }
            return boarNewTruffles;
        }
    }
}
