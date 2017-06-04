using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> userDuration = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> userIps = new Dictionary<string, HashSet<string>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (userDuration.ContainsKey(user))
                {
                    userDuration[user] += duration;
                    userIps[user].Add(ip);
                }
                else
                {
                    userDuration.Add(user, duration);
                    userIps.Add(user, new HashSet<string>(new string[]{ip}));
                }
            }

            foreach (var user in userDuration.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value} [{string.Join(", ", userIps[user.Key].OrderBy(x => x))}]");
            }
        }
    }
}
