using System;
using System.Linq;

namespace P04Froggy
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            var lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
