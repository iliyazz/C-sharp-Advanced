using System;
using System.Collections.Generic;
using System.Linq;

namespace P01TilesMaster
{
    public class TilesMaster
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> tiles = new Dictionary<string, int>();
            while (!(greyTiles.Count == 0 || whiteTiles.Count == 0))
            {
                int greyTilesQuantity = greyTiles.Peek();
                int whiteTilesQuantity = whiteTiles.Peek();
                if (greyTilesQuantity == whiteTilesQuantity)
                {
                    string product = ChooseProduct(greyTilesQuantity, whiteTilesQuantity);
                    if (!tiles.ContainsKey(product))
                    {
                        tiles.Add(product, 1);
                    }
                    else
                    {
                        tiles[product]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }
            if (whiteTiles.Count() == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (greyTiles.Count() == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            foreach (var tile in tiles.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
        private static string ChooseProduct(int greyTilesQuantity, int whiteTilesQuantity)
        {
            string tiles = string.Empty;
            int sum = whiteTilesQuantity + greyTilesQuantity;
            switch (sum)
            {
                case 40:
                    tiles = "Sink";
                    break;
                case 50:
                    tiles = "Oven";
                    break;
                case 60:
                    tiles = "Countertop";
                    break;
                case 70:
                    tiles = "Wall";
                    break;
                default:
                    tiles = "Floor";
                    break;
            }
            return tiles;
        }
    }
}
