using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inoutTokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var dict = new SortedDictionary<double, int>();

            foreach (var token in inoutTokens)
            {
                double reminder = double.Parse(token);

                if (!dict.ContainsKey(reminder))
                {
                    dict.Add(reminder, 1);
                }
                else
                {
                    dict[reminder]++;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
