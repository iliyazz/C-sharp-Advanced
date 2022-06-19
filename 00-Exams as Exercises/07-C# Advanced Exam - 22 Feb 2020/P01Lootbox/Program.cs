using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int sumTotal = 0;
            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstBox = firstLootBox.Peek();
                int secondBox = secondLootBox.Peek();
                int sum = firstBox + secondBox;
                if (sum % 2 == 0)
                {
                    sumTotal += firstLootBox.Dequeue() + secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }
            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (sumTotal >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumTotal}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumTotal}");
            }
        }
    }
}
