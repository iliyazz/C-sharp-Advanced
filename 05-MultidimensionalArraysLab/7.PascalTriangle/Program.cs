﻿using System;

namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[number][];
            for (int row = 0; row < number; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][row] = 1;
                for (int col = 1; col < row; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }
            }
            for (int row = 0; row < number; row++)
            {
                Console.WriteLine(string.Join(' ', pascalTriangle[row]));
            }
        }
    }
}
