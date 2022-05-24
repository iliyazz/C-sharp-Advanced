using System;
using System.Linq;

namespace _7.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            string[,] chess = new string[dimensions, dimensions];
            int sum = 0;
            for (int row = 0; row < dimensions; row++)
            {
                string[] input = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
                for (int col = 0; col < dimensions; col++)
                {
                    chess[row, col] = input[col];
                }
            }
            int[] colisionCoord = new int[2];
            while (MaxColision(chess, colisionCoord))
            {
                sum++;
                chess[colisionCoord[0], colisionCoord[1]] = "0";
            }
            Console.WriteLine(sum);
        }
        static bool MaxColision(string[,] chess, int[] colisionCoord)
        {
            int maxLocal = 0;
            int dim = chess.GetLength(0);
            bool isColision = false;
            for (int row = 0; row < dim; row++)
            {
                for (int col = 0; col < dim; col++)
                {
                    int sumLocal = 0;
                    if (chess[row,col] == "K")
                    {

                        if (row - 2 >= 0 && col - 1 >= 0)
                            if (chess[row - 2, col - 1] == "K")
                                sumLocal++;
                        if (row - 2 >= 0 && col + 1 < dim)
                            if (chess[row - 2, col + 1] == "K")
                                sumLocal++;
                        if (row - 1 >= 0 && col + 2 < dim)
                            if (chess[row - 1, col + 2] == "K")
                                sumLocal++;
                        if (row + 1 < dim && col + 2 < dim)
                            if (chess[row + 1, col + 2] == "K")
                                sumLocal++;
                        if (row + 2 < dim && col + 1 < dim)
                            if (chess[row + 2, col + 1] == "K")
                                sumLocal++;
                        if (row + 2 < dim && col - 1 >= 0)
                            if (chess[row + 2, col - 1] == "K")
                                sumLocal++;
                        if (row + 1 < dim && col - 2 >= 0)
                            if (chess[row + 1, col - 2] == "K")
                                sumLocal++;
                        if (row - 1 >= 0 && col - 2 >= 0)
                            if (chess[row - 1, col - 2] == "K")
                                sumLocal++;
                        if (maxLocal < sumLocal)
                        {
                            maxLocal = sumLocal;
                            colisionCoord[0] = row;
                            colisionCoord[1] = col;
                        }
                        if (sumLocal != 0)
                        {
                            isColision = true;
                        }
                    }
                }
            }
            return isColision;
        }
    }
}

