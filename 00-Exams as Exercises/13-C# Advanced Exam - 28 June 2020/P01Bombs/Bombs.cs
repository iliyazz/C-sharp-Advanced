using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Bombs
{
    public class Bombs
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0 },
                {"Cherry Bombs", 0 },
                {"Smoke Decoy Bombs", 0 }
            };
            bool isFinish = false;
            while (!isFinish)
            {
                if (bombEffects.Count == 0 || bombCasing.Count == 0)
                {
                    break;
                }
                int effectsQuantity = bombEffects.Peek();
                int casingQuantity = bombCasing.Peek();
                string product = ChooseProduct(effectsQuantity, casingQuantity);
                if (product != "nonOfList")
                {
                    bombs[product]++;
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                }
                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }
                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3  && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    isFinish = true;
                }
            }
            if (bombs.Any(x => x.Value < 3))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            foreach (var item in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        private static string ChooseProduct(int liquidQuanntity, int ingredientQuantity)
        {
            string bombs = string.Empty;
            int sum = ingredientQuantity + liquidQuanntity;
            switch (sum)
            {
                case 40:
                    bombs = "Datura Bombs";
                    break;
                case 60:
                    bombs = "Cherry Bombs";
                    break;
                case 120:
                    bombs = "Smoke Decoy Bombs";
                    break;
                default:
                    bombs = "nonOfList";
                    break;
            }
            return bombs;
        }
    }
}
