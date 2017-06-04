using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurePerformance
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            var list = new HashSet<string>();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i.ToString());
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch = Stopwatch.StartNew();
            list.Contains("888888");
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
