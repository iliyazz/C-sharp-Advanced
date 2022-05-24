using System;
using System.Linq;

namespace _1SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);
            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
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
    }
}
