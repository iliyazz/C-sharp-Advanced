using System;
using System.Collections.Generic;
using System.Linq;

namespace P04ProductShop
{
    internal class P04ProductShop
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string inputShop = command.Split(", ", StringSplitOptions.RemoveEmptyEntries)[0];
                string inputProduct = command.Split(", ", StringSplitOptions.RemoveEmptyEntries)[1];
                double inputPrice = double.Parse(command.Split(", ", StringSplitOptions.RemoveEmptyEntries)[2]);
                if (!shops.ContainsKey(inputShop))
                    shops.Add(inputShop, new Dictionary<string, double>());
                shops[inputShop].Add(inputProduct, inputPrice);
            }
            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");

                }
            }
        }
    }
}
