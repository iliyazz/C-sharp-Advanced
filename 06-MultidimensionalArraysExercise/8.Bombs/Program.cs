using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimension, dimension];
            for (int row = 0; row < dimension; row++)
            {
                int[] value = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < dimension; col++)
                {
                    matrix[row, col] = value[col];
                }
            }
            string[] firstCoord = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<Tuple<int, int>> bombCoord = new Queue<Tuple<int, int>>();
            foreach (var item in firstCoord)
            {
                int[] coord = item.Split(",").Select(int.Parse).ToArray();
                Tuple<int, int> current = Tuple.Create(coord[0], coord[1]);
                bombCoord.Enqueue(current);
            }
            int numberOfBomb = bombCoord.Count;
            for (int i = 0; i < numberOfBomb; i++)
            {
                int row = bombCoord.Peek().Item1;
                int col = bombCoord.Peek().Item2;
                if (matrix[row, col] > 0)
                {

                    if (row - 1 >= 0 && col - 1 >= 0)
                        if (matrix[row - 1, col - 1] > 0)
                            matrix[row - 1, col - 1] -= matrix[row, col];

                    if (row - 1 >= 0)
                        if (matrix[row - 1, col] > 0)
                            matrix[row - 1, col] -= matrix[row, col];

                    if (row - 1 >= 0 && col + 1 < dimension)
                        if (matrix[row - 1, col + 1] > 0)
                            matrix[row - 1, col + 1] -= matrix[row, col];

                    if (col - 1 >= 0)
                        if (matrix[row, col - 1] > 0)
                            matrix[row, col - 1] -= matrix[row, col];

                    if (col + 1 < dimension)
                        if (matrix[row, col + 1] > 0)
                            matrix[row, col + 1] -= matrix[row, col];

                    if (row + 1 < dimension && col - 1 >= 0)
                        if (matrix[row + 1, col - 1] > 0)
                            matrix[row + 1, col - 1] -= matrix[row, col];

                    if (row + 1 < dimension)
                        if (matrix[row + 1, col] > 0)
                            matrix[row + 1, col] -= matrix[row, col];

                    if (row + 1 < dimension && col + 1 < dimension)
                        if (matrix[row + 1, col + 1] > 0)
                            matrix[row + 1, col + 1] -= matrix[row, col];
                    matrix[row, col] = 0;
                }
                bombCoord.Dequeue();
            }
            int aliveCells = 0;
            int sumOfCells = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    aliveCells++;
                    sumOfCells += item;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    if (col < dimension - 1)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    else
                    {
                        Console.WriteLine($"{matrix[row, col]}");
                    }
                }
            }
        }
    }
}
