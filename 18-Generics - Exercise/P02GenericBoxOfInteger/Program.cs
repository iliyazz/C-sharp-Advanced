using System;

namespace P02GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var data = new Box<int>(input);
                Console.WriteLine(data);
            }
        }
    }
}
