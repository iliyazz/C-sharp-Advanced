using System;
using System.Collections.Generic;
using System.Linq;

namespace P01BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Dictionary<string, int> products = new Dictionary<string, int>();
            bool isFinish = true;
            while (isFinish)
            {
                if (water.Count == 0 || flour.Count == 0)
                {
                    break;
                }
                double waterQuanntity = water.Dequeue();
                double flourQuantity = flour.Pop();
                string product = ChooseProduct(waterQuanntity, flourQuantity);
                if (product != "nonOfList")
                {
                    AddProduct(products, product);
                }
                else
                {
                    if (waterQuanntity < flourQuantity)
                    {
                        MakeCroissant(flour, products, flourQuantity, waterQuanntity);
                        if (water.Count == 0 || flour.Count == 0)
                        {
                            break;
                        }
                    }
                    else if (waterQuanntity > flourQuantity)
                    {
                        while (waterQuanntity > flourQuantity)
                        {
                            if (flour.Count == 0)
                            {
                                isFinish = false;
                                break;
                            }
                            flourQuantity += flour.Pop();
                        }
                        if (isFinish)
                        {
                            MakeCroissant(flour, products, flourQuantity, waterQuanntity);
                        }
                    }
                }
            }
            foreach (var item in products.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
                Console.WriteLine("Flour left: None");
            }
            else if(flour.Count > 0)
            {
                Console.WriteLine("Water left: None");
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
                Console.WriteLine("Flour left: None");
            }
        }

        private static void MakeCroissant(Stack<double> flour, Dictionary<string, int> products, double flourQuantity, double waterQuanntity)
        {
            flour.Push(flourQuantity - waterQuanntity);
            AddProduct(products, "Croissant");
        }

        private static void AddProduct(Dictionary<string, int> products, string product)
        {
            if (!products.ContainsKey(product))
            {
                products.Add(product, 1);
            }
            else
            {
                products[product]++;
            }
        }

        private static string ChooseProduct(double waterQuanntity, double flourQuantity)
        {
            double waterPercentage = waterQuanntity * 100 / (flourQuantity + waterQuanntity);
            switch (waterPercentage)
            {
                case 50:
                    return "Croissant";
                    break;
                case 40:
                    return "Muffin";
                    break;
                case 30:
                    return "Baguette";
                    break;
                case 20:
                    return "Bagel";
                    break;
                default:
                    return "nonOfList";
                    break;
            }
        }
    }
}
