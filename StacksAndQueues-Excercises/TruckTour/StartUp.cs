using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int> liters = new Queue<int>();
            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] pumpDistance = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                liters.Enqueue(pumpDistance[0] - pumpDistance[1]);
            }
            int index = 0;
            long fuelAmounth = -1;
            for (int i = 0; i < numberOfPumps; i++)
            {
                if (liters.Peek() >= 0 && fuelAmounth < 0)
                {
                    index = i;
                    fuelAmounth = 0;
                }

                fuelAmounth += liters.Dequeue();
            }

            Console.WriteLine(index);
        }
    }
}
