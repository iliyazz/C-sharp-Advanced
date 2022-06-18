using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Masterchef
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> ingredient = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Dictionary<string, int> dishCollection = new Dictionary<string, int>();

            while (true)
            {
                if ((ingredient.Count == 0 || freshness.Count == 0))
                {
                    break;
                }
                if (ingredient.Peek() == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }
                int currentIngredient = ingredient.Dequeue();
                int currentFreshness = freshness.Pop();
                int result = currentIngredient * currentFreshness;
                string currentResult = ChooseDish(result);
                if (currentResult != "non")
                {
                    if (!dishCollection.ContainsKey(currentResult))
                    {
                        dishCollection[currentResult] = 1;
                    }
                    else
                    {
                        dishCollection[currentResult]++;
                    }
                }
                else
                {
                    ingredient.Enqueue(currentIngredient + 5);
                }
            }

            if (dishCollection.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredient.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }
            if (dishCollection.Count > 0)
            {
                foreach (var item in dishCollection.OrderBy(x => x.Key))
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }

        }
        public static string ChooseDish(int result)
        {
            string dish = string.Empty;
            switch (result)
            {
                case 150:
                    dish = "Dipping sauce";
                    break;
                case 250:
                    dish = "Green salad";
                    break;
                case 300:
                    dish = "Chocolate cake";
                    break;
                case 400:
                    dish = "Lobster";
                    break;
                default:
                    dish = "non";
                    break;
            }
            return dish;
        }
    }
}
