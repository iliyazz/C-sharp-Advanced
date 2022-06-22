using System;
using System.Collections.Generic;
using System.Linq;

namespace P01FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int sumForLaterUse = 0;
            int wreaths = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lily = lilies.Pop();
                int rose = roses.Dequeue();
                if (lily + rose == 15)
                {
                    wreaths++;
                }
                else if (lily + rose > 15)
                {
                    while (lily + rose > 15)
                    {
                        lily -= 2;
                        if (lily + rose == 15)
                        {
                            wreaths++;
                        }
                    }
                    if (lily + rose < 15)
                    {
                        sumForLaterUse += lily + rose;
                    }
                }
                else
                {
                    sumForLaterUse += lily + rose;
                }
            }
            wreaths += sumForLaterUse / 15;
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
