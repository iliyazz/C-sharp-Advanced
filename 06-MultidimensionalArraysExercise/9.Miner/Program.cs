using System;
using System.Linq;

namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[,] field = new string[dimension, dimension];
            int rowIndex = 0;
            int colIndex = 0;
            int counterCoals = 0;
            for (int row = 0; row < dimension; row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < dimension; col++)
                {
                    field[row, col] = line[col];
                    if (line[col] == "s")
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                    if (line[col] == "c")
                    {
                        counterCoals++;
                    }
                }
            }
            bool isCommandsFinish = true;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    if (rowIndex >= 1)
                    {
                        rowIndex--;
                    }
                }
                else if (commands[i] == "down")
                {
                    if (rowIndex <= dimension - 2)
                    {
                        rowIndex++; 
                    }
                }
                else if (commands[i] == "right")
                {
                    if (colIndex <= dimension - 2)
                    {
                        colIndex++;
                    }
                }
                else if (commands[i] == "left")
                {
                    if (colIndex >= 1)
                    {
                        colIndex--;
                    }
                }
                if (field[rowIndex, colIndex] == "e")
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    isCommandsFinish = false;
                    break;
                }
                else if (field[rowIndex, colIndex] == "c")
                {
                    counterCoals--;
                    field[rowIndex, colIndex] = "*";
                    if (counterCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                        isCommandsFinish = false;
                        break;
                    }
                }
            }
            if (isCommandsFinish)
            {
                Console.WriteLine($"{counterCoals} coals left. ({rowIndex}, {colIndex})");
            }
        }
    }
}
