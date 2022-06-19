using System;
using System.Linq;

namespace P02SuperMario
{
    public class Program
    {
        public static bool isReachPrinces = false;
        public static int marioRow = 0;
        public static int marioCol = 0;
        public static int lives = 0;
        
        static void Main(string[] args)
        {
            lives = int.Parse(Console.ReadLine());
            int rows= int.Parse(Console.ReadLine());
            string[][] matrix = new string[rows][];
            ReadMatrix(matrix);
            while (!isReachPrinces && lives > 0)
            {
                string[] cmdArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = cmdArg[0];
                matrix[int.Parse(cmdArg[1])][int.Parse(cmdArg[2])] = "B";
                Move(matrix, direction);
            }
            if (isReachPrinces)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            PrintMatrix(matrix);
        }
        public static void Move(string[][] matrix, string direction)
        {
            lives--;
            matrix[marioRow][marioCol] = "-";
            if (direction == "W")
            {
                marioRow--;
                if (!IsValidPosition(matrix))
                {
                    if (lives <= 0)
                    {
                        matrix[++marioRow][marioCol] = "X";
                        return;
                    }
                    marioRow++;
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "B")
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return ;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
                else if(matrix[marioRow][marioCol] == "P")
                {
                    matrix[marioRow][marioCol] = "-";
                    isReachPrinces = true;
                    return ;
                }
                else
                {
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
            }
            else if (direction == "S")
            {
                marioRow++;
                if (!IsValidPosition(matrix))
                {
                    if (lives <= 0)
                    {
                        matrix[--marioRow][marioCol] = "X";
                        return;
                    }
                    marioRow--;
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "B")
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "P")
                {
                    matrix[marioRow][marioCol] = "-";
                    isReachPrinces = true;
                    return;
                }
                else
                {
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
            }
            else if (direction == "A")
            {
                marioCol--;
                if (!IsValidPosition(matrix))
                {
                    if (lives <= 0)
                    {
                        matrix[marioRow][++marioCol] = "X";
                        return;
                    }
                    marioCol++;
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "B")
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "P")
                {
                    matrix[marioRow][marioCol] = "-";
                    isReachPrinces = true;
                    return;
                }
                else
                {
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
            }
            else if (direction == "D")
            {
                marioCol++;
                if (!IsValidPosition(matrix))
                {
                    if (lives <= 0)
                    {
                        matrix[marioRow][--marioCol] = "X";
                        return;
                    }
                    marioCol--;
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "B")
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
                else if (matrix[marioRow][marioCol] == "P")
                {
                    matrix[marioRow][marioCol] = "-";
                    isReachPrinces = true;
                    return;
                }
                else
                {
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = "X";
                        return;
                    }
                    matrix[marioRow][marioCol] = "M";
                }
            }

        }
        
        private static void ReadMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                matrix[row] = new string[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col].ToString();
                    if (input[col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(string[][] matrix)
        {
            foreach (string[] line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
        private static bool IsValidPosition(string[][] matrix)
        {
            bool isValid = marioRow >= 0 && marioRow < matrix.Length && marioCol >= 0 && marioCol < matrix[marioRow].Length;
            return isValid;
        }
    }
}
