using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Blacksmith
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Dictionary<string, int> swordCollection = new Dictionary<string, int>();

            while (true)
            {
                if ((steel.Count == 0 || carbon.Count == 0))
                {
                    break;
                }
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int sum = currentSteel + currentCarbon;
                string currentResult = ChooseSword(sum);
                if (currentResult != "non")
                {
                    if (!swordCollection.ContainsKey(currentResult))
                    {
                        swordCollection[currentResult] = 1;
                    }
                    else
                    {
                        swordCollection[currentResult]++;
                    }
                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                }
            }
            
            if (swordCollection.Count == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {swordCollection.Select(x => x.Value).Sum()} swords.");
            }
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            foreach (var item in swordCollection.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }


        }
        public static string ChooseSword(int sum)
        {
            string sword = string.Empty;
            switch (sum)
            {
                case 70:
                    sword = "Gladius";
                    break;
                case 80:
                    sword = "Shamshir";
                    break;
                case 90:
                    sword = "Katana";
                    break;
                case 110:
                    sword = "Sabre";
                    break;
                case 150:
                    sword = "Broadsword";
                    break;
                default:
                    sword = "non";
                    break;
            }
            return sword;
        }
    }
}
