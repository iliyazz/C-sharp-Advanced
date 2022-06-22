using System;
using System.Linq;

namespace P02Bee
{
    public class Bee
    {
        private static int pollinatedFlowers = 0;
        private static bool isFinish;
        private static int beePosRow;
        private static int beePosCol;
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixSize][];
            int[] beeCoordinates = new int[2];
            ReadMatrix(matrix, beeCoordinates);
            beePosRow = beeCoordinates[0];
            beePosCol = beeCoordinates[1];
            string command = string.Empty;
            isFinish = false;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        Move(matrix, -1, 0);
                        break;
                    case "down":
                        Move(matrix, 1, 0);
                        break;
                    case "left":
                        Move(matrix, 0, -1);
                        break;
                    case "right":
                        Move(matrix, 0, 1);
                        break;
                }
                if (isFinish)
                {
                    break;
                }
            }
            if (isFinish)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            PrintMatrix(matrix);
        }
        public static void Move(char[][] matrix, int moveToRow, int moveToCol)
        {
            matrix[beePosRow][beePosCol] = '.';
            beePosRow += moveToRow;
            beePosCol += moveToCol;
            if (!IsValidPosition(matrix, beePosRow, beePosCol))
            {
                isFinish = true;
                return;
            }
            else if (matrix[beePosRow][beePosCol] == 'O')
            {
                matrix[beePosRow][beePosCol] = '.';
                beePosRow += moveToRow;
                beePosCol += moveToCol;

                if (matrix[beePosRow][beePosCol] == 'f')
                {
                    pollinatedFlowers++;
                    matrix[beePosRow][beePosCol] = 'B';
                }
                else
                {
                    matrix[beePosRow][beePosCol] = 'B';
                }
            }
            else if (matrix[beePosRow][beePosCol] == 'f')
            {
                pollinatedFlowers++;
                matrix[beePosRow][beePosCol] = 'B';
            }
            else
            {
                matrix[beePosRow][beePosCol] = 'B';
            }
        }
        private static void ReadMatrix(char[][] matrix, int[] beeCoordinates)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                matrix[row] = input;
                for (int col = 0; col < input.Length; col++)
                {
                    if(matrix[row][col] == 'B')
                    {
                        beeCoordinates[0] = row;
                        beeCoordinates[1] = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
        private static bool IsValidPosition(char[][] matrix, int row, int col)
        {
            bool isValid = row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
            return isValid;
        }
    }
}
