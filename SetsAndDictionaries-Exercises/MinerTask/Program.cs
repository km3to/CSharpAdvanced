using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> result = new Dictionary<string, long>();
            Queue<string> resources = new Queue<string>();
            Queue<long> quantities = new Queue<long>();

            var input = Console.ReadLine();
            int index = 1;

            while (input != "stop")
            {
                if (index % 2 != 0)
                {
                    resources.Enqueue(input);
                }
                else
                {
                    quantities.Enqueue(long.Parse(input));
                }

                index++;
                input = Console.ReadLine();
            }

            while (resources.Count > 0)
            {
                var resource = resources.Dequeue();
                var quantity = quantities.Dequeue();

                if (result.ContainsKey(resource))
                {
                    result[resource] += quantity;
                }
                else
                {
                    result.Add(resource, quantity);
                }
            }

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
