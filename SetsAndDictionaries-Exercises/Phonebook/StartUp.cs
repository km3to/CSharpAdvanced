using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();

            string[] input = new[] { "", "" };

            while (input[0] != "stop")
            {
                input = Console.ReadLine()
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "search")
                {
                    PrintResultAfterInput(phoneBook);
                    return;
                }
                else
                {
                    phoneBook[input[0]] = input[1];
                }
            }

            Console.WriteLine();
        }

        private static void PrintResultAfterInput(Dictionary<string, string> phoneBook)
        {
            var input = Console.ReadLine()
                .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "stop")
            {
                
                if (phoneBook.ContainsKey(input[0]))
                {
                    Console.WriteLine($"{input[0]} -> {phoneBook[input[0]]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input[0]} does not exist.");
                }

                input = Console.ReadLine()
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            }
        }
    }
}
