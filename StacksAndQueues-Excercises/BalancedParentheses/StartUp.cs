using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var paranthesisLine = Console.ReadLine();
            var openParanthesis = new Stack<char>();
            var openingCases = new char[] {'{', '[' ,'('};
            var mismatch = false;

            for (int i = 0; i < paranthesisLine.Length; i++)
            {
                if (openingCases.Contains(paranthesisLine[i]))
                {
                    openParanthesis.Push(paranthesisLine[i]);
                }
                else
                {
                    if (openParanthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (paranthesisLine[i])
                    {
                        case '}':
                            if (openParanthesis.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ']':
                            if (openParanthesis.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ')':
                            if (openParanthesis.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
