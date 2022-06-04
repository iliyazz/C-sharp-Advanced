using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private DateTime dateMod;

        public DateTime DateMod { get => dateMod; set => dateMod = value; }
        public DateModifier()
        {

        }
        public DateModifier(DateTime startDate)
        {
            DateMod = startDate;
        }

        public void DayCounter()
        {
            int[] firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            DateTime start = new DateTime(firstInput[0], firstInput[1], firstInput[2]);
            DateTime end = new DateTime(secondInput[0], secondInput[1], secondInput[2]);
            Console.WriteLine(Math.Abs((start - end).TotalDays));
        }
    }
}
