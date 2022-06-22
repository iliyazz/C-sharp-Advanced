using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02Garden
{
    public class Garden
    {
        static void Main(string[] args)
        {

            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixSize[0]][];
            for (int i = 0; i < matrixSize[0]; i++) matrix[i] = new int[matrixSize[1]];
            List<Tuple<int, int>> flowers = new List<Tuple<int, int>>();
            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = commands.Split().Select(int.Parse).ToArray();
                if (!IsValidPosition(matrix, coordinates[0], coordinates[1]))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                matrix[coordinates[0]][coordinates[1]] = 1;
                flowers.Add(new Tuple<int, int>(coordinates[0], coordinates[1]));
            }
            foreach (var flower in flowers)
            {
                int row = flower.Item1;
                int col = flower.Item2;
                BloomFlower(matrix, row, col);
            }
            PrintMatrix(matrix);
        }
        private static void ReadMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                matrix[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = 0;
                }
            }
        }
        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void BloomFlower(int[][] matrix, int row, int col)
        { 
            int temp = matrix.GetLength(0);
            for (int column = 0; column < matrix[row].Length; column++)
            {
                if (column != col)
                {
                    matrix[row][column] += 1;
                }
            }
            for (int j = 0; j < matrix.Length; j++)
            {
                if(j != row)
                {
                    matrix[j][col] += 1;
                }
            }
        }

        private static bool IsValidPosition(int[][] matrix, int row, int col)
        {
            bool isValid = row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
            return isValid;
        }
    }
}
