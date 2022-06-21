using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Warships
{
    public class Warships
    {
        public static bool isFinish = false;
        public static int rowPlayer = 0;
        public static int colPlayer = 0;
        public static int firstPlayerShip = 0;
        public static int secondPlayerShip = 0;
        static void Main(string[] args)
        {
            int fieldSixe = int.Parse(Console.ReadLine());
            Queue<Tuple<int, int>> coordinates = new Queue<Tuple<int, int>>();
            ReadCommands(coordinates);
            string[][] matrix = new string[fieldSixe][];
            ReadMatrix(matrix);
            int shipsFirstPlayerBegin = firstPlayerShip;
            int shipsSecondPlayerBegin = secondPlayerShip;
            while (coordinates.Count > 0)
            {
                rowPlayer = coordinates.Peek().Item1;
                colPlayer = coordinates.Dequeue().Item2;
                if (!IsValidPosition(matrix, rowPlayer, colPlayer))
                {
                    continue;
                }
                if (firstPlayerShip == 0 || secondPlayerShip == 0)
                {
                    break;
                }
                Attack(matrix, rowPlayer, colPlayer);
            }
            if (secondPlayerShip == 0)
            {
                Console.WriteLine($"Player One has won the game! {shipsFirstPlayerBegin + shipsSecondPlayerBegin - firstPlayerShip - secondPlayerShip} ships have been sunk in the battle.");
            }
            else if (firstPlayerShip == 0)
            {
                Console.WriteLine($"Player Two has won the game! {shipsFirstPlayerBegin + shipsSecondPlayerBegin - firstPlayerShip - secondPlayerShip} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShip} ships left. Player Two has {secondPlayerShip} ships left.");
            }
        }


        public static void Attack(string[][] matrix, int rowPlayer, int colPlayer)
        {
           
            if (matrix[rowPlayer][colPlayer] == "<")
            {
                firstPlayerShip--;
                matrix[rowPlayer][colPlayer] = "X";
            }
            if (matrix[rowPlayer][colPlayer] == ">")
            {
                secondPlayerShip--;
                matrix[rowPlayer][colPlayer] = "X";
            }
            if (matrix[rowPlayer][colPlayer] == "#")
            {
                for (int iRow = -1; iRow <= 1; iRow++)
                {
                    for (int iCol = -1; iCol <= 1; iCol++)
                    {
                        int curentRow = rowPlayer + iRow;
                        int curentCol = colPlayer + iCol;
                        if (IsValidPosition(matrix, curentRow, curentCol))
                        {
                            if (!(curentRow == 0 && curentCol == 0))
                            {
                                if (matrix[curentRow][curentCol] == "<")
                                {
                                    firstPlayerShip--;
                                }
                                if (matrix[curentRow][curentCol] == ">")
                                {
                                    secondPlayerShip--;
                                }
                                matrix[curentRow][curentCol] = "X";
                            }
                        }
                    }
                }
            }

        }
        public static void ReadCommands(Queue<Tuple<int, int>> coordinates)
        {
            string[] input = Console.ReadLine().Split(",");
            foreach (var item in input)
            {
                int[] xCoord = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                coordinates.Enqueue(Tuple.Create(xCoord[0], xCoord[1]));
            }
        }
        private static void ReadMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                matrix[row] = new string[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col].ToString();
                    if (matrix[row][col] == "<")
                    {
                        firstPlayerShip++;
                    }
                    if (matrix[row][col] == ">")
                    {
                        secondPlayerShip++;
                    }
                }
            }
        }
        //private static void PrintMatrix(string[][] matrix)
        //{
        //    foreach (string[] line in matrix)
        //    {
        //        Console.WriteLine(string.Join("", line));
        //    }
        //}
        private static bool IsValidPosition(string[][] matrix, int row, int col)
        {
            bool isValid = row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
            return isValid;
        }
           

    }
}
