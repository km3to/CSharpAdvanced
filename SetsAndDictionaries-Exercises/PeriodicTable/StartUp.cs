using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var result = new HashSet<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(' ');

                foreach (var el in line)
                {
                    result.Add(el);
                }
            }

            foreach (var el in result)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
    }
}
