using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var command =
                    Console.ReadLine()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                switch (command[0])
                {
                    case "1":
                        AddText(command[1], result);
                        break;

                    case "2":
                        EraseElements(command[1], result);
                        break;

                    case "3":
                        FindElementByIndex(command[1], result);
                        break;

                    case "4":
                        UndoLast(result);
                        break;
                }

            }
        }

        private static void UndoLast(Stack<string> result)
        {
            result.Pop();
            return;
        }

        private static void FindElementByIndex(string index, Stack<string> result)
        {
            Console.WriteLine(result.Peek()[int.Parse(index) - 1]);
            return;
        }

        private static void EraseElements(string count, Stack<string> result)
        {
            var tmpText = result.Peek();
            result.Push(tmpText.Substring(0, tmpText.Length - int.Parse(count)));

            return;
        }

        private static void AddText(string text, Stack<string> result)
        {
            if (result.Any())
            {
                result.Push(result.Peek() + text);
            }
            else
            {
                result.Push(text);
            }
            return;
        }
    }
}
