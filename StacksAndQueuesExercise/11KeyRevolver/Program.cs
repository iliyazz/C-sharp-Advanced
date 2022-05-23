using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int availableBullets = bullets.Count;
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());
            int bulletsCounter = 0;
            while (true)
            {
                if (bulletsCounter == barrelSize && bullets.Count() >= 1)
                {
                    bulletsCounter = 0;
                    Console.WriteLine("Reloading!");
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

                int currentBullet = bullets.Pop();
                bulletsCounter++;
                int currentLock = locks.Peek();
                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    if (locks.Count == 0)
                    {
                        if (bulletsCounter == barrelSize && bullets.Count() >= 1)
                        {
                            bulletsCounter = 0;
                            Console.WriteLine("Reloading!");
                        }

                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (availableBullets - bullets.Count) * bulletPrice}");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");
                    if (bullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        break;
                    }
                }
            }
        }
    }
}
