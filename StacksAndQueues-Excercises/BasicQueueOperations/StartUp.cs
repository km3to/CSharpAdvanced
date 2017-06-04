using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elements = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            int elementToCheck = int.Parse(input[2]);

            var stack = new Queue<int>();
            for (int i = 0; i < elements; i++)
            {
                stack.Enqueue(nums[i]);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Dequeue();
            }

            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count != 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}