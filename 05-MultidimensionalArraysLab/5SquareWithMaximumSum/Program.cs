using System;
using System.Linq;

namespace _5SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);
            int maxSumRowIndex = 0;
            int maxSumColIndex = 0;
            int maxSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row +1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxSumRowIndex = row;
                        maxSumColIndex = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxSumRowIndex, maxSumColIndex]} {matrix[maxSumRowIndex, maxSumColIndex + 1]}");
            Console.WriteLine($"{matrix[maxSumRowIndex + 1, maxSumColIndex]} {matrix[maxSumRowIndex + 1, maxSumColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
        private static void ReadMatrix(int[,] matrix)
        {
            const string separator = ", ";

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
//private static void ReadMatrix(string[,] matrix)
//{
//    const string separator = ", ";

//    for (int row = 0; row < matrix.GetLength(0); row++)
//    {
//        string[] inputData = Console.ReadLine().Split(separator).ToArray();

//        for (int column = 0; column < matrix.GetLength(1); column++)
//        {
//            matrix[row, column] = inputData[column];
//        }
//    }
//}

