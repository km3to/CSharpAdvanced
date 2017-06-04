using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ParkingLot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carNumbers = new SortedSet<string>();

            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == "END")
                {
                    break;
                }

                var tokens = Regex.Split(inputLine, ", ", RegexOptions.IgnorePatternWhitespace)
                    .ToArray();

                if (tokens[0] == "IN")
                {
                    carNumbers.Add(tokens[1]);
                }
                else
                {
                    carNumbers.Remove(tokens[1]);
                }
            }

            if (carNumbers.Count > 0)
            {
                foreach (var carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber.Trim());
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
