using System;
using System.Linq;

namespace _2SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
        private static void ReadMatrix(int[,] matrix)
        {
            const string separator = " ";

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputData = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = inputData[column];
                }
            }
        }
    }
}
