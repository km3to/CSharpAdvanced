using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOfElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();
            var resultSet = new HashSet<int>();

            var nAndM = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var n = nAndM[0];
            var m = nAndM[1];

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                nSet.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (mSet.Add(number))
                {
                    if (nSet.Contains(number))
                    {
                        resultSet.Add(number);
                    }
                }
            }

            foreach (var num in resultSet)
            {
                Console.Write(num + " ");
            }
        }
    }
}
