using System;
using System.Linq;

namespace _4SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                string rowLine = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowLine[col].ToString();
                }
            }
            string symbol = Console.ReadLine();
            bool isExist = false;
            int rowSymbol = 0;
            int colSymbol = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (symbol == matrix[row, col])
                    {
                        isExist = true;
                        rowSymbol = row;
                        colSymbol = col;
                        break;
                    }
                }
                if (isExist)
                    break;
            }
            if (isExist)
            {
                Console.WriteLine($"({rowSymbol}, {colSymbol})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}

//private static void ReadMatrix(int[,] matrix)
//{
//    const string separator = " ";

//    for (int row = 0; row < matrix.GetLength(0); row++)
//    {
//        int[] inputData = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();

//        for (int column = 0; column < matrix.GetLength(1); column++)
//        {
//            matrix[row, column] = inputData[column];
//        }
//    }
//}
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

