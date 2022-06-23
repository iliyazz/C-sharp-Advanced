using System;
using System.Linq;

namespace P02Snake
{
    internal class Program
    {
        private static char[,] matrix;
        private static int[] snakePosition = new int[2];
        private static int food = 0;
        private static int[] burrowsPosition = new int[4];
        private static string command = string.Empty;
        private static bool isOutOfSquare = true;
        static void Main(string[] args)
        {
            int martrixSize = int.Parse(Console.ReadLine());
            matrix = new char[martrixSize, martrixSize];
            ReadMatrix(matrix, snakePosition, burrowsPosition);
            while (true)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
                if (!isOutOfSquare)
                {
                    break;
                }
                if (food >= 10)
                {
                    break;
                }
            }
            if (!isOutOfSquare)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");
            PrintMatrix(matrix);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] printLine = new char[matrix.GetLength(1)];
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    printLine[col] = matrix[row, col];
                }
                Console.WriteLine(string.Join("", printLine));
            }
        }
        private static void Move(int moveToRow, int moveToCol)
        {
            if (!IsValidPosition(snakePosition[0] + moveToRow, snakePosition[1] + moveToCol))
            {
                matrix[snakePosition[0], snakePosition[1]] = '.';
                isOutOfSquare = false;
                return;
            }
            matrix[snakePosition[0], snakePosition[1]] = '.';
            snakePosition[0] += moveToRow;
            snakePosition[1] += moveToCol;
            if (matrix[snakePosition[0], snakePosition[1]] == 'B')
            {
                if (snakePosition[0] == burrowsPosition[0] && snakePosition[1] == burrowsPosition[1])
                {
                    matrix[burrowsPosition[0], burrowsPosition[1]] = '.';
                    snakePosition[0] = burrowsPosition[2];
                    snakePosition[1] = burrowsPosition[3];
                    matrix[snakePosition[0], snakePosition[1]] = 'S';
                }
                else
                {
                    matrix[burrowsPosition[2], burrowsPosition[3]] = '.';
                    snakePosition[2] = burrowsPosition[0];
                    snakePosition[3] = burrowsPosition[1];
                    matrix[snakePosition[0], snakePosition[1]] = 'S';
                }
            }
            else
            {
                if (matrix[snakePosition[0], snakePosition[1]] == '*')
                {
                    food ++;
                }
                matrix[snakePosition[0], snakePosition[1]] = 'S';
            }
        }
        private static bool IsValidPosition(int newRowPosition, int newColPosition)
        {
            bool isValid = newRowPosition >= 0 && newColPosition >= 0 && newRowPosition < matrix.GetLength(0) && newColPosition < matrix.GetLength(1);
            isOutOfSquare = isValid;
            return isValid;
        }
        private static void ReadMatrix(char[,] matrix, int[] snakePosition, int[] burrowsPosition)
        {
            int burrowsCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakePosition[0] = row;
                        snakePosition[1] = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        if (burrowsCounter == 0)
                        {
                            burrowsPosition[0] = row;
                            burrowsPosition[1] = col;
                            burrowsCounter++;
                        }
                        else
                        {
                            burrowsPosition[2] = row;
                            burrowsPosition[3] = col;
                        }
                    }
                }
            }
        }
    }
}
