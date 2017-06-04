using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<char, int>();

            var input = Console.ReadLine();
            foreach (var letter in input)
            {
                if (result.ContainsKey(letter))
                {
                    result[letter]++;
                }
                else
                {
                    result.Add(letter, 1);
                }
            }

            foreach (var pair in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
