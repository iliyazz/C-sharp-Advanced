using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> sbHistory = new Stack<string>();
            for (int i = 0; i < number; i++)
            {
                string[] cmdArg = Console.ReadLine().Split().ToArray();
                if (cmdArg[0] == "1")
                {
                    sbHistory.Push(sb.ToString());
                    sb.Append(cmdArg[1]);
                }
                else if (cmdArg[0] == "2")
                {
                    sbHistory.Push(sb.ToString());
                    sb.Remove(sb.Length - int.Parse(cmdArg[1]), int.Parse(cmdArg[1]));
                }
                else if (cmdArg[0] == "3")
                {
                    Console.WriteLine(sb[int.Parse(cmdArg[1])-1]);
                }
                else if (cmdArg[0] == "4")
                {
                    sb.Clear();
                    sb.Append(sbHistory.Pop());
                }
            }
        }
    }
}
