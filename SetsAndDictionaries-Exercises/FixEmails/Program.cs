using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Queue<string> names = new Queue<string>();
            Queue<string> emails = new Queue<string>();

            var input = Console.ReadLine();
            int index = 1;

            while (input != "stop")
            {
                if (index % 2 != 0)
                {
                    names.Enqueue(input);
                }
                else
                {
                    emails.Enqueue(input);
                }

                index++;
                input = Console.ReadLine();
            }

            while (names.Count > 0)
            {
                var name = names.Dequeue();
                var email = emails.Dequeue();

                if (result.ContainsKey(name))
                {
                    result[name] = email;
                }
                else
                {
                    var emailTokens = email.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (emailTokens[1] != "us" && emailTokens[1] != "uk")
                    {
                        result.Add(name, email);
                    }
                }
            }

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
