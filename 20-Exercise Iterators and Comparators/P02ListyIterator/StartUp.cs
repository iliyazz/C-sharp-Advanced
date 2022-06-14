using System;
using System.Linq;

namespace P01ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            ListyIterator<string> iteratorList = null;
            while ((command = Console.ReadLine()) != "END")
            {
                var cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArg[0] == "Create")
                {
                    iteratorList = new ListyIterator<string>(cmdArg.Skip(1).ToArray());
                }
                else if (cmdArg[0] == "Move")
                {
                    Console.WriteLine(iteratorList.Move());
                }
                else if (cmdArg[0] == "Print")
                {
                    iteratorList.Print();
                }
                else if (cmdArg[0] == "HasNext")
                {
                    Console.WriteLine(iteratorList.HasNext());
                }
                else if(cmdArg[0] == "PrintAll")
                {
                    iteratorList.PrintAll();
                }
            }

        }
    }
}
