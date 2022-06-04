using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            family.AddMember();
            const int limit = 30;
            family.PrintPeople(limit);
        }
    }
}
