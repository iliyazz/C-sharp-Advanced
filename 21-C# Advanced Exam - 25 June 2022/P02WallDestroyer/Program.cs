using System;

namespace P02WallDestroyer
{
    public class Program
    {
        private static char[,] matrix;
        private static int[] vankosPosition = new int[2];
        private static int holes = 1;
        private static int holesAtRod = 0;
        private static bool isElectrocuted = false;
        static void Main(string[] args)
        {
            int martrixSize = int.Parse(Console.ReadLine());
            matrix = new char[martrixSize, martrixSize];
            ReadMatrix(matrix, vankosPosition);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
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
                if (isElectrocuted)
                {
                    break;
                }
            }
            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {holesAtRod} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
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

            if (!IsValidPosition(vankosPosition[0] + moveToRow, vankosPosition[1] + moveToCol))
            {
                return;
            }
            if (matrix[vankosPosition[0] + moveToRow, vankosPosition[1] + moveToCol] == 'R')
            {
                holesAtRod++;
                Console.WriteLine("Vanko hit a rod!");
                return ;
            }
            matrix[vankosPosition[0], vankosPosition[1]] = '*';
            vankosPosition[0] += moveToRow;
            vankosPosition[1] += moveToCol;
            if (matrix[vankosPosition[0], vankosPosition[1]] == 'C')
            {
                holes++;
                matrix[vankosPosition[0], vankosPosition[1]] = 'E';
                isElectrocuted = true;
                return ;
            }
            if (matrix[vankosPosition[0], vankosPosition[1]] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{vankosPosition[0]}, {vankosPosition[1]}]!");
                matrix[vankosPosition[0], vankosPosition[1]] = 'V';
            }
            else
            {
                holes++;
                matrix[vankosPosition[0], vankosPosition[1]] = 'V';
            }
        }
        private static bool IsValidPosition(int newRowPosition, int newColPosition)
        {
            bool isValid = newRowPosition >= 0 && newColPosition >= 0 && newRowPosition < matrix.GetLength(0) && newColPosition < matrix.GetLength(1);
            return isValid;
        }
        private static void ReadMatrix(char[,] matrix, int[] vankosPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'V')
                    {
                        vankosPosition[0] = row;
                        vankosPosition[1] = col;
                    }
                }
            }
        }
    }
}
