using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> dict = new SortedDictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "end")
            {
                string ip = input[0].Split('=').ToArray().Last();
                string user = input[2].Split('=').ToArray().Last();

                if (dict.ContainsKey(user))
                {
                    // TODO:
                    if (dict[user].ContainsKey(ip))
                    {
                        dict[user][ip]++;
                    }
                    else
                    {
                        dict[user].Add(ip, 1);
                    }
                }
                else
                {
                    var tmpDictionary = new Dictionary<string, int>();
                    tmpDictionary.Add(ip, 1);
                    dict.Add(user, tmpDictionary);
                }

                input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }


            foreach (var users in dict)
            {
                Console.WriteLine($"{users.Key}: ");
                foreach (var addresses in users.Value)
                {
                    if (addresses.Equals(users.Value.Last()))
                    {
                        Console.WriteLine($"{addresses.Key} => {addresses.Value}.");
                        break;
                    }
                    Console.Write($"{addresses.Key} => {addresses.Value}, ");
                }
            }
        }
    }
}
