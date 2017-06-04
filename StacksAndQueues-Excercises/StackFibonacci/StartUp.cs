using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                var nMinusOne = stack.Pop();
                var nMinusTwo = stack.Peek();

                stack.Push(nMinusOne);
                stack.Push(nMinusOne + nMinusTwo);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
