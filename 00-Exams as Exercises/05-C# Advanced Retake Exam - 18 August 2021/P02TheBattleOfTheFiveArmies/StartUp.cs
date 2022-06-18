using System;

namespace P02TheBattleOfTheFiveArmies
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rowsOfMap = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rowsOfMap][];
            int armyRowPosition = 0;
            int armyColPosition = 0;
            for (int row = 0; row < rowsOfMap; row++)
            {
                char[] inputRowData = Console.ReadLine().ToCharArray();
                matrix[row] = inputRowData;
                for (int col = 0; col < inputRowData.Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyRowPosition = row;
                        armyColPosition = col;
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split();
                string move = command[0];
                int spawnRow = int.Parse(command[1]);
                int spawnCol = int.Parse(command[2]);
                matrix[spawnRow][spawnCol] = 'O';
                if (move == "up" && armyRowPosition - 1 >= 0)
                {
                    matrix[armyRowPosition][armyColPosition] = '-';
                    armyRowPosition--;
                }
                else if (move == "right" && armyColPosition + 1 < matrix[armyRowPosition].Length)
                {
                    matrix[armyRowPosition][armyColPosition] = '-';
                    armyColPosition++;
                }
                else if (move == "left" && armyColPosition - 1 >= 0)
                {
                    matrix[armyRowPosition][armyColPosition] = '-';
                    armyColPosition--;
                }
                else if (move == "down" && armyRowPosition + 1 < rowsOfMap)
                {
                    matrix[armyRowPosition][armyColPosition] = '-';
                    armyRowPosition++;
                }
                armor--;
                if (armor <= 0)
                {
                    matrix[armyRowPosition][armyColPosition] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRowPosition};{armyColPosition}.");
                    break;
                }
                if (matrix[armyRowPosition][armyColPosition] == 'O')
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        matrix[armyRowPosition][armyColPosition] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRowPosition};{armyColPosition}.");
                        break;
                    }
                }
                else if (matrix[armyRowPosition][armyColPosition] == 'M')
                {
                    matrix[armyRowPosition][armyColPosition] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }
            }
            PrintMatrix(matrix);
        }
        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}
