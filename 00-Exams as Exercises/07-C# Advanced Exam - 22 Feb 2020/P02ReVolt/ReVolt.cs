using System;
using System.Linq;

namespace P02ReVolt
{
    internal class ReVolt
    {
        public static bool isReachFinishMark = false;
        public static int playerRow = 0;
        public static int playerCol = 0;
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());
            string[][] matrix = new string[numberOfRows][];
            ReadMatrix(matrix);
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                Move(matrix, command);
                if (isReachFinishMark == true) break;
            }
            if (isReachFinishMark) Console.WriteLine("Player won!");
            else Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        public static void Move(string[][] matrix, string direction)
        {
            matrix[playerRow][playerCol] = "-";
            if (direction == "up")
            {
                playerRow--;
                if (!IsValidPosition(matrix))
                {
                    playerRow = matrix.Length - 1;
                }
                CheckMark(matrix, direction);
            }
            else if (direction == "down")
            {
                playerRow++;
                if (!IsValidPosition(matrix))
                {
                    playerRow = 0;
                }
                CheckMark(matrix, direction);
            }
            else if (direction == "left")
            {
                playerCol--;
                if (!IsValidPosition(matrix))
                {
                    playerCol = matrix[playerRow].Length - 1;
                }
                CheckMark(matrix, direction);
            }
            else if (direction == "right")
            {
                playerCol++;
                if (!IsValidPosition(matrix))
                {
                    playerCol = 0;
                }
                CheckMark(matrix, direction);
            }
            matrix[playerRow][playerCol] = "f";
        }
        public static void CheckMark(string[][] matrix, string direction)
        {
            if (matrix[playerRow][playerCol] == "F")
            {
                isReachFinishMark = true;
                matrix[playerRow][playerCol] = "f";
            }
            else if (matrix[playerRow][playerCol] == "B")
            {
                Direction(direction, "B", matrix);
                if (matrix[playerRow][playerCol] == "F")
                {
                    isReachFinishMark = true;
                    return;
                }
                matrix[playerRow][playerCol] = "f";
            }
            else if (matrix[playerRow][playerCol] == "T")
            {
                Direction(direction, "T", matrix);
                matrix[playerRow][playerCol] = "f";
            }
        }
        public static void Direction(string direction, string letter, string[][] matrix)
        {
            if (letter == "B")
            {
                if (direction == "up") playerRow--;
                else if (direction == "down") playerRow++;
                else if (direction == "left") playerCol--;
                else if (direction == "right") playerCol++;
                if (!IsValidPosition(matrix))
                {
                    if (direction == "up") playerRow = matrix.Length - 1;
                    else if (direction == "down") playerRow = 0;
                    else if (direction == "left") playerCol = matrix[playerRow].Length - 1;
                    else if (direction == "right") playerCol = 0;
                }
            }
            else if (letter == "T")
            {
                if (direction == "up") playerRow++;
                else if (direction == "down") playerRow--;
                else if (direction == "left") playerCol++;
                else if (direction == "right") playerCol--;
            }
        }
        private static void ReadMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                matrix[row] = new string[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col].ToString();
                    if (input[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(string[][] matrix)
        {
            foreach (string[] line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
        private static bool IsValidPosition(string[][] matrix)
        {
            bool isValid = playerRow >= 0 && playerRow < matrix.Length && playerCol >= 0 && playerCol < matrix[playerRow].Length;
            return isValid;
        }
    }
}
