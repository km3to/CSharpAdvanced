using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> report = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine()
                .Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "report")
            {
                var town = input[0];
                var country = input[1];
                var population = long.Parse(input[2]);

                if (report.ContainsKey(country))
                {
                    report[country].Add(town, population);
                }
                else
                {
                    var tmpDict = new Dictionary<string, long>();
                    tmpDict.Add(town, population);
                    report.Add(country, tmpDict);
                }


                input = Console.ReadLine()
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            foreach (var country in report.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }

            //foreach (var country in report.OrderByDescending(x => x.Value.Values.Sum()))
            //{
            //    Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

            //    var towns = country.Value.OrderByDescending(x => x.Value).ToArray();


            //    foreach (var town in towns)
            //    {
            //        if (town.Equals(country.Value.Last()))
            //        {
            //            Console.WriteLine($"=>{town.Key}: {town.Value}");
            //            break;
            //        }
            //        Console.WriteLine($"=>{town.Key}: {town.Value}");
            //    }
            //}
        }
    }
}
