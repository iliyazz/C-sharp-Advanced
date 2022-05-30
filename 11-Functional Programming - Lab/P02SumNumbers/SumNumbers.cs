using System;
using System.Linq;

namespace P02SumNumbers
{
    internal class SumNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parser = x =>int.Parse(x);
            int[] numbers = input.Split(", ").Select(parser).ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
