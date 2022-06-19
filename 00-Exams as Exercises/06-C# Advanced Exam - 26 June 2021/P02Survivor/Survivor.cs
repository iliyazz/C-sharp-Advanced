using System;

namespace P02Survivor
{
    public class Survivor
    {
        public static int countOfCollected = 0;
        public static int countOfOpponentsTokens = 0;
        public static bool meOrOpponent = false;
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            string[][] matrix = new string[numberOfRows][];
            ReadMatrix(matrix);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArg[0] == "Find")
                {
                    meOrOpponent = true;
                    FindToken(matrix, int.Parse(cmdArg[1]), int.Parse(cmdArg[2]));
                }
                else if (cmdArg[0] == "Opponent")
                {
                    meOrOpponent = false;
                    if (IsValidPosition(matrix, int.Parse(cmdArg[1]), int.Parse(cmdArg[2])))
                    {
                        Opponent(matrix, int.Parse(cmdArg[1]), int.Parse(cmdArg[2]), cmdArg[3]);
                    }
                }
            }
            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }

        public static void Opponent(string[][] matrix, int rowFind, int colFind, string direction)
        {
            for (int i = 0; i < 4; i++)
            {
                if (direction == "up")
                {
                    FindToken(matrix, rowFind--, colFind);
                }
                else if (direction == "down")
                {
                    FindToken(matrix, rowFind++, colFind);
                }
                else if(direction == "left")
                {
                    FindToken(matrix, rowFind, colFind--);
                }
                else if(direction == "right")
                {
                    FindToken(matrix, rowFind, colFind++);
                }
            }
        }

        public static void FindToken(string[][] matrix, int rowFind, int colFind)
        {
            if (IsValidPosition(matrix, rowFind, colFind))
                if (matrix[rowFind][colFind] == "T")
                {
                    if (meOrOpponent) countOfCollected++;
                    else countOfOpponentsTokens++;
                    matrix[rowFind][colFind] = "-";
                }
        }
        private static void ReadMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void PrintMatrix(string[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }
        private static bool IsValidPosition(string[][] matrix, int newRowPosition, int newColPosition)
        {
            bool isValid = newRowPosition >= 0 && newRowPosition < matrix.Length && newColPosition >= 0 &&  newColPosition < matrix[newRowPosition].Length;
            return isValid;
        }
    }
}
