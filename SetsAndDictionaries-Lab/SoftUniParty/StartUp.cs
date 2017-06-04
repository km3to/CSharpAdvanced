using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var reservations = new SortedSet<string>();
            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                reservations.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                reservations.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(reservations.Count);
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}
