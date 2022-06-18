using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int wastedGramsOfFood = 0;
            while ((guests.Count > 0) && (plates.Count > 0))
            {
                int guest = guests.Dequeue();
                int plate = plates.Pop();
                if (guest - plate <= 0)
                {
                    wastedGramsOfFood += plate - guest;
                }
                else
                {
                    guest -= plate;
                    List<int> list = new List<int>(guests);
                    list.Insert(0, guest);
                    guests.Clear();
                    foreach (var item in list)
                    {
                        guests.Enqueue(item);
                    }
                }
            }
            string message = string.Empty;
            if (guests.Count == 0)
            {
                message = $"Plates: {string.Join(" ", plates)}";
            }
            else
            {
                message = $"Guests: {string.Join(" ", guests)}";
            }
            Console.WriteLine(message);
            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");
        }
    }
}
