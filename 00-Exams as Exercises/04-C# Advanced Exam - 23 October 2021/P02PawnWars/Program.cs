using System;
//using System.Text;

namespace P02PawnWars
{
    public class Program
    {
        private static char[,] matrix;
        private static int[] whitePosition = new int[2];
        private static bool whiteWin = false;
        private static bool blackWin = false;
        private static int[] blackPosition = new int[2];
        private static bool isWhite = true;
        static void Main(string[] args)
        {
            const int martrixSize = 8;
            matrix = new char[martrixSize, martrixSize];
            ReadMatrix(matrix, whitePosition, blackPosition);
            while (true)
            {
                if (isWhite)
                {
                    Move(isWhite);
                    if (whiteWin)
                    {
                        break;
                    }
                    isWhite = false;
                }
                else
                {
                    Move(isWhite);
                    if (blackWin)
                    {
                        break;
                    }
                    isWhite = true;
                }
            }
            string winner = string.Empty;
            string coordinates = string.Empty; ;
            if (whiteWin)
            {
                winner = "White";
                coordinates = ColumnLeter(whitePosition[1]) + (8 - whitePosition[0]).ToString();
            }
            else
            {
                winner = "Black";
                coordinates = ColumnLeter(blackPosition[1]) + (8 - blackPosition[0]).ToString();
            }
            string message = string.Empty;
            if (whiteWin && whitePosition[0] == 0)
            {
                message = $"Game over! {winner} pawn is promoted to a queen at {coordinates}.";
            }
            else if (blackWin && blackPosition[0] == 7)
            {
                message = $"Game over! {winner} pawn is promoted to a queen at {coordinates}.";
            }
            else
            {
                message = $"Game over! {winner} capture on {coordinates}.";
            }
            Console.WriteLine(message);
        }
        private static string ColumnLeter(int column)
        {
            string columnLeter = ((char) (97 + column)).ToString();
            return columnLeter;
        }
        //private static void PrintMatrix(char[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        char[] printLine = new char[matrix.GetLength(1)];
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            printLine[col] = matrix[row, col];
        //        }
        //        Console.WriteLine(string.Join("", printLine));
        //    }
        //}
        private static void Move(bool isWhite)
        {
            if (isWhite == true)
            {
                if (IsValidPosition(whitePosition[0] - 1, whitePosition[1] - 1))
                {
                    if (matrix[whitePosition[0] - 1, whitePosition[1] - 1] == 'b')
                    {
                        matrix[whitePosition[0], whitePosition[1]] = '-';
                        matrix[whitePosition[0] - 1, whitePosition[1] - 1] = 'w';
                        whitePosition[0] -= 1;
                        whitePosition[1] -= 1;
                        whiteWin = true;
                        return;
                    }
                }
                if (IsValidPosition(whitePosition[0] - 1, whitePosition[1] + 1))
                {
                    if (matrix[whitePosition[0] - 1, whitePosition[1] + 1] == 'b')
                    {
                        matrix[whitePosition[0], whitePosition[1]] = '-';
                        matrix[whitePosition[0] - 1, whitePosition[1] + 1] = 'w';
                        whitePosition[0] -= 1;
                        whitePosition[1] += 1;
                        whiteWin = true;
                        return ;
                    }
                    
                }
                if (whitePosition[0] - 1 == 0)
                {
                    matrix[whitePosition[0], whitePosition[1]] = '-';
                    matrix[whitePosition[0] - 1, whitePosition[1]] = 'w';
                    whitePosition[0] -= 1;
                    whiteWin = true;
                }
                else
                {
                    matrix[whitePosition[0], whitePosition[1]] = '-';
                    whitePosition[0] -= 1;
                    matrix[whitePosition[0], whitePosition[1]] = 'w';
                }
            }
            else
            {
                if (IsValidPosition(blackPosition[0] + 1, blackPosition[1] - 1))
                {
                    if (matrix[blackPosition[0] + 1, blackPosition[1] - 1] == 'w')
                    {
                        matrix[blackPosition[0], blackPosition[1]] = '-';
                        matrix[blackPosition[0] + 1, blackPosition[1] - 1] = 'b';
                        blackPosition[0] += 1;
                        blackPosition[1] -= 1;
                        blackWin = true;
                        return;
                    }
                }
                if (IsValidPosition(blackPosition[0] + 1, blackPosition[1] + 1))
                {
                    if (matrix[blackPosition[0] + 1, blackPosition[1] + 1] == 'w')
                    {
                        matrix[blackPosition[0], blackPosition[1]] = '-';
                        matrix[blackPosition[0] + 1, blackPosition[1] + 1] = 'b';
                        blackPosition[0] += 1;
                        blackPosition[1] += 1;
                        blackWin = true;
                        return;
                    }
                    
                }
                if (blackPosition[0] + 1 == 7)
                {
                    matrix[blackPosition[0], blackPosition[1]] = '-';
                    matrix[blackPosition[0] + 1, blackPosition[1]] = 'b';
                    blackPosition[0] += 1;
                    blackWin = true;
                }
                else
                {
                    matrix[blackPosition[0], blackPosition[1]] = '-';
                    blackPosition[0] += 1;
                    matrix[blackPosition[0], blackPosition[1]] = 'b';
                }
            }
        }

        private static bool IsValidPosition(int newRowPosition, int newColPosition)
        {
            bool isValid = newRowPosition >= 0 && newColPosition >= 0 && newRowPosition < matrix.GetLength(0) && newColPosition < matrix.GetLength(1);
            return isValid;
        }
        private static void ReadMatrix(char[,] matrix, int[] whitePosition, int[] blackPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'w')
                    {
                        whitePosition[0] = row;
                        whitePosition[1] = col;
                    }
                    if (matrix[row, col] == 'b')
                    {
                        blackPosition[0] = row;
                        blackPosition[1] = col;
                    }
                }
            }
        }
    }
}
