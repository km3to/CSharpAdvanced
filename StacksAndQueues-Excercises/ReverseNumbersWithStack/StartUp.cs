using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input.Length > 0)
            {
                var stack = new Stack<string>(input.Split(' '));

                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop() + " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
