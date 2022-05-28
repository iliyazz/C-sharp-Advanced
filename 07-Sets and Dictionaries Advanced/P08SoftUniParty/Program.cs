using System;
using System.Collections.Generic;

namespace P08SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipReservationList = new HashSet<string>();
            HashSet<string> regularReservationList = new HashSet<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(command[0]))
                    vipReservationList.Add(command);
                else
                    regularReservationList.Add(command);
            }
            command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(command[0]))
                {
                    if (vipReservationList.Contains(command))
                    {
                        vipReservationList.Remove(command);
                    }
                }
                else
                {
                    if (regularReservationList.Contains(command))
                    {
                        regularReservationList.Remove(command);
                    }
                }
            }
            Console.WriteLine(vipReservationList.Count + regularReservationList.Count);
            foreach (var vip in vipReservationList)
                Console.WriteLine(vip);
            foreach (var regular in regularReservationList)
                Console.WriteLine(regular);
        }
    }
}
