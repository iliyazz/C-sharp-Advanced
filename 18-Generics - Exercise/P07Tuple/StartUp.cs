using System;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tuple1 = new Tuple<string, string>($"{input1[0]} {input1[1]}", input1[2]);


            string[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tuple2 = new Tuple<string, int>(input2[0], int.Parse(input2[1]));

            string[] input3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tuple3 = new Tuple<int, double>(int.Parse(input3[0]), double.Parse(input3[1]));

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
