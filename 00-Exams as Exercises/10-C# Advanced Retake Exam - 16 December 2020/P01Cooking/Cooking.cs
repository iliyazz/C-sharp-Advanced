using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Cooking
{
    public class Cooking
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> products = new Dictionary<string, int>()
            { 
                {"Bread", 0 },
                {"Cake", 0 },
                {"Fruit Pie", 0 },
                {"Pastry", 0 }
            };
            bool isFinish = true;
            while (isFinish)
            {
                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }
                int liquidQuantity = liquids.Dequeue();
                int ingredientQuantity = ingredients.Pop();
                string product = ChooseProduct(liquidQuantity, ingredientQuantity);
                if (product != "nonOfList")
                {
                    products[product]++;
                    //AddProduct(products, product);
                }
                else
                {
                    ingredients.Push(ingredientQuantity + 3);
                }
            }
            if (products.Any(x => x.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            foreach (var item in products.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        //private static void AddProduct(Dictionary<string, int> products, string product)
        //{
            //if (!products.ContainsKey(product))
            //{
            //    products.Add(product, 1);
            //}
            //else
            //{
                //products[product]++;
            //}
        //}

        private static string ChooseProduct(int liquidQuanntity, int ingredientQuantity)
        {
            string product = string.Empty;
            int sum = ingredientQuantity + liquidQuanntity;
            switch (sum)
            {
                case 25:
                    product = "Bread";
                    break;
                case 50:
                    product = "Cake";
                    break;
                case 75:
                    product = "Pastry";
                    break;
                case 100:
                    product = "Fruit Pie";
                    break;
                default:
                    product = "nonOfList";
                    break;
            }
            return product;
        }
    }
}
