using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);

            Queue<int>[] result = new Queue<int>[3];
            for (int i = 0; i < 3; i++)
            {
                result[i] = new Queue<int>();
            }

            while (queue.Count > 0)
            {
                var number = queue.Dequeue();

                if (Math.Abs(number) % 3 == 0)
                {
                    result[0].Enqueue(number);
                }
                else if (Math.Abs(number) % 3 == 1)
                {
                    result[1].Enqueue(number);
                }
                else if (Math.Abs(number) % 3 == 2)
                {
                    result[2].Enqueue(number);
                }
            }

            foreach (var q in result)
            {
                Console.WriteLine(string.Join(" ", q));
            }
        }
    }
}
