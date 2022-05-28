using System;
using System.Collections.Generic;

namespace P05CitiesByContinentAndCountry
{
    internal class P05CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                AddCity(cities, continent, country, city);
            }
            PrintTowns(cities);
        }

        private static void PrintTowns(Dictionary<string, Dictionary<string, List<string>>> cities)
        {
            foreach (var itemContinent in cities)
            {
                Console.WriteLine($"{itemContinent.Key}:");
                foreach (var itemCountry in itemContinent.Value)
                {
                    Console.WriteLine($"  {itemCountry.Key} -> {string.Join(", ", itemCountry.Value)}");
                }
            }
        }

        private static void AddCity(Dictionary<string, Dictionary<string, List<string>>> cities, string continent, string country, string city)
        {
            //add the continent if missing
            if (!cities.ContainsKey(continent))
                cities.Add(continent, new Dictionary<string, List<string>>());
                
            //add the country in continent if missing
            Dictionary<string, List<string>> countries = cities[continent];
               
            if(!countries.ContainsKey(country))
                countries.Add(country, new List<string>());
            
            //Add City in the existing country
            cities[continent][country].Add(city);
        }
    }
}
