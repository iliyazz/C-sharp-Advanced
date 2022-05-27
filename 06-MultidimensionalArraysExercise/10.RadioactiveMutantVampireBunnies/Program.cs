using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            int rows = int.Parse(dimensions.Split(' ')[0]);
            int cols = int.Parse(dimensions.Split(' ')[1]);
            string[,] field = new string[rows, cols];
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = line[col];
                    if (line[col] == "P")
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            
            string[] cmdArg = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
            bool isWonOrDead = true;
            for (int i = 0; i < cmdArg.Length; i++)
            {
                if (cmdArg[i] == "U")
                {
                    if (rowIndex == 0)//1
                    {
                        isWonOrDead = true;
                        field[rowIndex, colIndex] = ".";
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else if (field[rowIndex - 1, colIndex] == "B")//2
                    {
                        isWonOrDead = false;
                        field[rowIndex, colIndex] = ".";
                        rowIndex--;
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else//3
                    {
                        field[rowIndex - 1, colIndex] = "P";
                        field[rowIndex, colIndex] = ".";
                        rowIndex--;
                    }
                }

                else if (cmdArg[i] == "D")
                {
                    if (rowIndex == rows - 1)//1
                    {
                        isWonOrDead = true;
                        field[rowIndex, colIndex] = ".";
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else if (field[rowIndex + 1, colIndex] == "B")//2
                    {
                        isWonOrDead = false;
                        field[rowIndex, colIndex] = ".";
                        rowIndex++;
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else//3
                    {
                        field[rowIndex + 1, colIndex] = "P";
                        field[rowIndex,colIndex] = ".";
                        rowIndex++;
                    }
                }
                else if (cmdArg[i] == "R")
                {
                    if (colIndex == cols - 1)//1
                    {
                        isWonOrDead = true;
                        field[rowIndex, colIndex] = ".";
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else if (field[rowIndex, colIndex + 1] == "B")//2
                    {
                        isWonOrDead = false;
                        field[rowIndex, colIndex] = ".";
                        colIndex++;
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else//3
                    {
                        field[rowIndex, colIndex + 1] = "P";
                        field[rowIndex, colIndex] = ".";
                        colIndex++;
                    }
                }
                else if (cmdArg[i] == "L")
                {
                    if (colIndex == 0)
                    {
                        isWonOrDead = true;
                        field[rowIndex, colIndex] = ".";
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else if (field[rowIndex, colIndex - 1] == "B")//2
                    {
                        isWonOrDead = false;
                        field[rowIndex, colIndex] = ".";
                        colIndex--;
                        PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                        break;
                    }
                    else
                    {
                        field[rowIndex,colIndex - 1] = "P";
                        field[rowIndex, colIndex] = ".";
                        colIndex--;
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (field[row, col] == "B")
                        {
                            if (row - 1 >= 0)
                            {
                                if (field[row - 1, col] == "P")
                                {
                                    isWonOrDead = false;
                                    PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                                    break;
                                }
                                if (field[row - 1, col] != "B")
                                {
                                    field[row - 1, col] = "+";
                                }
                            }

                            if (row + 1 <= rows - 1)
                            {
                                if (field[row + 1, col] == "P")
                                {
                                    isWonOrDead = false;
                                    PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                                    break;
                                }
                                if (field[row + 1, col] != "B")
                                {
                                    field[row + 1, col] = "+";
                                }
                            }

                            if (col - 1 >= 0)
                            {
                                if (field[row, col - 1] == "P")
                                {
                                    isWonOrDead = false;
                                    PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                                    break;
                                }
                                if (field[row, col - 1] != "B")
                                {
                                    field[row, col - 1] = "+";
                                }
                            }

                            if (col + 1 <= cols - 1)
                            {
                                if (field[row, col + 1] == "P")
                                {
                                    isWonOrDead = false;
                                    PrintMatrix(field, isWonOrDead, rowIndex, colIndex);
                                    break;
                                }
                                if (field[row, col + 1] != "B")
                                {
                                    field[row, col + 1] = "+";
                                }
                            }
                        }
                    }
                    if (!isWonOrDead)
                    {
                        break;
                    }
                }
                if (!isWonOrDead)
                {
                    break;
                }
                MakePlusToB(field);
            }
        }

        private static void RabitSpread(string[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == "B")
                    {
                        if (row - 1 >= 0)
                        {
                            if (field[row - 1, col] != "B")
                            {
                                field[row - 1, col] = "+";
                            }
                        }

                        if (row + 1 <= rows - 1)
                        {
                            if (field[row + 1, col] != "B")
                            {
                                field[row + 1, col] = "+";
                            }
                        }

                        if (col - 1 >= 0)
                        {
                            if (field[row, col - 1] != "B")
                            {
                                field[row, col - 1] = "+";
                            }
                        }

                        if (col + 1 <= cols - 1)
                        {
                            if (field[row, col + 1] != "B")
                            {
                                field[row, col + 1] = "+";
                            }
                        }
                    }
                }
            }
        }

        private static void MakePlusToB(string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == "+")
                    {
                        field[row, col] = "B";
                    }

                }
            }

        }

        private static void PrintMatrix(string[,] field, bool isWonOrDead, int rowIndex, int colIndex)
        {
            RabitSpread(field);
            MakePlusToB(field);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
            if (isWonOrDead)
            {
                Console.WriteLine($"won: {rowIndex} {colIndex}");
            }
            else
            {
                Console.WriteLine($"dead: {rowIndex} {colIndex}");
            }
        }
    }
}
