using System;
using System.Linq;

namespace _3.Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            ReadMatrix(matrix);
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }
            Console.WriteLine(sum);
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
