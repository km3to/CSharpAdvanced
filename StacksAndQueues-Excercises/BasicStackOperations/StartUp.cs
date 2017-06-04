using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var conditions = Console.ReadLine().Split(' ');
            var numToPush = int.Parse(conditions[0]);
            var numToPop = int.Parse(conditions[1]);
            var numToSeek = int.Parse(conditions[2]);

            var stack = new Stack<string>(Console.ReadLine().Split(' '));

            for (int i = 0; i < numToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (StackContaintsNum(stack, numToSeek))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(GetStackSmallestElement(stack));
            }
        }

        private static int GetStackSmallestElement(Stack<string> stack)
        {
            int minNumber = Int32.MaxValue;
            while (stack.Count > 0)
            {
                var currentNumber = int.Parse(stack.Pop());
                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }
            }
            return minNumber;
        }

        private static bool StackContaintsNum(Stack<string> stack, int numToSeek)
        {
            var queue = new Queue<string>(stack);
            while (queue.Count > 0)
            {
                if (int.Parse(queue.Dequeue()) == numToSeek)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
