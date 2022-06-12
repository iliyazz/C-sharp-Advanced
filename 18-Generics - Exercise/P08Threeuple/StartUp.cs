using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string town = input1[3];
            for (int i = 4; i < input1.Length; i++)
            {
                town += " " + input1[i];
            }
            var threeuple1 = new Threeuple<string, string, string>($"{input1[0]} {input1[1]}", input1[2], town);

            string[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool IsDrunked = input2[2] == "drunk" ? true : false;
            
            var threeuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), IsDrunked);

            string[] input3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var threeuple3 = new Threeuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);

            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}
