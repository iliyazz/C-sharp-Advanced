using System;
using System.Collections.Generic;
using System.Linq;

namespace P01TheFightForGondor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int wave = int.Parse(Console.ReadLine());
            

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> orcs = null;
            bool isFinish = false;

            for (int i = 1; i <= wave; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
                int waves = orcs.Count;

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                for (int j = 0; j < waves; j++)
                {
                    if (plates.Count == 0 || orcs.Count == 0)
                    {
                        isFinish = true;
                        break;
                    }
                    if (orcs.Peek() > plates.Peek())
                    {
                        int remaindedOrc = orcs.Pop() - plates.Dequeue();
                        orcs.Push(remaindedOrc);
                    }
                    else if (plates.Peek() > orcs.Peek())
                    {
                        int remaindedPlate = plates.Dequeue() - orcs.Pop();
                        plates.Enqueue(remaindedPlate);

                        for (int k = 0; k < plates.Count - 1; k++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }
                if (isFinish)
                {
                    break;
                }
            }
            if (orcs.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}
