using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jaggedMatrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArg = command.Split(' ');
                int rowNum = int.Parse(cmdArg[1]);
                int colNum = int.Parse(cmdArg[2]);
                int value = int.Parse(cmdArg[3]);
                if (rowNum >= 0 && rowNum < jaggedMatrix.GetLength(0) && colNum >= 0 && colNum <= jaggedMatrix[rowNum].GetLongLength(0))
                {
                    if (cmdArg[0] == "Add")
                    {
                        jaggedMatrix[rowNum][colNum] += value;
                    }
                    else if (cmdArg[0] == "Subtract")
                    {
                        jaggedMatrix[rowNum][colNum] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', jaggedMatrix[row]));
            }
        }
    }
}
