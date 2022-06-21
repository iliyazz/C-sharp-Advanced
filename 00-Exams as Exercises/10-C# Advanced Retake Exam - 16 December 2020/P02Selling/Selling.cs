using System;
using System.Linq;

namespace P02Selling
{
    public class Selling
    {
        private static bool isFinish = false;
        private static int playerPosRow = 0;
        private static int playerPosCol = 0;
        private static int money = 0;

        static void Main(string[] args)
        {
            int sizOfmatrix = int.Parse(Console.ReadLine());
            char[][]matrix = new char[sizOfmatrix][];
            Tuple<int, int>[] pillarsCoord = new Tuple<int, int>[2];
            string command = string.Empty;
            ReadMatrix(matrix, pillarsCoord);
            while (true)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        Move(matrix, -1, 0, pillarsCoord);
                        break;
                    case "down":
                        Move(matrix, 1, 0, pillarsCoord);
                        break;
                    case "left":
                        Move(matrix, 0, -1, pillarsCoord);
                        break;
                    case "right":
                        Move(matrix, 0, 1, pillarsCoord);
                        break;
                }
                if (isFinish || (money >= 50))
                {
                    break;
                }
            }
            if (money < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");
            PrintMatrix(matrix);
        }
        public static void Move(char[][] matrix, int moveToRow, int moveToCol, Tuple<int, int>[] pillarsCoord)
        {
            matrix[playerPosRow][playerPosCol] = '-';
            playerPosRow += moveToRow;
            playerPosCol += moveToCol;
            if (!IsValidPosition(matrix, playerPosRow, playerPosCol))
            {
                isFinish = true;
                return;
            }
            else if (char.IsDigit(matrix[playerPosRow][playerPosCol]))
            {
                money += int.Parse(matrix[playerPosRow][playerPosCol].ToString());
                matrix[playerPosRow][playerPosCol] = 'S';
            }
            else if (matrix[playerPosRow][playerPosCol] == 'O')
            {
                if (pillarsCoord[0].Item1 == playerPosRow && pillarsCoord[0].Item2 == playerPosCol)
                {
                    matrix[playerPosRow][playerPosCol] = '-';
                    playerPosRow = pillarsCoord[1].Item1;
                    playerPosCol = pillarsCoord[1].Item2 ;
                    matrix[playerPosRow][playerPosCol] = 'S';
                }
                else
                {
                    matrix[playerPosRow][playerPosCol] = '-';
                    playerPosRow = pillarsCoord[0].Item1;
                    playerPosCol = pillarsCoord[0].Item2;
                    matrix[playerPosRow][playerPosCol] = 'S';
                }
            }
            else if(matrix[playerPosRow][playerPosCol] == '-')
            {
                matrix[playerPosRow][playerPosCol] = 'S';
            }
        }
        private static void ReadMatrix(char[][] matrix, Tuple<int, int>[] pillarsCoord)
        {
            int pillarsCounter = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (matrix[row][col] == 'S')
                    {
                        playerPosRow =row;
                        playerPosCol =col;
                    }
                    if (matrix[row][col] == 'O')
                    {
                        if (pillarsCounter == 0)
                        {
                            pillarsCoord[pillarsCounter] = new Tuple<int, int>(row, col);
                        }
                        else if(pillarsCounter == 1)
                        {
                            pillarsCoord[pillarsCounter] = new Tuple<int, int>(row, col);
                        }
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
        private static bool IsValidPosition(char[][] matrix, int row, int col)
        {
            bool isValid = row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
            return isValid;
        }

    }
}
